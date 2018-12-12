using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemoOne
{
    public class NHUserInfo : IUserInfo
    {
        public string Name { get; set; }
        public IUserInfo EFUserInfo;

       
        public void Show()
        {
            EFUserInfo.Show();
            Console.WriteLine("这是NHDal" + Name);
        }
    }
}
