namespace EmbeddedSystems.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("Languages", "FlagUrl", c => c.String());
            AddColumn("Customers", "Email", c => c.String());
        }

        public override void Down()
        {
            DropColumn("Languages", "FlagUrl");
            DropColumn("Customers", "Email");
        }
    }
}
