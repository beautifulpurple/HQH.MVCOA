using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.IDAL;
using HQH.OA.Model;

namespace HQH.OA.DAL
{
    /// <summary>
    /// 难道OrderInfo也要在封装一次  oh no don't repeat yourself
    /// </summary>
    public class OrderInfoDal : BaseDal<OrderInfo>, IOrderInfoDal
    {
    }
}
