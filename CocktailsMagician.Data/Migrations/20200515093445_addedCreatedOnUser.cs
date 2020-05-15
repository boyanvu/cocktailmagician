using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsMagician.Data.Migrations
{
    public partial class addedCreatedOnUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc17bced-7e46-4564-80e1-128b3ad0bfe6", "AQAAAAEAACcQAAAAELlhAvfTwRDNKiDS+V/w6TxEFb6/LOVZ5kM9byR29yRYccm9XC8ITMljVHwcMQl8QA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad513447-0536-432b-a848-ea96ade0040d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee019a54-1fcc-4971-81bd-9a575867d5ab", "AQAAAAEAACcQAAAAEN/vnIqGE46yaCrKRh2n9eDslO1i9GTPUbghzUeyJBNerSwEN2sYdm9eMgvGqcGmRw==" });

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 509, DateTimeKind.Utc).AddTicks(5533));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 509, DateTimeKind.Utc).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 509, DateTimeKind.Utc).AddTicks(6693));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("d277aee1-8292-4d39-a347-77b9da349c54"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 509, DateTimeKind.Utc).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 510, DateTimeKind.Utc).AddTicks(8906));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 510, DateTimeKind.Utc).AddTicks(8938));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 510, DateTimeKind.Utc).AddTicks(7986));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 15, 9, 34, 44, 510, DateTimeKind.Utc).AddTicks(8931));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

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
    }
}
