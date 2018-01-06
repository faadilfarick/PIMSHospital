namespace ThePIMS_Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defalutLogin : DbMigration
    {
        public override void Up()
        {
            Sql("insert into [dbo].[Users]([Name],[email],[role],[contact],[Password],[dob])values('Default User','admin@a.com','admin',000000,'123','1900-01-01 00:00:00.000')");

        }

    public override void Down()
        {
        }
    }
}
