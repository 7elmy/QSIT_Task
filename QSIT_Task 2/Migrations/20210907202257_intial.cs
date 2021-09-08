using Microsoft.EntityFrameworkCore.Migrations;

namespace QSIT_Task_2.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MapTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapTypes_MapTypes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MapTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MapConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClusterRadius = table.Column<double>(type: "float", nullable: false),
                    GeoFencing = table.Column<bool>(type: "bit", nullable: false),
                    DuplicationEventTimeBuffer = table.Column<double>(type: "float", nullable: false),
                    DuplicationEventLocationBuffer = table.Column<double>(type: "float", nullable: false),
                    EndEventDuration = table.Column<double>(type: "float", nullable: false),
                    MapSubTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MapConfigurations_MapTypes_MapSubTypeId",
                        column: x => x.MapSubTypeId,
                        principalTable: "MapTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapConfigurations_MapSubTypeId",
                table: "MapConfigurations",
                column: "MapSubTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MapTypes_ParentId",
                table: "MapTypes",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapConfigurations");

            migrationBuilder.DropTable(
                name: "MapTypes");
        }
    }
}
