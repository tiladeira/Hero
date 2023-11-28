namespace GestaoSuperHeroi.API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SugarLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Description = c.String(nullable: false),
                        MeasuredAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SugarLevels");
        }
    }
}
