using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQH.OA.Common.Log
{
    /// <summary>
    /// 用来处理全局异常过滤器中的异常
    /// </summary>
    public class Log4NetWrite : ILogWrite
    {
        public void WriteLogInfo(string message)
        {
            Log4NetFactory.SetSystemLogger(message);
            //Log4NetFactory.GetLogger("错误").Error(message);
        }
    }
}
