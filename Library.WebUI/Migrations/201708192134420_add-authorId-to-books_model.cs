namespace Library.WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addauthorIdtobooks_model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            RenameColumn(table: "dbo.Books", name: "Author_Id", newName: "AuthorId");
            AlterColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            AlterColumn("dbo.Books", "AuthorId", c => c.Int());
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id");
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
