using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webPage.Areas.ComManage
{
    
   // 一些共用的控制器和视图，比如文件上传等  的注册类文件
    public class ComManageAreaRegistration:AreaRegistration
    {
        public override string AreaName
        {
            get { return "ComManage"; }
          
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {

            context.MapRoute(
                "ComManage_default",
                "Com/{controller}/{action}/{id}",
                new { action="Index",id=UrlParameter.Optional},
                new string[] { "webPage.Areas.ConManage.Controller"}
           );
        }
    }
}