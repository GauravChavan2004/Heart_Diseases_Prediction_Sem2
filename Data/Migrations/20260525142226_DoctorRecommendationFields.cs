using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartDiseasePrediction.Data.Migrations
{
    /// <inheritdoc />
    public partial class DoctorRecommendationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PatientName",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuggestedMedicine",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SuggestedTests",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientName",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "SuggestedMedicine",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "SuggestedTests",
                table: "Predictions");

            migrationBuilder.AlterColumn<string>(
                name: "Sex",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
