namespace Library.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMsSqlSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorMsSqls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookMsSqls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Year = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AuthorMsSqls", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.AuthorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookMsSqls", "AuthorId", "dbo.AuthorMsSqls");
            DropIndex("dbo.BookMsSqls", new[] { "AuthorId" });
            DropTable("dbo.BookMsSqls");
            DropTable("dbo.AuthorMsSqls");
        }
    }
}
