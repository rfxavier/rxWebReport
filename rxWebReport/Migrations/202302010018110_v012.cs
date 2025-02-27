namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v012 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.message_get_info");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.message_get_info",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TopicDeviceId = c.String(maxLength: 250, unicode: false),
                        Destiny = c.Int(nullable: false),
                        CompanyName = c.String(maxLength: 250, unicode: false),
                        CompanyCNPJ = c.String(maxLength: 250, unicode: false),
                        DeviceSN = c.String(maxLength: 250, unicode: false),
                        DeviceFirmVersion = c.String(maxLength: 250, unicode: false),
                        DeviceBlocked = c.Boolean(nullable: false),
                        BillMachineType = c.String(maxLength: 250, unicode: false),
                        BillMachineSN = c.String(maxLength: 250, unicode: false),
                        IsAck = c.Boolean(nullable: false),
                        Timestamp = c.String(maxLength: 250, unicode: false),
                        TimestampDatetime = c.DateTime(),
                        trackLastWriteTime = c.DateTime(),
                        trackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
