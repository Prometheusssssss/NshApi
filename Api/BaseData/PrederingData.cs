using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class PrederingData : BizServiceBase<PrederingData>
    {
        public List<PrederingModel> predataList { get; set; }

        #region L.加载方法
        public void Initial()
        {
            using (var x = Join.Dal.MySqlProvider.X())
            {
                var selSql = "select * from b_pondering where is_delete=0";
                var table = x.ExecuteSqlCommand(selSql);
                this.predataList = new List<PrederingModel>();
                foreach (DataRow item in table.Tables[0].Rows)
                {
                    var model = new PrederingModel();
                    model.LEVEL = int.Parse(item["LEVEL"].ToString());
                    model.EXPERIENCE = int.Parse(item["EXPERIENCE"].ToString());
                    model.SILVER = int.Parse(item["SILVER"].ToString());
                    this.predataList.Add(model);
                }
            }
        }
        #endregion
    }

    public class PrederingModel
    {
        public int LEVEL { get; set; }
        public int EXPERIENCE { get; set; }
        public int SILVER { get; set; }
    }
}