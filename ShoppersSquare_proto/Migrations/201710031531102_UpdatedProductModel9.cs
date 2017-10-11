namespace ShoppersSquare_proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProductModel9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Tags", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Tags");
        }
    }
}
