using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HQH.OA.Common.Log
{
    public class LogHelper
    {
        private static Queue<string> ExceptionStringQueue = new Queue<string>();
        private static List<ILogWrite> LogWriteList = new List<ILogWrite>();
        //        静态构造函数在这个类被调用时就已经执行  而且只执行一次
        //静态构造函数不允许有访问修饰符的修饰
        static LogHelper()
        {
            LogWriteList.Add(new Log4NetWrite());

            ThreadPool.QueueUserWorkItem(o =>
            {
                while (true)
                {
                    lock (ExceptionStringQueue)
                    {
                        if (ExceptionStringQueue.Any())//有数据再操作
                        {
                            string str = ExceptionStringQueue.Dequeue();
                            foreach (var item in LogWriteList)
                            {
                                item.WriteLogInfo(str);
                            }
                        }
                        else
                        {
                            Thread.Sleep(30);
                        }
                    }
                }
            });
        }
        /// <summary>
        ///将错误信息添加到队列
        /// </summary>
        /// <param name="exceptionText"></param>
        public static void WriteLog(string exceptionText)
        {
            lock (ExceptionStringQueue)
            {
                ExceptionStringQueue.Enqueue(exceptionText);
            }
        }
    }
}
