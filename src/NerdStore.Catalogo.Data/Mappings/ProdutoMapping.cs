using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Valor)
                    .HasColumnType("decimal(10,2)");

            builder.OwnsOne(p => p.Dimensoes, dm =>
            {
                dm.Property(d => d.Altura)
                    .HasColumnType("Altura")
                    .HasColumnType("int");
                
                dm.Property(d => d.Largura)
                    .HasColumnType("Largura")
                    .HasColumnType("int");
                
                dm.Property(d => d.Profundidade)
                    .HasColumnType("Profundidade")
                    .HasColumnType("int");
            });

            builder.ToTable("Produtos");
        }
    }
}