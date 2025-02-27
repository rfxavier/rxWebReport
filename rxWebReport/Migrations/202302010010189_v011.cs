namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v011 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.message_get_info");
            AlterColumn("dbo.message_get_info", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.message_get_info", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.message_get_info");
            AlterColumn("dbo.message_get_info", "Id", c => c.String(nullable: false, maxLength: 250, unicode: false));
            AddPrimaryKey("dbo.message_get_info", "Id");
        }
    }
}
