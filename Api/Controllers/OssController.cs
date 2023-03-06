using Join;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace NshApi
{
    [RoutePrefix("api/_oss")]
    //[Security.AuthorizationRequired]
    public class OssController : BaseController
    {
        #region X.成员方法[Oss]
        [HttpPost]
        [Route("ossimg")]
        public async Task<object> OssPost()
        {
            try
            {
                var value = await Request.Content.ReadAsStringAsync();
                var temp = new { name = "", content = "" }.AsArray();
                var list = JsonConvert.DeserializeAnonymousType(value, temp);
                List<object> result = new List<object>();
                foreach (var de in list)
                {
                    var client = new Oss.OssClient();
                    var returnResult = await client.PostFile(de.name, de.content);
                    string[] resultArray = returnResult.Split('|');
                    var id = resultArray[0];
                    var takeTime = "";
                    if (resultArray.Length >= 2)
                    {
                        takeTime = resultArray[1];
                    }
                    var url = client.GenImageUrl(id);
                    result.Add(new
                    {
                        name = de.name,
                        url = url,
                        size = de.content.Length,
                        takeTime = takeTime
                    });
                }
                return new { Table = result, IS_SUCCESS = true, MSG = "" };
            }
            catch (Exception ex)
            {
                this.WriteLogFile(ex.Message);
                throw;
            }
        }
        #endregion

        #region X.成员方法[Oss]
        [HttpPost]
        [Route("ossfile")]
        public async Task<object> OssFilePost()
        {
            var value = await Request.Content.ReadAsStringAsync();
            var temp = new { name = "", content = "" }.AsArray();
            var list = JsonConvert.DeserializeAnonymousType(value, temp);
            List<object> result = new List<object>();
            foreach (var de in list)
            {
                var client = new Oss.OssClient();
                var returnResult = await client.PostFile(de.name, de.content);
                string[] resultArray = returnResult.Split('|');
                var id = resultArray[0];
                var takeTime = "";
                if (resultArray.Length >= 2)
                {
                    takeTime = resultArray[1];
                }

                var url = client.GenUrl(id);

                result.Add(new
                {
                    name = de.name,
                    url = url,
                    size = de.content.Length,
                    takeTime = takeTime
                });
            }
            return result;
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
