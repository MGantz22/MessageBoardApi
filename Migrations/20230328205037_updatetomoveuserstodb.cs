using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class updatetomoveuserstodb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "GivenName", "Password", "Role", "Surname", "UserName" },
                values: new object[] { 2, "jason.admin@email.com", "Jason", "MyPass_w0rd", "Administrator", "Bryant", "jason_admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "GivenName", "Password", "Role", "Surname", "UserName" },
                values: new object[] { 3, "elyse.seller@email.com", "Elyse", "MyPass_w0rd", "Seller", "Lambert", "elyse_seller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
