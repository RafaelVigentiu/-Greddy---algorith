using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSack {
    //Comparison function to sort Item according
    public class Compare1 : IComparer {
        static void Main(string[] args) {
            int weight = 50;
            Item[] items = { new Item(60, 10), new Item(100, 20), new Item(120, 30), new Item(120, 30) };
            Console.WriteLine(FracKnapSack(items, weight));
        }

        public int Compare(Object x, Object y) {
            Item item1 = (Item)x;
            Item item2 = (Item)y;
            double cp1 = (double)item1.profit / (double)item1.weight;
            double cp2 = (double)item2.profit / (double)item2.weight;

            if (cp1 < cp2) {
                return 1;
            }
            return cp1 > cp2 ? -1 : 0;
        }

        static double FracKnapSack(Item[] items, int weight) {
            Compare1 obj = new Compare1();

            //Sort Items based by Compare(Object x, Object y) from IComparer.
            Array.Sort(items, obj);
            double totalVal = 0f; //Initialize max profit.
            int curretWeight = 0; //Initialize current weignt.

            foreach (Item item in items) {
                float remaining = weight - curretWeight; //Remaining weight.

                //Check if current Item weight <= remaining.
                if (item.weight <= remaining) {
                    totalVal += (double)item.profit; //Add profit.
                    curretWeight += item.weight; //Update Wight.

                } else {
                    if (remaining == 0) break; //Stop program if there no more space.


                    // Calculate the fraction of the item that can be taken based on the remaining capacity
                    double fraction = remaining / item.weight; 
                    //Update profit.
                    totalVal += fraction * item.profit;
                    // Update the current weight by adding the fractional part of the item's weight
                    curretWeight += (int)(fraction * (double)item.weight);
                }
            }
            return totalVal;

        }
    }
}
