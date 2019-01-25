namespace TestTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adduserstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        SkypeLogin = c.String(),
                        Signature = c.String(),
                        Avatar = c.String(),
                        Role = c.Int(nullable: false),
                        IsDisabled = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            this.DropTable("dbo.Users");
        }
    }
}
