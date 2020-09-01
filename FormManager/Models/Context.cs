using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FormManager.Models
{
    public class Context : DbContext
    {
        public DbSet<InputField> InputFields { get; set; }

        public DbSet<Form> Forms { get; set; }

        public Context(DbContextOptions<Context> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
