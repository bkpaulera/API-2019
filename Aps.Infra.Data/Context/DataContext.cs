using Aps.Infra.Data.EntityConfig;
using Aps.Domain.Entities;
using System.Data.Entity;

namespace Aps.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ApsDataConnectionSting"){
            Database.SetInitializer<DataContext>(new DataContextInitializer());
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class DataContextInitializer: DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Users.Add(new User { Id = 1, Login=  "paulo" , Password="123456" , Email="paulo@email.com", Active=true});
            context.Users.Add(new User { Id = 3, Login = "false", Password = "123456", Email = "false@email.com", Active = false });
            context.Users.Add(new User { Id = 3, Login = "false2", Password = "123456", Email = "false2@email.com", Active = false });
            context.Users.Add(new User { Id = 4, Login = "thais", Password = "123456", Email = "thai@email.com", Active = true });

            context.SaveChanges();

        }
    }
}
