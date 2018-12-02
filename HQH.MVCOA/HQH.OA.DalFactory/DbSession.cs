using HQH.OA.DAL;
using HQH.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQH.OA.DalFactory
{
    /// <summary>
    /// 在抽象工厂的模式上 在进行封装  
    /// 注意：如果牵扯到层与层之间的调用 不要问为什么  使用接口
    /// </summary>
    public class DbSession:IDbSession
    {
        public IUserInfoDal UserInfoDal
        {
            get { return StaticDalFactory.GetUserInfoDal(); }
        }
        public IOrderInfoDal OrderInfoDal
        {
            get { return StaticDalFactory.GetOrderInfoDal(); }
        }
        /// <summary>
        /// 拿到当前EF的上下文 然后把修改一次提交
        /// </summary>
        /// <returns></returns>
        public int SaveChanges()
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
