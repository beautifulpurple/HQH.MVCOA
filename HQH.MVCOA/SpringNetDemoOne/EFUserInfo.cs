using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemoOne
{
    public class EFUserInfo:IUserInfo
    {
        public string Name { get; set; }
        public EFUserInfo(string parm)
        {
            Name = parm;
        }
        public void Show()
        {
            Console.WriteLine("这是EFDal   "+Name);
        }
    }
}
