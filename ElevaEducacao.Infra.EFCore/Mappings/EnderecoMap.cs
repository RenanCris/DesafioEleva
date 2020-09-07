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
                   .IsRequired();

            builder.HasOne(x => x.Cidade)
                  .WithMany(x => x.Enderecos)
                  .IsRequired();

           
        }
    }
}
