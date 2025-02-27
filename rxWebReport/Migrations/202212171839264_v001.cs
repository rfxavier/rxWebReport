namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUserCofres",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 250, unicode: false),
                        CofreId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CofreId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.cofre", t => t.CofreId)
                .Index(t => t.UserId)
                .Index(t => t.CofreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserCofres", "CofreId", "dbo.cofre");
            DropForeignKey("dbo.AspNetUserCofres", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserCofres", new[] { "CofreId" });
            DropIndex("dbo.AspNetUserCofres", new[] { "UserId" });
            DropTable("dbo.AspNetUserCofres");
        }
    }
}
