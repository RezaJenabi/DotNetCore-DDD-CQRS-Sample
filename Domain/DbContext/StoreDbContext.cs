using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.BaseEntities;
using Domain.Models.Customers;
using Domain.Models.Customers.Addresses;
using Domain.Models.Customers.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Domain.DbContext
{
    public class StoreDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StoreDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Address { get; set; }
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
