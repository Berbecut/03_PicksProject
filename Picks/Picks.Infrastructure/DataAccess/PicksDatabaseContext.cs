using Microsoft.EntityFrameworkCore;
using Picks.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Picks.Infrastructure.DataAccess
{
    public class PicksDatabaseContext : DbContext
    {
        public PicksDatabaseContext(DbContextOptions<PicksDatabaseContext> options) : base(options)
        {

        }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
    }
}
