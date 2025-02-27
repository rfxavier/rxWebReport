namespace rxWebReport.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v025 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cofre_user", "sobrenome", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.cofre_user", "passwd", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.cofre_user", "enable", c => c.Boolean(nullable: false));
            AddColumn("dbo.cofre_user", "access_level", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.cofre_user", "access_level");
            DropColumn("dbo.cofre_user", "enable");
            DropColumn("dbo.cofre_user", "passwd");
            DropColumn("dbo.cofre_user", "sobrenome");
        }
    }
}
