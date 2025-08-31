namespace LinqQueryEf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmpDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        empusername = c.String(),
                        emppassword = c.String(),
                        empemail = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmpDetails");
        }
    }
}
