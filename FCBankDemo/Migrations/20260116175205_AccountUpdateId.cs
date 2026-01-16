using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCBankDemo.Migrations
{
    /// <inheritdoc />
    public partial class AccountUpdateId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Accounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
