using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IfxData.Migrations
{
    public partial class RenombrarAEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Empresas_EmpresaId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Empleados",
                newName: "EntidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_EmpresaId",
                table: "Empleados",
                newName: "IX_Empleados_EntidadId");

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Entidades_EntidadId",
                table: "Empleados",
                column: "EntidadId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Entidades_EntidadId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.RenameColumn(
                name: "EntidadId",
                table: "Empleados",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Empleados_EntidadId",
                table: "Empleados",
                newName: "IX_Empleados_EmpresaId");

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RazonSocial = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Empresas_EmpresaId",
                table: "Empleados",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
