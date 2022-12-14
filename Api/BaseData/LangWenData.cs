using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class LangWenData : BizServiceBase<LangWenData>
    {
        public DataTable goldLangwenModels { get; set; }
        public DataTable goldLangwenAttrModels { get; set; }
        public DataTable goldLangwenAttr2Models { get; set; }
        public DataTable purpleLangwenModels { get; set; }



        #region L.加载方法
        public void Initial()
        {
            using (var x = Join.Dal.MySqlProvider.X())
            {
                //金色琅纹
                var selGoldSql = "select * from b_gold_langwen where is_delete=0";
                var goldTable = x.ExecuteSqlCommand(selGoldSql);
                this.goldLangwenModels = goldTable.Tables[0];
                //金色琅纹属性
                var selAttrSql = "select * from b_gold_langwen_attr where is_delete=0";
                var tableAttr = x.ExecuteSqlCommand(selAttrSql);
                this.goldLangwenAttrModels = tableAttr.Tables[0];
                //金色琅纹属性
                var selAttr2Sql = "select * from b_gold_langwen_attr_2 where is_delete=0";
                var tableAttr2 = x.ExecuteSqlCommand(selAttr2Sql);
                this.goldLangwenAttr2Models = tableAttr2.Tables[0];
                //紫色琅纹
                var selPurpleSql = "select * from b_purple_langwen where is_delete=0";
                var purpleTable = x.ExecuteSqlCommand(selPurpleSql);
                this.purpleLangwenModels = purpleTable.Tables[0];
            }
        }
        #endregion
    }
}