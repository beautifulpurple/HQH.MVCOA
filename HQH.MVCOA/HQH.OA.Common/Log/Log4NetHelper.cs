using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQH.OA.Common.Log
{
  public  class Log4NetHelper
    {
        /// <summary>
        ///  静态只读实体对象error信息  只用来处理全局异常过滤器中配置的异常处理
        /// 获取配置中logger的name为systemlogerror的配置
        /// </summary>
        public static readonly log4net.ILog LogSystemError = log4net.LogManager.GetLogger("systemlogerror");
        /// <summary>
        /// 处理全局异常过滤器中的信息
        /// </summary>
        /// <param name="message">自定义日志内容说明</param>
        /// <param name="ex">异常信息</param>
        public static void SetSystemError(object ex)
        {
            try
            {
                if (LogSystemError.IsErrorEnabled)
                {
                    LogSystemError.Error(ex);
                }
            }
            catch { }
        }
        //===================下面的是可以自定义的日志配置==================================
        private ILog logger;
        public Log4NetHelper(ILog log)
        {
            this.logger = log;
        }
        public void Debug(object message)
        {
            this.logger.Debug(message);
        }
        public void Error(object message)
        {
            this.logger.Error(message);
        }
        public void Info(object message)
        {
            this.logger.Info(message);
        }
        public void Warn(object message)
        {
            this.logger.Warn(message);
        }
    }
}
