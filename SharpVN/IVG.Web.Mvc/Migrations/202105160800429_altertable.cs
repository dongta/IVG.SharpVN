namespace IVG.Web.Mvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altertable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Users", "UserType", c => c.Int());

        }

        public override void Down()
        {
            DropColumn("dbo.tbl_Users", "UserType");
        }
    }
}
