using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public class Customer
    {
        private readonly int _numberOfItems;

        public Customer(int clothingItemCount, int maxClothingItemsAllowed)
        {
            if (clothingItemCount == 0)
            {
                _numberOfItems = Randomizer.GetRandomNumber(1, maxClothingItemsAllowed);
            }
            else
            {
                _numberOfItems = clothingItemCount;
            }
        }

        public int NumberOfItems => _numberOfItems;

    }
}
