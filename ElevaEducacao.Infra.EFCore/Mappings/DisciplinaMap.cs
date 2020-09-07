using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class DisciplinaMap : EntityMap<Disciplina>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Disciplina> builder)
        {
            builder.HasIndex(x => x.Descricao).IsUnique();
            builder
                .Property(x => x.Descricao)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
