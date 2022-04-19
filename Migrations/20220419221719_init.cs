using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Mission.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    QuoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuoteText = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Citation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.QuoteId);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "QuoteText", "Subject" },
                values: new object[] { 1, "Brennan Williams", "Book of mormon", new DateTime(2022, 4, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), "We are all sons and daughters of a loving heavenly father", "Book of Mormon History" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "QuoteText", "Subject" },
                values: new object[] { 2, "Brennan Williams", "Book of mormon", new DateTime(2022, 4, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), "We are all sons and daughters of a loving heavenly father", "Book of Mormon History" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "QuoteId", "Author", "Citation", "Date", "QuoteText", "Subject" },
                values: new object[] { 3, "Brennan Williams", "Book of mormon", new DateTime(2022, 4, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "We are all sons and daughters of a loving heavenly father", "Book of Mormon History" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
