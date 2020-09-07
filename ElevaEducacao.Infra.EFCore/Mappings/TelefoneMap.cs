using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElevaEducacao.Infra.EFCore.Mappings
{
    public class TelefoneMap : EntityMap<Telefone>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Telefone> builder)
        {
            builder
                .Property(x => x.Numero)
                .IsRequired();

            builder
               .Property(x => x.DDD)
              .IsRequired();

            builder.HasOne(x => x.Escola)
                .WithMany(x => x.Telefones)
                .HasForeignKey(x=> x.IdEscola)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
