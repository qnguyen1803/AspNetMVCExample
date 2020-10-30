using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AltranSIWallet.Models
{
    public class AltranSIWalletContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public AltranSIWalletContext() : base("name=AltranSIWalletContext"){}

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Profil> Profils { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
    }
}
