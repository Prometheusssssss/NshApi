using Join;
using Newtonsoft.Json.Linq;
using System;
using System.Web.Http;

namespace NshApi
{
    [RoutePrefix("api/_search")]
    //[Security.AuthorizationRequired]
    public class SearchController : BaseController
    {
        #region X.成员方法[测试]
        /// <summary>
        /// 测试
        /// </summary>
        [HttpGet]
        [Route("test/{str}")]
        public string Post(string str)
        {
            return str;
        }
        #endregion

        /// <summary>
        /// 通用查询表 
        /// http://localhost:64665/api/_search/defaultSearch/a_game_setting?filter={"PARENT_ID":null}
        /// </summary>
        [HttpGet]
        [Route("defaultSearch/{tableName}")]
        public IHttpActionResult GetTable(string tableName, string filter)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    var wsql = "";
                    if (filter != "{}")
                    {
                        var jsn = filter.ToJToken();
                        wsql = jsn.ToWhereSql();
                    }
                    var backResult = SearchHelper.SearchTable(tableName, wsql);
                    return new { Table = backResult.Tables[0], IS_SUCCESS = true, MSG = "" };

                }
                catch (Exception ex)
                {
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }
            });
        }

        /// <summary>
        /// POST获取数据
        /// http://localhost:64665/api/_search/postSearch
        /// </summary>
        [HttpPost]
        [Route("postSearch")]
        public IHttpActionResult PostSearch([FromBody] JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                WxPayData wx = new WxPayData();
                try
                {
                    var jtoken = json.AsDynamic();
                    string tableName = jtoken.tableName;
                    int page = jtoken.page;
                    int limit = jtoken.limit;
                    JToken filter = jtoken.filters;
                    string orderByField = jtoken.orderByField;
                    string isDesc = jtoken.isDesc;
                    var wsql = filter.ToFilterSql();
                    wx.WriteLogFile("postSearch的SQL" + wsql);
                    //构造take
                    var backResult = SearchHelper.SearchTable(tableName, wsql, page, limit, orderByField, isDesc);
                    return new { Table = backResult.Tables[0], IS_SUCCESS = true, MSG = "" };
                }
                catch (Exception ex)
                {
                    wx.WriteLogFile("postSearch的Exp" + ex.Message);
                    return new { Table = "", IS_SUCCESS = false, MSG = ex.Message };
                }

            });
        }

        /// <summary>
        /// 技能获取
        /// http://localhost:64665/api/_search/postSkillSearch
        /// </summary>
        [HttpPost]
        [Route("postSkillSearch")]
        public IHttpActionResult postQiyuSearch([FromBody] JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    var jtoken = json.AsDynamic();
                    string groups = jtoken.groups;
                    string name = jtoken.name;
                    string orderByField = jtoken.orderByField;
                    string isDesc = jtoken.isDesc;
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        var wsql = "";
                        if (!string.IsNullOrWhiteSpace(name))
                            wsql = "a.name ='" + name + "'";
                        if (!string.IsNullOrWhiteSpace(groups))
                        {
                            if (wsql != "")
                                wsql += " and ";
                            wsql += "a.GROUP_NAME ='" + groups + "'";
                        }
                        if (wsql == "")
                        {
                            wsql = "1=1";
                        }
                        wsql += " AND a.IS_DELETE=0 AND b.IS_DELETE=0 ";
                        string sql = string.Format(@"SELECT a.KID ,B.KID AS DETAIL_ID,a.GROUP_NAME,a.NAME,B.`TRIGGER_LOCATION`,B.`LOCATION`,B.`ACCESS`,B.`IS_DELETE`
                                        ,B.`CRT_TIME` FROM `B_GET_JINENG` AS a LEFT JOIN `B_GET_JINENG_DETAIL` AS b
                                        ON a.NAME=b.GROUP_NAME where {0}", wsql);
                        //排序
                        if (orderByField != "" && orderByField != null)
                        {
                            if (isDesc == "1")
                                sql = sql + " order by " + orderByField + " desc";
                            else
                                sql = sql + " order by " + orderByField;
                        }
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

        /// <summary>
        /// 菜谱查询
        /// http://localhost:64665/api/_search/postCaipuSearch
        /// </summary>
        [HttpPost]
        [Route("postCaipuSearch")]
        public IHttpActionResult postCaipuSearch([FromBody] JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    var jtoken = json.AsDynamic();
                    string groups = jtoken.groups;
                    string name = jtoken.name;
                    string orderByField = jtoken.orderByField;
                    string isDesc = jtoken.isDesc;

                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {

                        var wsql = "";
                        if (!string.IsNullOrWhiteSpace(name))
                            wsql = "name ='" + name + "'";
                        if (!string.IsNullOrWhiteSpace(groups))
                        {
                            if (wsql != "")
                                wsql += " and ";
                            wsql += "GROUP_NAME ='" + groups + "'";
                        }
                        if (wsql == "")
                        {
                            wsql = "1=1";
                        }
                        string sql = string.Format(@"SELECT A.KID,B.KID AS DETAIL_ID,A.GROUP_NAME,A.NAME,B.DETAIL_NAME,B.CONTENT,B.IS_DELETE,B.CRT_TIME,B.`FILLER`,B.`CONTRIBUTOR` FROM B_CAIPU_CATEGORY AS A 
                                                        LEFT JOIN (SELECT * FROM B_CAIPU WHERE IS_ENABLE=1) AS B
                                                        ON A.KID=B.PID where {0}", wsql);
                        //排序
                        if (orderByField != "" && orderByField != null)
                        {
                            if (isDesc == "1")
                                sql = sql + " order by " + orderByField + " desc";
                            else
                                sql = sql + " order by " + orderByField;
                        }
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

        /// <summary>
        /// 食物鱼王查询
        /// http://localhost:64665/api/_search/postFoodSearch
        /// </summary>
        [HttpPost]
        [Route("postFoodSearch")]
        public IHttpActionResult postFoodSearch([FromBody] JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    var jtoken = json.AsDynamic();
                    string groups = jtoken.groups;
                    string name = jtoken.name;
                    string orderByField = jtoken.orderByField;
                    string isDesc = jtoken.isDesc;
                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {
                        var wsql = "";
                        if (!string.IsNullOrWhiteSpace(name))
                            wsql = "name ='" + name + "'";
                        if (!string.IsNullOrWhiteSpace(groups))
                        {
                            if (wsql != "")
                                wsql += " and ";
                            wsql += "GROUP_NAME ='" + groups + "'";
                        }
                        if (wsql == "")
                        {
                            wsql = "1=1";
                        }
                        string sql = string.Format(@"SELECT A.KID,B.KID AS DETAIL_ID,A.GROUP_NAME,A.NAME,B.DETAIL_NAME,B.CONTENT,B.IS_DELETE,B.CRT_TIME,B.`FILLER`,B.`CONTRIBUTOR` FROM b_food_fish_category AS A 
                                                        LEFT JOIN (SELECT * FROM b_food_fish WHERE IS_ENABLE=1) AS B
                                                        ON A.KID=B.PID where  {0}", wsql);
                        //排序
                        if (orderByField != "" && orderByField != null)
                        {
                            if (isDesc == "1")
                                sql = sql + " order by " + orderByField + " desc";
                            else
                                sql = sql + " order by " + orderByField;
                        }
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

        /// <summary>
        /// 古董查询
        /// http://localhost:64665/api/_search/postGuDongSearch
        /// </summary>
        [HttpPost]
        [Route("postGuDongSearch")]
        public IHttpActionResult postGuDongSearch([FromBody] JToken json)
        {
            return this.TryReturn<object>(() =>
            {
                try
                {
                    var jtoken = json.AsDynamic();
                    string groups = jtoken.groups;
                    string name = jtoken.name;
                    string orderByField = jtoken.orderByField;
                    string isDesc = jtoken.isDesc;

                    //执行sql
                    using (var x = Join.Dal.MySqlProvider.X())
                    {

                        var wsql = "";
                        if (!string.IsNullOrWhiteSpace(name))
                            wsql = "name like '%" + name + "%'";
                        if (!string.IsNullOrWhiteSpace(groups))
                        {
                            if (wsql != "")
                                wsql += " and ";
                            wsql += "GROUP_NAME ='" + groups + "'";
                        }
                        if (wsql == "")
                        {
                            wsql = "1=1";
                        }
                        string sql = string.Format(@"SELECT * FROM B_ANTIQUE where {0}", wsql);
                        //排序
                        if (orderByField != "" && orderByField != null)
                        {
                            if (isDesc == "1")
                                sql = sql + " order by " + orderByField + " desc";
                            else
                                sql = sql + " order by " + orderByField;
                        }
                        else
                        {
                            sql = sql + " order by seq_no";
                        }
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
    }
}
