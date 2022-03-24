using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeRepository
{
    public class BadgeRepo
    {
        public Dictionary<int, List<string>> BadgeDictionary = new Dictionary<int, List<string>>();
        public bool CreateNewBadge(int badgeNumber)
        {
            BadgeDictionary.Add(badgeNumber, new List<string>());
            if (BadgeDictionary.ContainsKey(badgeNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Dictionary<int, List<string>> GetBadgeList()
        {
            return BadgeDictionary;
        }
        public bool AddDoor(int badgeNumber, string door)
        {
            if (BadgeDictionary.ContainsKey(badgeNumber))
            {
                List<string> allDoors = BadgeDictionary[badgeNumber];
                int startingCount = allDoors.Count();
                allDoors.Add(door);
                BadgeDictionary[badgeNumber] = allDoors;
                return allDoors.Count > startingCount && BadgeDictionary[badgeNumber] == allDoors ? true : false;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDoor(int badgeNumber, string door)
        {
            if (BadgeDictionary.ContainsKey(badgeNumber))
            {
                List<string> allDoors = BadgeDictionary[badgeNumber];
                if (allDoors.Contains(door))
                {

                    int startingCount = allDoors.Count();
                    allDoors.Remove(door);
                    BadgeDictionary[badgeNumber] = allDoors;
                    return allDoors.Count < startingCount && BadgeDictionary[badgeNumber] == allDoors ? true : false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool DeleteAllDoors(int badgeNumber)
        {
            if (BadgeDictionary.ContainsKey(badgeNumber))
            {
                BadgeDictionary[badgeNumber] = new List<string>();
                return BadgeDictionary[badgeNumber].Count == 0 ? true : false;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteBadge(int badgeNumber)
        {
            if (BadgeDictionary.ContainsKey(badgeNumber))
            {
                return BadgeDictionary.Remove(badgeNumber) ? true : false;
            }
            else
            {
                return false;
            }
        }
    }
}
