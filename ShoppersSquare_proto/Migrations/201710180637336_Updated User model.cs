namespace ShoppersSquare_proto.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUsermodel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Cart_Id", newName: "CartId");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Cart_Id", newName: "IX_CartId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_CartId", newName: "IX_Cart_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "CartId", newName: "Cart_Id");
        }
    }
}
