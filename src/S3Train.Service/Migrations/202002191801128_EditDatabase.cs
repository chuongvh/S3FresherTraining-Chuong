namespace S3Train.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDatabase : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IdentityUser", newName: "AspNetUsers");
            DropForeignKey("dbo.Order", "IdentityUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.OrderItem", "Id", "dbo.Product");
            DropIndex("dbo.OrderItem", new[] { "Id" });
            DropIndex("dbo.Order", new[] { "IdentityUser_Id" });
            AddColumn("dbo.OrderItem", "ProductId", c => c.String(maxLength: 128));
            AddColumn("dbo.Customer", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Avatar", c => c.String());
            AddColumn("dbo.AspNetRoles", "Description", c => c.String());
            CreateIndex("dbo.Customer", "UserId");
            CreateIndex("dbo.OrderItem", "ProductId");
            AddForeignKey("dbo.Customer", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OrderItem", "ProductId", "dbo.Product", "Id");
            DropColumn("dbo.Order", "UserId");
            DropColumn("dbo.Order", "IdentityUser_Id");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Status", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Order", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Order", "UserId", c => c.String());
            DropForeignKey("dbo.OrderItem", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Customer", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.OrderItem", new[] { "ProductId" });
            DropIndex("dbo.Customer", new[] { "UserId" });
            DropColumn("dbo.AspNetRoles", "Description");
            DropColumn("dbo.AspNetUsers", "Avatar");
            DropColumn("dbo.Customer", "UserId");
            DropColumn("dbo.OrderItem", "ProductId");
            CreateIndex("dbo.Order", "IdentityUser_Id");
            CreateIndex("dbo.OrderItem", "Id");
            AddForeignKey("dbo.OrderItem", "Id", "dbo.Product", "Id");
            AddForeignKey("dbo.Order", "IdentityUser_Id", "dbo.IdentityUser", "Id");
            RenameTable(name: "dbo.AspNetUsers", newName: "IdentityUser");
        }
    }
}
