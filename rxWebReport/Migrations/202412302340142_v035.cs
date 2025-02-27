namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v035 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUserCofres", name: "CofreId", newName: "id_cofre");
            RenameIndex(table: "dbo.AspNetUserCofres", name: "IX_CofreId", newName: "IX_id_cofre");
            DropPrimaryKey("dbo.AspNetUserCofres");
            AddPrimaryKey("dbo.AspNetUserCofres", new[] { "id_cofre", "UserId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AspNetUserCofres");
            AddPrimaryKey("dbo.AspNetUserCofres", new[] { "UserId", "CofreId" });
            RenameIndex(table: "dbo.AspNetUserCofres", name: "IX_id_cofre", newName: "IX_CofreId");
            RenameColumn(table: "dbo.AspNetUserCofres", name: "id_cofre", newName: "CofreId");
        }
    }
}
