namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v016 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.message_get_status_bit_profile",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StatusType = c.String(maxLength: 250, unicode: false),
                        Bit = c.Int(nullable: false),
                        Caption = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.message_get_status_bit_profile");
        }
    }
}
