using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetRazorPage.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNetRazorPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}