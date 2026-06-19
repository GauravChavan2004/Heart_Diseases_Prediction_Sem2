using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartDiseasePrediction.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecommendationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecommendationDate",
                table: "Predictions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecommendedBy",
                table: "Predictions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecommendationDate",
                table: "Predictions");

            migrationBuilder.DropColumn(
                name: "RecommendedBy",
                table: "Predictions");
        }
    }
}
