using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListingWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedDataIntoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "country",
                columns: new[] {"Id", "Name", "shortName"},
                values: new object[] { 1 , "India", "IN" });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "Name", "shortName" },
                values: new object[] { 2, "Russia", "RA" });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "Id", "Name", "shortName" },
                values: new object[] { 3, "America", "AMA" });

            migrationBuilder.InsertData(
                table: "hotel",
                columns: new[] { "hotelId", "Name", "Address" , "Rating", "countryId" },
                values: new object[] { 1, "IndianHotel", "Pimple Saudgar","4.5", 1 });
            migrationBuilder.InsertData(
                table: "hotel",
                 columns: new[] { "hotelId", "Name", "Address", "Rating", "countryId" },
                values: new object[] { 2, "RussiaHotel", "skdjflks lksdjfs", "4.4", 2 });
            migrationBuilder.InsertData(
                table: "hotel",
                columns: new[] { "hotelId", "Name", "Address", "Rating", "countryId" },
                values: new object[] {3 , "AmericalHotel", "sjdfl klsdjf sldkjf", "4.0", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
