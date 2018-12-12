using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spring.Context;
using Spring.Context.Support;

namespace SpringNetDemoOne
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfo userinfo;
            userinfo = (IUserInfo) ctx.GetObject("UserInfo");
            userinfo.Show();
            userinfo = (IUserInfo) ctx.GetObject("EFUserInfo");
            userinfo.Show();
            userinfo = (IUserInfo) ctx.GetObject("NHUserInfo");
            userinfo.Show();
            Console.ReadKey();
        }
    }
}
 