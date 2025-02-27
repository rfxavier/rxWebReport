namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.api_log",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ApiName = c.String(maxLength: 250, unicode: false),
                        UserName = c.String(maxLength: 250, unicode: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataFim = c.DateTime(nullable: false),
                        Error = c.Boolean(nullable: false),
                        Response = c.String(maxLength: 250, unicode: false),
                        TrackLastWriteTime = c.DateTime(),
                        TrackCreationTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.api_log");
        }
    }
}
