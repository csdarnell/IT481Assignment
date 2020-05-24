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
        private static int _totalRooms;
        private static int _numberOfCustomers;
        private static int _scenarioMaxItemsPerCustomer;
        private const int _standardItemsPerCustomerThreshold = 6;
        private static int _totalItems = 0;

        private static Semaphore _semaphore;
        private static long _cummulativeWaitTime;
        private static long _cumulativeRunTime;

        private static Thread[] _threads;

        public Scenario(int totalRooms, int numberOfCustomers)
        {
            _totalRooms = totalRooms;
            _numberOfCustomers = numberOfCustomers;

            Console.WriteLine($"{_totalRooms} dressing rooms for {_numberOfCustomers} customers.");
        }

        static void Main(string[] args)
        {
            Console.Write("How many rooms does the store have? ");
            _totalRooms = Int32.Parse(Console.ReadLine());

            Console.Write("How many customers do you want? ");
            _numberOfCustomers = Int32.Parse(Console.ReadLine());

            Console.Write("What is the maximum number of clothing items per customer? (0 = random): ");
            _scenarioMaxItemsPerCustomer = Int32.Parse(Console.ReadLine());

            _semaphore = new Semaphore(_totalRooms, _totalRooms);

            Scenario scenario = new Scenario(_totalRooms, _numberOfCustomers);

            DressingRooms dressingRooms = new DressingRooms(_totalRooms);

            Stopwatch stopWatch = new Stopwatch();

            _threads = new Thread[_numberOfCustomers];

            for (int i = 0; i < _numberOfCustomers; i++)
            {
                Customer _customer = new Customer(_scenarioMaxItemsPerCustomer, _standardItemsPerCustomerThreshold);

                _totalItems += _customer.NumberOfItems;

                _threads[i] = new Thread(() => doThread(i, dressingRooms, _numberOfCustomers, _totalItems));

                _threads[i].Start();
            }

            Console.WriteLine($"Average run time in milliseconds: {_cumulativeRunTime / _numberOfCustomers}");
            Console.WriteLine($"Average wait time in milliseconds: {_cummulativeWaitTime / _numberOfCustomers}");
            Console.WriteLine($"Total Customers is: {_numberOfCustomers}");
            Console.WriteLine($"Average number of items was: {_totalItems / _numberOfCustomers}");

            Console.ReadKey();
        }

        private static void doThread(int customerNumber, DressingRooms dressingRooms, int tc, int numberOfItems)
        {

            // Initiate a wait timer
            Stopwatch waitingForAvailableRoomTimer = new Stopwatch();
            waitingForAvailableRoomTimer.Start();

            // Waiting on thread
            Console.WriteLine($"{customerNumber} is waiting for an available room");
            _semaphore.WaitOne();

            // Stop the wait timer
            waitingForAvailableRoomTimer.Stop();
            _cummulativeWaitTime += waitingForAvailableRoomTimer.ElapsedMilliseconds;

            // Start the run timer, since the customer can now go into the dressing room
            Stopwatch tryingOnClothesTimer = new Stopwatch();

            // Run the thread
            Console.WriteLine($"Customer {customerNumber} can now use a dressing room.");

            // Get the wait time, then sleep
            int wait = dressingRooms.RequestRoom();
            Thread.Sleep(wait * numberOfItems);

            // Stop the run timer, since the customer has left the dressing room
            tryingOnClothesTimer.Stop();
            _cumulativeRunTime += tryingOnClothesTimer.ElapsedMilliseconds;
            Console.WriteLine($"Customer {customerNumber} finished trying on items in room");

            _semaphore.Release();

        }
    }
}
