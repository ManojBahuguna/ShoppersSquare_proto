namespace ShoppersSquare_proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderItemmodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CartItems", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.CartItems", name: "IX_Product_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CartItems", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.CartItems", name: "ProductId", newName: "Product_Id");
        }
    }
}
