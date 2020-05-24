using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public class Scenario
    {
        private const int _standardGarmentsPerCustomerThreshold = 6;

        public Scenario(int totalRooms, int numberOfCustomers, int scenarioMaxGarmentsPerCustomer, int scenarioAverageTimePerGarment, int timeScale = 60000)
        {
            List<Customer> customers = new List<Customer>();

            Console.WriteLine($"{totalRooms} dressing rooms for {numberOfCustomers} customers.");

            DressingRooms dressingRooms = new DressingRooms(timeScale, totalRooms);
            List<Task> dressingRoomCustomerTasks = new List<Task>();
            for (int i = 0; i < numberOfCustomers; i++)
            {
                Customer customer = new Customer(i.ToString(), scenarioMaxGarmentsPerCustomer, _standardGarmentsPerCustomerThreshold, scenarioAverageTimePerGarment);
                customers.Add(customer);
                Console.WriteLine($"{DateTime.Now} - Customer {customer.Name} has {customer.NumberOfGarments} garments, with average time/garment {customer.TimePerGarment}.");
                dressingRoomCustomerTasks.Add(Task.Factory.StartNew(async () => { await dressingRooms.RequestRoom(customer); }));
            }

            // Wait for all the customers to use the Dressing Room
            Task.WaitAll(dressingRoomCustomerTasks.ToArray());

            // Gather statistics
            int totalGarments = 0;
            long cummulativeWaitTime = 0;
            long cumulativeRunTime = 0;
            foreach (Customer customer in customers)
            {
                totalGarments += customer.NumberOfGarments;
                cummulativeWaitTime += customer.WaitingStopWatch.ElapsedMilliseconds;
                cumulativeRunTime += customer.OccupiedStopwatch.ElapsedMilliseconds;
            }

            // Report the Statistics
            Console.WriteLine($"Average run time in milliseconds: {cumulativeRunTime / numberOfCustomers}");
            Console.WriteLine($"Average wait time in milliseconds: {cummulativeWaitTime / numberOfCustomers}");
            Console.WriteLine($"Total Customers is: {numberOfCustomers}");
            Console.WriteLine($"Average number of garments was: {totalGarments / numberOfCustomers}");

            Console.ReadKey();
        }
    }
}
