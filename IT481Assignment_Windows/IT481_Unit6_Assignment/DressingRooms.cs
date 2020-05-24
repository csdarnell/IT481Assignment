using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public class DressingRooms
    {
        private readonly int _totalRooms;

        private int _occupiedRoomCount;

        private Semaphore _semaphore;

        public DressingRooms(int rooms = 3)
        {
            _totalRooms = rooms;
            _semaphore = new Semaphore(_totalRooms, _totalRooms);
        }

        private DressingRooms()
        {

        }

        /// <summary>
        /// Request a Room
        /// </summary>
        /// <returns>Wait Time</returns>
        public void RequestRoom(Customer customer)
        {
            // Customer is now in the dressing room waiting line
            customer.WaitingStopWatch.Start();

            // Waiting on thread
            Console.WriteLine($"{customer.Name} is waiting for an available room");
            _semaphore.WaitOne();

            // Stop the wait timer
            customer.WaitingStopWatch.Stop();

            Console.WriteLine($"Customer {customer.Name} can now use a dressing room.");
        }

        public void ReleaseRoom(Customer customer)
        {
            // Customer has entered a dressing room
            customer.OccupiedStopwatch.Start();

            // Get the wait time, then sleep
            Thread.Sleep(customer.TimePerGarment * customer.NumberOfGarments);

            // Stop the run timer, since the customer has left the dressing room
            customer.OccupiedStopwatch.Stop();

            Console.WriteLine($"Customer {customer.Name} finished trying on items in room");
        }


    }
}
