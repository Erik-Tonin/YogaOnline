using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YogaOnline.Domain.Entities;

namespace YogaOnline.Infra.EntityMappers
{
    public class TeacherProfileMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher", "tc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(65).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(80).IsRequired();
            //builder.Ignore(e => e.AttemptedValue);
        }
    }
}
