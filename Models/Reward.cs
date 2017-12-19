using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChoreScore.Models
{
    public class Reward
    {
        public int Id { get; set; }
        public string RewardTitle { get; set; }
        public string Description { get; set; }
        public bool isRedeemed { get; set; }
        public float PointValue { get; set; }

        public virtual ApplicationUser User { get; set; }
    }

    public class RewardViewModel
    {
        public int Id { get; set; }
        public string RewardTitle { get; set; }
        public string Description { get; set; }
        public bool isRedeemed { get; set; }
        public float PointValue { get; set; }

        public string UserId { get; set; }
    }
}