using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Service.ServiceImp
{
    public  class UserManage:RepositoryBase<Domain.SYS_USER>,IService.IUserManage
    {


      /// <summary>
      /// 管理用户登录验证
      /// </summary>
      /// <param name="useraccount"></param>
      /// <param name="password"></param>
      /// <returns></returns>
        public Domain.SYS_USER UserLogin(string useraccount, string password)
        {
            
            var entity = this.Get(p => p.ACCOUNT == useraccount);
            if (entity != null && new Common.CryptHelper.AESCrypt().Decrypt(entity.PASSWORD) == password)
            {
                return entity;
            }
            return null;
        }
        /// <summary>
        /// 是否超级管理员
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsAdmin(int userId)
        {
            return true;
        }
        /// <summary>
        /// 根据用户id获取用户名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetUserName(int Id)
        {

            var query = this.LoadAll(c => c.ID == Id);
            if (query == null || !query.Any())
            {
                return "";
            }

            return query.First().NAME;
        }

        

    }
}
