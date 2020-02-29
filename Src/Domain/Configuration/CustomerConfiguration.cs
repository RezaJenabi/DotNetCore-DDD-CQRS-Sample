using Domain.Models.CustomerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Domain.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(b => b.LastName).HasMaxLength(200).IsRequired();

            //builder.OwnsMany(p => p.CreditCards, a =>
            //{
            //    a.WithOwner().HasForeignKey("CustomerId");
            //    a.Property<Guid>("Id");
            //    a.HasKey("Id");
            //});

            //builder.OwnsOne(p => p.Address, od =>
            //{
            //    od.ToTable("Address");
            //});
        }
    }
}