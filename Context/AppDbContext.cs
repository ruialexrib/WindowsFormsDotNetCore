using Microsoft.EntityFrameworkCore;
using Programatica.Framework.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsFormsDotNetCore.Models;

namespace WindowsFormsDotNetCore.Context
{
    public class AppDbContext : BaseDbContext
    {

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
   

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "User1",
                    Password = Guid.NewGuid().ToString(),
                    Email = "user1@server.com"
                },
                new User
                {
                    Id = 2,
                    Username = "User2",
                    Password = Guid.NewGuid().ToString(),
                    Email = "user2@server.com"
                }
);
        }

    }
}
