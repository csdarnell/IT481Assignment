using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is the time scale to use(1000 = 1 second)?  (0 = 1 minute or 60000 milliseconds): ");
            int timeScale = Int32.Parse(Console.ReadLine());
            if (timeScale == 0)
            {
                timeScale = 60000;
            }

            Console.Write("How many rooms does the store have? ");
            int totalRooms = Int32.Parse(Console.ReadLine());

            Console.Write("How many customers do you want? ");
            int numberOfCustomers = Int32.Parse(Console.ReadLine());

            Console.Write("What is the maximum number of garments per customer? (0 = random): ");
            int scenarioMaxGarmentsPerCustomer = Int32.Parse(Console.ReadLine());

            Console.Write("What is the average 'time per garment' dressing room time? (0 = random): ");
            int scenarioAverageTimePerGarment = Int32.Parse(Console.ReadLine());

            // Prepare the Scenario, Dressing Rooms, and Customers
            Scenario scenario = new Scenario(totalRooms, numberOfCustomers, scenarioMaxGarmentsPerCustomer, scenarioAverageTimePerGarment, timeScale);
        }
    }
}
