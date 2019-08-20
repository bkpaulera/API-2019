using Aps.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Aps.Infra.Data.EntityConfig
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(x=>x.Id);

            Property(x=>x.Login).HasMaxLength(20).IsRequired();
            Property(x => x.Password).HasMaxLength(30).IsRequired();
            Property(x => x.Email).HasMaxLength(120).IsRequired();

        }   
    }
}
