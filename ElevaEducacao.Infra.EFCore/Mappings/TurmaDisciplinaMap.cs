using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class TurmaDisciplinaMap : EntityMap<TurmaDisciplina>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<TurmaDisciplina> builder)
        {
            builder.HasKey(x => new {x.Id, x.IdTurma, x.IdDisciplina });

            builder
                .HasOne(x => x.Turma)
                .WithMany(x => x.Disciplinas)
                .HasForeignKey(x=> x.IdTurma)
                .IsRequired();

            builder
                .HasOne(x => x.Disciplina)
                .WithMany(x => x.Turmas)
                .HasForeignKey(x => x.IdDisciplina)
                .IsRequired();
        }
    }
}
