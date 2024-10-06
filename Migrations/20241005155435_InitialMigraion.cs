using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkPoint_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigraion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail1 = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Detail2 = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Detail3 = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Picture1 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture2 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture3 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture4 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture5 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture6 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture7 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture8 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture9 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Picture10 = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedDate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedTime = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
