using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class CidadeMap : EntityMap<Cidade>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(x => x.Descricao);
            builder.HasOne(x => x.UF)
                   .WithMany(x => x.Cidades)
                   .IsRequired();
        }
    }
}
