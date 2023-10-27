using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tachyon.Migrations
{
    public partial class addd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7614dd60-b6e1-403e-ba41-fbe0444197c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c6e44ac-1f89-4373-9f89-c35966a63795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cee851f6-be8e-4d1f-a578-b9a5242bfdd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e14e7ac2-b50d-4425-921a-d23c6670242f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1450c7aa-9eb5-41ab-add7-83af971f3df3", "99946b7d-8019-41e9-86b2-a3f428431e3f", "Doctor", "Doctor" },
                    { "3c130dbc-011f-4f4a-b062-caa594682e94", "208f38d5-7dc2-4889-821f-582b269f3f65", "Admin", "ADMIN" },
                    { "774c4bc8-4ff1-4731-b8a8-18e3cf3fb949", "2b7a7314-aaa9-4191-af81-6f8a5f61b37a", "Nurse", "NURSE" },
                    { "b1b3a2b5-ced9-438b-8b41-577c3f69a365", "4bd71901-0f1d-47e0-9d5f-bc6d1503519b", "Patient", "PATIENT" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1450c7aa-9eb5-41ab-add7-83af971f3df3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c130dbc-011f-4f4a-b062-caa594682e94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "774c4bc8-4ff1-4731-b8a8-18e3cf3fb949");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1b3a2b5-ced9-438b-8b41-577c3f69a365");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7614dd60-b6e1-403e-ba41-fbe0444197c4", "885acd3f-aa93-4654-9762-466837219937", "Doctor", "Doctor" },
                    { "9c6e44ac-1f89-4373-9f89-c35966a63795", "9fd7f828-f89f-4a0e-97fd-25db713908e6", "Patient", "PATIENT" },
                    { "cee851f6-be8e-4d1f-a578-b9a5242bfdd5", "3069d45a-3a78-42c3-8638-989da290cabc", "Nurse", "NURSE" },
                    { "e14e7ac2-b50d-4425-921a-d23c6670242f", "741aac57-1e38-42ec-83f8-51ce8888a8af", "Admin", "ADMIN" }
                });
        }
    }
}
