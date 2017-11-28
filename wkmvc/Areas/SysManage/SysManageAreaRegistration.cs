using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webPage.Areas.SysManages
{
    //后台管理  ；注册的类文件
    public class SysManageAreaRegistration:AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SysManage";
            }
        }
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SysManage_default",
                "Sys/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "webPage.Areas.SysManage.Controllers" }

                );
        }
    }
}