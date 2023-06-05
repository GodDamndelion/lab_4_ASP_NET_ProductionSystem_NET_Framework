namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Production_machine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Recipe_Id = c.Int(nullable: false),
                        Recipe_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id1)
                .Index(t => t.Recipe_Id1);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Use_in",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type_of_product_Id = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Is_output = c.Boolean(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                        Recipe_Id1 = c.Int(),
                        Type_of_product_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id1)
                .ForeignKey("dbo.Type_of_product", t => t.Type_of_product_Id1)
                .Index(t => t.Recipe_Id1)
                .Index(t => t.Type_of_product_Id1);
            
            CreateTable(
                "dbo.Type_of_product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Volume = c.Int(nullable: false),
                        Type_Id = c.Int(nullable: false),
                        Type_of_product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Type_of_product", t => t.Type_of_product_Id)
                .Index(t => t.Type_of_product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Use_in", "Type_of_product_Id1", "dbo.Type_of_product");
            DropForeignKey("dbo.Products", "Type_of_product_Id", "dbo.Type_of_product");
            DropForeignKey("dbo.Use_in", "Recipe_Id1", "dbo.Recipes");
            DropForeignKey("dbo.Production_machine", "Recipe_Id1", "dbo.Recipes");
            DropIndex("dbo.Products", new[] { "Type_of_product_Id" });
            DropIndex("dbo.Use_in", new[] { "Type_of_product_Id1" });
            DropIndex("dbo.Use_in", new[] { "Recipe_Id1" });
            DropIndex("dbo.Production_machine", new[] { "Recipe_Id1" });
            DropTable("dbo.Products");
            DropTable("dbo.Type_of_product");
            DropTable("dbo.Use_in");
            DropTable("dbo.Recipes");
            DropTable("dbo.Production_machine");
        }
    }
}
