using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElevaEducacao.Infra.EFCore.Migrations
{
    public partial class AjusteMapForeigkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Bairro_BairroId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco");


            migrationBuilder.DropIndex(
                name: "IX_Endereco_BairroId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "BairroId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "IdBairro",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);

      
            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdBairro",
                table: "Endereco",
                column: "IdBairro");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_IdCidade",
                table: "Endereco",
                column: "IdCidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Bairro_IdBairro",
                table: "Endereco",
                column: "IdBairro",
                principalTable: "Bairro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cidade_IdCidade",
                table: "Endereco",
                column: "IdCidade",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Bairro_IdBairro",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cidade_IdCidade",
                table: "Endereco");

      
            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdBairro",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_IdCidade",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdBairro",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "BairroId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);


            migrationBuilder.CreateIndex(
                name: "IX_Endereco_BairroId",
                table: "Endereco",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                column: "CidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Bairro_BairroId",
                table: "Endereco",
                column: "BairroId",
                principalTable: "Bairro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
