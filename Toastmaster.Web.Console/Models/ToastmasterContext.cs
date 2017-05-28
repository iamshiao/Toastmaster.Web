using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Toastmaster.Web.Console.Models
{
    public class ToastmasterContext : DbContext
    {
        // Your context has been configured to use a 'ToastmasterContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Toastmaster.Web.Console.Models.ToastmasterContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ToastmasterContext' 
        // connection string in the application configuration file.
        public ToastmasterContext()
            : base("name=ToastmasterContext")
        {
            Database.SetInitializer<ToastmasterContext>(new CreateDatabaseIfNotExists<ToastmasterContext>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Meeting> Meetings { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SpeechRecord> SpeechRecords { get; set; }
        public virtual DbSet<RoleRecord> RoleRecords { get; set; }
        public virtual DbSet<IERecord> IERecords { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}