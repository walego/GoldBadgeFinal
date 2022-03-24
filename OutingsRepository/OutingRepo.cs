using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsRepository
{
    public class OutingRepo
    {
        private readonly List<Outing> _outings = new List<Outing>();

        //Add new outing
        public bool AddNewOuting(Outing outing)
        {
            int startingCount = _outings.Count();
            _outings.Add(outing);
            bool wasAdded = (_outings.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Return list of all outings
        public List<Outing> GetAllOutings()
        {
            return _outings.OrderByDescending(o => o.EventDate).ToList();
        }
        //Return cost of all outings
        public decimal GetTotalCostAll()
        {
            decimal cost = 0;
            foreach(Outing outing in _outings)
            {
                cost = outing.TotalCost + cost;
            }
            return cost;
        }
        //Return cost of all outings by type
        public decimal GetTotalCostByType(Outing.EventType type)
        {
            decimal cost = 0;
            foreach(Outing outing in _outings)
            {
                if (outing.Type == type)
                {
                    cost = outing.TotalCost + cost;
                }
            }
            return cost;
        }
    }
}
