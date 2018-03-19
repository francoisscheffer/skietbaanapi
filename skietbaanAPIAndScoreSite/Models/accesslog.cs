namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("accesslog")]
    public partial class accesslog
    {
        [Key]
        public int pkid { get; set; }

        public DateTime? entrdate { get; set; }

        [StringLength(50)]
        public string msisdn { get; set; }

        public bool? bsuccsess { get; set; }
    }
}
