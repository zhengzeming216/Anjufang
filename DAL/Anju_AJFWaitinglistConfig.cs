using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Entity;

namespace DAL
{
    class Anju_AJFWaitinglistConfig:EntityTypeConfiguration<Anju_AJFWaitinglistEntity>
    {
        public Anju_AJFWaitinglistConfig()
        {
            ToTable("Anju_AJFWaitinglist", "public");
        }
    }
}
