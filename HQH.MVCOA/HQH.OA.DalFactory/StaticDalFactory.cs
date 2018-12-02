using HQH.OA.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HQH.OA.DalFactory
{
   public class StaticDalFactory
    {
        #region 简单工厂的写法
        //虽然这样写 很好的解耦了dal和bll，已经很好了，但是应对变化的能力还不是很完美 还是要改动代码，
        //    之后还会牵扯到重新生成什么的

        //public static IUserInfoDal GetUserInfoDal()
        //{
        //    return new UserInfoDal();
        //}

        //public static IOrderInfoDal GetOrderInfoDal()
        //{
        //    return new OrderInfoDal();
        //} 
        #endregion

        //抽象工厂  (利用反射 --在web层webconfig中配置的dal程序集名称)
        //能很好的应对变化  
        public static string AssemblyName = ConfigurationManager.AppSettings["DalAssemblyName"];
        public static IUserInfoDal GetUserInfoDal()
        {
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".UserInfoDal") as IUserInfoDal;
        }

        public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(AssemblyName).CreateInstance(AssemblyName + ".UserInfoDal") as IOrderInfoDal;
        }
    }
}
