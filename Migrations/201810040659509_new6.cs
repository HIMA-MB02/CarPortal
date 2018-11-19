namespace VahanBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        ImageData = c.Binary(),
                        ImageMimeType = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Model = c.String(nullable: false),
                        FuelType = c.String(nullable: false),
                        TransmissionType = c.String(nullable: false),
                        Owners = c.String(nullable: false),
                        Kilometers = c.String(nullable: false),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.CarId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImageDataA = c.Binary(),
                        ImageMimeTypeA = c.String(),
                        Car_CarId = c.Int(),
                    })
                .PrimaryKey(t => t.ImageId)
                .ForeignKey("dbo.Cars", t => t.Car_CarId)
                .Index(t => t.Car_CarId);
            
            CreateTable(
                "dbo.MakeFilters",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        isSelected = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Images", "Car_CarId", "dbo.Cars");
            DropIndex("dbo.Images", new[] { "Car_CarId" });
            DropTable("dbo.MakeFilters");
            DropTable("dbo.Images");
            DropTable("dbo.Cars");
            DropTable("dbo.BlogPosts");
        }
    }
}
