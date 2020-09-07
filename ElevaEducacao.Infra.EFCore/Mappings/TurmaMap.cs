using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class TurmaMap : EntityMap<Turma>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Turma> builder)
        {
            builder
                .Property(x => x.CodigoPesquisa)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.HorasAula);
            builder.Property(x => x.TotalVagas).HasDefaultValue(1).IsRequired();
            builder.Ignore(x => x.TotalVagasDisponiveis);
            builder.Property(x => x.TotalVagasOcupadas);

            builder.HasOne(x => x.Escola)
                .WithMany(x => x.Turmas)
                .HasForeignKey(x => x.IdEscola)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
