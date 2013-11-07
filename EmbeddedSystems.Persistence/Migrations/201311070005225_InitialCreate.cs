// --------------------------------------------------------------------------------------------------------------------
// <copyright file="201311070005225_InitialCreate.cs" company="ESD">
//    Copyright 2013
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace EmbeddedSystems.Persistence.Migrations
{
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// <see cref="DbMigration"/> for creating the database.
    /// </summary>
    public partial class InitialCreate : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.CreateTable(
                "dbo.AudioFiles",
                c => new
                    {
                        ExhibitId = c.Int(nullable: false),
                        KnowledgeLevelId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => new { t.ExhibitId, t.KnowledgeLevelId, t.LanguageId })
                .ForeignKey("dbo.Exhibits", t => t.ExhibitId, cascadeDelete: true)
                .ForeignKey("dbo.KnowledgeLevels", t => t.KnowledgeLevelId, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: true)
                .Index(t => t.ExhibitId)
                .Index(t => t.KnowledgeLevelId)
                .Index(t => t.LanguageId);
            
            this.CreateTable(
                "dbo.Exhibits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HandsetKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "dbo.KnowledgeLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            this.CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MobileNumber = c.String(),
                        Address = c.String(),
                        KnowledgeLevel_Id = c.Int(nullable: false),
                        Language_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KnowledgeLevels", t => t.KnowledgeLevel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.Language_Id, cascadeDelete: true)
                .Index(t => t.KnowledgeLevel_Id)
                .Index(t => t.Language_Id);
            
            this.CreateTable(
                "dbo.HandsetRentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WhenRentedOut = c.DateTime(nullable: false),
                        RentalExpires = c.DateTime(nullable: false),
                        Pin = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                        Handset_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Handsets", t => t.Handset_Id, cascadeDelete: true)
                .Index(t => t.Customer_Id)
                .Index(t => t.Handset_Id);
            
            this.CreateTable(
                "dbo.Handsets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HandsetNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);            
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.HandsetRentals", "Handset_Id", "dbo.Handsets");
            this.DropForeignKey("dbo.HandsetRentals", "Customer_Id", "dbo.Customers");
            this.DropForeignKey("dbo.Customers", "Language_Id", "dbo.Languages");
            this.DropForeignKey("dbo.Customers", "KnowledgeLevel_Id", "dbo.KnowledgeLevels");
            this.DropForeignKey("dbo.AudioFiles", "LanguageId", "dbo.Languages");
            this.DropForeignKey("dbo.AudioFiles", "KnowledgeLevelId", "dbo.KnowledgeLevels");
            this.DropForeignKey("dbo.AudioFiles", "ExhibitId", "dbo.Exhibits");
            this.DropIndex("dbo.HandsetRentals", new[] { "Handset_Id" });
            this.DropIndex("dbo.HandsetRentals", new[] { "Customer_Id" });
            this.DropIndex("dbo.Customers", new[] { "Language_Id" });
            this.DropIndex("dbo.Customers", new[] { "KnowledgeLevel_Id" });
            this.DropIndex("dbo.AudioFiles", new[] { "LanguageId" });
            this.DropIndex("dbo.AudioFiles", new[] { "KnowledgeLevelId" });
            this.DropIndex("dbo.AudioFiles", new[] { "ExhibitId" });
            this.DropTable("dbo.Handsets");
            this.DropTable("dbo.HandsetRentals");
            this.DropTable("dbo.Customers");
            this.DropTable("dbo.Languages");
            this.DropTable("dbo.KnowledgeLevels");
            this.DropTable("dbo.Exhibits");
            this.DropTable("dbo.AudioFiles");
        }
    }
}
