using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using NewsMediaMvc.Data;
using System;
using System.Linq;

namespace NewsMediaMvc.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NewsMediaDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NewsMediaDbContext>>()))
            {
                // Look for any Reports.
                if (context.Reports.Any())
                {
                    return;   // DB has been seeded
                }

                
            }
        }
    }
}