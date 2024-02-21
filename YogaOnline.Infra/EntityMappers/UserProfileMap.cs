using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using YogaOnline.Domain.Entities;

namespace YogaOnline.Infra.EntityMappers
{
    public class UserProfileMap : IEntityTypeConfiguration<User>  
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "up");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(65).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(80).IsRequired();
            //builder.Ignore(e => e.AttemptedValue);
        }
    }
}
