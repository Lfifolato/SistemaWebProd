namespace SistemaWebProd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajuste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produto", "Dvencimento", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produto", "Dvencimento", c => c.DateTime(nullable: false));
        }
    }
}
