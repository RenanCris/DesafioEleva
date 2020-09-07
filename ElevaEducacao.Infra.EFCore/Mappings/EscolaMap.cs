using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class EscolaMap : EntityMap<Escola>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Escola> builder)
        {
            builder.Property(x => x.ConvenioPoderPublico);
            builder.Property(x => x.AtendeEducacaoEspecial);

            builder
               .Property(c => c.CategoriaAdministrativa)
               .HasConversion<int>();

            builder
               .Property(c => c.TipoLocalizacao)
               .HasConversion<int>();

        }
    }
}
