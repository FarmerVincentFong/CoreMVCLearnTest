using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationEFCoreLocalTest1.Models;

namespace WebApplicationEFCoreLocalTest1.Repositories
{
    public class CusDbContext : DbContext
    {
        private IConfiguration Config { get; }
        public CusDbContext(IConfiguration config)
        {
            this.Config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("fwqdb"));
        }

        /// <summary>
        /// 映射到User表
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }
    }
}
