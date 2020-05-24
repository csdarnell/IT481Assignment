using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public class Customer
    {
        const int _constMaxTimePerGarment = 3;

        private readonly int _timePerGarment;

        public Customer(string customerName, int clothingItemCount, int maxClothingItemsAllowed, int timePerGarment)
        {
            Name = customerName;

            if (clothingItemCount == 0)
            {
                NumberOfGarments = Randomizer.GetRandomNumber(1, maxClothingItemsAllowed);
            }
            else
            {
                NumberOfGarments = clothingItemCount;
            }

            if (timePerGarment == 0)
            {
                _timePerGarment = Randomizer.GetRandomNumber(1, _constMaxTimePerGarment);
            }
            else
            {
                _timePerGarment = timePerGarment;
            }

            WaitingStopWatch = new Stopwatch();
            OccupiedStopwatch = new Stopwatch();
        }


        public string Name { get; set; }

        public int NumberOfGarments { get; set; }

        /// <summary>
        /// Because each customer is different, establish this customer's unique "Time Per Garment" time.
        /// </summary>
        public int TimePerGarment { get { return _timePerGarment; } }

        public Stopwatch WaitingStopWatch { get; set; }

        public Stopwatch OccupiedStopwatch { get; set; }
    }
}
