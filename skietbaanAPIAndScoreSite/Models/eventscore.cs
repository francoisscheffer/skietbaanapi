namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eventscore")]
    public partial class eventscore
    {
        [Key]
        public int pkid { get; set; }

        public int? fkcompetition { get; set; }

        public double? score { get; set; }
    }
}
