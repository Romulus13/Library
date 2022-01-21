using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Authors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    PrintDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookInventoryItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookInventoryItem_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BookInventoryItemsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "BookRents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    Borrowed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart"),
                    PeriodStart = table.Column<DateTime>(type: "datetime2", nullable: false)
                        .Annotation("SqlServer:IsTemporal", true)
                        .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                        .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookRent_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRent_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BookRentsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.CreateTable(
                name: "UserContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<byte>(type: "TINYINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserContact_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Authors", "ISBN", "PrintDate", "ReleaseDate", "SerialNumber", "Title" },
                values: new object[,]
                {
                    { 1L, "J.R.R. Tolkien", "0618002227", new DateTime(2008, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "d206d8ba-3852-4efb-b02c-368850cd98d1", "The Fellowship of the Ring" },
                    { 2L, "J.R.R. Tolkien", "0618002113", new DateTime(2001, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1954, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "5e3b8f90-04cd-4926-809d-8f5c46ae9c91", "The Fellowship of the Ring" },
                    { 3L, "Edgar Rice Burroughs", "09568879111", new DateTime(2011, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1917, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "7ce831cd-3076-4369-8397-5a63ed793486", "A Princess of Mars" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Created", "FirstName", "LastName", "Modified" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan", "Horvat", null },
                    { 2, new DateTime(2001, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko", "Ban", null },
                    { 3, new DateTime(1993, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iva", "Kralj", null }
                });

            migrationBuilder.InsertData(
                table: "BookRents",
                columns: new[] { "Id", "BookId", "Borrowed", "Created", "DueDate", "Modified", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 2L, 3L, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3 },
                    { 3L, 3L, new DateTime(2021, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserContacts",
                columns: new[] { "Id", "Type", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, (byte)1, 1, "+9877412111" },
                    { 2, (byte)3, 3, "iva.kralj@aol.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookInventoryItems_BookId",
                table: "BookInventoryItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRents_BookId",
                table: "BookRents",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRents_UserId",
                table: "BookRents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SerialNumber",
                table: "Books",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserContacts_UserId",
                table: "UserContacts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookInventoryItems")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BookInventoryItemsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "BookRents")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "BookRentsHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", null)
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropTable(
                name: "UserContacts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
