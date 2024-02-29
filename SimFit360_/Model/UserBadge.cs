using SimFit360.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace SimFit360_.Model
{
    public class UserBadge
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BadgeId { get; set; }
        public DateTime AchievedAt { get; set; }
        public int Progress { get; set; }

        public SimFit360.Model.User Users { get; set; }
        public Badge Badge { get; set; }
    }
}
