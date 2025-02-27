namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.api_log", "CofreId", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.api_log", "CofreId");
        }
    }
}
