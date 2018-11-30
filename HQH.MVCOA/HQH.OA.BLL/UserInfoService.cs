using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQH.OA.DAL;
using HQH.OA.IDAL;
using HQH.OA.Model;
using HQH.OA.StaticDalFactory;

namespace HQH.OA.BLL
{
    public class UserInfoService
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
        public IUserInfoDal UserInfoDal = DalFactory.GetUserInfoDal();


        public UserInfo Add(UserInfo userInfo)
        {
            return UserInfoDal.Add(userInfo);
        }

        public bool Update(UserInfo userInfo)
        {
            return UserInfoDal.Update(userInfo);
        }
    }
}
