using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class GongMingData : BizServiceBase<GongMingData>
    {
        //所有参与共鸣的琅纹属性
        public string[] allAttrList { get; set; }
        ////攻击类共鸣琅纹属性
        //public string[] gongjiAttrList { get; set; }
        ////防御类共鸣琅纹属性
        //public string[] fangyuAttrList { get; set; }
        ////特殊类共鸣琅纹属性
        //public string[] teshuAttrList { get; set; }



        #region L.加载方法
        public void Initial()
        {
            using (var x = Join.Dal.MySqlProvider.X())
            {
                var allAttrStrs = "攻击、会心、暗伤、会心增伤、暗伤增伤、破招、内功防御、外功防御、气血、会心抗性、暗伤抗性、会心减伤、暗伤减伤、拆招、力道、气劲、身法、根骨";
                allAttrList = allAttrStrs.Split('、');
                //var gongjiAttrStr = "攻击、会心、暗伤、会心增伤、暗伤增伤、破招";
                //gongjiAttrList = gongjiAttrStr.Split('、');
                //var fangyuAttrStr = "内功防御、外功防御、气血、会心抗性、暗伤抗性、会心减伤、暗伤减伤、拆招";
                //fangyuAttrList = fangyuAttrStr.Split('、');
                //var teshuAttrStr = "会心、暗伤、会心增伤、暗伤增伤、会心抗性、暗伤抗性";
                //teshuAttrList = teshuAttrStr.Split('、');
            }
        }
        #endregion
    }
}