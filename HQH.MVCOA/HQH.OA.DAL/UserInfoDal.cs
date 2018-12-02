using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.IDAL;
using HQH.OA.Model;

namespace HQH.OA.DAL
{
    /// <summary>
    /// 对UserInfo实体的CRUD封装
    /// </summary>
    public class UserInfoDal : BaseDal<UserInfo>, IUserInfoDal
    {
        ///// <summary>
        ///// 声明上下文
        ///// </summary>
        //private DataModelContainer context = new DataModelContainer();
        ///// <summary>
        ///// 根据主键得到实体
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public UserInfo GetUserInfoById(int id)
        //{
        //    return context.UserInfoes.Find(id);
        //}
        ///// <summary>
        ///// 得到所有实体
        ///// </summary>
        ///// <returns></returns>
        //public IQueryable<UserInfo> GetAllUserInfos()
        //{
        //    return context.UserInfoes.AsQueryable();
        //}
        ///// <summary>
        ///// 根据条件得到实体集 其实已经包含前两种情况了
        ///// </summary>
        ///// <param name="express"></param>
        ///// <returns></returns>
        //public IQueryable<UserInfo> GetUserInfoByWhere(Expression<Func<UserInfo, bool>> express)
        //{
        //    return context.UserInfoes.Where(express);
        //}
        ///// <summary>
        ///// 增加   如果主键是自动增长的  增加到数据库中后  会返回一个给主键付了值的实体
        ///// </summary>
        ///// <param name="userinfo"></param>
        ///// <returns></returns>
        //public UserInfo Add(UserInfo userinfo)
        //{
        //    context.UserInfoes.Add(userinfo);
        //    context.SaveChanges();
        //    return userinfo;
        //}
        ///// <summary>
        ///// 更新
        ///// </summary>
        ///// <param name="userinfo"></param>
        ///// <returns></returns>
        //public bool Update(UserInfo userinfo)
        //{
        //    context.Entry(userinfo).State = EntityState.Modified;
        //    return context.SaveChanges() > 0;
        //}
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="userinfo"></param>
        ///// <returns></returns>
        //public bool Delete(UserInfo userinfo)
        //{
        //    context.Entry(userinfo).State = EntityState.Deleted;
        //    return context.SaveChanges() > 0;
        //}
        ///// <summary>
        ///// 分页  泛型方法
        ///// PS：为什么为了排序 把这个方法做成泛型  而不是Expression<Func<UserInfo,object>> expressionOrderBy
        ///// 用object的话  由于sql脚本不能识别object这个类型  这样导致的结果是排序会在内存中进行  而不是数据库中
        ///// 这显然不是我们想要的
        ///// </summary>
        ///// <typeparam name="TS"></typeparam>
        ///// <param name="pageIndex"></param>
        ///// <param name="pageSize"></param>
        ///// <param name="total"></param>
        ///// <param name="expressionWhere"></param>
        ///// <param name="expressionOrderBy"></param>
        ///// <param name="isAsc">升序还是降序</param>
        ///// <returns></returns>
        //public IQueryable<UserInfo> GetPageEntities<TS>(int pageIndex, int pageSize, out int total, Expression<Func<UserInfo, bool>> expressionWhere, Expression<Func<UserInfo, TS>> expressionOrderBy, bool isAsc)
        //{
        //    total = context.UserInfoes.Count();
        //    if (isAsc)
        //    {
        //        return context.UserInfoes
        //            .OrderBy(expressionOrderBy)
        //            .Where(expressionWhere)
        //            .Skip(pageSize * (pageIndex - 1))
        //            .Take(pageSize);
        //    }
        //    else
        //    {
        //        return context.UserInfoes
        //           .OrderByDescending(expressionOrderBy)
        //           .Where(expressionWhere)
        //           .Skip(pageSize * (pageIndex - 1))
        //           .Take(pageSize);
        //    }
        //}
    }
}
