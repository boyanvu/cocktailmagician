using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsMagician.Data.Migrations
{
    public partial class addedLocationBar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Bars",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Bars",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01a0e376-6f2d-4cf7-90db-209dd0518d98", "AQAAAAEAACcQAAAAEAe/v1th/8hJd/5lk1UrN0FBSnr98nMUxxJ4Pek03tMUiT+3wuc+z09l+gogmOZomA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad513447-0536-432b-a848-ea96ade0040d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80efce02-aae6-43ef-8d38-a4b158de69b1", "AQAAAAEAACcQAAAAEO/37Jimfz74TlcjdFC+QjMIFVFXOSll7bPzKLf2N2wdOW+aVI/SSd4m+RjR9hLhYw==" });

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 579, DateTimeKind.Utc).AddTicks(4532));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 579, DateTimeKind.Utc).AddTicks(5262));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 579, DateTimeKind.Utc).AddTicks(5253));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("d277aee1-8292-4d39-a347-77b9da349c54"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 579, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                column: "Website",
                value: "https://www.facebook.com/barkonushnite/");

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 580, DateTimeKind.Utc).AddTicks(859));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 580, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 580, DateTimeKind.Utc).AddTicks(366));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"),
                column: "ReviewedOn",
                value: new DateTime(2020, 6, 3, 20, 17, 37, 580, DateTimeKind.Utc).AddTicks(884));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Bars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27662d55-ebd8-4029-92b4-b65e389d5efb", "AQAAAAEAACcQAAAAEBNrfHWkG3cdN0mI8WiEYFZWl9RlUIhH+LikLavN4R2+Ot6n+742NiQyTh1HGAo5Hw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad513447-0536-432b-a848-ea96ade0040d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d0d9f8ad-63e6-44df-8d70-311e05bede24", "AQAAAAEAACcQAAAAEBXLwYuhUCzIQ+eeC1bbypG6AtE3Ucu8+rdZ1YcvI2lT0TY30f/Ery35eAb2HuW7rA==" });

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 907, DateTimeKind.Utc).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 907, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 907, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("d277aee1-8292-4d39-a347-77b9da349c54"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 907, DateTimeKind.Utc).AddTicks(8131));

            migrationBuilder.UpdateData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("1f573fa6-3cc0-48ad-8850-ee7675cc3096"),
                column: "Website",
                value: "-");

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 908, DateTimeKind.Utc).AddTicks(8277));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 908, DateTimeKind.Utc).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 908, DateTimeKind.Utc).AddTicks(7411));

            migrationBuilder.UpdateData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"),
                column: "ReviewedOn",
                value: new DateTime(2020, 5, 19, 13, 40, 54, 908, DateTimeKind.Utc).AddTicks(8302));
        }
    }
}
