using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class UFMap : EntityMap<UF>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<UF> builder)
        {
            builder.HasIndex(x => x.Descricao).IsUnique(true);
            
            builder
                .Property(x => x.Descricao)
                .IsRequired()
                ;
        }
    }
}
