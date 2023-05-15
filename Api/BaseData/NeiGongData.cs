using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using static NshApi.ZhouTianData;

namespace NshApi
{
    public class NeiGongData : BizServiceBase<NeiGongData>
    {
        public List<NeiGongM> neigongModels { get; set; }

        public class NeiGongM
        {
            public int KID { get; set; }
            public string NAME { get; set; }
            public int JIN { get; set; }
            public int MU { get; set; }
            public int SHUI { get; set; }
            public int HUO { get; set; }
            public int TU { get; set; }
            public string DESCRIPTION { get; set; }
            public string QUALITY { get; set; }
            public string IMAGE_URL { get; set; }
        }

        #region L.加载方法
        public void Initial()
        {
            this.neigongModels = new List<NeiGongM>();
            using (var x = Join.Dal.MySqlProvider.X())
            {
                var sql = "select * from b_neigong where is_delete=0";
                var tbl = x.ExecuteSqlCommand(sql);
                foreach (DataRow item in tbl.Tables[0].Rows)
                {
                    this.neigongModels.Add(new NeiGongM()
                    {
                        KID = int.Parse(item["KID"].ToString()),
                        NAME = item["NAME"].ToString(),
                        JIN = int.Parse(item["JIN"].ToString()),
                        MU = int.Parse(item["MU"].ToString()),
                        SHUI = int.Parse(item["SHUI"].ToString()),
                        HUO = int.Parse(item["HUO"].ToString()),
                        TU = int.Parse(item["TU"].ToString()),
                        DESCRIPTION = item["DESCRIPTION"].ToString(),
                        QUALITY = item["QUALITY"].ToString(),
                        IMAGE_URL = item["IMAGE_URL"].ToString(),
                    });
                }
            }
        }
        #endregion
    }
}