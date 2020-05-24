using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public class DressingRooms
    {
        private readonly int _rooms;

        private int _occupiedRoomCount;

        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        public DressingRooms(int rooms = 3)
        {
            _rooms = rooms;
        }

        private DressingRooms()
        {

        }

        /// <summary>
        /// Request a Room
        /// </summary>
        /// <returns>Wait Time</returns>
        public int RequestRoom()
        {
            return Randomizer.GetRandomNumber(1, 3);
        }

        public void ReleaseRoom()
        {
            _occupiedRoomCount--;
        }


    }
}
