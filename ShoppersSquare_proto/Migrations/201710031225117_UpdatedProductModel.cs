namespace ShoppersSquare_proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProductModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "Rating", c => c.Short(nullable: false));
            AddColumn("dbo.Products", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Tags");
            DropColumn("dbo.Products", "Rating");
            DropColumn("dbo.Products", "DateAdded");
        }
    }
}
