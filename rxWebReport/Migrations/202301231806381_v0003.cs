namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BasicAuthKey", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "BasicAuthKey");
        }
    }
}
