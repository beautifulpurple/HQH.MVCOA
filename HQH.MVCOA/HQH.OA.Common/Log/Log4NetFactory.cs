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
    class Log4NetFactory
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
        //public static void 
    }
}
