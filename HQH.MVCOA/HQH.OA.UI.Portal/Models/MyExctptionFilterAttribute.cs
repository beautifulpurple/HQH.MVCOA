using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HQH.OA.Common;
using HQH.OA.Common.Log;

namespace HQH.OA.UI.Portal.Models
{
    public class MyExctptionFilterAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogHelper.WriteLog(filterContext.Exception.ToString());
        }
    }
}