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
    /// 老师说不用继承IBaseDal  其实我感觉还是继承好点 先不继承了  之后再好好理解理解
    public class BaseDal<T> where T : class,new()//解释：T冒号后面是用来约束T是一个类 并且有一个默认构造函数
    {
        //这里为什么可以用DbContext作为返回值 因为dal层用到的所有方法都是DbContext的 
        //    用父类作为返回值  这也是面向抽象编程的一种应用  在实际开发中要注意体会
        public DbContext Db
        {
            get { return DbContextFactory.GetCurrentDbContext(); }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public IQueryable<T> Get(Expression<Func<T, bool>> express)
        {
            return Db.Set<T>().Where(express);
        }
        /// <summary>
        /// 增加   如果主键是自动增长的  增加到数据库中后  会返回一个给主键付了值的实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
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
        public IQueryable<T> GetPageEntities<TS>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> expressionWhere,
            Expression<Func<T, TS>> expressionOrderBy, bool isAsc)
        {
            total = Db.Set<T>().Count();
            if (isAsc)
            {
                return Db.Set<T>()
                    .OrderBy(expressionOrderBy)
                    .Where(expressionWhere)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize);
            }
            else
            {
                return Db.Set<T>()
                   .OrderByDescending(expressionOrderBy)
                   .Where(expressionWhere)
                   .Skip(pageSize * (pageIndex - 1))
                   .Take(pageSize);
            }
        }
    }
}
