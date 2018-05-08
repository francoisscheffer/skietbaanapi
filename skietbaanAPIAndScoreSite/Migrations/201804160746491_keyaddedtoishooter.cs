namespace skietbaanAPIAndScoreSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keyaddedtoishooter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.accesslog",
                c => new
                    {
                        pkid = c.Int(nullable: false, identity: true),
                        entrdate = c.DateTime(),
                        msisdn = c.String(maxLength: 50, unicode: false),
                        bsuccsess = c.Boolean(),
                    })
                .PrimaryKey(t => t.pkid);
            
            CreateTable(
                "dbo.competition",
                c => new
                    {
                        pkid = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.pkid);
            
            CreateTable(
                "dbo.eventscore",
                c => new
                    {
                        pkid = c.Int(nullable: false, identity: true),
                        fkcompetition = c.Int(),
                        score = c.Double(),
                    })
                .PrimaryKey(t => t.pkid);
            
            CreateTable(
                "dbo.shoot_event",
                c => new
                    {
                        pkid = c.Int(nullable: false, identity: true),
                        fkshooter = c.Int(),
                        entrydate = c.DateTime(),
                    })
                .PrimaryKey(t => t.pkid);
            
            CreateTable(
                "dbo.shooter",
                c => new
                    {
                        msisdn = c.String(nullable: false, maxLength: 50, unicode: false),
                        pkid = c.Int(nullable: false),
                        name = c.String(maxLength: 50, unicode: false),
                        surname = c.String(maxLength: 50, unicode: false),
                        bmember = c.Boolean(),
                        pws = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.msisdn);
            
            CreateTable(
                "dbo.shoot",
                c => new
                    {
                        pkid = c.Int(nullable: false, identity: true),
                        msisdn = c.String(maxLength: 50, unicode: false),
                        entrydate = c.DateTime(),
                        fkcompetition = c.Int(),
                        score = c.Decimal(precision: 5, scale: 2),
                        tl = c.Int(),
                        tr = c.Int(),
                        bl = c.Int(),
                        br = c.Int(),
                        _month = c.Int(),
                        compavg = c.Double(),
                        _year = c.Int(),
                        yearlytop4score = c.Decimal(precision: 5, scale: 2),
                        monthlybestscore = c.Decimal(precision: 5, scale: 2),
                    })
                .PrimaryKey(t => t.pkid)
                .ForeignKey("dbo.competition", t => t.fkcompetition)
                .ForeignKey("dbo.shooter", t => t.msisdn)
                .Index(t => t.msisdn)
                .Index(t => t.fkcompetition);
            
            CreateTable(
                "dbo.SkietbaanList",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Cell = c.String(maxLength: 50, unicode: false),
                        Surname = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.vw_shoot",
                c => new
                    {
                        ShooterId = c.Int(nullable: false),
                        pkid = c.Int(nullable: false),
                        Competition = c.String(maxLength: 50, unicode: false),
                        score = c.Decimal(precision: 5, scale: 2),
                        name = c.String(maxLength: 50, unicode: false),
                        surname = c.String(maxLength: 50, unicode: false),
                        entrydate = c.DateTime(),
                        msisdn = c.String(maxLength: 50, unicode: false),
                        tl = c.Int(),
                        tr = c.Int(),
                        bl = c.Int(),
                        br = c.Int(),
                        _month = c.Int(),
                        compavg = c.Double(),
                        fkcompetition = c.Int(),
                        _year = c.Int(),
                        yearlytop4score = c.Decimal(precision: 5, scale: 2),
                        monthlybestscore = c.Decimal(precision: 5, scale: 2),
                    })
                .PrimaryKey(t => new { t.ShooterId, t.pkid });
            
            CreateTable(
                "dbo.vw_yearlyrating",
                c => new
                    {
                        ShooterId = c.Int(nullable: false),
                        Competition = c.String(maxLength: 50, unicode: false),
                        fkcompetition = c.Int(),
                        name = c.String(maxLength: 50, unicode: false),
                        surname = c.String(maxLength: 50, unicode: false),
                        msisdn = c.String(maxLength: 50, unicode: false),
                        yearlytop4score = c.Decimal(precision: 5, scale: 2),
                        _year = c.Int(),
                    })
                .PrimaryKey(t => t.ShooterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.shoot", "msisdn", "dbo.shooter");
            DropForeignKey("dbo.shoot", "fkcompetition", "dbo.competition");
            DropIndex("dbo.shoot", new[] { "fkcompetition" });
            DropIndex("dbo.shoot", new[] { "msisdn" });
            DropTable("dbo.vw_yearlyrating");
            DropTable("dbo.vw_shoot");
            DropTable("dbo.SkietbaanList");
            DropTable("dbo.shoot");
            DropTable("dbo.shooter");
            DropTable("dbo.shoot_event");
            DropTable("dbo.eventscore");
            DropTable("dbo.competition");
            DropTable("dbo.accesslog");
        }
    }
}
