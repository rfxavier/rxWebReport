namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v010 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message_get_info", "Timestamp", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.message_get_info", "Timestamp");
        }
    }
}
