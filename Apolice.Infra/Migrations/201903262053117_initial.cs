namespace Apolice.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seguro",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NumeroApolice = c.Int(nullable: false),
                        Cpf = c.String(maxLength: 15, unicode: false),
                        Cnpj = c.String(maxLength: 19, unicode: false),
                        PlacaVeiculo = c.String(maxLength: 100, unicode: false),
                        ValorPremio = c.Double(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true, name: "UK_SEGURO_ID")
                .Index(t => t.Cpf, unique: true, name: "UK_SEGURO_CPF")
                .Index(t => t.Cnpj, unique: true, name: "UK_SEGURO_CNPJ");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Seguro", "UK_SEGURO_CNPJ");
            DropIndex("dbo.Seguro", "UK_SEGURO_CPF");
            DropIndex("dbo.Seguro", "UK_SEGURO_ID");
            DropTable("dbo.Seguro");
        }
    }
}
