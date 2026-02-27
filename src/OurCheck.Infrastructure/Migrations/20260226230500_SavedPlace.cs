using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCheck.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SavedPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SavedPlaceId",
                schema: "app",
                table: "Appointments",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SavedPlaces",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedPlaces", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_SavedPlaceId",
                schema: "app",
                table: "Appointments",
                column: "SavedPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_SavedPlaces_Id",
                schema: "app",
                table: "SavedPlaces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_SavedPlaces_SavedPlaceId",
                schema: "app",
                table: "Appointments",
                column: "SavedPlaceId",
                principalSchema: "app",
                principalTable: "SavedPlaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_SavedPlaces_SavedPlaceId",
                schema: "app",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "SavedPlaces",
                schema: "app");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_SavedPlaceId",
                schema: "app",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "SavedPlaceId",
                schema: "app",
                table: "Appointments");
        }
    }
}
