using CoreMVCViewTest1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCViewTest1.Repositories
{
    /// <summary>
    /// 对用户表的CRUD操作
    /// </summary>
    public class UserRepository
    {
        private CoreLearnTestDbContext DbContext { get; }
        public UserRepository(CoreLearnTestDbContext dbc)
        {
            //在构造函数中注入DbContext
            this.DbContext = dbc;
        }
        //添加用户

        public int Add(UserEntity user)
        {
            using (DbContext)
            {
                //由于我们在UserEntity.Id配置了自增列的Attribute，EF执行完成后会自动把自增列的值赋值给user.Id
                DbContext.Users.Add(user);
                return DbContext.SaveChanges();
            }
        }

        //删除用户
        public int Delete(int id)
        {
            using (DbContext)
            {
                UserEntity user = DbContext.Users.Find(id);
                DbContext.Users.Remove(user);
                return DbContext.SaveChanges();
            }
        }

        //修改用户
        public int Update(UserEntity user)
        {
            using (DbContext)
            {
                UserEntity oldUser = DbContext.Users.Find(user.Id);
                if (oldUser != null)
                {
                    oldUser.SetValNoPk(user);
                    return DbContext.SaveChanges();
                }
                return 0;
            }
        }

        //查询用户
        public UserEntity QueryById(int id)
        {
            using (DbContext)
            {
                return DbContext.Users.Find(id);
            }
        }

        //通过age查询用户集合
        public List<UserEntity> QueryByAge(int age)
        {
            using (DbContext)
            {
                return DbContext.Users.Where(u => u.Age == age).ToList();
            }
        }
    }
}
