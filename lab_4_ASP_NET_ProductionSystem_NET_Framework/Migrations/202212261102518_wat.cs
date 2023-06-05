namespace lab_4_ASP_NET_ProductionSystem_NET_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Type_of_product", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Type_of_product", "Name", c => c.String());
        }
    }
}
