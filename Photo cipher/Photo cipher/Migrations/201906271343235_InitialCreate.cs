namespace Photo_cipher.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Compositions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, unicode: false, storeType: "text"),
                        NumberPhotos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        bottomKey = c.String(nullable: false, unicode: false, storeType: "text"),
                        RightKey = c.String(nullable: false, unicode: false, storeType: "text"),
                        CompositionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Compositions", t => t.CompositionId)
                .Index(t => t.CompositionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "CompositionId", "dbo.Compositions");
            DropIndex("dbo.Photos", new[] { "CompositionId" });
            DropTable("dbo.Photos");
            DropTable("dbo.Compositions");
        }
    }
}
