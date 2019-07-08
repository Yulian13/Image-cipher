namespace Photo_cipher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compositions", "IdFirstPhoto", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Compositions", "IdFirstPhoto");
        }
    }
}
