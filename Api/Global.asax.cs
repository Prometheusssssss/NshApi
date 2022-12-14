using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace NshApi
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ////初始化数据
            //StarLuckData.X.Initial();
            ////初始化金色琅纹属性表
            //LangWenData.X.Initial();
            ////初始化琅纹图片
            //LangWenImgUrlData.X.Initial();
            ////初始化共鸣
            //GongMingData.X.Initial();
            ////初始化琢磨
            //PrederingData.X.Initial();
            ////初始化帮贡
            //BanggongData.X.Initial();
            ////初始化心法
            //XinFaData.X.Initial();
        }
    }
}