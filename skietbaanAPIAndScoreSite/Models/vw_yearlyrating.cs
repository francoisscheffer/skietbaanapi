namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vw_yearlyrating
    {
        [StringLength(50)]
        public string Competition { get; set; }

        public int? fkcompetition { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShooterId { get; set; }

        [StringLength(50)]
        public string msisdn { get; set; }

        public decimal? yearlytop4score { get; set; }

        [Column("_year")]
        public int? C_year { get; set; }
    }
}
