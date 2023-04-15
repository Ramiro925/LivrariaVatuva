using Livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Data.Map
{
    public class AutorMap : IEntityTypeConfiguration<AutorModel>
    {
        public void Configure(EntityTypeBuilder<AutorModel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Nome).IsRequired().HasMaxLength(255);
            builder.Property(a => a.Biografia).IsRequired().HasMaxLength(255);
            builder.Property(a => a.Star).IsRequired().HasMaxLength(255);
        }
    }
}
