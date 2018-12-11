using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ComponentIdToStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Components_ComponentId",
                table: "Storages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComponentId",
                table: "Storages",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Components_ComponentId",
                table: "Storages",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Components_ComponentId",
                table: "Storages");

            migrationBuilder.AlterColumn<Guid>(
                name: "ComponentId",
                table: "Storages",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Components_ComponentId",
                table: "Storages",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
