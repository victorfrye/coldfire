using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VictorFrye.Coldfire.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Isbn = table.Column<string>(type: "TEXT", nullable: false),
                    Authors = table.Column<string>(type: "TEXT", nullable: false),
                    NumberOfPages = table.Column<int>(type: "INTEGER", nullable: false),
                    Publisher = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    MediaType = table.Column<string>(type: "TEXT", nullable: true),
                    Released = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Culture = table.Column<string>(type: "TEXT", nullable: true),
                    Born = table.Column<string>(type: "TEXT", nullable: true),
                    Died = table.Column<string>(type: "TEXT", nullable: true),
                    Titles = table.Column<string>(type: "TEXT", nullable: false),
                    Aliases = table.Column<string>(type: "TEXT", nullable: false),
                    CharacterFatherForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    CharacterMotherForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    CharacterSpouseForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    TvSeries = table.Column<string>(type: "TEXT", nullable: false),
                    PlayedBy = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Characters_CharacterFatherForeignKey",
                        column: x => x.CharacterFatherForeignKey,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Characters_CharacterMotherForeignKey",
                        column: x => x.CharacterMotherForeignKey,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Characters_Characters_CharacterSpouseForeignKey",
                        column: x => x.CharacterSpouseForeignKey,
                        principalTable: "Characters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookCharacters",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "INTEGER", nullable: false),
                    CharactersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCharacters", x => new { x.BooksId, x.CharactersId });
                    table.ForeignKey(
                        name: "FK_BookCharacters_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCharacters_Characters_CharactersId",
                        column: x => x.CharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookPovCharacters",
                columns: table => new
                {
                    PovBooksId = table.Column<int>(type: "INTEGER", nullable: false),
                    PovCharactersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPovCharacters", x => new { x.PovBooksId, x.PovCharactersId });
                    table.ForeignKey(
                        name: "FK_BookPovCharacters_Books_PovBooksId",
                        column: x => x.PovBooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPovCharacters_Characters_PovCharactersId",
                        column: x => x.PovCharactersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    CoatOfArms = table.Column<string>(type: "TEXT", nullable: true),
                    Words = table.Column<string>(type: "TEXT", nullable: true),
                    Titles = table.Column<string>(type: "TEXT", nullable: false),
                    Seats = table.Column<string>(type: "TEXT", nullable: false),
                    HouseCurrentLordForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    HouseHeirForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    HouseOverlordForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    Founded = table.Column<string>(type: "TEXT", nullable: true),
                    HouseFounderForeignKey = table.Column<int>(type: "INTEGER", nullable: true),
                    DiedOut = table.Column<string>(type: "TEXT", nullable: true),
                    AncestralWeapons = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Characters_HouseCurrentLordForeignKey",
                        column: x => x.HouseCurrentLordForeignKey,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_Characters_HouseFounderForeignKey",
                        column: x => x.HouseFounderForeignKey,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_Characters_HouseHeirForeignKey",
                        column: x => x.HouseHeirForeignKey,
                        principalTable: "Characters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Houses_Houses_HouseOverlordForeignKey",
                        column: x => x.HouseOverlordForeignKey,
                        principalTable: "Houses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HouseCadetBranches",
                columns: table => new
                {
                    CadetBranchesId = table.Column<int>(type: "INTEGER", nullable: false),
                    HouseEntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseCadetBranches", x => new { x.CadetBranchesId, x.HouseEntityId });
                    table.ForeignKey(
                        name: "FK_HouseCadetBranches_Houses_CadetBranchesId",
                        column: x => x.CadetBranchesId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseCadetBranches_Houses_HouseEntityId",
                        column: x => x.HouseEntityId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseSwornMembers",
                columns: table => new
                {
                    AllegiancesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SwornMembersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseSwornMembers", x => new { x.AllegiancesId, x.SwornMembersId });
                    table.ForeignKey(
                        name: "FK_HouseSwornMembers_Characters_SwornMembersId",
                        column: x => x.SwornMembersId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseSwornMembers_Houses_AllegiancesId",
                        column: x => x.AllegiancesId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCharacters_CharactersId",
                table: "BookCharacters",
                column: "CharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPovCharacters_PovCharactersId",
                table: "BookPovCharacters",
                column: "PovCharactersId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterFatherForeignKey",
                table: "Characters",
                column: "CharacterFatherForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterMotherForeignKey",
                table: "Characters",
                column: "CharacterMotherForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterSpouseForeignKey",
                table: "Characters",
                column: "CharacterSpouseForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_HouseCadetBranches_HouseEntityId",
                table: "HouseCadetBranches",
                column: "HouseEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseCurrentLordForeignKey",
                table: "Houses",
                column: "HouseCurrentLordForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseFounderForeignKey",
                table: "Houses",
                column: "HouseFounderForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseHeirForeignKey",
                table: "Houses",
                column: "HouseHeirForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_HouseOverlordForeignKey",
                table: "Houses",
                column: "HouseOverlordForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_HouseSwornMembers_SwornMembersId",
                table: "HouseSwornMembers",
                column: "SwornMembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCharacters");

            migrationBuilder.DropTable(
                name: "BookPovCharacters");

            migrationBuilder.DropTable(
                name: "HouseCadetBranches");

            migrationBuilder.DropTable(
                name: "HouseSwornMembers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
