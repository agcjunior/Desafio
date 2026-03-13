using Desafio.Dominio.Autores;
using Desafio.Dominio.Generos;
using Desafio.Dominio.Livros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Infraestrutura.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livros");
            builder.HasKey(livro => livro.Id);
            builder.Property(livro => livro.Nome).HasMaxLength(100).IsRequired();

            builder.HasOne(l => l.Genero)
                .WithMany()
                .HasForeignKey(l => l.GeneroId);

            builder.HasOne(l => l.Autor)
                .WithMany()
                .HasForeignKey(l => l.AutorId);
        }
    }
}
