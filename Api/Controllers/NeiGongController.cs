using Join;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using static NshApi.ZhouTianData;

namespace NshApi
{
    [RoutePrefix("api/_neigong")]
    //[Security.AuthorizationRequired]
    public class NeiGongController : BaseController
    {
        #region 内功计算
        /// <summary>
        /// 内功计算
        /// </summary>
        [HttpPost]
        [Route("neigongSum")]
        public IHttpActionResult NeiGongSum([FromBody] JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        var jtoken = json.AsDynamic();
                        //需要计算的内功
                        string ids = jtoken.Ids;
                        var idList = ids.Split(',');
                        var neigongDataList = NeiGongData.X.neigongModels;
                        var zhoutianDataList = ZhouTianData.X.ZhouTianModel;

                        var sumList = neigongDataList.Where(de => idList.Contains(de.KID.ToString()));
                        //汇总金木水火土的数量，计算周天属性
                        var jinSum = sumList.Sum(de => de.JIN) > 12 ? 12 : sumList.Sum(de => de.JIN);
                        var muSum = sumList.Sum(de => de.MU) > 12 ? 12 : sumList.Sum(de => de.MU);
                        var shuiSum = sumList.Sum(de => de.SHUI) > 12 ? 12 : sumList.Sum(de => de.SHUI);
                        var huoSum = sumList.Sum(de => de.HUO) > 12 ? 12 : sumList.Sum(de => de.HUO);
                        var tuSum = sumList.Sum(de => de.TU) > 12 ? 12 : sumList.Sum(de => de.TU);


                        ZhouTianM jinZT = null;
                        ZhouTianM muZT = null;
                        ZhouTianM shuiZT = null;
                        ZhouTianM huoZT = null;
                        ZhouTianM tuZT = null;
                        jinZT = zhoutianDataList.Where(de => de.NAME == "金" && jinSum >= de.NUM).OrderByDescending(de => de.NUM).FirstOrDefault();
                        muZT = zhoutianDataList.Where(de => de.NAME == "木" && muSum >= de.NUM).OrderByDescending(de => de.NUM).FirstOrDefault();
                        shuiZT = zhoutianDataList.Where(de => de.NAME == "水" && shuiSum >= de.NUM).OrderByDescending(de => de.NUM).FirstOrDefault();
                        huoZT = zhoutianDataList.Where(de => de.NAME == "火" && huoSum >= de.NUM).OrderByDescending(de => de.NUM).FirstOrDefault();
                        tuZT = zhoutianDataList.Where(de => de.NAME == "土" && tuSum >= de.NUM).OrderByDescending(de => de.NUM).FirstOrDefault();

                        var rel = new List<NeiGongResultM>();
                        rel.Add(new NeiGongResultM()
                        {
                            Name = "金元素" + ConvertLevel(jinSum) + "级",
                            Level = ConvertLevel(jinSum),
                            Num = jinSum,
                            Desc = jinZT == null ? "" : jinZT.DESC,
                        });
                        rel.Add(new NeiGongResultM()
                        {
                            Name = "木元素" + ConvertLevel(muSum) + "级",
                            Level = ConvertLevel(muSum),
                            Num = muSum,
                            Desc = muZT == null ? "" : muZT.DESC,
                        });
                        rel.Add(new NeiGongResultM()
                        {
                            Name = "水元素" + ConvertLevel(shuiSum) + "级",
                            Level = ConvertLevel(shuiSum),
                            Num = shuiSum,
                            Desc = shuiZT == null ? "" : shuiZT.DESC,
                        });
                        rel.Add(new NeiGongResultM()
                        {
                            Name = "火元素" + ConvertLevel(huoSum) + "级",
                            Level = ConvertLevel(huoSum),
                            Num = huoSum,
                            Desc = huoZT == null ? "" : huoZT.DESC,
                        });

                        rel.Add(new NeiGongResultM()
                        {
                            Name = "土元素" + ConvertLevel(tuSum) + "级",
                            Level = ConvertLevel(tuSum),
                            Num = tuSum,
                            Desc = tuZT == null ? "" : tuZT.DESC,
                        });
                        return new { Table = rel, IS_SUCCESS = true, MSG = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new { Table = new { }, IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }

        public class NeiGongResultM
        {
            public string Name { get; set; }
            public string Desc { get; set; }
            public int Num { get; set; }
            public int Level { get; set; }
        }

        private int ConvertLevel(int num)
        {
            if (num >= 12)
                return 3;
            else if (num >= 8 && num < 12)
                return 2;
            else if (num >= 4 && num < 8)
                return 1;
            else
                return 0;
        }
        #endregion

        #region WriteLogFile
        public void WriteLogFile(string input)
        {
            DateTime now = DateTime.Now;
            var date = now.Year + "" + now.Month + "" + now.Day;
            var time = now.ToLongTimeString();
            var application = System.Web.HttpContext.Current.Server.MapPath("/OSSLOGS/" + date + "/");

            if (Directory.Exists(application) == false)
            //如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(application);
            }

            var fileName = application + "wxp" + ".txt";
            FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            try
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    //开始写入               
                    string str = time + "----" + input;
                    sw.WriteLine(str);

                    //清空缓冲区
                    sw.Flush();
                    sw.Close();
                    //关闭流
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        #endregion
    }
}
