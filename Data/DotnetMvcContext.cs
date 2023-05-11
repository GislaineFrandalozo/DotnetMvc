using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotnetMvc.Models;

namespace DotnetMvc.Data
{
    public class DotnetMvcContext : DbContext
    {
        public DotnetMvcContext (DbContextOptions<DotnetMvcContext> options)
            : base(options)
        {
        }

        public DbSet<DotnetMvc.Models.ListModel> ListModel { get; set; } = default!;
    }
}
