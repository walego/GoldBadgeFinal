using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsRepository
{
    public class Outing
    {
        public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
        public Outing() { }
        public Outing(int attended, DateTime date, decimal cost, int type)
        {
            NumberAttended = attended;
            EventDate = date;
            TotalCost = cost;
            Type = (EventType)type;
        }
        public Outing(int attended, DateTime date, decimal cost, EventType type)
        {
            NumberAttended = attended;
            EventDate = date;
            TotalCost = cost;
            Type = type;
        }
        public int NumberAttended { get; set; }
        public DateTime EventDate { get; set; }
        public decimal CostPerPerson
        {
            get
            {
                return TotalCost / NumberAttended;
            }
        }
        public decimal TotalCost { get; set; }
        public EventType Type { get; set; }
    }
}
