using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsMagician.Data.Migrations
{
    public partial class addedUnlistedOnForCityAndIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UnlistedOn",
                table: "IngredientTypes",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnlistedOn",
                table: "Cities",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8aaedced-44e0-4510-9c61-d8457f286592", "AQAAAAEAACcQAAAAEONXQaY70EKLXl/2Orw5EjLPpe0woeZJ4vqTxH97jHClC23oERnVfT0Rzb5zTN5X4w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad513447-0536-432b-a848-ea96ade0040d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ca6affe2-b3b7-4075-88d6-03c9dff152e1", "AQAAAAEAACcQAAAAEAvwgDHhi8p44AtkFo/iATY/A5q2Zr0VmpNufEM/9AwSUVzrhNduQZ22hsTBXXiI8w==" });

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 517, DateTimeKind.Utc).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 518, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 518, DateTimeKind.Utc).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("d277aee1-8292-4d39-a347-77b9da349c54"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 518, DateTimeKind.Utc).AddTicks(56));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 519, DateTimeKind.Utc).AddTicks(309));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 519, DateTimeKind.Utc).AddTicks(341));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 518, DateTimeKind.Utc).AddTicks(9266));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 14, 9, 44, 25, 519, DateTimeKind.Utc).AddTicks(332));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnlistedOn",
                table: "IngredientTypes");

            migrationBuilder.DropColumn(
                name: "UnlistedOn",
                table: "Cities");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c592b2cd-c2f8-49a8-8394-bc26e711bee3", "AQAAAAEAACcQAAAAEH0GWb9YLu8ayVcyi/BMDL2ESrZoY8drS4k35h/oBCO771ps3w2joNkDrcypJb5f/Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad513447-0536-432b-a848-ea96ade0040d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "527e39e6-4eb5-474c-bc25-52509a2a9238", "AQAAAAEAACcQAAAAEPC72jXlz1MI0WjiuPQPQKMDibChiZdKyud9Tim1XYMeysuxkO9XhMy7TZGIFbr5Ig==" });

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(1756));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("d277aee1-8292-4d39-a347-77b9da349c54"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(1178));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(1221));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(283));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(1209));
        }
    }
}
