namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v026 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.message_user_add_edit_remove",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TopicDeviceId = c.String(maxLength: 250, unicode: false),
                        Destiny = c.Int(nullable: false),
                        Timestamp = c.String(maxLength: 250, unicode: false),
                        IsAck = c.Boolean(nullable: false),
                        Operation = c.String(maxLength: 250, unicode: false),
                        UserId = c.Int(nullable: false),
                        Response = c.Int(nullable: false),
                        TimestampDatetime = c.DateTime(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.message_user_add_edit_remove");
        }
    }
}
