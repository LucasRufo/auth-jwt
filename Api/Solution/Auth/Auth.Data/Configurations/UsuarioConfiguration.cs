using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).HasColumnType("VARCHAR(100)").IsRequired();
            builder.Property(m => m.Documento).HasColumnType("VARCHAR(20)").IsRequired();
            builder.Property(m => m.Email).HasColumnType("VARCHAR(60)").IsRequired();
            builder.Property(m => m.Senha).HasColumnType("VARCHAR(40)").IsRequired();
            builder.Property(m => m.DataCriacao).HasDefaultValueSql("GetDate()");
            builder.Property(m => m.DataAlteracao).HasColumnType("VARCHAR(100)");
        }
    }
}
