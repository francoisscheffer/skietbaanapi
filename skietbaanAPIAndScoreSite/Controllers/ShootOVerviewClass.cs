using System;

namespace skietbaanAPIAndScoreSite.Controllers
{
    internal class ShootOVerviewClass
    {
        public DateTime? Date { get; set; }
        public string Competition { get; set; }
        public string Name { get; set; }
        public decimal? Score { get; set; }
        public double? AvgMonthlyScore { get; set; }
        public decimal? MonthBest { get; set; }
        public decimal? YealyScore { get; set; }
        public int? Month { get; set; }
    }
}