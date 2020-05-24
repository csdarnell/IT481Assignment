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
        private static long _waitTimer;
        private static long _runTimer;

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

                _threads[i] = new Thread(() => doThread(dressingRooms, _numberOfCustomers, _totalItems));

                stopWatch.Start();

                _threads[i].Name = $"Customer Thread {i}";

                stopWatch.Stop();

                _waitTimer += stopWatch.ElapsedMilliseconds;

                stopWatch.Start();
                _threads[i].Start();

                stopWatch.Stop();
                _runTimer = stopWatch.ElapsedMilliseconds;
            }

            Console.WriteLine($"Average run time in milliseconds: {_runTimer / _numberOfCustomers}");
            Console.WriteLine($"Average wait time in milliseconds: {_waitTimer / _numberOfCustomers}");
            Console.WriteLine($"Total Customers is: {_numberOfCustomers}");
            Console.WriteLine($"Average number of items was: {_totalItems / _numberOfCustomers}");

            Console.ReadKey();
        }

        private static void doThread(DressingRooms dressingRooms, int tc, int numberOfItems)
        {
            // Waiting on thread
            Console.WriteLine($"{Thread.CurrentThread.Name} is waiting");
            _semaphore.WaitOne();

            // Run the thread
            Console.WriteLine($"{Thread.CurrentThread.Name} is running now");

            // Get the wait time, then sleep
            int wait = dressingRooms.RequestRoom();
            Thread.Sleep(wait * numberOfItems);

            Console.WriteLine($"{Thread.CurrentThread.Name} finished trying on items in room");

            _semaphore.Release();

        }
    }
}
