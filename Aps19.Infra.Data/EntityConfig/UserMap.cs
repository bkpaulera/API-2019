using Aps.Domain;
using System.Data.Entity.ModelConfiguration;

namespace Aps19.Infra.Data.EntityConfig
{
    class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(x => x.Id);

            Property(x => x.Login).HasMaxLength(20).IsRequired();
            Property(x => x.Password).HasMaxLength(30).IsRequired();
            Property(x => x.Email).HasMaxLength(120).IsRequired();
        }  
    }
}
