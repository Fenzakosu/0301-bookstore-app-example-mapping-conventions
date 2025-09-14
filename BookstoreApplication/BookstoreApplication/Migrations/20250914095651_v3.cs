using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookstoreApplication.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Biography", "Birthday", "FullName" },
                values: new object[,]
                {
                    { 1, "Srpski pisac postmodernizma, autor Hazarskog rečnika", new DateTime(1929, 10, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Milorad Pavić" },
                    { 2, "Nobelovac za književnost, autor Na Drini ćuprija", new DateTime(1892, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Ivo Andrić" },
                    { 3, "Jedan od najvažnijih srpskih pisaca XX veka", new DateTime(1935, 2, 22, 0, 0, 0, 0, DateTimeKind.Utc), "Danilo Kiš" },
                    { 4, "Bosanski pisac, autor romana Derviš i smrt", new DateTime(1910, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), "Meša Selimović" },
                    { 5, "Srpski pisac, dramaturg i scenarista", new DateTime(1930, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Borislav Pekić" }
                });

            migrationBuilder.InsertData(
                table: "Awards",
                columns: new[] { "Id", "Description", "Name", "StartYear" },
                values: new object[,]
                {
                    { 1, "Najpoznatija književna nagrada u Srbiji", "NIN-ova nagrada", 1954 },
                    { 2, "Nagrada za najbolje ostvarenje u oblasti pripovedne proze", "Andrićeva nagrada", 1975 },
                    { 3, "Nagrada za životno delo u oblasti književnosti", "Vukova nagrada", 1994 },
                    { 4, "Nagrada za roman godine", "Borislav Pekić", 2000 }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Address", "Name", "Website" },
                values: new object[,]
                {
                    { 1, "Terazije 16, Beograd", "Prosveta", "https://www.prosveta.rs" },
                    { 2, "Žorža Klemansoa 22, Beograd", "Dereta", "https://www.dereta.rs" },
                    { 3, "Knez Mihailova 18, Beograd", "Stubovi kulture", "https://www.stubovi-kulture.rs" }
                });

            migrationBuilder.InsertData(
                table: "AuthorAwardBridge",
                columns: new[] { "AuthorId", "AwardId", "YearAwarded" },
                values: new object[,]
                {
                    { 1, 1, 1984 },
                    { 1, 2, 1985 },
                    { 1, 3, 2009 },
                    { 1, 4, 2002 },
                    { 2, 1, 1961 },
                    { 2, 3, 1982 },
                    { 3, 1, 1976 },
                    { 3, 2, 1977 },
                    { 3, 3, 1983 },
                    { 4, 1, 1966 },
                    { 4, 2, 1967 },
                    { 4, 3, 1987 },
                    { 5, 1, 1970 },
                    { 5, 2, 1971 },
                    { 5, 4, 2001 }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "ISBN", "PageCount", "PublishedDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "978-86-11-12345-1", 320, new DateTime(1984, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Hazarski rečnik" },
                    { 2, 1, "978-86-11-12345-2", 280, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Unutrašnja strana vetra" },
                    { 3, 1, "978-86-11-12345-3", 200, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Predeo slikan čajem" },
                    { 4, 2, "978-86-11-12345-4", 420, new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Na Drini ćuprija" },
                    { 5, 2, "978-86-11-12345-5", 380, new DateTime(1942, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Travnička hronika" },
                    { 6, 2, "978-86-11-12345-6", 250, new DateTime(1954, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Prokleta avlija" },
                    { 7, 3, "978-86-11-12345-7", 180, new DateTime(1965, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Bašta, pepeo" },
                    { 8, 3, "978-86-11-12345-8", 150, new DateTime(1976, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Grobnica za Borisa Davidoviča" },
                    { 9, 4, "978-86-11-12345-9", 350, new DateTime(1966, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Derviš i smrt" },
                    { 10, 4, "978-86-11-12345-10", 400, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 3, "Tvrđava" },
                    { 11, 5, "978-86-11-12345-11", 600, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, "Hodočašće Arsenija Njegovana" },
                    { 12, 5, "978-86-11-12345-12", 450, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, "Atlantida" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "AuthorAwardBridge",
                keyColumns: new[] { "AuthorId", "AwardId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Awards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
