using SimFit360_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Pwm;

namespace SimFit360.Model
{
    public class Badge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxProgress { get; set; }
        public int? Tier { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<UserBadge> UserBadges { get; set; }
    }
}

