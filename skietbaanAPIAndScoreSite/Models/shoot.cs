namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("shoot")]
    public partial class shoot
    {
        [Key]
        public int pkid { get; set; }

        [ForeignKey("Shooter")]
        [StringLength(50)]
        public string msisdn { get; set; }
        public virtual shooter Shooter { get; set; }



        public DateTime? entrydate { get; set; }

        [ForeignKey("Compititions")]
        public int? fkcompetition { get; set; }
        public virtual competition Compititions { get; set; }

        public decimal? score { get; set; }

        public int? tl { get; set; }

        public int? tr { get; set; }

        public int? bl { get; set; }

        public int? br { get; set; }

        [Column("_month")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? C_month { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? compavg { get; set; }

        [Column("_year")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? C_year { get; set; }

        public decimal? yearlytop4score { get; set; }

        public decimal? monthlybestscore { get; set; }
    }
}
