namespace S3Train.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddProductAdvertisementTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductAdvertisement",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        EventUrl = c.String(nullable: false, maxLength: 50),
                        EventUrlCaption = c.String(maxLength: 10),
                        ImagePath = c.String(nullable: false, maxLength: 200),
                        AdType = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductAdvertisement");
        }
    }
}
