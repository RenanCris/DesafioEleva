using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElevaEducacao.Infra.EFCore.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bairro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairro", x => x.Id);
                });

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
                    Nome = table.Column<string>(unicode: false, nullable: false),
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
                name: "UF",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UF", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEscola = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2020, 9, 8, 14, 16, 30, 319, DateTimeKind.Local).AddTicks(4005))
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEscola = table.Column<int>(nullable: false),
                    IdModalidadeEnsino = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalidade_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UFId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_UF_UFId",
                        column: x => x.UFId,
                        principalTable: "UF",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaDisciplina",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdTurma = table.Column<int>(nullable: false),
                    IdDisciplina = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCidade = table.Column<int>(nullable: false),
                    IdBairro = table.Column<int>(nullable: false),
                    Numero = table.Column<string>(unicode: false, nullable: true),
                    Complemento = table.Column<string>(unicode: false, nullable: true),
                    Descricao = table.Column<string>(unicode: false, nullable: true),
                    IdEscola = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Endereco_Bairro_IdBairro",
                        column: x => x.IdBairro,
                        principalTable: "Bairro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endereco_Cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "Cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Endereco_Escola_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escola",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bairro_Descricao",
                table: "Bairro",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_UFId",
                table: "Cidade",
                column: "UFId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_Descricao",
                table: "Disciplina",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdBairro",
                table: "Endereco",
                column: "IdBairro");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdCidade",
                table: "Endereco",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdEscola",
                table: "Endereco",
                column: "IdEscola",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoStatus_IdEscola",
                table: "HistoricoStatus",
                column: "IdEscola");

            migrationBuilder.CreateIndex(
                name: "IX_Modalidade_IdEscola",
                table: "Modalidade",
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

            migrationBuilder.CreateIndex(
                name: "IX_TurmaDisciplina_IdTurma",
                table: "TurmaDisciplina",
                column: "IdTurma");

            migrationBuilder.CreateIndex(
                name: "IX_UF_Descricao",
                table: "UF",
                column: "Descricao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "HistoricoStatus");

            migrationBuilder.DropTable(
                name: "Modalidade");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "TurmaDisciplina");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "UF");

            migrationBuilder.DropTable(
                name: "Escola");
        }
    }
}
