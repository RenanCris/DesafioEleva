using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElevaEducacao.Infra.EFCore.Migrations
{
    public partial class MapEscolaAgregados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escola",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ConvenioPoderPublico = table.Column<bool>(nullable: false),
                    AtendeEducacaoEspecial = table.Column<bool>(nullable: false),
                    CategoriaAdministrativa = table.Column<int>(nullable: false),
                    TipoLocalizacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escola", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEscola = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2020, 9, 6, 20, 11, 41, 804, DateTimeKind.Local).AddTicks(7107))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoStatus_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modalidade",
                columns: table => new
                {
                    IdEscola = table.Column<int>(nullable: false),
                    IdModalidadeEnsino = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalidade_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id"
                        );
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DDD = table.Column<int>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    IdEscola = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoPesquisa = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    IdEscola = table.Column<int>(nullable: false),
                    HorasAula = table.Column<int>(nullable: false),
                    TotalVagas = table.Column<int>(nullable: false, defaultValue: 1),
                    TotalVagasOcupadas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplina",
                columns: table => new
                {
                    IdTurma = table.Column<int>(nullable: false),
                    IdDisciplina = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataVinculacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataModificacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaDisciplina", x => new { x.Id, x.IdTurma, x.IdDisciplina });
                    table.ForeignKey(
                        name: "FK_TurmaDisciplina_Disciplina_IdDisciplina",
                        column: x => x.IdDisciplina,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaDisciplina_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdEscola",
                table: "Endereco",
                column: "IdEscola",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_Descricao",
                table: "Disciplina",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoStatus_IdEscola",
                table: "HistoricoStatus",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_IdEscola",
                table: "Telefone",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdEscola",
                table: "Turma",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplina_IdDisciplina",
                table: "TurmaDisciplina",
                column: "IdDisciplina");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Escola_IdEscola",
                table: "Endereco",
                column: "IdEscola",
                principalTable: "Escola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Escola_IdEscola",
                table: "Endereco");

            migrationBuilder.DropTable(
                name: "HistoricoStatus");

            migrationBuilder.DropTable(
                name: "Modalidade");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "TurmaDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Escola");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdEscola",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdEscola",
                table: "Endereco");
        }
    }
}
