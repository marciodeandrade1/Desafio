using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Logotipo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Logradouros",
                columns: table => new
                {
                    LogradouroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Cliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    clienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logradouros", x => x.LogradouroId);
                    table.ForeignKey(
                        name: "FK_Logradouros_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logradouros_clienteId",
                table: "Logradouros",
                column: "clienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logradouros");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
