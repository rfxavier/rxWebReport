namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v017 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.message_get_userlist",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TopicDeviceId = c.String(maxLength: 250, unicode: false),
                        Destiny = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        UserIndex = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserEnable = c.Boolean(nullable: false),
                        UserAccessLevel = c.String(maxLength: 250, unicode: false),
                        UserName = c.String(maxLength: 250, unicode: false),
                        UserPasswd = c.String(maxLength: 250, unicode: false),
                        Timestamp = c.String(maxLength: 250, unicode: false),
                        IsAck = c.Boolean(nullable: false),
                        TimestampDatetime = c.DateTime(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.message_get_userlist");
        }
    }
}
