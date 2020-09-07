using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class EnderecoMap : EntityMap<Endereco>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Descricao);
            builder.HasOne(x => x.Bairro)
                   .WithMany(x => x.Enderecos)
                   .HasForeignKey(x=> x.IdBairro)
                   .IsRequired();

            builder.HasOne(x => x.Cidade)
                  .WithMany(x => x.Enderecos)
                  .HasForeignKey(x => x.IdCidade)
                  .IsRequired();

            builder.HasOne(x => x.Escola).WithOne(x => x.Endereco).HasForeignKey<Endereco>(x => x.IdEscola).IsRequired();
        }
    }
}
