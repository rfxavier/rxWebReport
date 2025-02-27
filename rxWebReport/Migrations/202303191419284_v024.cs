namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v024 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.message_get_status", "UptimeSec", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.message_get_status", "UptimeSec", c => c.Long(nullable: false));
        }
    }
}
