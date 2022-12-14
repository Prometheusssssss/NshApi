using Join;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NshApi
{
    [RoutePrefix("api/_cud")]
    //[Security.AuthorizationRequired]
    public class CudController : BaseController
    {
        #region 插入/更新
        /// <summary>
        /// 插入/更新
        /// http://localhost:64665/api/_cud/createAndUpdate/tableName
        /// </summary>
        [HttpPost]
        [Route("createAndUpdate/{tableName}")]
        public IHttpActionResult CreteoAndUpdateTable(string tablename, [FromBody]JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        tablename = tablename.ToUpper();
                        var dicJson = json.ToJsonString();
                        var dict = dicJson.JsonToDictionary();
                        var kid = dict.GetValue("KID");
                        var sql = "";
                        //new
                        if (kid == "-1")
                        {
                            var ra = new Random();
                            var keys = "";
                            var values = "";
                            if (tablename != "B_ORDER_MSG_DETAILS" && tablename != "B_MESSAGE" && tablename != "B_CHANGE_LIFE_DETAIL")
                            {
                                keys = "`CODE`,`IS_DELETE`,`CRT_TIME`";
                                values = "'" + DateTime.Now.ToString("yyyyMMddHHmmss") + ra.Next(1000, 9999) + "',0,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            }
                            else
                            {
                                keys = "`IS_DELETE`,`CRT_TIME`";
                                values = "0,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                            }
                            foreach (var item in dict)
                            {
                                if (item.Key != "KID")
                                {
                                    keys = keys.AppendSql(item.Key, "`", true);
                                    values = values.AppendSql(item.Value.ToString(), "'", true);
                                }
                            }
                            sql = string.Format(@"insert into {0} ({1}) values ({2})", tablename, keys, values);
                        }
                        //update
                        else
                        {
                            var updateSql = "";
                            foreach (var item in dict)
                            {
                                if (item.Key != "KID")
                                {
                                    var updateValue = "";
                                    if (item.Value != null)
                                        updateValue = item.Value.ToString();
                                    if (updateSql != "")
                                        updateSql = updateSql + "`" + item.Key + "`='" + updateValue + "',";
                                    else
                                        updateSql = "`" + item.Key + "`='" + updateValue + "',";
                                }
                            }
                            updateSql = updateSql.Substring(0, updateSql.Length - 1);
                            sql = string.Format(@"update {0} set {1} where kid='{2}'", tablename, updateSql, kid);
                        }
                        WxPayData wx = new WxPayData();
                        wx.WriteLogFile("createAndUpdate的SQL" + sql);
                        var dt = x.ExecuteSqlCommand(sql);
                        ////执行扩展逻辑
                        //switch (tablename)
                        //{
                        //    case "B_ADVENTURE_STRATEGY":
                        //        var name = dict.GetValue("NAME");
                        //        ExcuteQiyu(kid, name);
                        //        break;
                        //    default:
                        //        break;
                        //}
                        return new { Table = dt, IS_SUCCESS = true, MSG = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// http://localhost:64665/api/_cud/del/tableName
        /// </summary>
        [HttpPost]
        [Route("del/{tableName}")]
        public IHttpActionResult DelTable(string tablename, [FromBody]JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    var dicJson = json.ToJsonString();
                    var dict = dicJson.JsonToDictionary();
                    var kid = dict.GetValue("KID");

                    //执行扩展逻辑
                    switch (tablename.ToUpper())
                    {
                        //case "B_PRODUCT_LIST":
                        //    var result = ExcuteDelOrderEx(tablename, kid);
                        //    if (result == false)
                        //        return new { Table = "", IS_SUCCESS = false, MSG = "产品状态为已售卖，不可删除" };
                        //    break;
                        default:
                            break;
                    }
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        var sql = string.Format(@"update {0} set is_delete=1 where KID='{1}'", tablename, kid);
                        var dt = x.ExecuteSqlCommand(sql);

                        return new { Table = dt, IS_SUCCESS = true, MSG = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }
        #endregion

        #region 启用
        /// <summary>
        /// 启用
        /// http://localhost:64665/api/_cud/enableTable/tableName
        /// </summary>
        [HttpPost]
        [Route("enableTable/{tableName}")]
        public IHttpActionResult EnableTable(string tablename, [FromBody]JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        tablename = tablename.ToUpper();
                        var dicJson = json.ToJsonString();
                        var dict = dicJson.JsonToDictionary();
                        var kid = dict.GetValue("KID");
                        var sql = "";
                        var updateSql = "";
                        foreach (var item in dict)
                        {
                            if (item.Key != "KID")
                            {
                                var updateValue = "";
                                if (item.Value != null)
                                    updateValue = item.Value.ToString();
                                if (updateSql != "")
                                    updateSql = updateSql + "`" + item.Key + "`='" + updateValue + "',";
                                else
                                    updateSql = "`" + item.Key + "`='" + updateValue + "',";
                            }
                        }
                        updateSql = updateSql.Substring(0, updateSql.Length - 1);
                        sql = string.Format(@"update {0} set {1} where kid='{2}'", tablename, updateSql, kid);
                        WxPayData wx = new WxPayData();
                        wx.WriteLogFile("EnableTable的SQL  " + sql);
                        var dt = x.ExecuteSqlCommand(sql);
                        //执行扩展逻辑
                        switch (tablename)
                        {
                            case "B_ADVENTURE_STRATEGY":
                                var name = dict.GetValue("NAME");
                                ExcuteQiyu(kid, name);
                                break;
                            case "B_CAIPU":
                                var pid = dict.GetValue("PID");
                                ExcuteCaipu(kid, pid);
                                break;
                            case "B_FOOD_FISH":
                                var pid1 = dict.GetValue("PID");
                                ExcuteFishFood(kid, pid1);
                                break;
                            default:
                                break;
                        }
                        return new { Table = dt, IS_SUCCESS = true, MSG = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }

        #region 执行奇遇扩展逻辑
        /// <summary>
        /// 执行奇遇扩展逻辑
        /// </summary>
        /// <param name="kid"></param>
        /// <param name="name"></param>
        public void ExcuteQiyu(string kid, string name)
        {
            //修改其他同GROUPS的奇遇状态为禁用
            //执行sql
            using (var x = Join.Dal.MySqlProvider.X())
            {
                WxPayData wxp = new WxPayData();
                var sql = "update B_ADVENTURE_STRATEGY set IS_ENABLE = 0 where NAME='" + name + "' and kid!='" + kid + "'";
                wxp.WriteLogFile("ExcuteQiyu的SQL   " + sql);
                x.ExecuteSqlCommand(sql);
            }
        }
        #endregion

        #region 执行菜谱扩展逻辑
        /// <summary>
        /// 执行菜谱扩展逻辑
        /// </summary>
        public void ExcuteCaipu(string kid, string pid)
        {
            //修改其他同GROUPS的菜谱状态为禁用
            //执行sql
            using (var x = Join.Dal.MySqlProvider.X())
            {
                WxPayData wxp = new WxPayData();
                var sql = "update B_CAIPU set IS_ENABLE = 0 where PID='" + pid + "' and kid!='" + kid + "'";
                wxp.WriteLogFile("ExcuteCaipu的SQL   " + sql);
                x.ExecuteSqlCommand(sql);
            }
        }
        #endregion

        #region 执行食材/鱼王扩展逻辑
        /// <summary>
        /// 执行食材/鱼王扩展逻辑
        /// </summary>
        public void ExcuteFishFood(string kid, string pid)
        {
            //修改其他同GROUPS的食材/鱼王状态为禁用
            //执行sql
            using (var x = Join.Dal.MySqlProvider.X())
            {
                WxPayData wxp = new WxPayData();
                var sql = "update B_FOOD_FISH set IS_ENABLE = 0 where PID='" + pid + "' and kid!='" + kid + "'";
                wxp.WriteLogFile("ExcuteFishFood的SQL   " + sql);
                x.ExecuteSqlCommand(sql);
            }
        }
        #endregion

        #endregion

        #region 创建伙伴亲密度明细
        /// <summary>
        /// 创建伙伴亲密度明细
        /// http://localhost:64665/api/_cud/createPartner
        /// </summary>
        [HttpPost]
        [Route("createPartner")]
        public IHttpActionResult CreatePartner([FromBody]JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        var result = json.AsDynamic();
                        WxPayData wp = new WxPayData();
                        var recommand = result.recommand;
                        string delkids = result.delkids;
                        string manKid = "";
                        JArray details = result.details;
                        //JArray list = json.AsDynamic();
                        //删除
                        if (!string.IsNullOrWhiteSpace(delkids))
                        {
                            wp.WriteLogFile("createPartner-要删除的KIDS:" + delkids);
                            var delkidList = delkids.Split(',');
                            foreach (var item in delkidList)
                            {
                                var delSql = "UPDATE b_partner_intimacy_detail SET IS_DELETE=1 WHERE KID='" + item + "'";
                                x.ExecuteSqlCommand(delSql);
                            }
                        }
                        foreach (var item in details)
                        {
                            var detail = item.AsDynamic();
                            manKid = detail.PID;
                            string pid = detail.PID;
                            string kid = detail.KID;
                            string propsId = detail.PROPS_ID;
                            string propsName = detail.PROPS_NAME;
                            string intimacy = detail.INTIMACY;
                            var sql = "";
                            if (kid == "-1")
                            {
                                sql = string.Format(@"INSERT INTO `b_partner_intimacy_detail` (`PID`, 
                                                    `IS_ENABLE`,`PROPS_NAME`, `INTIMACY`, `IS_DELETE`,
                                                    `CRT_TIME`)
                                                    values('{0}','1','{1}','{2}','0','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')"
                                                    , pid, propsName, intimacy);
                            }
                            else
                            {
                                sql = string.Format(@"UPDATE B_PARTNER_INTIMACY_DETAIL SET PROPS_NAME='{0}',INTIMACY='{1}' where kid='{2}'"
                                                    , propsName, intimacy, kid);
                            }
                            wp.WriteLogFile("createPartner 的 执行sql :" + sql);
                            x.ExecuteSqlCommand(sql);
                        }
                        //更新主表推荐字段
                        var updateSql = "update B_PARTNER_INTIMACY set RECOMMEND='" + recommand + "' where kid='" + manKid + "'";
                        x.ExecuteSqlCommand(updateSql);
                        wp.WriteLogFile("createPartner-更新主表推荐使用字段sql:" + updateSql);
                        return new { Table = "", IS_SUCCESS = true, MSG = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }
        #endregion

        #region 创建断案明细
        /// <summary>
        /// 创建断案明细
        /// http://localhost:64665/api/_cud/createDuanan
        /// </summary>
        [HttpPost]
        [Route("createDuanan")]
        public IHttpActionResult CreateDuanan([FromBody]JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        var result = json.AsDynamic();
                        WxPayData wp = new WxPayData();
                        string delkids = result.delkids;
                        JArray details = result.details;
                        //JArray list = json.AsDynamic();
                        //删除
                        if (!string.IsNullOrWhiteSpace(delkids))
                        {
                            wp.WriteLogFile("createDuanan-要删除的KIDS:" + delkids);
                            var delkidList = delkids.Split(',');
                            foreach (var item in delkidList)
                            {
                                var delSql = "UPDATE B_DUANAN SET IS_DELETE=1 WHERE KID='" + item + "'";
                                x.ExecuteSqlCommand(delSql);
                            }
                        }
                        foreach (var item in details)
                        {
                            var detail = item.AsDynamic();
                            string pid = detail.PID;
                            string kid = detail.KID;
                            string name = detail.NAME;
                            string content = detail.CONTENT;
                            var sql = "";
                            if (kid == "-1")
                            {
                                sql = string.Format(@"INSERT INTO `B_DUANAN` (`PID`, 
                                                    `NAME`,`CONTENT`, `IS_DELETE`,
                                                    `CRT_TIME`)
                                                    values('{0}','{1}','{2}','0','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')"
                                                    , pid, name, content);
                            }
                            else
                            {
                                sql = string.Format(@"UPDATE B_DUANAN SET CONTENT='{0}',NAME='{1}' where kid='{2}'"
                                                    , content, name, kid);
                            }
                            wp.WriteLogFile("createDuanan 的 执行sql :" + sql);
                            x.ExecuteSqlCommand(sql);
                        }
                        return new { Table = "", IS_SUCCESS = true, MSG = "" };
                    }
                }
                catch (Exception ex)
                {
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }
        #endregion

    }
}
