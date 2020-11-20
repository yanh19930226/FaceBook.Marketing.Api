using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api
{
    public class FacebookContext: DbContext
    {
        public FacebookContext(DbContextOptions<FacebookContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            foreach (Type item in (Assembly.GetEntryAssembly()!.GetTypes()).Where(type => type.HasImplementedRawGeneric(typeof(IEntityTypeConfiguration<>))))
            {
                dynamic val = Activator.CreateInstance(item);
                modelBuilder.ApplyConfiguration(val);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
