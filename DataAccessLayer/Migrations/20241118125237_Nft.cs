using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Nft : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedAt",
                table: "NFTs");

            migrationBuilder.RenameColumn(
                name: "PostedBy",
                table: "NFTs",
                newName: "CreatorId");

            migrationBuilder.AddColumn<short>(
                name: "HighestBid",
                table: "NFTs",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighestBid",
                table: "NFTs");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "NFTs",
                newName: "PostedBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedAt",
                table: "NFTs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
