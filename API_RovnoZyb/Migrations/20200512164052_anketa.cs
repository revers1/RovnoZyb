using Microsoft.EntityFrameworkCore.Migrations;

namespace API_RovnoZyb.Migrations
{
    public partial class anketa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAnketa",
                columns: table => new
                {
                    AnketaId = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Servant = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Time = table.Column<string>(nullable: false),
                    isClose = table.Column<bool>(nullable: false),
                    id = table.Column<string>(nullable: false),
                    UserMoreid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAnketa", x => x.AnketaId);
                    table.ForeignKey(
                        name: "FK_tblAnketa_tblMoreInfo_UserMoreid",
                        column: x => x.UserMoreid,
                        principalTable: "tblMoreInfo",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAnketa_UserMoreid",
                table: "tblAnketa",
                column: "UserMoreid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAnketa");
        }
    }
}
