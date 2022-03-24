using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class CafeRepo
    {
        private readonly List<MenuItem> _menuItems = new List<MenuItem>();
        public bool AddMenuItem(MenuItem item)
        {
            int startingCount = _menuItems.Count();
            _menuItems.Add(item);
            bool wasAdded = (_menuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public bool AddIngredientToItem(MenuItem item, string ingredient)
        {
            int startingCount = item.Ingredients.Count();
            item.Ingredients.Add(ingredient);
            return item.Ingredients.Count > startingCount ? true : false;
        }
        public MenuItem GetMenuItemByNumber(int number)
        {
            return _menuItems.Where(i => i.MealNumber == number).SingleOrDefault();
        }
        public List<MenuItem> GetAllMenuItems()
        {
            return _menuItems.OrderBy(i => i.MealNumber).ToList();
        }
        public bool RemoveMenuItem(MenuItem item)
        {
            bool removeResult = _menuItems.Remove(item);
            return removeResult;
        }
    }
}
