namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SkietbaanList")]
    public partial class SkietbaanList
    {
        [StringLength(50)]
        public string Cell { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public int id { get; set; }
    }
}
