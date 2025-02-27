namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v022 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.message_update_firmware",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TopicDeviceId = c.String(maxLength: 250, unicode: false),
                        Destiny = c.Int(nullable: false),
                        IsAck = c.Boolean(nullable: false),
                        Timestamp = c.String(maxLength: 250, unicode: false),
                        UpdateFirmware = c.String(maxLength: 250, unicode: false),
                        TimestampDatetime = c.DateTime(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.message_update_firmware");
        }
    }
}
