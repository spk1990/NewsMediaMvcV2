#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Comments.Models;

    public class CommentsContext : DbContext
    {
        public CommentsContext (DbContextOptions<CommentsContext> options)
            : base(options)
        {
        }

        public DbSet<Comments.Models.Comment> Comment { get; set; }
    }
