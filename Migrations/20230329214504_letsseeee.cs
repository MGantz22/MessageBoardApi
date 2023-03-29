using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MessageBoardApi.Migrations
{
    public partial class letsseeee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af1ef50a-9212-415c-b7eb-dd5514d049df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fd9c81fa-8e89-494d-b3c7-4e0fa7a01e7d");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "MessageName",
                table: "Posts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GivenName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "6fd22eba-587f-468e-a5a1-8365059b0524", 0, "9cac4ef3-a161-4ba0-aa03-d17351677ad3", "jason.admin@email.com", false, "Jason", false, null, null, null, "MyPass_w0rd", null, null, false, "Administrator", "6ba545df-37d8-4b91-ab86-a8f2d45a2e79", "Bryant", false, 2, "jason_admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "GivenName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "f3b7305b-db81-4cd8-80d6-48da643dbf28", 0, "b93ef036-50b9-4b60-bbc4-35352215529f", "elyse.seller@email.com", false, "Elyse", false, null, null, null, "MyPass_w0rd", null, null, false, "Seller", "f90d1d4b-d330-4ad8-b6d8-b5388fc1b306", "Lambert", false, 3, "elyse_seller" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fd22eba-587f-468e-a5a1-8365059b0524");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3b7305b-db81-4cd8-80d6-48da643dbf28");

            migrationBuilder.DropColumn(
                name: "MessageName",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailAddress", "EmailConfirmed", "GivenName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "af1ef50a-9212-415c-b7eb-dd5514d049df", 0, "a945eed5-b274-4dfe-a20c-a69974981a8c", null, "jason.admin@email.com", false, "Jason", false, null, null, null, "MyPass_w0rd", null, null, false, "Administrator", "0ce93afd-fc0b-499f-b619-1219dd3070c1", "Bryant", false, 2, "jason_admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailAddress", "EmailConfirmed", "GivenName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserId", "UserName" },
                values: new object[] { "fd9c81fa-8e89-494d-b3c7-4e0fa7a01e7d", 0, "69c14e8c-66d2-4218-8e69-9fe7021d67e2", null, "elyse.seller@email.com", false, "Elyse", false, null, null, null, "MyPass_w0rd", null, null, false, "Seller", "cb82aa17-bb8b-454e-98ad-a81eb15e6849", "Lambert", false, 3, "elyse_seller" });
        }
    }
}
