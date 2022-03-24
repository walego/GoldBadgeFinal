using OutingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outings_App
{
    public class ProgramUI
    {
        private OutingRepo _outingRepo = new OutingRepo();
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
                Console.WriteLine("Please enter the number of the option you want to select:\n" +
                    "1: Add a new outing to database\n" +
                    "2: Get a list of all outings\n" +
                    "3: Get the total cost of all outings\n" +
                    "4: Get the total cost of all outings separated by type\n" +
                    "5: Exit Program");
                switch (Console.ReadLine())
                {
                    case "1":
                        AddNewOuting();
                        break;
                    case "2":
                        GetListOfAllOutings();
                        break;
                    case "3":
                        GetTotalCostAll();
                        break;
                    case "4":
                        GetTotalCostByType();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        AnyKey();
                        break;
                }
            }
        }
        private void AddNewOuting()
        {
            Console.Clear();
            Console.WriteLine("Please enter the date of the event");
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Day: ");
            int day = Convert.ToInt32(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);
            Console.Write("Number of attendees: ");
            int people = Convert.ToInt32(Console.ReadLine());
            Console.Write("Event Cost: $");
            decimal cost = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter type of outing:\n" +
                "1: Golf\n" +
                "2: Bowling\n" +
                "3: Amusement Park\n" +
                "4: Concert\n");
            int type = Convert.ToInt32(Console.ReadLine());
            Outing outing = new Outing(people, date, cost, type);
            if (_outingRepo.AddNewOuting(outing))
            {
                Console.WriteLine("Outing successfully added");
                AnyKey();
            }
            else
            {
                Console.WriteLine("Something went wrong");
                AnyKey();
            }
        }
        private void GetListOfAllOutings()
        {
            Console.Clear();
            List<Outing> outings = _outingRepo.GetAllOutings();
            foreach (Outing outing in outings)
            {
                OutingDisplay(outing);
            }
            AnyKey();
        }
        private void GetTotalCostAll()
        {
            Console.Clear();
            decimal totalCost = _outingRepo.GetTotalCostAll();
            Console.WriteLine("Total Cost of Outings: " + totalCost.ToString("C"));
            AnyKey();
        }
        private void GetTotalCostByType()
        {
            int number = 1;
            Console.Clear();
            while (number <= 4)
            {
                Outing.EventType type = (Outing.EventType)number;
                decimal cost = _outingRepo.GetTotalCostByType(type);
                string costFormat = String.Format("{0:C}", cost);
                Console.WriteLine($"Combined {type} outing costs: {costFormat}");
                number++;
            }
            AnyKey();
        }
        private void AnyKey()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        private void OutingDisplay(Outing outing)
        {
            string costFormat = String.Format("{0:C}", outing.CostPerPerson);
            string totalCostFormat = String.Format("{0:C}", outing.TotalCost);
            Console.WriteLine($"{outing.EventDate.ToString("MM/dd/yyyy")} {outing.Type}\n" +
                $"Attendees: {outing.NumberAttended} Cost Per Person: {costFormat}\n" +
                $"Total Cost: {totalCostFormat}\n");
        }
        private void SeedContent()
        {
            DateTime dateTimeOne = new DateTime(2022, 02, 25);
            DateTime dateTimeTwo = new DateTime(2022, 02, 22);
            DateTime dateTimeThree = new DateTime(2022, 03, 07);
            DateTime dateTimeFour = new DateTime(2022, 03, 12);
            DateTime dateTimeFive = new DateTime(2022, 01, 28);
            DateTime dateTimeSix = new DateTime(2022, 03, 15);
            Outing outingOne = new Outing(4, dateTimeOne, 150m, 1);
            Outing outingTwo = new Outing(8, dateTimeTwo, 90.50m, 2);
            Outing outingThree = new Outing(12, dateTimeThree, 300m, 3);
            Outing outingFour = new Outing(6, dateTimeFour, 192m, 4);
            Outing outingFive = new Outing(10, dateTimeFive, 110m, 2);
            Outing outingSix = new Outing(5, dateTimeSix, 120m, 4);
            _outingRepo.AddNewOuting(outingOne);
            _outingRepo.AddNewOuting(outingTwo);
            _outingRepo.AddNewOuting(outingThree);
            _outingRepo.AddNewOuting(outingFour);
            _outingRepo.AddNewOuting(outingFive);
            _outingRepo.AddNewOuting(outingSix);
        }
    }
}
