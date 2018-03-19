namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_shoot
    {
        [StringLength(50)]
        public string Competition { get; set; }

        public decimal? score { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShooterId { get; set; }

        public DateTime? entrydate { get; set; }

        [StringLength(50)]
        public string msisdn { get; set; }

        public int? tl { get; set; }

        public int? tr { get; set; }

        public int? bl { get; set; }

        public int? br { get; set; }

        [Column("_month")]
        public int? C_month { get; set; }

        public double? compavg { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int pkid { get; set; }

        public int? fkcompetition { get; set; }

        [Column("_year")]
        public int? C_year { get; set; }

        public decimal? yearlytop4score { get; set; }

        public decimal? monthlybestscore { get; set; }
    }
}
