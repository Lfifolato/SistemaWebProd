namespace SistemaWebProd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedor",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cnpj = c.String(nullable: false),
                        Site = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Valor = c.Single(nullable: false),
                        Dvencimento = c.DateTime(nullable: false),
                        IdFornecedor = c.Long(nullable: false),
                        Tipo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedor", t => t.IdFornecedor, cascadeDelete: true)
                .Index(t => t.IdFornecedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "IdFornecedor", "dbo.Fornecedor");
            DropIndex("dbo.Produto", new[] { "IdFornecedor" });
            DropTable("dbo.Produto");
            DropTable("dbo.Fornecedor");
        }
    }
}
