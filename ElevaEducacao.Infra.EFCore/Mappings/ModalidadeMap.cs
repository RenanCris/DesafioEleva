using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class ModalidadeMap : EntityMap<Modalidade>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Modalidade> builder)
        {
            
            builder.HasOne(x => x.Escola)
                .WithMany(x => x.Modalidades)
                .HasForeignKey(x => x.IdEscola)
                .IsRequired();

            builder
                .Property(c => c.IdModalidadeEnsino)
                .HasConversion<int>();

        }
    }
}
