using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemoOne
{
    public class UserInfo : IUserInfo
    {
        public void Show()
        {
            Console.WriteLine("第一个SpringNet实例");
        }
    }
}
