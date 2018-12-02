using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.Model;

namespace HQH.OA.DAL
{
    /// <summary>
    /// 一次请求共用一个上下文
    /// </summary>
    public class DbContextFactory
    {
        //这里为什么可以用DbContext作为返回值 因为dal层用到的所有方法都是DbContext的 
        //    用父类作为返回值  这也是面向抽象编程的一种应用  在实际开发中要注意体会
        public static DbContext GetCurrentDbContext()
        {
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)
            {
                dbContext = new DataModelContainer();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
