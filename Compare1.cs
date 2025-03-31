using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSack {
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
            Array.Sort(items, obj);
            double totalVal = 0f;
            int curretWeight = 0;

            foreach (Item item in items) {
                float remaining = weight - curretWeight;

                if (item.weight <= remaining) {
                    totalVal += (double)item.profit;
                    curretWeight += item.weight;

                } else {
                    if (remaining == 0) break;

                    double fraction = remaining / item.weight;
                    totalVal += fraction * item.profit;
                    curretWeight += (int)(fraction * (double)item.weight);
                }
            }
            return totalVal;

        }
    }
}
