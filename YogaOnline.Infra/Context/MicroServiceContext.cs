using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YogaOnline.Domain.Entities;
using YogaOnline.Infra.EntityMappers;

namespace YogaOnline.Infra.Context
{
    public class MicroServiceContext : DbContext
    {

        public MicroServiceContext(DbContextOptions<MicroServiceContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<ValidationFailure>();
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new UserProfileMap());

        }
    }
}
