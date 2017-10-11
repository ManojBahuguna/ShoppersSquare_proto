namespace ShoppersSquare_proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProductModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Ratings", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Sold", c => c.Short(nullable: false));
            DropColumn("dbo.Products", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Rating", c => c.Short(nullable: false));
            DropColumn("dbo.Products", "Sold");
            DropColumn("dbo.Products", "Ratings");
        }
    }
}
