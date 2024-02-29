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
        public int Order { get; set; }
        public int KcalBurned { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
    }
}
