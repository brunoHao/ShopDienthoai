using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBSITEDIENTHOAI.Migrations
{
    public partial class Addbatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CTHOADON",
                columns: table => new
                {
                    Idcthd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idhoadon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngaythanhtoan = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHOADON", x => x.Idcthd);
                });

            migrationBuilder.CreateTable(
                name: "CTSANPHAM",
                columns: table => new
                {
                    IDCTSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idsp = table.Column<int>(type: "int", nullable: false),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuongHieu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTSANPHAM", x => x.IDCTSP);
                });

            migrationBuilder.CreateTable(
                name: "GIOHANG",
                columns: table => new
                {
                    IdGiohang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idsp = table.Column<int>(type: "int", nullable: true),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sluongdat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GIOHANG", x => x.IdGiohang);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    Idhoadon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGiohang = table.Column<int>(type: "int", nullable: true),
                    Sluongdat = table.Column<int>(type: "int", nullable: true),
                    Tongdonhang = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.Idhoadon);
                });

            migrationBuilder.CreateTable(
                name: "MAUSAC",
                columns: table => new
                {
                    Idcl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Idctsp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MAUSAC", x => x.Idcl);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    Idsp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Giasp = table.Column<float>(type: "real", nullable: true),
                    Sluong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM", x => x.Idsp);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTHOADON");

            migrationBuilder.DropTable(
                name: "CTSANPHAM");

            migrationBuilder.DropTable(
                name: "GIOHANG");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "MAUSAC");

            migrationBuilder.DropTable(
                name: "SANPHAM");
        }
    }
}
