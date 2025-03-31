using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSack {
    public class Item {
        public int profit;
        public int weight;

        public Item(int profit, int weight) {
            this.profit = profit;
            this.weight = weight;
        }
    }
}
