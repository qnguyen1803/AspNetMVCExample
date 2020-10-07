using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    
        public AltranSIWalletContext() : base("name=AltranSIWalletContext")
        {
        }

        public DbSet<AltranSIWallet.Models.User> Users { get; set; }
        public DbSet<AltranSIWallet.Models.Consultant> Consultants { get; set; }
        public DbSet<AltranSIWallet.Models.Manager> Managers { get; set; }
        public DbSet<AltranSIWallet.Models.Project> Projects { get; set; }
        public DbSet<AltranSIWallet.Models.ProjectManager> ProjectManagers { get; set; }
    }
}
