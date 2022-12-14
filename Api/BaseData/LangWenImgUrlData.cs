using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace NshApi
{
    public class LangWenImgUrlData : BizServiceBase<LangWenImgUrlData>
    {
        public List<LangwenImgUrlNameModel> langwenImgUrlNameModel { get; set; }

        public class LangwenImgUrlNameModel
        {
            public string URL { get; set; }
            public string NAME { get; set; }
        }

        #region L.加载方法
        public void Initial()
        {
            var list = new List<LangwenImgUrlNameModel>();
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】云",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512182/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】虹",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512183/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】月",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512184/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】雪",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512185/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】风",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512186/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】雨",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512187/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】日",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512188/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】金",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512189/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】木",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512111/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】水",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512112/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】土",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512113/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】泽",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512114/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】山",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512115/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】田",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512116/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】厚土",
                //URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512117/image"
                URL = "https://oss.dazuiba.top:8003//api/oss/20201209-c021afb2-cccb-46dc-8aac-8651ed7f2d16/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】菊台",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512118/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】梅林",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512119/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【地】竹川",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512121/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】道心",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512122/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】上清",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512123/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】神人",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512124/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】太清",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512125/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】玉清",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512126/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】皇天",
                //URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512127/image"
                URL = "https://oss.dazuiba.top:8003//api/oss/20201209-1921a908-a03b-4ca4-a05d-8cb8f203b785/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】辉宸",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512128/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】穹宇",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512129/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】星渊",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512131/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】玄宙",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512132/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】太玄",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512191/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】上玄",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512190/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【混】玉玄",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512192/image"
            });
            list.Add(new LangwenImgUrlNameModel()
            {
                NAME = "【天】银河",
                URL = "https://oss.dazuiba.top:8003//api/oss/20201024-A9C4DE6A-BF80-41AB-B8BB-9C986C512193/image"
            });
            this.langwenImgUrlNameModel = list;
        }
        #endregion
    }
}