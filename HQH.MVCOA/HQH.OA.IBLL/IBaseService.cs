using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HQH.OA.IBLL
{
    public interface IBaseService<T> where T : class, new()
    {

        IQueryable<T> Get(Expression<Func<T, bool>> express);

      
        T Add(T entity);

        bool Update(T entity);

       
        bool Delete(T entity);

        IQueryable<T> GetPageEntities<TS>(int pageIndex, int pageSize, out int total,
           Expression<Func<T, bool>> expressionWhere,
           Expression<Func<T, TS>> expressionOrderBy, bool isAsc);
    }
}