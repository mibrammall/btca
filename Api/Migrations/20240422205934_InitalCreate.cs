using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    company_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nchar(128)", fixedLength: true, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Company__3E267235EB8F4963", x => x.company_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__47027DF547745186", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    company_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__465962290815EC49", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_order_to_company",
                        column: x => x.company_id,
                        principalTable: "Company",
                        principalColumn: "company_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderproduct", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_orderproduct_order",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id");
                    table.ForeignKey(
                        name: "FK_orderproduct_product",
                        column: x => x.product_id,
                        principalTable: "Product",
                        principalColumn: "product_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_company_id",
                table: "Order",
                column: "company_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_product_id",
                table: "OrderProduct",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
