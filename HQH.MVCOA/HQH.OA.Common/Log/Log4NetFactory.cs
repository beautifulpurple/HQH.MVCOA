using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using System.Web;

namespace HQH.OA.Common.Log
{
    public class Log4NetFactory
    {
        static Log4NetFactory()
        {
            FileInfo configFile = new FileInfo(HttpContext.Current.Server.MapPath("/Config/log4net.config"));
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        public static Log4NetHelper GetLogger(Type type)
        {
            return new Log4NetHelper(LogManager.GetLogger(type));
        }
        public static Log4NetHelper GetLogger(string str)
        {
            return new Log4NetHelper(LogManager.GetLogger(str));
        }
        /// <summary>
        /// 专门用来处理全局异常过滤器中的异常信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void SetSystemLogger(object ex)
        {
            Log4NetHelper.SetSystemError(ex);
        }

    }
}
