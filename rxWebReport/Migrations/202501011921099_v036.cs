namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v036 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AspNetUserCofres");
            AddPrimaryKey("dbo.AspNetUserCofres", new[] { "UserId", "id_cofre" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AspNetUserCofres");
            AddPrimaryKey("dbo.AspNetUserCofres", new[] { "id_cofre", "UserId" });
        }
    }
}
