using Livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<livroModel>
    {
        public void Configure(EntityTypeBuilder<livroModel> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Titulo).IsRequired().HasMaxLength(30);
            builder.Property(a => a.DataPublic).IsRequired().HasMaxLength(12);
            builder.Property(a => a.Editora).IsRequired().HasMaxLength(30);
            builder.Property(a => a.NumISBN).IsRequired().HasMaxLength(30);
            builder.Property(a => a.LivroClassif).IsRequired();
            builder.Property(a => a.AutorId);

            builder.HasOne(a => a.Autor);
        }
    }
}