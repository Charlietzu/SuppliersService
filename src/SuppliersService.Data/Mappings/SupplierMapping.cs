using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuppliersService.Business.Models;

namespace SuppliersService.Data.Mappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            // 1 : 1 => Supplier : Address
            builder.HasOne(f => f.Address)
                .WithOne(e => e.Supplier);

            // 1 : N => Supplier : Products
            builder.HasMany(f => f.Products)
                .WithOne(p => p.Supplier)
                .HasForeignKey(p => p.SupplierId);

            builder.ToTable("Suppliers");
        }
    }
}