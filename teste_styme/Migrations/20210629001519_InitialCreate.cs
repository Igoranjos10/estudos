using Microsoft.EntityFrameworkCore.Migrations;

namespace teste_styme.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Restaurantes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Restaurantes",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "imageUri",
                table: "Restaurantes",
                newName: "ImageUri");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Restaurantes",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Restaurantes",
                newName: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_restaurantId",
                table: "Menus",
                column: "restaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_Restaurantes_restaurantId",
                table: "Menus",
                column: "restaurantId",
                principalTable: "Restaurantes",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_Restaurantes_restaurantId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_restaurantId",
                table: "Menus");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Restaurantes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Restaurantes",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "ImageUri",
                table: "Restaurantes",
                newName: "imageUri");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Restaurantes",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Restaurantes",
                newName: "address");
        }
    }
}
