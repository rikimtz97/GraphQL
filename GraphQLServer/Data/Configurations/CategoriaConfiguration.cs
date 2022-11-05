using GraphQLServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLServer.Data.Configurations
{
    public class CategoriaConfiguration:IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria", "blog");

            builder.Property(u => u.Nombre)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(u => u.Publicaciones)
                .WithOne(u => u.Categoria)
                .HasForeignKey(u => u.CategoriaId);
        }
        
    }
}
