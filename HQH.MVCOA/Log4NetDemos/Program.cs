using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.cnblogs.com/vichin/p/6022612.html
            //https://www.cnblogs.com/lsgsanxiao/p/5845300.html
            //https://www.cnblogs.com/wohenxinwei/p/3912528.html

            //初始化日志文件 
            string state = ConfigurationManager.AppSettings["IsWriteLog"];
            //判断是否开启日志记录
            if (state == "1")
            {
                var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                           ConfigurationManager.AppSettings["log4net"];
                var fi = new System.IO.FileInfo(path);
                log4net.Config.XmlConfigurator.Configure(fi);
            }
            LogHelper.WriteLog("holle world",new Exception());
            Console.WriteLine("记录完成");
            Console.ReadKey();
        }
    }
}
