﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.IO;

namespace NshApi
{
    internal class GlobalVariableWeChatApplets
    {
        public const string UNIFIEDORDER_URL = "https://api.mch.weixin.qq.com/pay/unifiedorder";
        public const string REFUND_URL = "https://api.mch.weixin.qq.com/secapi/pay/refund";
     

        public static string MCH_ID = "1601662044"; //微信支付分配的商户号
        public static string API_KEY = "60878661699542A59601575597ED9B59";//(服务商)的KEY

        public static string APPID = "wx7cfb15e5d4f6c7c6"; //小程序APP_ID
        public static string APP_SECRET = "bef021a4ebcd87ea16bcda8388be0d0d";

        public const string NOTIFY_URL = "http://106.15.38.99:6006/api/wxp/tenpay_notify";
        public const string REFUND_API = "http://106.15.38.99:6006/api/wxp/refundApi";
    }
}
