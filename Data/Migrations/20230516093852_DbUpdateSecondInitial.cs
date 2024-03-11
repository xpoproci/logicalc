using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DbUpdateSecondInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseFormula",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Input = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputationTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogicType = table.Column<int>(type: "int", nullable: false),
                    FormulaType = table.Column<int>(type: "int", nullable: false),
                    Tautology = table.Column<bool>(type: "bit", nullable: false),
                    Contradiction = table.Column<bool>(type: "bit", nullable: false),
                    Satisfiability = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Goal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formulas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TruthTable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDNF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UCNF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DNF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skolemization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formulas1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formula_Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clausule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseFormula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogicType = table.Column<int>(type: "int", nullable: false),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LogicType = table.Column<int>(type: "int", nullable: false),
                    FormulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_BaseFormula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "BaseFormula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_History_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_FormulaId",
                table: "History",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_History_UserId",
                table: "History",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "BaseFormula");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
