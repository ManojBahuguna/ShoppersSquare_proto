namespace ShoppersSquare_proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProductModel10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Tags", c => c.String());
        }
    }
}
