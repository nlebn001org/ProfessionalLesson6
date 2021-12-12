using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace Library
{
    // Задание переделал под себя, чтобы лучше понять тему рефлексии. 
    public class Customer  // Shop - all for RegionInfo.CurrentRegion.CurrencySymbol
    {
        public string Name { get; private set; }
        public int ProdCount { get; private set; }
        public double Money { get; private set; }
        int stolenProd;

        string cur = RegionInfo.CurrentRegion.CurrencySymbol;

        public Customer(string name, double money)
        {
            Name = name;
            Money = money;
            Console.WriteLine($"Customer {Name} has {Money} {cur}");
        }

        public void Buy(int count)
        {
            if (this.Money >= 2 * count)
            {
                Money -= 2 * count;
                ProdCount += count;
                Console.WriteLine($"Customer {Name} has spent {2 * count} {cur}. Actual customer state is {Money} {cur} and {ProdCount} pieces.");
            }
            else
                Steal(count);

        }

        private void Steal(int count)
        {
            stolenProd += count;
            Console.WriteLine($"Customer {Name} has stolen {count} pieces. Actual customer state is {Money} {cur}, {ProdCount} legally bought pieces" +
                $" and {stolenProd} stolen pieces.");
        }
    }
}
