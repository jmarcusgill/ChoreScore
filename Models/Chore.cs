using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoreScore.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string ChoreName { get; set; }
        public float PointsAssigned { get; set; }
        public bool isAssigned { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public virtual ApplicationUser user { get; set; }
    }

    public class ChoreViewModel
    {
        public int Id { get; set; }
        public string ChoreName { get; set; }
        public float PointsAssigned { get; set; }
        public bool isAssigned { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedDate { get; set; }

        public string UserId { get; set; }
    }
}