namespace ContactWeb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateContactAndStateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 50),
                    LastName = c.String(nullable: false, maxLength: 250),
                    Email = c.String(nullable: false, maxLength: 250),
                    PhonePrimary = c.String(nullable: false, maxLength: 15),
                    PhoneSecondary = c.String(maxLength: 15),
                    Birthday = c.DateTime(nullable: false),
                    StreetAddress1 = c.String(maxLength: 4),
                    StreetAddress2 = c.String(maxLength: 4),
                    City = c.String(nullable: false, maxLength: 50),
                    StateId = c.Int(nullable: false),
                    Zip = c.String(nullable: false, maxLength: 50),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.StateId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.States",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Abbreviation = c.String(nullable: false, maxLength: 4),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contacts", "StateId", "dbo.States");
            DropIndex("dbo.Contacts", new[] { "UserId" });
            DropIndex("dbo.Contacts", new[] { "StateId" });
            DropTable("dbo.States");
            DropTable("dbo.Contacts");
        }
    }
}
