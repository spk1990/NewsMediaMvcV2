#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.Models;


    public class NewsMediaDbContext : DbContext
    {
        public NewsMediaDbContext (DbContextOptions<NewsMediaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Reports.Models.Report> Reports { get; set; }
    }
