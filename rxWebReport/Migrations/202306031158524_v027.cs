namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v027 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message", "balance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.message", "limit_deposit_enabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.message", "limit_deposit_value", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message", "limit_deposit_value");
            DropColumn("dbo.message", "limit_deposit_enabled");
            DropColumn("dbo.message", "balance");
        }
    }
}
