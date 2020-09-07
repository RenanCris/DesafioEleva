using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElevaEducacao.Infra.EFCore.Migrations
{
    public partial class IndicacaoNome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Escola",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Escola");

        }
    }
}
