using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xena.Domain;
using Xena.Domain.Users;
using Xena.Domain.Roles;
using Xena.Domain.Logs;
using Xena.Domain.Amazon;
using Microsoft.EntityFrameworkCore;

namespace Xena.Infrastructure.Persistence
{
    public class XenaContext : DbContext
    {
        public DbSet<BlackListedToken> BlackListedTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Log> Logs { get; set; }

        public DbSet<AmazonAdGroup> AmazonAdGroups { get; set; }
        public DbSet<AmazonCampaign> AmazonCampaigns { get; set; }
        public DbSet<AmazonKeyword> AmazonKeywords { get; set; }
        public DbSet<AmazonProfile> AmazonProfiles { get; set; }

        public XenaContext(DbContextOptions<XenaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            SetDefaultFields();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetDefaultFields();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void SetDefaultFields()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity)
                {
                    var entity = ((BaseEntity)entry.Entity);
                    switch (entry.State)
                    {
                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entity.IsDeleted = true;
                            break;
                        case EntityState.Added:
                            entity.CreateDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            entity.CreateDate = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}