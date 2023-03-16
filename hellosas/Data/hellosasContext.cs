using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using hellosas.Controllers.Models;

namespace hellosas.Data
{
    public class hellosasContext : DbContext
    {
        public hellosasContext (DbContextOptions<hellosasContext> options)
            : base(options)
        {
        }

        public DbSet<hellosas.Controllers.Models.course> course { get; set; }

        public DbSet<hellosas.Controllers.Models.stdinfo> stdinfo { get; set; }

        public DbSet<hellosas.Controllers.Models.admissioninfo> admissioninfo { get; set; }
    }
}
