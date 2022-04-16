#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reports.Models;


    public class ReportsContext : DbContext
    {
        public ReportsContext (DbContextOptions<ReportsContext> options)
            : base(options)
        {
        }

        public DbSet<Reports.Models.Report> Reports { get; set; }
    }
