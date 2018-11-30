using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace HQH.OA.IDAL
{
    public interface IBaseDal<T> where T : class,new()
    {
       
        IQueryable<T> Get(Expression<Func<T, bool>> express);

        /// <summary>
        /// 增加   如果主键是自动增长的  增加到数据库中后  会返回一个给主键付了值的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool Delete(T entity);

        /// <summary>
        /// 分页  泛型方法
        /// PS：为什么为了排序 把这个方法做成泛型  而不是Expression<Func<entity,object>> expressionOrderBy
        /// 用object的话  由于sql脚本不能识别object这个类型  这样导致的结果是排序会在内存中进行  而不是数据库中
        /// 这显然不是我们想要的
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="expressionWhere"></param>
        /// <param name="expressionOrderBy"></param>
        /// <param name="isAsc">升序还是降序</param>
        /// <returns></returns>
        IQueryable<T> PageIndex<TS>(int pageIndex, int pageSize, out int total,
           Expression<Func<T, bool>> expressionWhere,
           Expression<Func<T, TS>> expressionOrderBy, bool isAsc);
    }
}