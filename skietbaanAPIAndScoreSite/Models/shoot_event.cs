namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class shoot_event
    {
        [Key]
        public int pkid { get; set; }

        public int? fkshooter { get; set; }

        public DateTime? entrydate { get; set; }
    }
}
