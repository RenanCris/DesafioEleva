using ElevaEducacao.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
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

    public class EscolaMap : EntityMap<Escola>
    {
        public override void ConfigureEntityBuilder(EntityTypeBuilder<Escola> builder)
        {
            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Escola)
                .IsRequired();

            builder.Property(x => x.ConvenioPoderPublico);
            builder.Property(x => x.AtendeEducacaoEspecial);

            builder
               .Property(c => c.CategoriaAdministrativa)
               .HasConversion<int>();

            builder
               .Property(c => c.TipoLocalizacao)
               .HasConversion<int>();

            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Escola)
                .HasForeignKey<Endereco>(b => b.IdEscola)
                .IsRequired();
        }
    }

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
