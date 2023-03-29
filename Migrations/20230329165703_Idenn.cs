using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class Idenn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailAddress", "EmailConfirmed", "GivenName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "af1ef50a-9212-415c-b7eb-dd5514d049df", 0, "a945eed5-b274-4dfe-a20c-a69974981a8c", null, "jason.admin@email.com", false, "Jason", false, null, null, null, "MyPass_w0rd", null, null, false, "Administrator", "0ce93afd-fc0b-499f-b619-1219dd3070c1", "Bryant", false, 2, "jason_admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailAddress", "EmailConfirmed", "GivenName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "fd9c81fa-8e89-494d-b3c7-4e0fa7a01e7d", 0, "69c14e8c-66d2-4218-8e69-9fe7021d67e2", null, "elyse.seller@email.com", false, "Elyse", false, null, null, null, "MyPass_w0rd", null, null, false, "Seller", "cb82aa17-bb8b-454e-98ad-a81eb15e6849", "Lambert", false, 3, "elyse_seller" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { 1, "Gossip" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af1ef50a-9212-415c-b7eb-dd5514d049df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9c81fa-8e89-494d-b3c7-4e0fa7a01e7d");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1);
        }
    }
}
