using HQH.OA.IBLL;
using HQH.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQH.OA.BLL
{
    public class OrderInfoService : BaseService<OrderInfo>,IOrderInfoService
    {
        public override void SetCurrentDal()
        {
            this.CurrentDal = this.DbSession.OrderInfoDal;
        }
    }
}
