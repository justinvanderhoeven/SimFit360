using SimFit360_.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimFit360.Model
{
    public class User
    {
        public static User LoggedInUser { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public ICollection<Badge> Badges { get; set; }
        public ICollection<UserBadge> UserBadges { get; set; }

    }
}
