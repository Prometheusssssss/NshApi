using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class StarLuckData : BizServiceBase<StarLuckData>
    {
        public List<DataModel> dataModels { get; set; }

        public class DataModel
        {
            public string C_NAME { get; set; }
            public decimal X_BEGAN { get; set; }
            public decimal X_END { get; set; }
            public decimal Y_BEGAN { get; set; }
            public decimal Y_END { get; set; }
            public List<Detail> DETAILS { get; set; }
        }

        public class Detail
        {
            public string NAME { get; set; }
            public decimal X_BEGAN { get; set; }
            public decimal X_END { get; set; }
            public decimal Y_BEGAN { get; set; }
            public decimal Y_END { get; set; }
        }

        #region L.加载方法
        public void Initial()
        {
            var dataList = new List<DataModel>();
            //破军
            dataList.Add(new DataModel()
            {
                C_NAME = "破军",
                X_BEGAN = 0.65m,
                X_END = 1.00m,
                Y_BEGAN = 0.5m,
                Y_END = 1.00m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.65m,
                         X_END=0.76m,
                         Y_BEGAN=0.5m,
                         Y_END=1m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.76m,
                         X_END=0.85m,
                         Y_BEGAN=0.5m,
                         Y_END=0.76m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                         X_BEGAN=0.85m,
                         X_END=1m,
                         Y_BEGAN=0.5m,
                         Y_END=0.85m
                    },
                }
            });
            //破军
            dataList.Add(new DataModel()
            {
                C_NAME = "破军",
                X_BEGAN = 0.5m,
                X_END = 1.00m,
                Y_BEGAN = 0.65m,
                Y_END = 1.00m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.5m,
                         X_END=0.76m,
                         Y_BEGAN=0.65m,
                         Y_END=0.76m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.5m,
                         X_END=0.85m,
                         Y_BEGAN=0.76m,
                         Y_END=0.85m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                         X_BEGAN=0.5m,
                         X_END=1m,
                         Y_BEGAN=0.85m,
                         Y_END=1m
                    },
                }
            });
            //紫薇
            dataList.Add(new DataModel()
            {
                C_NAME = "紫薇",
                X_BEGAN = 0.65m,
                X_END = 1.00m,
                Y_BEGAN = 0m,
                Y_END = 0.5m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.65m,
                         X_END=0.76m,
                        Y_BEGAN = 0.35m,
                        Y_END = 0.5m,
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.76m,
                         X_END=0.85m,
                        Y_BEGAN = 0.24m,
                Y_END = 0.5m,
                    },
                     new Detail()
                    {
                         NAME="耀升",
                         X_BEGAN=0.85m,
                         X_END=1m,
                        Y_BEGAN = 0.15m,
                Y_END = 0.5m,
                    },
                }
            });
            //紫薇
            dataList.Add(new DataModel()
            {
                C_NAME = "紫薇",
                X_BEGAN = 0.5m,
                X_END = 1.00m,
                Y_BEGAN = 0m,
                Y_END = 0.35m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                          X_BEGAN = 0.5m,
                X_END = 0.76m,
                         Y_BEGAN=0.24m,
                         Y_END=0.35m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                        X_BEGAN = 0.5m,
                X_END = 0.85m,
                         Y_BEGAN=0.15m,
                         Y_END=0.24m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                          X_BEGAN = 0.5m,
                X_END = 1.00m,
                         Y_BEGAN=0m,
                         Y_END=0.15m
                    },
                }
            });
            //天同
            dataList.Add(new DataModel()
            {
                C_NAME = "天同",
                X_BEGAN = 0.35m,
                X_END = 0.65m,
                Y_BEGAN = 0.35m,
                Y_END = 0.65m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.35m,
                         X_END=0.4m,
                         Y_BEGAN=0.35m,
                         Y_END=0.65m
                    },
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.6m,
                         X_END=0.65m,
                         Y_BEGAN=0.35m,
                         Y_END=0.65m
                    },
                      new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.35m,
                         X_END=0.65m,
                         Y_BEGAN=0.35m,
                         Y_END=0.4m
                    },
                        new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.35m,
                         X_END=0.65m,
                         Y_BEGAN=0.6m,
                         Y_END=0.65m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.4m,
                         X_END=0.45m,
                         Y_BEGAN=0.4m,
                         Y_END=0.45m
                    },
                      new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.55m,
                         X_END=0.6m,
                         Y_BEGAN=0.55m,
                         Y_END=0.6m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                         X_BEGAN=0.45m,
                         X_END=0.55m,
                         Y_BEGAN=0.45m,
                         Y_END=0.55m
                    },
                }
            });
            //贪狼
            dataList.Add(new DataModel()
            {
                C_NAME = "贪狼",
                X_BEGAN = 0m,
                X_END = 0.35m,
                Y_BEGAN = 0.5m,
                Y_END = 1m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.24m,
                         X_END=0.35m,
                       Y_BEGAN = 0.5m,
                Y_END = 0.65m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.15m,
                         X_END=0.24m,
                        Y_BEGAN = 0.5m,
                Y_END = 0.76m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                         X_BEGAN=0m,
                         X_END=0.15m,
                          Y_BEGAN = 0.5m,
                Y_END = 0.85m
                    },
                }
            });
            //贪狼
            dataList.Add(new DataModel()
            {
                C_NAME = "贪狼",
                X_BEGAN = 0m,
                X_END = 0.5m,
                Y_BEGAN = 0.65m,
                Y_END = 1m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                        X_BEGAN = 0.35m,
                        X_END = 0.5m,
                         Y_BEGAN=0.65m,
                         Y_END=0.76m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                        X_BEGAN = 0.24m,
                        X_END = 0.5m,
                         Y_BEGAN=0.76m,
                         Y_END=0.85m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                            X_BEGAN = 0m,
                X_END = 0.5m,
                         Y_BEGAN=0.85m,
                         Y_END=1m
                    },
                }
            });
            //七煞
            dataList.Add(new DataModel()
            {
                C_NAME = "七煞",
                X_BEGAN = 0m,
                X_END = 0.35m,
                Y_BEGAN = 0m,
                Y_END = 0.5m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN=0.24m,
                         X_END=0.35m,
                          Y_BEGAN = 0.35m,
                Y_END = 0.5m,
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN=0.15m,
                         X_END=0.24m,
                          Y_BEGAN = 0.24m,
                Y_END = 0.5m,
                    },
                     new Detail()
                    {
                         NAME="耀升",
                         X_BEGAN=0m,
                         X_END=0.15m,
                          Y_BEGAN = 0.15m,
                Y_END = 0.5m,
                    },
                }
            });
            //七煞
            dataList.Add(new DataModel()
            {
                C_NAME = "七煞",
                X_BEGAN = 0m,
                X_END = 0.5m,
                Y_BEGAN = 0m,
                Y_END = 0.35m,
                DETAILS = new List<Detail>()
                {
                    new Detail()
                    {
                         NAME="利照",
                         X_BEGAN = 0.35m,
                        X_END = 0.5m,
                         Y_BEGAN=0.24m,
                         Y_END=0.35m
                    },
                     new Detail()
                    {
                         NAME="旺相",
                         X_BEGAN = 0.24m,
                        X_END = 0.5m,
                         Y_BEGAN=0.15m,
                         Y_END=0.24m
                    },
                     new Detail()
                    {
                         NAME="耀升",
                        X_BEGAN = 0m,
                        X_END = 0.5m,
                         Y_BEGAN=0m,
                         Y_END=0.15m
                    },
                }
            });
            this.dataModels = dataList;
        }
        #endregion
    }
}