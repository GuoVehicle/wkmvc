using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;

namespace Domain
{  
    
    /// 字符串对应应用程序中配置文件
    public class MyConfig:Entities
    {
        /// 封装EF实体模型，供Dao使用，
        public System.Data.Entity.DbContext db { get; private set; }

        public MyConfig()
        {
            ///实例化ef数据库上下文
            db = new Entities();


        }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string DefaultConnectionString = "";


        public static IDbConnection DefaultConnection
        {
            get
            {
                IDbConnection defaultConn = null;
                string action= ConfigurationManager.AppSettings["daoType"];
                switch (action)
                {
                    case "mssql":
                        defaultConn = new System.Data.SqlClient.SqlConnection();
                        DefaultConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                        break;
                    default:
                        break;
                }

                return defaultConn;
            }

        }
        public static string DataBaseConnectionString(string EntityName)
        {
             IDbConnection con = DefaultConnection;
             return EFConnectionStringModle(EntityName, DefaultConnectionString);
        }

        static string EFConnectionStringModle(string EntityName, string DBsoure)
         {
             return string.Concat("metadata=res://*/",
                EntityName, ".csdl|res://*/",
               EntityName, ".ssdl|res://*/",
               EntityName, ".msl;provider=System.Data.SqlClient;provider connection string='",
               DBsoure, "'");

        }


}
}
