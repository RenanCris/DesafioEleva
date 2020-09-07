using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class HistoricoStatusMap : EntityMap<HistoricoStatus>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<HistoricoStatus> builder)
        {
            builder
                .Property(x => x.Status)
                .IsRequired();

            builder
                .Property(x => x.Data)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.HasOne(x => x.Escola)
                .WithMany(x => x.StatusHistorico)
                .HasForeignKey(x => x.IdEscola)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
