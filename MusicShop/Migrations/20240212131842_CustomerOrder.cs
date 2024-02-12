using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicShop.Migrations
{
    /// <inheritdoc />
    public partial class CustomerOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order_Customer",
                columns: table => new
                {
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_Customer_pk", x => new { x.Order_id, x.Customer_id });
                    table.ForeignKey(
                        name: "Customer_Order_Customer",
                        column: x => x.Customer_id,
                        principalTable: "Customer",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "Customer_Order_Order",
                        column: x => x.Order_id,
                        principalTable: "Order",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_Customer_id",
                table: "Order_Customer",
                column: "Customer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_Customer");
        }
    }
}
