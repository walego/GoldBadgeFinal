using CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp
{
    public class ProgramUI
    {
        private CafeRepo _cafe = new CafeRepo();
        public void Run()
        {
            SeedContent();
            Menu();
        }
        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Please enter the number of the option you would like:\n" +
                    "1: Add a new item to the menu\n" +
                    "2: See all menu items\n" +
                    "3: Remove an item from the menu\n" +
                    "4: Exit Program");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddItemToMenu();
                        break;
                    case "2":
                        SeeAllMenuItems();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        AnyKey();
                        break;
                }
            }
        }
        private void AddItemToMenu()
        {
            Console.Clear();
            MealNumberList();
            Console.Write("Enter meal number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter meal name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the meal's description:");
            string description = Console.ReadLine();
            Console.Write("Enter meal price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            MenuItem item = new MenuItem(number, name, description, price);
            Console.WriteLine("Enter each ingredient individually\n" +
                "When finished please enter 'stop' or press Enter again");
            bool addIngredient = true;
            while (addIngredient)
            {
                string ingredient = Console.ReadLine();
                if (ingredient == "stop" || ingredient == "")
                {
                    addIngredient = false;
                }
                else
                {
                    bool added = _cafe.AddIngredientToItem(item, ingredient);
                    if (!added)
                    {
                        Console.WriteLine("Something went wrong adding that ingredient");
                    }
                }
            }
            if (_cafe.AddMenuItem(item))
            {
                Console.WriteLine("Menu item successfully created!");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong adding the new item.");
                AnyKey();
            }
        }
        private void SeeAllMenuItems()
        {
            Console.Clear();
            List<MenuItem> menuList = _cafe.GetAllMenuItems();
            foreach (MenuItem item in menuList)
            {
                DisplayMenuItem(item);
            }
            AnyKey();
        }
        private void DeleteMenuItem()
        {
            bool pickItem = true;
            while (pickItem)
            {
                Console.Clear();
                MealNumberList();
                Console.Write("Enter meal number of menu item you want to remove: ");
                int number = Convert.ToInt32(Console.ReadLine());
                MenuItem item = _cafe.GetMenuItemByNumber(number);
                Console.WriteLine("Enter 'y' if this is the item you want to delete");
                DisplayMenuItem(item);
                string checkDelete = Console.ReadLine();
                if (checkDelete.ToLower() == "y")
                {
                    pickItem = false;
                    if(_cafe.RemoveMenuItem(item))
                    {
                        Console.WriteLine("Item successfully removed");
                        AnyKey();
                    }
                    else
                    {
                        Console.WriteLine("Item was not removed");
                        AnyKey();
                    }

                }
                else
                {
                    Console.WriteLine("Enter 'y' if you want to return to the main menu");
                    string checkMenu = Console.ReadLine();
                    if (checkMenu.ToLower() == "y")
                    {
                        pickItem = false;
                    }
                }
            }

        }
        private void DisplayMenuItem(MenuItem item)
        {
            string fullList = string.Join(", ", item.Ingredients);
            string price = String.Format("{0:C}", item.Price);
            Console.WriteLine($"#{item.MealNumber} {item.MealName}\n" +
                $"{item.Description}\n" +
                $"Ingredients: {fullList}\n" +
                $"{price}\n");
        }
        private void MealNumberList()
        {
            Console.Write("Currently used meal numbers:");
            var repo = _cafe.GetAllMenuItems();
            foreach (MenuItem menuItem in repo)
            {
                Console.Write($"  {menuItem.MealNumber}");
            }
            Console.WriteLine("");
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            MenuItem itemOne = new MenuItem(1, "Grilled Cheese", "A grilled cheese sandwich", 3.15m);
            itemOne.Ingredients.Add("White Bread");
            itemOne.Ingredients.Add("American Cheese");
            _cafe.AddMenuItem(itemOne);
            MenuItem itemTwo = new MenuItem(2, "Turducken", "It's a chicken inside of a duck inside of a turkey", 11m);
            itemTwo.Ingredients.Add("Turkey");
            itemTwo.Ingredients.Add("Duck");
            itemTwo.Ingredients.Add("Chicken");
            _cafe.AddMenuItem(itemTwo);
        }
    }
}
