using Aventude.Demo.eShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aventude.Demo.eShop.Data.Configurations
{
    internal class CatalogTypeConfigurations : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("int").ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy");

            builder.Property(x => x.CreatedOn).HasColumnName("CreatedOn").HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.LastModifiedBy).HasColumnName("LastModifiedBy");

            builder.Property(x => x.LastModifiedOn).HasColumnName("LastModifiedOn");

            builder.Property(x => x.Deleted).HasColumnName("Deleted").HasDefaultValue(bool.FalseString);
        }
    }
}
