using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCPublishersProject.Models
{
    public class PublishersDB: System.Data.Entity.DbContext
    {
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<PhoneType> PhoneType { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Publisher> Publisher { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure Code First to ignore PluralizingTableName convention 
            // If you keep this convention then the generated tables will have pluralized names. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}