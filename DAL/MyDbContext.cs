using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace DAL
{
    public class MyDbContext:DbContext
    {
        private static ILog log = LogManager.GetLogger(typeof(MyDbContext));
        public MyDbContext() : base("name=connection")
        {
            Database.SetInitializer<MyDbContext>(null);
            this.Database.Log = (sql) =>
            {
                log.DebugFormat("EF执行SQL：{0}", sql);
            };
        }

        public DbSet<Anju_AJFWaitinglistEntity> AjFWaitinglist { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
