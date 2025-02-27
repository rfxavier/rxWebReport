namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v029 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message", "balance_id", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message", "balance_id");
        }
    }
}
