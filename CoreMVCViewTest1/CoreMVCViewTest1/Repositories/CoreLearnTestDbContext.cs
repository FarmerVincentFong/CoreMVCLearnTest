using CoreMVCViewTest1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCViewTest1.Repositories
{
    /// <summary>
    /// 数据库上下文类（映射CoreLearnTest数据库实例）
    /// </summary>
    public class CoreLearnTestDbContext : DbContext
    {
        private IConfiguration Configuration { get; }
        public CoreLearnTestDbContext(IConfiguration config)
        {
            this.Configuration = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("testdb"));
        }

        /// <summary>
        /// 映射到User表
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }
    }
}
