using Aventude.Demo.eShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aventude.Demo.eShop.Data.Configurations
{
    internal class CatalogItemConfigurations : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItem");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd();

            builder.Property(x => x.TypeId).HasColumnName("TypeId").HasColumnType("int").IsRequired();

            builder.Property(x => x.BrandId).HasColumnName("BrandId").HasColumnType("int").IsRequired();

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(x => x.Description).HasColumnName("Description").HasMaxLength(1000);

            builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("decimal(18, 4)").IsRequired();

            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasMaxLength(100).IsRequired();

            builder.Property(x => x.ReorderLevel).HasColumnName("ReorderLevel").HasColumnType("int").IsRequired();

            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy");

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.LastModifiedBy).HasColumnName("LastModifiedBy");

            builder.Property(x => x.LastModifiedOn).HasColumnName("LastModifiedOn");

            builder.Property(x => x.Deleted).HasColumnName("Deleted").HasDefaultValue(bool.FalseString);

            builder.HasOne(x => x.Type).WithMany(y => y.CatalogItems).HasForeignKey(x => x.TypeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Brand).WithMany(y => y.CatalogItems).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);
        }
    }
            
}
