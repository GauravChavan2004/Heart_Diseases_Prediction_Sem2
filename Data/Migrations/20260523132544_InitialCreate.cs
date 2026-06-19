using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeartDiseasePrediction.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChestPainType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestingBP = table.Column<int>(type: "int", nullable: false),
                    Cholesterol = table.Column<int>(type: "int", nullable: false),
                    FastingBS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestingECG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxHR = table.Column<int>(type: "int", nullable: false),
                    ExerciseAngina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oldpeak = table.Column<float>(type: "real", nullable: false),
                    ST_Slope = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredictionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predictions");
        }
    }
}
