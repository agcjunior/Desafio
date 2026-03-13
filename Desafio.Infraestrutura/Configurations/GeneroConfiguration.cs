using Desafio.Dominio.Generos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infraestrutura.Configurations
{
    public class GeneroConfiguration : IEntityTypeConfiguration<Genero>
    {
        public void Configure(EntityTypeBuilder<Genero> builder)
        {
            builder.ToTable("Generos");
            builder.HasKey(genero => genero.Id);
            builder.Property(genero => genero.Nome).HasMaxLength(100).IsRequired();
        }
    }
}
