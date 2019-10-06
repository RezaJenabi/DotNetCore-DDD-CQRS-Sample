using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.BaseEntities;
using Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Utilities.Extensions.ModelBuilder;

namespace Domain.DbContext
{
    public class StoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var domainAssembly = typeof(Customer).Assembly;
            modelBuilder.RegisterAllEntities<IEntity>(domainAssembly);
            modelBuilder.RegisterEntityTypeConfiguration(domainAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddPluralizingTableNameConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            

            foreach (var entry in entries.Where(x => x.State != EntityState.Deleted))
            {
                EntityTrack(entry);
            }

            foreach (var entry in entries.Where(x => x.State == EntityState.Deleted))
            {
                SoftDeleteTrack(entry);
            }
        }

        private void EntityTrack(EntityEntry entry)
        {
            var now = DateTime.UtcNow;
            var user = GetCurrentUser();

            if (!(entry.Entity is ITrackable trackable)) return;
            trackable.LastUpdatedAt = now;
            trackable.LastUpdatedBy = user;

            if (entry.State != EntityState.Added) return;
            trackable.CreatedAt = now;
            trackable.CreatedBy = user;
        }

        private void SoftDeleteTrack(EntityEntry entry)
        {
            var now = DateTime.UtcNow;
            var user = GetCurrentUser();
            var softDelete = entry.Entity as ISoftDelete;
            entry.State = EntityState.Modified;
            if (softDelete == null) return;
            softDelete.Deleted = true;
            softDelete.DeletedAt = now;
            softDelete.DeletedBy = user;
        }

        private string GetCurrentUser()
        {
            return "UserName";
        }
    }
}
