using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.DalFactory;
using HQH.OA.IDAL;

namespace HQH.OA.BLL
{
    public abstract class BaseService<T> where T : class, new()
    {
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession DbSession
        {
            get
            {
                return DbSessionFactory.GetCurrentDbSession();
            }
        }
        public BaseService()//基类的构造函数
        {
            SetCurrentDal();//抽象方法
        }
        //抽象方法  要求子类必须实现
        //目的：在调用基类里的方法之前 要确保CurrentDal必须已经赋值  要不然不知道这个dal是谁
        public abstract void SetCurrentDal();

        public IQueryable<T> Get(Expression<Func<T, bool>> express)
        {
            return CurrentDal.Get(express);
        }

        public T Add(T entity)
        {
            CurrentDal.Add(entity);
            DbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity)
        {
            CurrentDal.Update(entity);
            return DbSession.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            CurrentDal.Delete(entity);
            return DbSession.SaveChanges() > 0;

        }

        public IQueryable<T> GetPageEntities<TS>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> expressionWhere,
            Expression<Func<T, TS>> expressionOrderBy, bool isAsc)
        {
            return CurrentDal.GetPageEntities(pageIndex, pageSize, out total, expressionWhere, expressionOrderBy, isAsc);
        }
    }
}
