namespace KakPishetsya.Common.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexesToWordsRulesUsers : DbMigration
    {
        public override void Up()
        {
            CreateIndex("Words", "Name", true, "IX_Word_Name");
            CreateIndex("Words", "SmartName", true, "IX_Word_SmartName");

            CreateIndex("Rules", "Name", true, "IX_Rules_Name");

            CreateIndex("Users", "Login", true, "IX_Users_Login");
        }
        
        public override void Down()
        {
            DropIndex("Words", "IX_Word_Name");
            DropIndex("Words", "IX_Word_SmartName");

            DropIndex("Rules", "IX_Rules_Name");

            DropIndex("Users", "IX_Users_Login");
        }
    }
}
