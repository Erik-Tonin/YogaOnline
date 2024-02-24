using Microsoft.EntityFrameworkCore;
using YogaOnline.Domain.Entities;

namespace YogaOnline.Infra.Context
{
    public class MicroServiceContext : DbContext
    {

        public MicroServiceContext(DbContextOptions<MicroServiceContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<ValidationFailure>();
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new UserProfileMap());

        }
    }
}
