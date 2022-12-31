
using Microsoft.EntityFrameworkCore;
using NewsManagementForm.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestmentPermit.Infrastructure.DBContext
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
        {
        }

        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        { }
        public  DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NewsCategory>().HasData(
    new { Id = 1, Name = "Economy", Description = "this is economy" },
    new { Id = 2, Name = "Politics", Description = "this is politics" },
    new { Id = 3, Name = "Agriculture", Description = "this is agriculture" });
        }
        }
    }

