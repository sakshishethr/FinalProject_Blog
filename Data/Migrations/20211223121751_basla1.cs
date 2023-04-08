using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjeOT.Data.Migrations
{
    public partial class basla1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    AboutID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutDetails = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    AboutDetails_2 = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    AboutImage = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    AboutImage_2 = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.AboutID);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    AdminRole = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieS",
                columns: table => new
                {
                    CategoriesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriesName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CategoryDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieS", x => x.CategoriesID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    SName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactID);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterN_S = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    WriterAbout = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    WriterTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ShortAbout = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WriterImage = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterID);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogHeader = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true),
                    BlogDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BlogImage = table.Column<string>(type: "nvarchar(110)", maxLength: 110, nullable: true),
                    CategoriesID = table.Column<int>(type: "int", nullable: false),
                    WriterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.BlogID);
                    table.ForeignKey(
                        name: "FK_Blogs_CategorieS_CategoriesID",
                        column: x => x.CategoriesID,
                        principalTable: "CategorieS",
                        principalColumn: "CategoriesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Blogs_Writers_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentS",
                columns: table => new
                {
                    CommentsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserN = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CommentDetail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentStatus = table.Column<bool>(type: "bit", nullable: false),
                    BlogID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentS", x => x.CommentsID);
                    table.ForeignKey(
                        name: "FK_CommentS_Blogs_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blogs",
                        principalColumn: "BlogID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoriesID",
                table: "Blogs",
                column: "CategoriesID");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_WriterID",
                table: "Blogs",
                column: "WriterID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentS_BlogID",
                table: "CommentS",
                column: "BlogID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CommentS");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "CategorieS");

            migrationBuilder.DropTable(
                name: "Writers");
        }
    }
}
