using System;
using System.Collections.Generic;
using System.Text;

namespace CM.VO
{
    public class Node
    {
        public Dictionary<int, Double> near = new Dictionary<int, Double>();
        public int id;
        public Double value;

        public Double pathValue;
        public List<int> path = new List<int>();

        public int pai;
        public Boolean neto = false;
    }
}
