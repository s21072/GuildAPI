using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuildAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Def = table.Column<int>(type: "int", nullable: true),
                    Dmg = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentID);
                });

            migrationBuilder.CreateTable(
                name: "Fissures",
                columns: table => new
                {
                    FissureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NSLoc = table.Column<float>(type: "real", nullable: false),
                    WELoc = table.Column<float>(type: "real", nullable: false),
                    OSLev = table.Column<float>(type: "real", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    FissureTypes = table.Column<int>(type: "int", nullable: false),
                    FindDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fissures", x => x.FissureID);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsAdventurer = table.Column<bool>(type: "bit", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Retirement = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Pesel);
                    table.ForeignKey(
                        name: "FK_Person_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FissureID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                    table.ForeignKey(
                        name: "FK_Country_Fissures_FissureID",
                        column: x => x.FissureID,
                        principalTable: "Fissures",
                        principalColumn: "FissureID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Attribute = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingID);
                    table.ForeignKey(
                        name: "FK_Trainings_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CEOs",
                columns: table => new
                {
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CEOs", x => x.Pesel);
                    table.ForeignKey(
                        name: "FK_CEOs_Person_Pesel",
                        column: x => x.Pesel,
                        principalTable: "Person",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    CommissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CommissionType = table.Column<int>(type: "int", nullable: false),
                    MinRank = table.Column<int>(type: "int", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AcceptTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reword = table.Column<float>(type: "real", nullable: false),
                    Rates = table.Column<int>(type: "int", maxLength: 2, nullable: false, defaultValue: 1),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FissureID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    FissureID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.CommissionID);
                    table.ForeignKey(
                        name: "FK_Commissions_Fissures_FissureID",
                        column: x => x.FissureID,
                        principalTable: "Fissures",
                        principalColumn: "FissureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_Fissures_FissureID1",
                        column: x => x.FissureID1,
                        principalTable: "Fissures",
                        principalColumn: "FissureID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commissions_Person_Pesel",
                        column: x => x.Pesel,
                        principalTable: "Person",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Commissions_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuildWorkers",
                columns: table => new
                {
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    WorkRole = table.Column<int>(type: "int", nullable: false),
                    Bonus = table.Column<float>(type: "real", nullable: true),
                    NymberOfCommissionsDone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildWorkers", x => x.Pesel);
                    table.ForeignKey(
                        name: "FK_GuildWorkers_Person_Pesel",
                        column: x => x.Pesel,
                        principalTable: "Person",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lends",
                columns: table => new
                {
                    LendID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HowMuch = table.Column<int>(type: "int", nullable: false),
                    EquipmentID = table.Column<int>(type: "int", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TrainingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lends", x => x.LendID);
                    table.ForeignKey(
                        name: "FK_Lends_Equipment_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lends_Person_Pesel",
                        column: x => x.Pesel,
                        principalTable: "Person",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lends_Trainings_TrainingID",
                        column: x => x.TrainingID,
                        principalTable: "Trainings",
                        principalColumn: "TrainingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adventurers",
                columns: table => new
                {
                    Pesel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Str = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Int = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Vit = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Spd = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    CommissionID = table.Column<int>(type: "int", nullable: true),
                    TeamID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adventurers", x => x.Pesel);
                    table.ForeignKey(
                        name: "FK_Adventurers_Commissions_CommissionID",
                        column: x => x.CommissionID,
                        principalTable: "Commissions",
                        principalColumn: "CommissionID");
                    table.ForeignKey(
                        name: "FK_Adventurers_Person_Pesel",
                        column: x => x.Pesel,
                        principalTable: "Person",
                        principalColumn: "Pesel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adventurers_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adventurers_CommissionID",
                table: "Adventurers",
                column: "CommissionID");

            migrationBuilder.CreateIndex(
                name: "IX_Adventurers_TeamID",
                table: "Adventurers",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_FissureID",
                table: "Commissions",
                column: "FissureID");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_FissureID1",
                table: "Commissions",
                column: "FissureID1");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_Pesel",
                table: "Commissions",
                column: "Pesel");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_TeamID",
                table: "Commissions",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Country_FissureID",
                table: "Country",
                column: "FissureID");

            migrationBuilder.CreateIndex(
                name: "IX_Lends_EquipmentID",
                table: "Lends",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Lends_Pesel",
                table: "Lends",
                column: "Pesel");

            migrationBuilder.CreateIndex(
                name: "IX_Lends_TrainingID",
                table: "Lends",
                column: "TrainingID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TeamID",
                table: "Trainings",
                column: "TeamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adventurers");

            migrationBuilder.DropTable(
                name: "CEOs");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "GuildWorkers");

            migrationBuilder.DropTable(
                name: "Lends");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Fissures");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
