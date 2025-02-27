namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v007 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.message_get_status", "TopicDeviceId", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.message_get_status", "TopicDeviceId", c => c.Int(nullable: false));
        }
    }
}
