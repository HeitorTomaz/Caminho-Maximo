using System;
using System.Collections.Generic;
using System.Text;

namespace CM.VO
{
    public class Node
    {
        public Dictionary<int, int> near = new Dictionary<int, int>();
        public int id;
        public int value;

        public int? pathValue;
        public List<int> path = new List<int>();
    }
}
