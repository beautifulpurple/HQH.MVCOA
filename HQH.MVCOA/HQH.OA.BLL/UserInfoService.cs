using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.DAL;
using HQH.OA.DalFactory;
using HQH.OA.IBLL;
using HQH.OA.IDAL;
using HQH.OA.Model;
namespace HQH.OA.BLL
{
    public class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        //一：菜鸟的写法
        //UserInfoDal UserInfoDal = new UserInfoDal();
        //直接用dal层进行实例化  这样是刚开始学习的时候的三层  最简单的  各个层之间  直接实例化进行调用
        //简单直接  但是带来的结果是  各层之间的耦合度高 不好应对之后的变化  也就是说不好维护
        //二：菜鸟到一般程序员
        //面向接口编程（面向抽象编程）
        //private IUserInfoDal UserInfoDal = new UserInfoDal();
        //虽然这样好点了 但是还是不是很好 应对变化 可扩展和可维护性有限
        //三：一般程序员到稍微高级点的程序员 
        //简单工厂模式，抽象工厂来增加可维护性
        //public IUserInfoDal UserInfoDal = StaticDalFactory.GetUserInfoDal();
        //public IDbSession DbSession = DbSessionFactory.GetCurrentDbSession();

        //public UserInfo Add(UserInfo userInfo)
        //{
        //    DbSession.UserInfoDal.Add(userInfo);
        //    DbSession.SaveChanges(); 
        //    return userInfo;
        //    //将对数据库的操作  由dal层挪到bll层 这样操作起来更灵活 其中一个好处就是 我可以add好多实体 
        //    //然后在savechanges  这样的话 相当于多条sql 语句一次执行  减少了对数据库的链接操作  更节省时间
        //    //效率更高  这种模式是：UnitWork 单元工作模式
        //}

        public override void SetCurrentDal()
        {
            this.CurrentDal =this.DbSession.UserInfoDal;
        }

        //public bool Update(UserInfo userInfo)
        //{
        //    DbSession.UserInfoDal.Update(userInfo);
        //    return DbSession.SaveChanges() > 0;
        //}
       
    }
}
