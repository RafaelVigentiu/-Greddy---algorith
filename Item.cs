using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapSack {
    public class Item {
        //Instance fileds.
        public int profit;
        public int weight;

        //Constructor.
        public Item(int profit, int weight) {
            this.profit = profit;
            this.weight = weight;
        }
    }
}
