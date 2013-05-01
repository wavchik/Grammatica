namespace KakPishetsya.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Words",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        SmartName = c.String(nullable: false, maxLength: 64),
                        H1 = c.String(maxLength: 64),
                        Title = c.String(maxLength: 64),
                        Keywords = c.String(maxLength: 64),
                        Description = c.String(maxLength: 64),
                        InvalidDescription = c.String(maxLength: 64),
                        Explanation = c.String(nullable: false),
                        RuleId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rules", t => t.RuleId)
                .Index(t => t.RuleId);
            
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 64),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 64),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Words", new[] { "RuleId" });
            DropForeignKey("dbo.Words", "RuleId", "dbo.Rules");
            DropTable("dbo.Users");
            DropTable("dbo.Rules");
            DropTable("dbo.Words");
            DropIndex("OfferWords", new[] { "Id" });
            DropTable("OfferWords");
        }
    }
}
