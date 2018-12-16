using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetfromNfine
{
    public class LogFactory
    {
        static LogFactory()
        {
            FileInfo configFile = new FileInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                           ConfigurationManager.AppSettings["log4net"]);
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        public static Log GetLogger(Type type)
        {
            return new Log(LogManager.GetLogger(type));
        }
        public static Log GetLogger(string str)
        {
            return new Log(LogManager.GetLogger(str));
        }
    }
}
