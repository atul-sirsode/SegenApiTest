using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SegenApi.Migrations
{
    /// <inheritdoc />
    public partial class intialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CreatedAt", "Description", "ModifiedAt", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0c579fbf-6b9a-4c76-a220-6ecd809a3c66"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9325), "Mostly Harmless is a 1992 novel by Douglas Adams and the fifth book in the Hitchhiker's Guide to the Galaxy series. It is described on the cover of the first editions as \"The fifth book in the increasingly inaccurately named Hitchhikers Trilogy\".", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9325), "Mostly Harmless", 7.99m },
                    { new Guid("1a9de348-4c39-410d-bcc2-8a63eb5b872d"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9338), "some description for test book 1", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9338), "Test book 5", 7.99m },
                    { new Guid("2540f6f4-b853-46bf-8f9d-bf56baa8dfe9"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9334), "some description for test book 1", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9334), "Test book 3", 7.99m },
                    { new Guid("2918c354-f85e-4186-ae2c-4c58cfd22da7"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9331), "some description for test book 1", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9331), "Test book 2", 7.99m },
                    { new Guid("4739cb83-c1cd-49bd-80d8-e029429684b3"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9329), "some description for test book 1", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9330), "Test book 1", 7.99m },
                    { new Guid("74a62c17-16de-4aaa-b096-0629b9851591"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9339), "some description for test book 1", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9340), "Test book 6", 7.99m },
                    { new Guid("87f28e2b-ca41-4fb7-9e2e-0480ac85c2cf"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9328), "And Another Thing... is the sixth and final installment of Douglas Adams' The Hitchhiker's Guide to the Galaxy \"trilogy\". The book, written by Eoin Colfer, author of the Artemis Fowl series, was published on the thirtieth anniversary of the first book, 12 October 2009, in hardback.", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9328), "And Another Thing...", 7.99m },
                    { new Guid("c1d54714-1b8a-45ec-b71f-8f164328c4c0"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9312), "The Hitchhiker's Guide to the Galaxy is a comic science fiction series created by Douglas Adams that has become popular among fans of the genre and members of the scientific community.", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9313), "The Hitchhiker's Guide to the Galaxy", 7.99m },
                    { new Guid("cbfbc90a-6dd2-4320-b6ca-b7d57484ea4c"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9323), "So Long, and Thanks for All the Fish is the fourth book of the Hitchhiker's Guide to the Galaxy \"trilogy\" written by Douglas Adams. Its title is the message left by the dolphins when they departed Planet Earth just before it was demolished to make way for a hyperspace bypass, as described in The Hitchhiker's Guide to the Galaxy.", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9323), "So Long, and Thanks for All the Fish", 7.99m },
                    { new Guid("d2ffe2b9-2093-4c25-bb6a-dd966db47fdf"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9319), "The Restaurant at the End of the Universe (1980, ISBN 0-345-39181-0) is the second book in the Hitchhiker's Guide to the Galaxy comedy science fiction trilogy by Douglas Adams, and is a sequel.", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9320), "The Restaurant at the End of the Universe", 7.99m },
                    { new Guid("e04fd0e5-7382-4a21-a32c-e206c1e833b1"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9336), "some description for test book 1", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9336), "Test book 4", 7.99m },
                    { new Guid("e5d5952b-85dd-49bf-93be-21936d11929b"), new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9321), "Life, the Universe and Everything (1982, ISBN 0-345-39182-9) is the third book in the five-volume Hitchhiker's Guide to the Galaxy science fiction trilogy by British writer Douglas Adams.", new DateTime(2023, 10, 3, 12, 12, 33, 838, DateTimeKind.Utc).AddTicks(9322), "Life, the Universe and Everything", 7.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
