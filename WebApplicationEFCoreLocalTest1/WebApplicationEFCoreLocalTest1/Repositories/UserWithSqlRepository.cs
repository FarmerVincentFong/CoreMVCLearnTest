using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEFCoreLocalTest1.Models;

namespace WebApplicationEFCoreLocalTest1.Repositories
{
    /// <summary>
    /// EF Core 使用SQL
    /// </summary>
    public class UserWithSqlRepository
    {
        private CusDbContext _dbContext;
        public UserWithSqlRepository(CusDbContext dbc)
        {
            //在构造方法中注入DbContext
            this._dbContext = dbc;
        }

        //添加
        public int Add(UserEntity user)
        {
            //使用sql添加
            using (var conn = _dbContext.Database.GetDbConnection())
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"insert into [user](name,age,hobby) values(@name,@age,@hobby)";
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 255) { Value = user.Name });
                cmd.Parameters.Add(new SqlParameter("@age", SqlDbType.SmallInt) { Value = user.Age });
                cmd.Parameters.Add(new SqlParameter("@hobby", SqlDbType.VarChar, 500) { Value = user.Hobby });
                int count = cmd.ExecuteNonQuery();
                return count;
            }
        }

        public int Delete(int id)
        {
            using (_dbContext)
            {
                return _dbContext.Database.ExecuteSqlCommand("delete from [user] where id=@userid"
                    , new SqlParameter { ParameterName = "@userid", SqlDbType = SqlDbType.Int, Value = id });
            }
        }

        public int Update(UserEntity user)
        {
            using (_dbContext)
            {
                return _dbContext.Database.ExecuteSqlCommand("update [user] set name={0},age={1},hobby={2} where id={3}"
                    , user.Name, user.Age, user.Hobby, user.Id);
            }
        }

        public UserEntity QueryById(int id)
        {
            return _dbContext.Users.FromSql("select * from [user] where id={0}", id).FirstOrDefault();
        }

        public List<UserEntity> QueryAll()
        {
            return _dbContext.Users.FromSql("select * from [user]").ToList();
        }

        public List<UserEntity> QueryByAge(short age)
        {
            return _dbContext.Users.FromSql("select * from [user] where age={0}", age).ToList();
        }

        public List<string> QueryNamesByAge(short age)
        {
            //不知道是否需要加id
            var eer = _dbContext.Users.FromSql("select id,name from [user] where age={0}", age);
            return eer.Select(n => n.Name).ToList();
        }

        public List<UserEntity> QueryUserPaging(int pageSize, int pageIndex)
        {
            return _dbContext.Users.FromSql("select * from [user] order by id offset {0} rows fetch next {1} rows only"
                , pageIndex < 1 ? 0 : ((pageSize * (pageIndex - 1))), pageSize).ToList();
        }

        //使用事务：将年龄<0的用户修改年龄为0
        public int FixAgeByTrans1()
        {
            using (var conn = _dbContext.Database.GetDbConnection())
            {
                //打开链接
                conn.Open();
                //开启事务
                using (var trans = conn.BeginTransaction())
                {
                    try
                    {
                        //获取命令对象
                        var cmd = conn.CreateCommand();
                        cmd.Transaction = trans;
                        cmd.CommandText = @"update [user] set age=0 where age<0";
                        var count = cmd.ExecuteNonQuery();
                        trans.Commit();
                        return count;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        conn.Close();
                        return 0;
                    }
                }
            }
        }
    }
}
