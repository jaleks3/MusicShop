using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicShop.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    state = table.Column<string>(type: "text", nullable: false),
                    postcode = table.Column<int>(type: "int", nullable: false),
                    street_name = table.Column<string>(type: "text", nullable: false),
                    street_number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Address_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Artist_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<int>(type: "int", nullable: false),
                    MaxDiscount = table.Column<int>(type: "int", nullable: false),
                    MinPrice = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Discount_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Distributor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Distributor_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Genre_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Status_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Type_Of_Record",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Type_Of_Record_pk", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Address_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Storage_pk", x => x.id);
                    table.ForeignKey(
                        name: "Storage_Address",
                        column: x => x.Address_id,
                        principalTable: "Address",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    surname = table.Column<string>(type: "text", nullable: false),
                    Discount_id = table.Column<int>(type: "int", nullable: true),
                    Address_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Customer_pk", x => x.id);
                    table.ForeignKey(
                        name: "Customer_Address",
                        column: x => x.Address_id,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Customer_Discount",
                        column: x => x.Discount_id,
                        principalTable: "Discount",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    Address_id = table.Column<int>(type: "int", nullable: false),
                    Status_id = table.Column<int>(type: "int", nullable: false),
                    RequestAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    FulfillAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pk", x => x.id);
                    table.ForeignKey(
                        name: "Order_Address",
                        column: x => x.Address_id,
                        principalTable: "Address",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Order_Status",
                        column: x => x.Status_id,
                        principalTable: "Status",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    released = table.Column<DateTime>(type: "date", nullable: false),
                    Distributor_id = table.Column<int>(type: "int", nullable: false),
                    TypeOfRecord_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Record_pk", x => x.id);
                    table.ForeignKey(
                        name: "Record_Distributor",
                        column: x => x.Distributor_id,
                        principalTable: "Distributor",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Record_TypeOfRecord",
                        column: x => x.TypeOfRecord_id,
                        principalTable: "Type_Of_Record",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Artist_Record",
                columns: table => new
                {
                    Artist_id = table.Column<int>(type: "int", nullable: false),
                    Record_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Artist_Record_pk", x => new { x.Artist_id, x.Record_id });
                    table.ForeignKey(
                        name: "Artist_Record_Artist",
                        column: x => x.Artist_id,
                        principalTable: "Artist",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Artist_Record_Record",
                        column: x => x.Record_id,
                        principalTable: "Record",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Order_Record",
                columns: table => new
                {
                    Record_id = table.Column<int>(type: "int", nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_Record_pk", x => new { x.Record_id, x.Order_id });
                    table.ForeignKey(
                        name: "Order_Record_Order",
                        column: x => x.Order_id,
                        principalTable: "Order",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Order_Record_Record",
                        column: x => x.Record_id,
                        principalTable: "Record",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Record_Genre",
                columns: table => new
                {
                    Record_id = table.Column<int>(type: "int", nullable: false),
                    Genre_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Record_Genre_pk", x => new { x.Record_id, x.Genre_id });
                    table.ForeignKey(
                        name: "Record_Genre_Genre",
                        column: x => x.Genre_id,
                        principalTable: "Genre",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Record_Genre_Record",
                        column: x => x.Record_id,
                        principalTable: "Record",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Record_Storage",
                columns: table => new
                {
                    Record_id = table.Column<int>(type: "int", nullable: false),
                    Storage_id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Record_Storage_pk", x => new { x.Record_id, x.Storage_id });
                    table.ForeignKey(
                        name: "RecordStorage_Record",
                        column: x => x.Record_id,
                        principalTable: "Record",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "RecordStorage_Storage",
                        column: x => x.Storage_id,
                        principalTable: "Storage",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_Record_Record_id",
                table: "Artist_Record",
                column: "Record_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Address_id",
                table: "Customer",
                column: "Address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Discount_id",
                table: "Customer",
                column: "Discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Address_id",
                table: "Order",
                column: "Address_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Status_id",
                table: "Order",
                column: "Status_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Record_Order_id",
                table: "Order_Record",
                column: "Order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Record_Distributor_id",
                table: "Record",
                column: "Distributor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Record_TypeOfRecord_id",
                table: "Record",
                column: "TypeOfRecord_id");

            migrationBuilder.CreateIndex(
                name: "IX_Record_Genre_Genre_id",
                table: "Record_Genre",
                column: "Genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_Record_Storage_Storage_id",
                table: "Record_Storage",
                column: "Storage_id");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Address_id",
                table: "Storage",
                column: "Address_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist_Record");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order_Record");

            migrationBuilder.DropTable(
                name: "Record_Genre");

            migrationBuilder.DropTable(
                name: "Record_Storage");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Distributor");

            migrationBuilder.DropTable(
                name: "Type_Of_Record");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
