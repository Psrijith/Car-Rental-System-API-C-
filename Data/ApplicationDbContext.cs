﻿
using DEMO__ASS9.Models;
using Microsoft.EntityFrameworkCore;

namespace DEMO__ASS9.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
