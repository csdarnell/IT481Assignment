using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit6_Assignment
{
    public static class Randomizer
    {
        private static readonly Random getRandom = new Random();
        public static int GetRandomNumber(int minimum, int maximum)
        {
            lock (getRandom)
            {
                return getRandom.Next(minimum, maximum);
            }
        }
    }
}
