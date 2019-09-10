using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEFCoreLocalTest1.Models;

namespace WebApplicationEFCoreLocalTest1.Repositories
{
    /// <summary>
    /// 用户表的访问类
    /// </summary>
    public class UserRepository
    {
        //映射到数据库
        private CusDbContext DbContext { get; }
        //DI，在构造方法中注入DbContext
        public UserRepository(CusDbContext dbc)
        {
            this.DbContext = dbc;
        }

        public int Add(UserEntity newUser)
        {
            using (DbContext)
            {
                DbContext.Users.Add(newUser);
                return DbContext.SaveChanges();
            }
        }
        public List<UserEntity> QueryAll()
        {
            using (DbContext)
            {
                return DbContext.Users.ToList();
            }
        }
    }
}
