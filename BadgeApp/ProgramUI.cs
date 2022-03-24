using BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeApp
{
    public class ProgramUI
    {
        private readonly BadgeRepo _badgeRepo = new BadgeRepo();
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
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Remove all doors from a badge\n" +
                    "5. Delete a badge\n" +
                    "6. Exit Program\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        RemoveAllDoors();
                        break;
                    case "5":
                        RemoveBadge();
                        break;
                    case "6":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        AnyKey();
                        break;
                }

            }
        }
        private void AddBadge()
        {
            Console.Clear();
            DisplayBadgeList();
            Console.Write("What is the number on the badge: ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            if (_badgeRepo.CreateNewBadge(badgeNumber))
            {
                Console.WriteLine("");
                AddDoor(badgeNumber);
            }
            else
            {
                Console.WriteLine("Badge not created.");
                AnyKey();
            }
        }
        private void EditBadge()
        {
            bool editBadge = true;
            while (editBadge)
            {
                Console.Clear();
                DisplayBadgeList();
                Console.Write("What is the badge number to update? ");
                int badgeNumber = Convert.ToInt32(Console.ReadLine());
                if (_badgeRepo.BadgeDictionary.ContainsKey(badgeNumber))
                {
                    Console.WriteLine($"\n" +
                        $"{DisplayBadgeAccess(badgeNumber)}\n" +
                        $"\n" +
                        $"What would you like to do?\n" +
                        $"\n" +
                        $"  1. Remove a door\n" +
                        $"  2. Add a door.\n");
                    string userInput = Console.ReadLine();
                    Console.WriteLine("");
                    switch (userInput)
                    {
                        case "1":
                            RemoveDoor(badgeNumber);
                            editBadge = false;
                            break;
                        case "2":
                            AddDoor(badgeNumber);
                            editBadge = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option selected. Returning to menu");
                            editBadge = false;
                            AnyKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("No badge with that ID exists");
                    AnyKey();
                }
            }
        }
        private void AddDoor(int badgeNumber)
        {
            bool moreDoors = true;
            while (moreDoors)
            {
                Console.Write("List a door that it needs access to: ");
                string addDoor = Console.ReadLine();
                addDoor = addDoor.ToUpper();
                if (_badgeRepo.AddDoor(badgeNumber, addDoor))
                {
                    Console.WriteLine($"");
                    Console.Write("Any other doors(y/n)? ");
                    string userInput = Console.ReadLine();
                    Console.WriteLine("");
                    if (userInput.ToLower() != "y")
                    {
                        moreDoors = false;
                    }
                }
                else
                {
                    Console.WriteLine("Door was not added");
                    AnyKey();
                    moreDoors = false;
                }
            }
        }
        private void RemoveDoor(int badgeNumber)
        {
            bool moreDoors = true;
            while (moreDoors)
            {
                Console.Write("Which door would you like to remove? ");
                string removeDoor = Console.ReadLine();
                removeDoor = removeDoor.ToUpper();
                if (_badgeRepo.RemoveDoor(badgeNumber, removeDoor))
                {
                    Console.WriteLine($"\n" +
                        $"Door Removed.\n" +
                        $"\n" +
                        $"{DisplayBadgeAccess(badgeNumber)}\n");
                    Console.Write("Any other doors(y/n)? ");
                    string userInput = Console.ReadLine();
                    Console.WriteLine("");
                    if (userInput.ToLower() != "y")
                    {
                        moreDoors = false;
                    }
                }
                else
                {
                    Console.WriteLine("Door was not removed");
                    AnyKey();
                    moreDoors = false;
                }
            }
        }
        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Badge#      Door Access");
            foreach (KeyValuePair<int, List<string>> badges in _badgeRepo.BadgeDictionary)
            {
                AllBadgeDisplay(badges.Key);
            }
            AnyKey();
        }
        private void RemoveAllDoors()
        {
            Console.Clear();
            DisplayBadgeList();
            Console.Write("Which badge do you want to remove all doors from? ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n" +
                $"{DisplayBadgeAccess(badgeNumber)}\n");
            Console.Write("Input 1 to confirm door deletion(any other input will cancel): ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                if (_badgeRepo.DeleteAllDoors(badgeNumber))
                {
                    Console.WriteLine("\n" +
                        "All doors removed\n");
                    AnyKey();
                }
                else
                {
                    Console.WriteLine("\n" +
                        "Doors were not removed\n");
                    AnyKey();
                }
            }
            else
            {
                Console.WriteLine("\n" +
                    "Doors were not removed\n");
                AnyKey();
            }
        }
        private void RemoveBadge()
        {
            Console.Clear();
            DisplayBadgeList();
            Console.Write("Which badge do you want to remove from the system? ");
            int badgeNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            Console.Write("Input 1 to confirm badge deletion(any other input will cancel: ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                if (_badgeRepo.DeleteBadge(badgeNumber))
                {
                    Console.WriteLine("\n" +
                        "Badge Removed\n");
                    AnyKey();
                }
                else
                {
                    Console.WriteLine("\n" +
                        "Badge not removed\n");
                    AnyKey();
                }
            }
            else
            {
                Console.WriteLine("\n" +
                    "Badge not removed\n");
                AnyKey();
            }
        }
        // Helper Methods
        private void DisplayBadgeList()
        {
            Console.Write("Badge List: ");
            foreach(KeyValuePair<int, List<string>> key in _badgeRepo.BadgeDictionary)
            {
                Console.Write($"{key.Key} ");
            }
            Console.WriteLine("");
        }
        private string DisplayBadgeAccess(int badgeNumber)
        {
            string doorList = string.Join(" & ", _badgeRepo.BadgeDictionary[badgeNumber]);
            return $"{badgeNumber} has access to doors {doorList}.";
        }
        private string DisplayBadgeAccessComma(int badgeNumber)
        {
            string doorList = string.Join(", ", _badgeRepo.BadgeDictionary[badgeNumber]);
            return $"{doorList}";
        }
        private void AllBadgeDisplay(int badgeNumber)
        {
            Console.WriteLine($"{badgeNumber}       {DisplayBadgeAccessComma(badgeNumber)}");
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void SeedContent()
        {
            List<string> badgeA = new List<string> { "A7" };
            List<string> badgeB = new List<string> { "A1", "A4", "B1", "B2" };
            List<string> badgeC = new List<string> { "A4", "A5" };
            _badgeRepo.BadgeDictionary.Add(12345, badgeA);
            _badgeRepo.BadgeDictionary.Add(22345, badgeB);
            _badgeRepo.BadgeDictionary.Add(32345, badgeC);
        }
    }
}
