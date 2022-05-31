using Microsoft.EntityFrameworkCore.Migrations;

namespace JackStore.Data.Mapping.Migrations.ApplicationIdentityDb
{
    public partial class AddSchemaIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.RenameTable(
                name: "identity_user_token",
                newName: "identity_user_token",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "identity_user_role",
                newName: "identity_user_role",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "identity_user_login",
                newName: "identity_user_login",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "identity_user_claim",
                newName: "identity_user_claim",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "identity_user",
                newName: "identity_user",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "identity_role_claim",
                newName: "identity_role_claim",
                newSchema: "Security");

            migrationBuilder.RenameTable(
                name: "identity_role",
                newName: "identity_role",
                newSchema: "Security");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "identity_user_token",
                schema: "Security",
                newName: "identity_user_token");

            migrationBuilder.RenameTable(
                name: "identity_user_role",
                schema: "Security",
                newName: "identity_user_role");

            migrationBuilder.RenameTable(
                name: "identity_user_login",
                schema: "Security",
                newName: "identity_user_login");

            migrationBuilder.RenameTable(
                name: "identity_user_claim",
                schema: "Security",
                newName: "identity_user_claim");

            migrationBuilder.RenameTable(
                name: "identity_user",
                schema: "Security",
                newName: "identity_user");

            migrationBuilder.RenameTable(
                name: "identity_role_claim",
                schema: "Security",
                newName: "identity_role_claim");

            migrationBuilder.RenameTable(
                name: "identity_role",
                schema: "Security",
                newName: "identity_role");
        }
    }
}
