using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Pwm;

namespace SimFit360.Model
{
    public class Badges
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime AchievedAt { get; set; }
        public int? MaxProgress { get; set; }
        public int Progress { get; set; }
        public int? Tier { get; set; }

        [InverseProperty(nameof(User.Id))]
        public int UserId { get ; set; }
    }
}
