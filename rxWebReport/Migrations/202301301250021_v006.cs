namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v006 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.message_get_status", "DeviceStatus", c => c.Long(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit0", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit1", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit2", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit3", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit4", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit5", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit6", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit7", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit8", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit9", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit10", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit11", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit12", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit13", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit14", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit15", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit16", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit17", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit18", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit19", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit20", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit21", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit22", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit23", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit24", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit25", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit26", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit27", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit28", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit29", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit30", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceStatusBit31", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "Timestamp", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.message_get_status", "IsAck", c => c.Boolean(nullable: false));
            AddColumn("dbo.message_get_status", "TimestampDatetime", c => c.DateTime());
            DropColumn("dbo.message_get_status", "DeviceSensors");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit0");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit1");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit2");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit3");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit4");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit5");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit6");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit7");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit8");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit9");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit10");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit11");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit12");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit13");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit14");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit15");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit16");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit17");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit18");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit19");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit20");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit21");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit22");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit23");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit24");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit25");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit26");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit27");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit28");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit29");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit30");
            DropColumn("dbo.message_get_status", "DeviceSensorsBit31");
        }
        
        public override void Down()
        {
            AddColumn("dbo.message_get_status", "DeviceSensorsBit31", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit30", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit29", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit28", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit27", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit26", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit25", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit24", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit23", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit22", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit21", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit20", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit19", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit18", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit17", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit16", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit15", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit14", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit13", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit12", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit11", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit10", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit9", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit8", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit7", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit6", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit5", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit4", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit3", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit2", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit1", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensorsBit0", c => c.Int(nullable: false));
            AddColumn("dbo.message_get_status", "DeviceSensors", c => c.Long(nullable: false));
            DropColumn("dbo.message_get_status", "TimestampDatetime");
            DropColumn("dbo.message_get_status", "IsAck");
            DropColumn("dbo.message_get_status", "Timestamp");
            DropColumn("dbo.message_get_status", "DeviceStatusBit31");
            DropColumn("dbo.message_get_status", "DeviceStatusBit30");
            DropColumn("dbo.message_get_status", "DeviceStatusBit29");
            DropColumn("dbo.message_get_status", "DeviceStatusBit28");
            DropColumn("dbo.message_get_status", "DeviceStatusBit27");
            DropColumn("dbo.message_get_status", "DeviceStatusBit26");
            DropColumn("dbo.message_get_status", "DeviceStatusBit25");
            DropColumn("dbo.message_get_status", "DeviceStatusBit24");
            DropColumn("dbo.message_get_status", "DeviceStatusBit23");
            DropColumn("dbo.message_get_status", "DeviceStatusBit22");
            DropColumn("dbo.message_get_status", "DeviceStatusBit21");
            DropColumn("dbo.message_get_status", "DeviceStatusBit20");
            DropColumn("dbo.message_get_status", "DeviceStatusBit19");
            DropColumn("dbo.message_get_status", "DeviceStatusBit18");
            DropColumn("dbo.message_get_status", "DeviceStatusBit17");
            DropColumn("dbo.message_get_status", "DeviceStatusBit16");
            DropColumn("dbo.message_get_status", "DeviceStatusBit15");
            DropColumn("dbo.message_get_status", "DeviceStatusBit14");
            DropColumn("dbo.message_get_status", "DeviceStatusBit13");
            DropColumn("dbo.message_get_status", "DeviceStatusBit12");
            DropColumn("dbo.message_get_status", "DeviceStatusBit11");
            DropColumn("dbo.message_get_status", "DeviceStatusBit10");
            DropColumn("dbo.message_get_status", "DeviceStatusBit9");
            DropColumn("dbo.message_get_status", "DeviceStatusBit8");
            DropColumn("dbo.message_get_status", "DeviceStatusBit7");
            DropColumn("dbo.message_get_status", "DeviceStatusBit6");
            DropColumn("dbo.message_get_status", "DeviceStatusBit5");
            DropColumn("dbo.message_get_status", "DeviceStatusBit4");
            DropColumn("dbo.message_get_status", "DeviceStatusBit3");
            DropColumn("dbo.message_get_status", "DeviceStatusBit2");
            DropColumn("dbo.message_get_status", "DeviceStatusBit1");
            DropColumn("dbo.message_get_status", "DeviceStatusBit0");
            DropColumn("dbo.message_get_status", "DeviceStatus");
        }
    }
}
