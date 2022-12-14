using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class XinFaData : BizServiceBase<XinFaData>
    {
        public List<XinFaModel> xinfaList { get; set; }

        #region L.加载方法
        public void Initial()
        {
            using (var x = Join.Dal.MySqlProvider.X())
            {
                var selSql = "select * from B_QIHAI where is_delete=0";
                var table = x.ExecuteSqlCommand(selSql);
                this.xinfaList = new List<XinFaModel>();
                foreach (DataRow item in table.Tables[0].Rows)
                {
                    var model = new XinFaModel();
                    model.LEVEL = int.Parse(item["LEVEL"].ToString());
                    model.REN_UPNUM = int.Parse(item["REN_UPNUM"].ToString());
                    model.DI_UPNUM = int.Parse(item["DI_UPNUM"].ToString());
                    model.TIAN_UPNUM = int.Parse(item["TIAN_UPNUM"].ToString());
                    this.xinfaList.Add(model);
                }
            }
        }
        #endregion
    }

    public class XinFaModel
    {
        public int LEVEL { get; set; }
        public int REN_UPNUM { get; set; }
        public int DI_UPNUM { get; set; }
        public int TIAN_UPNUM { get; set; }
    }
}