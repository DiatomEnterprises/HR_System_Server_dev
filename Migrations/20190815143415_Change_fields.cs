using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HR_Server.Migrations
{
    public partial class Change_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Position = table.Column<string>(maxLength: 150, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    IsCvUploaded = table.Column<bool>(type: "bit", nullable: false),
                    Experience = table.Column<string>(maxLength: 1000, nullable: true),
                    Email = table.Column<string>(maxLength: 150, nullable: true),
                    Other = table.Column<string>(maxLength: 150, nullable: true),
                    DiatomEnterviewees = table.Column<string>(maxLength: 250, nullable: true),
                    InterviewDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    Rate = table.Column<decimal>(type: "money", nullable: false),
                    Status = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
