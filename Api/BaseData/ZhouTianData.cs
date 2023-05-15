using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class ZhouTianData : BizServiceBase<ZhouTianData>
    {
        public List<ZhouTianM> ZhouTianModel { get; set; }

        public class ZhouTianM
        {
            public string NAME { get; set; }
            public int NUM { get; set; }
            public string DESC { get; set; }
        }

        #region L.加载方法
        public void Initial()
        {
            this.ZhouTianModel = new List<ZhouTianM>();
            using (var x = Join.Dal.MySqlProvider.X())
            {
                var sql = "select * from b_zhoutian where is_delete=0";
                var tbl = x.ExecuteSqlCommand(sql);
                foreach (DataRow item in tbl.Tables[0].Rows)
                {
                    this.ZhouTianModel.Add(new ZhouTianM()
                    {
                        NAME = item["NAME"].ToString(),
                        NUM = int.Parse(item["NUM"].ToString()),
                        DESC = item["DESCRIPTION"].ToString(),
                    });
                }
            }
        }
        #endregion
    }
}