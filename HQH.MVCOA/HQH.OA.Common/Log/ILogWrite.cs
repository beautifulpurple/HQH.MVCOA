using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQH.OA.Common.Log
{
    public interface ILogWrite
    {
        void WriteLogInfo(string message);
    }
}
