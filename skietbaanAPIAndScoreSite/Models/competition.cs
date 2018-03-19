namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("competition")]
    public partial class competition
    {
        [Key]
        public int pkid { get; set; }

        [StringLength(50)]
        public string description { get; set; }
    }
}
