using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.Model;

namespace HQH.OA.DAL
{
    /// <summary>
    /// 用泛型类封装基本的CURD 分页
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDal<T> where T : class,new()//解释：T冒号后面是用来约束T是一个类 并且有一个默认构造函数
    {
        /// <summary>
        /// 声明上下文
        /// </summary>
        private DataModelContainer context = new DataModelContainer();
        /// <summary>
        /// 根据条件得到实体集 其实已经包含前两种情况了
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IQueryable<T> GetentityByWhere(Expression<Func<T, bool>> express)
        {
            return context.Set<T>().Where(express);
        }
        /// <summary>
        /// 增加   如果主键是自动增长的  增加到数据库中后  会返回一个给主键付了值的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }
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
        public IQueryable<T> PageIndex<TS>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> expressionWhere,
            Expression<Func<T, TS>> expressionOrderBy, bool isAsc)
        {
            total = context.Set<T>().Count();
            if (isAsc)
            {
                return context.Set<T>()
                    .OrderBy(expressionOrderBy)
                    .Where(expressionWhere)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
            }
            else
            {
                return context.Set<T>()
                   .OrderByDescending(expressionOrderBy)
                   .Where(expressionWhere)
                   .Skip(pageSize * (pageIndex - 1))
                   .Take(pageSize);
            }
        }
    }
}
