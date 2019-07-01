namespace Photo_cipher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Photos", "bottomKey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "bottomKey", c => c.String(nullable: false, unicode: false, storeType: "text"));
        }
    }
}
