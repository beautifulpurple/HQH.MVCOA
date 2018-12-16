using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetfromNfine
{
    class Program
    {
        static void Main(string[] args)
        {
            LogFactory.GetLogger("zhehsierror").Error("测试从Nfine整过来的2");
            Console.ReadKey();
        }
    }
}
