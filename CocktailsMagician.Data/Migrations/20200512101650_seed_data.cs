using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailsMagician.Data.Migrations
{
    public partial class seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bars_Website",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "CocktailIngredients");

            migrationBuilder.DropColumn(
                name: "Uom",
                table: "CocktailIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Bars",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("f4fd169e-b855-496a-8d76-8c7720b60f46"), "d921ef64-4fb3-4f8a-83e7-e9d3b3fb41dd", "User role", "User", "user" },
                    { new Guid("1286919b-3fc1-484d-80ad-9aea8e55ac37"), "c56fc50a-5f68-4e7d-838b-dc064a59ea09", "Admin role", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "DeletedOn", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "isBanned" },
                values: new object[,]
                {
                    { new Guid("ad513447-0536-432b-a848-ea96ade0040d"), 0, "527e39e6-4eb5-474c-bc25-52509a2a9238", null, null, "rsimeonov@abv.bg", false, "Radoslav", "Simeonov", true, null, "RSIMEONOV@ABV.BG", "RSIMEONOV@ABV.BG", "AQAAAAEAACcQAAAAEPC72jXlz1MI0WjiuPQPQKMDibChiZdKyud9Tim1XYMeysuxkO9XhMy7TZGIFbr5Ig==", null, false, "HNWQ7GQFUMWKGOAWSJNC5XV2VFYQRWHC", false, "rsimeonov@abv.bg", false },
                    { new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"), 0, "c592b2cd-c2f8-49a8-8394-bc26e711bee3", null, null, "bvuchev@abv.bg", false, "Boyan", "Vuchev", true, null, "BVUCHEV@ABV.BG", "BVUCHEV@ABV.BG", "AQAAAAEAACcQAAAAEH0GWb9YLu8ayVcyi/BMDL2ESrZoY8drS4k35h/oBCO771ps3w2joNkDrcypJb5f/Q==", null, false, "DC6E275DD1E24957A7781D42BB68293B", false, "bvuchev@abv.bg", false }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("68fee6bf-edd0-4121-8b06-37f0c7e11d4a"), "Sofia" },
                    { new Guid("e3e92ad8-b117-42a8-b263-ec351d9234fc"), "Plovdiv" },
                    { new Guid("cc44371d-594f-4c47-a82b-e606bede8d3b"), "Varna" },
                    { new Guid("50b800ab-bdec-48fa-8951-aaf2e2f19782"), "Veliko Tarnovo" },
                    { new Guid("51d75009-3674-4a35-92f1-48a4981d26bb"), "Burgas" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AvgRating", "Description", "Name", "UnlistedOn" },
                values: new object[,]
                {
                    { new Guid("0961dd49-79f4-4d85-ab15-7844d602e076"), 0.0, "Master this all-time gin classic. The Tom Collins is essentially a sparkling lemonade spiked with a healthy dose of the juniper-centric spirit. While there is a debate raging about which side of the pond this drink hails from, this cocktail lives up to its classic status with every sip.", "Tom Collins", null },
                    { new Guid("9ef97551-87f6-40ce-a88b-6c0e876ccb51"), 0.0, "The Margarita is one of the most popular cocktails in North America—for good reason. Combining the tang of lime and the sweetness of orange liqueur with the distinctive strength of tequila, our classic Margarita strikes all of the right keys.", "Margarita", null },
                    { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), 0.0, "You could stumble down a very deep, very dark rabbit hole trying to determine who mixed the world’s first Martini. Was it a California prospector during the 1849 Gold Rush or the barman at a flossy New York City hotel 50 years later? Both stories hold water. Neither will leave you feeling as blissful and content as a well-made Dry Martini.", "Dry Martini", null },
                    { new Guid("74d3f564-5811-4eda-97d6-e39d6bbd35a9"), 0.0, "The legendary Cosmopolitan is a simple cocktail with a big history. It reached its height of popularity in the 1990s, when the HBO show “Sex and the City” was at its peak. The pink-hued Martini was a favorite of the characters on the show.", "Cosmopolitan", null },
                    { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), 0.0, "The White Russian is decadent and sophisticated. Combining vodka, Kahlúa and cream and serving it on the rocks create a delicious alternative to adult milkshakes. The Dude's favourite one.", "White Russian", null }
                });

            migrationBuilder.InsertData(
                table: "IngredientTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a13131de-cef0-4e94-9742-b698fa911de3"), "Fruit" },
                    { new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f"), "Herbs" },
                    { new Guid("b54d35b5-1a1e-4da8-af73-46814ecdf240"), "Cream" },
                    { new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6"), "Others" },
                    { new Guid("d45a9b74-04d4-4584-a25f-78a8692bbc31"), "Cola" },
                    { new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693"), "Bitter" },
                    { new Guid("8f799a3d-47cb-40e3-aeb4-a9fe80811360"), "Wine" },
                    { new Guid("62bfb206-9d01-41cc-be6b-161faf95de55"), "Soda" },
                    { new Guid("619ac43c-075a-47be-befc-c68249054b85"), "Rum" },
                    { new Guid("8ff6497e-800b-43ac-8f53-9492e38d60a1"), "Tonic" },
                    { new Guid("27309394-4ac3-4dc6-a81a-c8e147e378f0"), "Burbon" },
                    { new Guid("d949ac47-e51f-4a05-823e-d14c652d94da"), "Cognac" },
                    { new Guid("c237a265-dd68-4218-a6a4-4eb7465e512f"), "Vermouth" },
                    { new Guid("90ec3674-7a5c-4e8f-9a5f-d3aeef5e6c2e"), "Tequila" },
                    { new Guid("67ffa75b-d067-4d77-a98d-99e203f4ad45"), "Brendy" },
                    { new Guid("4a399308-dec0-4161-a679-18b4898c7e4b"), "Liqeur" },
                    { new Guid("2fd6a412-0117-4a62-a608-494e414c9c03"), "Whisky" },
                    { new Guid("3c93e448-aa7f-40f9-b66f-fdf98b66053c"), "Vodka" },
                    { new Guid("265dcf12-bcfc-43d3-93a6-6c48c97d51bc"), "Juice" },
                    { new Guid("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"), "Gin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("ad513447-0536-432b-a848-ea96ade0040d"), new Guid("f4fd169e-b855-496a-8d76-8c7720b60f46") },
                    { new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"), new Guid("1286919b-3fc1-484d-80ad-9aea8e55ac37") }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "AvgRating", "CityId", "Description", "Name", "Phone", "UnlistedOn", "Website" },
                values: new object[,]
                {
                    { new Guid("e3be83dd-0c12-41d0-9f05-56554ad74a2d"), "31 Morska Str.", 0.0, new Guid("51d75009-3674-4a35-92f1-48a4981d26bb"), "We chose the heart of Burgas, just a few steps away from the sea coast, to create the oasis of the pleasure for you. With the commercial music background we offer perfect conditions for the morning cup of coffee or the cocktail at sunset. ", "Foket Bar", "0888050505", null, "http://www.facebook.com/%D0%9A%D0%B0%D1%84%D0%B5-%D0%A4%D0%BE%D0%BA%D0%B5%D1%82-348364438530436/" },
                    { new Guid("5fedc033-16db-4d62-b5e6-20eb3a056ead"), "at the corner of Angel Kanchev and Solunska", 0.0, new Guid("68fee6bf-edd0-4121-8b06-37f0c7e11d4a"), "Is incomparable pleasure to have a cup of coffee under the shade of linden trees and greenery of the park in close proximity to the coolness of the fountain. ", "Pavement", "0877151152", null, "https://www.facebook.com/pages/%D0%91%D0%B0%D1%80-%D0%9F%D0%B0%D0%B2%D0%B0%D0%B6/662197613861829" },
                    { new Guid("1f573fa6-3cc0-48ad-8850-ee7675cc3096"), "40 Saborna Str.", 0.0, new Guid("e3e92ad8-b117-42a8-b263-ec351d9234fc"), "Live music", "Konyushnite", "0899516116", null, "-" },
                    { new Guid("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"), "62 Prof. Marin Drinov Str.", 0.0, new Guid("cc44371d-594f-4c47-a82b-e606bede8d3b"), "Very nice bar", "Pappa's Bar", "0898878465", null, "-" }
                });

            migrationBuilder.InsertData(
                table: "CocktailReviews",
                columns: new[] { "Id", "CocktailId", "Comment", "DeletedOn", "Rating", "ReviewedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"), new Guid("9ef97551-87f6-40ce-a88b-6c0e876ccb51"), "Too sour", null, 1, new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(283), new Guid("ad513447-0536-432b-a848-ea96ade0040d") },
                    { new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"), new Guid("0961dd49-79f4-4d85-ab15-7844d602e076"), "Not bad.", null, 3, new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(1221), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") },
                    { new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"), new Guid("9ef97551-87f6-40ce-a88b-6c0e876ccb51"), "Perfect for summer", null, 5, new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(1209), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") },
                    { new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"), new Guid("0961dd49-79f4-4d85-ab15-7844d602e076"), "Piece of shit", null, 1, new DateTime(2020, 5, 12, 10, 16, 48, 820, DateTimeKind.Utc).AddTicks(1178), new Guid("ad513447-0536-432b-a848-ea96ade0040d") }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Abv", "Description", "Name", "TypeId", "UnlistedOn" },
                values: new object[,]
                {
                    { new Guid("c5651f9b-a02c-4a87-9be0-cddf9ce07b98"), 40.0, "Vodka is a clear distilled alcoholic beverage with different varieties originating in Poland and Russia. It is composed primarily of water and ethanol, but sometimes with traces of impurities and flavorings. Traditionally it is made by distilling the liquid from potatoes or cereal grains that have been fermented, though some modern brands use fruits or sugar as the base.", "Vodka", new Guid("3c93e448-aa7f-40f9-b66f-fdf98b66053c"), null },
                    { new Guid("d8b1f1e3-b6a7-4e6d-8abe-2aa1db4abbe4"), 34.0, "Orange bitters is a form of bitters, a cocktail flavoring made from such ingredients as the peels of Seville oranges, cardamom, caraway seed, coriander, anise, and burnt sugar in an alcohol base.", "Orange bitter", new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693"), null },
                    { new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693"), 0.0, "-", "Heavy cream", new Guid("b54d35b5-1a1e-4da8-af73-46814ecdf240"), null },
                    { new Guid("db3d1530-7f55-40c9-82dd-10428c8e8dcc"), 0.0, "", "Lemon", new Guid("a13131de-cef0-4e94-9742-b698fa911de3"), null },
                    { new Guid("7d4c332d-c016-4594-9a46-4e1b0cd22955"), 0.0, "", "Orange juice", new Guid("265dcf12-bcfc-43d3-93a6-6c48c97d51bc"), null },
                    { new Guid("9d4efae0-c48a-4b65-908a-6597658be6f8"), 0.0, "", "Martini Dry", new Guid("c237a265-dd68-4218-a6a4-4eb7465e512f"), null },
                    { new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6"), 0.0, "", "Martini Extra Dry", new Guid("c237a265-dd68-4218-a6a4-4eb7465e512f"), null },
                    { new Guid("e89fd1c6-532e-42e0-8024-a2ff9c600006"), 40.0, "Tequila is a distilled beverage made from the blue agave plant, primarily in the area surrounding the city of Tequila 65 km (40 mi) northwest of Guadalajara", "Tequila", new Guid("90ec3674-7a5c-4e8f-9a5f-d3aeef5e6c2e"), null },
                    { new Guid("829f36d4-1ac9-438c-a653-964890eeff58"), 20.0, "Kahlua is a coffee-flavored liqueur from Mexico. The drink contains rum, sugar, vanilla bean, and arabica coffee.", "Kahlua", new Guid("4a399308-dec0-4161-a679-18b4898c7e4b"), null },
                    { new Guid("8f799a3d-47cb-40e3-aeb4-a9fe80811360"), 40.0, "Whisky or whiskey is a type of distilled alcoholic beverage made from fermented grain mash. Various grains (which may be malted) are used for different varieties, including barley, corn, rye, and wheat. Whisky is typically aged in wooden casks, generally made of charred white oak.", "Whisky", new Guid("2fd6a412-0117-4a62-a608-494e414c9c03"), null },
                    { new Guid("b91ed0c3-b009-4c83-993e-9acc4b0e384f"), 0.0, "-", "Peppermint", new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f"), null },
                    { new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f"), 40.0, "Gin is a distilled alcoholic drink that derives its predominant flavour from juniper berries (Juniperus communis). Gin is one of the broadest categories of spirits, all of various origins, styles, and flavour profiles, that revolve around juniper as a common ingredient.", "Gin", new Guid("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"), null }
                });

            migrationBuilder.InsertData(
                table: "BarReviews",
                columns: new[] { "Id", "BarId", "Comment", "DeletedOn", "Rating", "ReviewedOn", "UserId" },
                values: new object[,]
                {
                    { new Guid("d277aee1-8292-4d39-a347-77b9da349c54"), new Guid("1f573fa6-3cc0-48ad-8850-ee7675cc3096"), "Not bad", null, 3, new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(1716), new Guid("ad513447-0536-432b-a848-ea96ade0040d") },
                    { new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"), new Guid("1f573fa6-3cc0-48ad-8850-ee7675cc3096"), "Very nice place to drink and listen live music.", null, 5, new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(1772), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") },
                    { new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"), new Guid("e3be83dd-0c12-41d0-9f05-56554ad74a2d"), "Very nice and cosy place", null, 5, new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(731), new Guid("ad513447-0536-432b-a848-ea96ade0040d") },
                    { new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"), new Guid("e3be83dd-0c12-41d0-9f05-56554ad74a2d"), "It is fuckin hole", null, 2, new DateTime(2020, 5, 12, 10, 16, 48, 819, DateTimeKind.Utc).AddTicks(1756), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") }
                });

            migrationBuilder.InsertData(
                table: "CocktailIngredients",
                columns: new[] { "CocktailId", "IngredientId" },
                values: new object[,]
                {
                    { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), new Guid("c5651f9b-a02c-4a87-9be0-cddf9ce07b98") },
                    { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), new Guid("829f36d4-1ac9-438c-a653-964890eeff58") },
                    { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("9d4efae0-c48a-4b65-908a-6597658be6f8") },
                    { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f") },
                    { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("db3d1530-7f55-40c9-82dd-10428c8e8dcc") },
                    { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693") },
                    { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("d8b1f1e3-b6a7-4e6d-8abe-2aa1db4abbe4") }
                });

            migrationBuilder.InsertData(
                table: "CocktailReviewLikes",
                columns: new[] { "CocktailReviewId", "UserId", "IsInappropriate", "IsLiked" },
                values: new object[,]
                {
                    { new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"), false, true },
                    { new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"), true, false }
                });

            migrationBuilder.InsertData(
                table: "BarReviewLikes",
                columns: new[] { "BarReviewId", "UserId", "IsInappropriate", "IsLiked" },
                values: new object[] { new Guid("d277aee1-8292-4d39-a347-77b9da349c54"), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"), false, true });

            migrationBuilder.InsertData(
                table: "BarReviewLikes",
                columns: new[] { "BarReviewId", "UserId", "IsInappropriate", "IsLiked" },
                values: new object[] { new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"), new Guid("ad513447-0536-432b-a848-ea96ade0040d"), true, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"), new Guid("1286919b-3fc1-484d-80ad-9aea8e55ac37") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("ad513447-0536-432b-a848-ea96ade0040d"), new Guid("f4fd169e-b855-496a-8d76-8c7720b60f46") });

            migrationBuilder.DeleteData(
                table: "BarReviewLikes",
                keyColumns: new[] { "BarReviewId", "UserId" },
                keyValues: new object[] { new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"), new Guid("ad513447-0536-432b-a848-ea96ade0040d") });

            migrationBuilder.DeleteData(
                table: "BarReviewLikes",
                keyColumns: new[] { "BarReviewId", "UserId" },
                keyValues: new object[] { new Guid("d277aee1-8292-4d39-a347-77b9da349c54"), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") });

            migrationBuilder.DeleteData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("162a3202-b5d8-495a-a9d8-76b1974d3525"));

            migrationBuilder.DeleteData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("2790a53d-b5ea-4ba6-a651-eb3e79f8db7f"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("5fedc033-16db-4d62-b5e6-20eb3a056ead"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("92a05c62-6f33-4dc9-bcc1-c9c946bf693a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("50b800ab-bdec-48fa-8951-aaf2e2f19782"));

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), new Guid("829f36d4-1ac9-438c-a653-964890eeff58") });

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), new Guid("c5651f9b-a02c-4a87-9be0-cddf9ce07b98") });

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"), new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693") });

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f") });

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("9d4efae0-c48a-4b65-908a-6597658be6f8") });

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("d8b1f1e3-b6a7-4e6d-8abe-2aa1db4abbe4") });

            migrationBuilder.DeleteData(
                table: "CocktailIngredients",
                keyColumns: new[] { "CocktailId", "IngredientId" },
                keyValues: new object[] { new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"), new Guid("db3d1530-7f55-40c9-82dd-10428c8e8dcc") });

            migrationBuilder.DeleteData(
                table: "CocktailReviewLikes",
                keyColumns: new[] { "CocktailReviewId", "UserId" },
                keyValues: new object[] { new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") });

            migrationBuilder.DeleteData(
                table: "CocktailReviewLikes",
                keyColumns: new[] { "CocktailReviewId", "UserId" },
                keyValues: new object[] { new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"), new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac") });

            migrationBuilder.DeleteData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("16e1a85a-1d0f-4c42-b7dc-64efc096eb51"));

            migrationBuilder.DeleteData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("d7047a3a-7b5e-4eb5-8ed2-c846b7a4d5ce"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("74d3f564-5811-4eda-97d6-e39d6bbd35a9"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("27309394-4ac3-4dc6-a81a-c8e147e378f0"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("619ac43c-075a-47be-befc-c68249054b85"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("62bfb206-9d01-41cc-be6b-161faf95de55"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("67ffa75b-d067-4d77-a98d-99e203f4ad45"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("8f799a3d-47cb-40e3-aeb4-a9fe80811360"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("8ff6497e-800b-43ac-8f53-9492e38d60a1"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("d45a9b74-04d4-4584-a25f-78a8692bbc31"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("d949ac47-e51f-4a05-823e-d14c652d94da"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("4039e0f3-8d2d-43a5-a82b-477e42371cd6"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7d4c332d-c016-4594-9a46-4e1b0cd22955"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("8f799a3d-47cb-40e3-aeb4-a9fe80811360"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b91ed0c3-b009-4c83-993e-9acc4b0e384f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e89fd1c6-532e-42e0-8024-a2ff9c600006"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1286919b-3fc1-484d-80ad-9aea8e55ac37"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4fd169e-b855-496a-8d76-8c7720b60f46"));

            migrationBuilder.DeleteData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("5549a94f-081a-4491-a386-022bd3fe2c4b"));

            migrationBuilder.DeleteData(
                table: "BarReviews",
                keyColumn: "Id",
                keyValue: new Guid("d277aee1-8292-4d39-a347-77b9da349c54"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("68fee6bf-edd0-4121-8b06-37f0c7e11d4a"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("cc44371d-594f-4c47-a82b-e606bede8d3b"));

            migrationBuilder.DeleteData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("11c58b41-f0db-480d-bbe5-115bc027f868"));

            migrationBuilder.DeleteData(
                table: "CocktailReviews",
                keyColumn: "Id",
                keyValue: new Guid("febc5720-77ef-444b-b3fd-d440af2a9359"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("8a15e590-0b66-4fae-abfa-d75812b76da6"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("96a5f42a-e14d-4cf6-834c-368f4e77076c"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("265dcf12-bcfc-43d3-93a6-6c48c97d51bc"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("2fd6a412-0117-4a62-a608-494e414c9c03"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("90ec3674-7a5c-4e8f-9a5f-d3aeef5e6c2e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("1b98e50e-8314-4b1e-82df-491c3c8d086f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("829f36d4-1ac9-438c-a653-964890eeff58"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9d4efae0-c48a-4b65-908a-6597658be6f8"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c5651f9b-a02c-4a87-9be0-cddf9ce07b98"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d8b1f1e3-b6a7-4e6d-8abe-2aa1db4abbe4"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("db3d1530-7f55-40c9-82dd-10428c8e8dcc"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a137730d-bb81-4611-8fb8-bb777aae86ac"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad513447-0536-432b-a848-ea96ade0040d"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("1f573fa6-3cc0-48ad-8850-ee7675cc3096"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("e3be83dd-0c12-41d0-9f05-56554ad74a2d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("0961dd49-79f4-4d85-ab15-7844d602e076"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("9ef97551-87f6-40ce-a88b-6c0e876ccb51"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("24cd3f18-f0a8-4f66-bc5b-2108e099cf53"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("3c93e448-aa7f-40f9-b66f-fdf98b66053c"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("4a399308-dec0-4161-a679-18b4898c7e4b"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("a13131de-cef0-4e94-9742-b698fa911de3"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("b54d35b5-1a1e-4da8-af73-46814ecdf240"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("c237a265-dd68-4218-a6a4-4eb7465e512f"));

            migrationBuilder.DeleteData(
                table: "IngredientTypes",
                keyColumn: "Id",
                keyValue: new Guid("e393a0e6-c687-40e6-a0f1-e38032dfb693"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("51d75009-3674-4a35-92f1-48a4981d26bb"));

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("e3e92ad8-b117-42a8-b263-ec351d9234fc"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "CocktailIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Uom",
                table: "CocktailIngredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Website",
                table: "Bars",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bars_Website",
                table: "Bars",
                column: "Website",
                unique: true);
        }
    }
}
