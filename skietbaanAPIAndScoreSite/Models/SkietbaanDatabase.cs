namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkietbaanDatabase : DbContext
    {
        public SkietbaanDatabase()
            : base("name=SkietbaanDatabase1")
        {
        }

        public virtual DbSet<accesslog> accesslogs { get; set; }
        public virtual DbSet<competition> competitions { get; set; }
        public virtual DbSet<eventscore> eventscores { get; set; }
        public virtual DbSet<shoot> shoots { get; set; }
        public virtual DbSet<shoot_event> shoot_event { get; set; }
        public virtual DbSet<shooter> shooters { get; set; }
        public virtual DbSet<SkietbaanList> SkietbaanLists { get; set; }
        public virtual DbSet<vw_shoot> vw_shoot { get; set; }
        public virtual DbSet<vw_yearlyrating> vw_yearlyrating { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accesslog>()
                .Property(e => e.msisdn)
                .IsUnicode(false);

            modelBuilder.Entity<competition>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<shoot>()
                .Property(e => e.msisdn)
                .IsUnicode(false);

            modelBuilder.Entity<shoot>()
                .Property(e => e.score)
                .HasPrecision(5, 2);

            modelBuilder.Entity<shoot>()
                .Property(e => e.yearlytop4score)
                .HasPrecision(5, 2);

            modelBuilder.Entity<shoot>()
                .Property(e => e.monthlybestscore)
                .HasPrecision(5, 2);

            modelBuilder.Entity<shooter>()
                .Property(e => e.msisdn)
                .IsUnicode(false);

            modelBuilder.Entity<shooter>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<shooter>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<shooter>()
                .Property(e => e.pws)
                .IsUnicode(false);

            modelBuilder.Entity<SkietbaanList>()
                .Property(e => e.Cell)
                .IsUnicode(false);

            modelBuilder.Entity<SkietbaanList>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.Competition)
                .IsUnicode(false);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.score)
                .HasPrecision(5, 2);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.msisdn)
                .IsUnicode(false);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.yearlytop4score)
                .HasPrecision(5, 2);

            modelBuilder.Entity<vw_shoot>()
                .Property(e => e.monthlybestscore)
                .HasPrecision(5, 2);

            modelBuilder.Entity<vw_yearlyrating>()
                .Property(e => e.Competition)
                .IsUnicode(false);

            modelBuilder.Entity<vw_yearlyrating>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<vw_yearlyrating>()
                .Property(e => e.surname)
                .IsUnicode(false);

            modelBuilder.Entity<vw_yearlyrating>()
                .Property(e => e.msisdn)
                .IsUnicode(false);

            modelBuilder.Entity<vw_yearlyrating>()
                .Property(e => e.yearlytop4score)
                .HasPrecision(5, 2);
        }
    }
}
