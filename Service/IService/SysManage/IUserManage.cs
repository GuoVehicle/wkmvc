using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    /// <summary>
    /// Service层基本用户信息接口
    /// add Vehicle by 2017-10-27s
    /// </summary>
    public interface IUserManage:IRepository <Domain.SYS_USER>
    {

        /// <summary>
        /// 管理用户登录验证,并返回用户信息与权限集合
        /// </summary>
        /// <param name="useraccount"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Domain.SYS_USER UserLogin(string useraccount, string password);
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        bool IsAdmin(int userId);
        /// <summary>
        /// 根据用户ID获取用户名，不存在返回空
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        string GetUserName(int userId);


    }
}
