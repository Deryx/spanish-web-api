using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpanishWebApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectPronoun = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectTranslation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Tense",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    tense = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tense", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Verb",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    infinitive = table.Column<string>(type: "TEXT", nullable: false),
                    translation = table.Column<string>(type: "TEXT", nullable: false),
                    pronunciation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verb", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionary",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    word = table.Column<string>(type: "TEXT", nullable: false),
                    translation = table.Column<string>(type: "TEXT", nullable: false),
                    pronunciation = table.Column<string>(type: "TEXT", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    category = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionary", x => x.id);
                    table.ForeignKey(
                        name: "FK_Dictionary_Category_category",
                        column: x => x.category,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conjugation",
                columns: table => new
                {
                    ConjugationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConjugationText = table.Column<string>(type: "TEXT", nullable: false),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    TenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    VerbId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjugation", x => x.ConjugationId);
                    table.ForeignKey(
                        name: "FK_Conjugation_Subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subject",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conjugation_Tense_TenseId",
                        column: x => x.TenseId,
                        principalTable: "Tense",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conjugation_Verb_VerbId",
                        column: x => x.VerbId,
                        principalTable: "Verb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConjugationsWide",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    yo = table.Column<string>(type: "TEXT", nullable: false),
                    tu = table.Column<string>(type: "TEXT", nullable: false),
                    el = table.Column<string>(type: "TEXT", nullable: false),
                    nosotros = table.Column<string>(type: "TEXT", nullable: false),
                    vosotros = table.Column<string>(type: "TEXT", nullable: false),
                    ellos = table.Column<string>(type: "TEXT", nullable: false),
                    verb = table.Column<int>(type: "INTEGER", nullable: false),
                    tense = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConjugationsWide", x => x.id);
                    table.ForeignKey(
                        name: "FK_ConjugationsWide_Tense_tense",
                        column: x => x.tense,
                        principalTable: "Tense",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConjugationsWide_Verb_verb",
                        column: x => x.verb,
                        principalTable: "Verb",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conjugation_SubjectId_TenseId_VerbId",
                table: "Conjugation",
                columns: new[] { "SubjectId", "TenseId", "VerbId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Conjugation_TenseId",
                table: "Conjugation",
                column: "TenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Conjugation_VerbId",
                table: "Conjugation",
                column: "VerbId");

            migrationBuilder.CreateIndex(
                name: "IX_ConjugationsWide_tense",
                table: "ConjugationsWide",
                column: "tense");

            migrationBuilder.CreateIndex(
                name: "IX_ConjugationsWide_verb",
                table: "ConjugationsWide",
                column: "verb");

            migrationBuilder.CreateIndex(
                name: "IX_Dictionary_category",
                table: "Dictionary",
                column: "category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conjugation");

            migrationBuilder.DropTable(
                name: "ConjugationsWide");

            migrationBuilder.DropTable(
                name: "Dictionary");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Tense");

            migrationBuilder.DropTable(
                name: "Verb");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
