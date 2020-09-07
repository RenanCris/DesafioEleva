using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class BairroMap : EntityMap<Bairro>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Bairro> builder)
        {
            builder.HasIndex(x => x.Descricao).IsUnique(true);
            builder.Property(x => x.Descricao);
        }
    }
}
