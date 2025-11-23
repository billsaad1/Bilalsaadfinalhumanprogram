using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanitarianProjectManagement.Migrations
{
    public partial class AddProcurementTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // This migration was deleted and is being restored to maintain history.
            // The `Up` method is intentionally left empty as the corresponding tables
            // are being removed by the `RemoveProcurementModule` migration.
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // If we were to roll back the `RemoveProcurementModule` migration,
            // this `Down` method would need to re-create the procurement tables.
            // For now, it is left empty.
        }
    }
}
