namespace skietbaanAPIAndScoreSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("shooter")]
    public partial class shooter
    {
       
        public int pkid { get; set; }

        [Key]
        [StringLength(50)]
        public string msisdn { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string surname { get; set; }

        public bool? bmember { get; set; }

        [StringLength(50)]
        public string pws { get; set; }

        [NotMapped]
        public string Detail
        { get {return name+" "+surname+" "+msisdn ; } }
    }
}
