using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimFit360.Model
{
    public class SessionPart
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int DifficultyLevel { get; set; }
        public int DistanceRan {  get; set; }
        public DateTime CreatedAt { get; set; }

        [InverseProperty(nameof(Session.Id))]
        public int SessionId { get; set; }
    }
}
