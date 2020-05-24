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

        private int _timeScale;

        private Semaphore _semaphore;

        public DressingRooms(int timeScale, int rooms = 3)
        {
            _timeScale = timeScale;
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
        public async Task RequestRoom(Customer customer)
        {
            // Customer is now in the dressing room waiting line
            customer.WaitingStopWatch.Start();

            // Waiting on thread
            Console.WriteLine($"Customer {customer.Name} is now waiting for an available room");
            _semaphore.WaitOne();

            // Stop the wait timer
            customer.WaitingStopWatch.Stop();

            Console.WriteLine($"Customer {customer.Name} can now use a dressing room.");

            // Customer has entered a dressing room
            customer.OccupiedStopwatch.Start();

            // Get the wait time, then sleep
            Thread.Sleep(customer.TimePerGarment * _timeScale * customer.NumberOfGarments);

            // Stop the run timer, since the customer has left the dressing room
            customer.OccupiedStopwatch.Stop();

            Console.WriteLine($"Customer {customer.Name} finished trying on items in room");

            _semaphore.Release();
        }



    }
}
