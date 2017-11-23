using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace CM.VO
{
    public class global
    {
        public static int MIN_VALUE = -999999;
    }
    public class Graph
    {
        public Graph() { }

        public Graph(Graph gr)
        {
            nodes = gr.nodes.ToList();
        }
        public List<Node> nodes = new List<Node>();
        
        private List<int> GalhoMaximo(int f)
        {
            throw new NotImplementedException();
        }

        public List<Aresta> Arestas = new List<Aresta>();

        public List<Subciclo> subciclos = new List<Subciclo>();
    }

    public class Aresta
    {
        public int A;

        public Double AVal = 0;

        public int B;

        public Double BVal = 0;

        public Double val = 0;
    }
    public class Subciclo
    {
        public Subciclo() { }
        public Subciclo(int nd) { nodes.Add(nd); }

        public List<int> nodes = new List<int>();
        public double maximo;
    }
}
