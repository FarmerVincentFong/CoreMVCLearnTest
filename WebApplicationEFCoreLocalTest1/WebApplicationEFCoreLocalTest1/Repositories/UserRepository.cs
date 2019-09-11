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

        //添加
        public int Add(UserEntity newUser)
        {
            using (DbContext)
            {
                DbContext.Users.Add(newUser);
                return DbContext.SaveChanges();
            }
        }
        //查询所有
        public List<UserEntity> QueryAll()
        {
            //Dispose这个DbContext后，在调用其他方法访问，会抛Context已销毁异常
            //using (DbContext)
            {
                return DbContext.Users.ToList();
            }
        }

        //删除
        public int Delete(int id)
        {
            using (DbContext)
            {
                var findUser = DbContext.Users.Find(id);
                DbContext.Users.Remove(findUser);
                return DbContext.SaveChanges();
            }
        }

        //更新
        public int Update(UserEntity newUser)
        {
            using (DbContext)
            {
                var oldUser = DbContext.Users.Find(newUser?.Id);
                if (oldUser != null)
                {
                    oldUser.Name = newUser.Name;
                    oldUser.Age = newUser.Age;
                    oldUser.Hobby = newUser.Hobby;
                    return DbContext.SaveChanges();
                }
                return 0;
            }
        }

        //查询id
        public UserEntity QueryById(int id)
        {
            using (DbContext)
            {
                return DbContext.Users.Find(id);
            }
        }

        //查询年龄
        public List<UserEntity> QueryByAge(short age)
        {
            using (DbContext)
            {
                return DbContext.Users.Where(u => u.Age == age).ToList();
            }
        }

        //查看指定列
        public List<string> QueryNamesByAge(short age)
        {
            using (DbContext)
            {
                var ee = DbContext.Users.Where(u => u.Age == age);
                return ee.Select(u => u.Name).ToList();
            }
        }

        //分页查询
        public List<UserEntity> QueryUserPaging(int pageSize, int PageIndex)
        {
            using (DbContext)
            {
                return DbContext.Users.Skip(((PageIndex < 1 ? 1 : PageIndex) - 1) * pageSize).Take(pageSize).ToList();
            }
        }

        //使用事务：将年龄<0的用户修改年龄为0
        public int FixAgeByTrans()
        {
            //using (DbContext)
            {
                using (var trans = DbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var unfixUsers = DbContext.Users.Where(u => u.Age < 0);
                        foreach (var ufu in unfixUsers)
                        {
                            //修正为0
                            ufu.Age = 0;
                        }
                        var count = DbContext.SaveChanges();
                        trans.Commit();
                        return count;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        return -1;
                    }
                }
            }
        }
    }
}
