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
        public List<Node> nodes = new List<Node>();
        #region public
        public List<List<int>> Cicles()
        {
            List<List<int>> ammount = new List<List<int>>();
            foreach (Node nd in this.nodes)
            {
                IsCiclic(this, nd);
            }
            ammount = ammount.Select(x => x).Distinct().ToList();
            return ammount;
        }

        public void Clean()
        {
            List<int> fol = this.Folhas();

            foreach (int f in fol)
            {
                int val = global.MIN_VALUE;
                List<int> path = GalhoMaximo(f,ref val );
                if (path.Count > 2)
                {
                    Node newND = new Node() { id = this.nodes.Max(x => x.id) + 1, value = 0 };
                    newND.near.Add(path.Last(), val);
                    //Retirando a ligação entre o galho e o grafo
                    path.ForEach(x => this.nodes.Select(y => y).Where(y => y.id == path.Last()).First().near.Remove(x));
                    this.nodes.Select(x => x).Where(x => x.id == path[path.Count - 2]).First().near.Remove(path.Last());

                    this.nodes.Select(x => x).Where(x => x.id == path.Last()).First().near.Add(newND.id, val);

                    //path.Remove(path.Last());
                    //path.ForEach(x => this.nodes.Remove(this.nodes.Select(y => y).Where(y => y.id == x).First()));
                    this.nodes.Add(newND);
                }
            }
        }

        private List<int> GalhoMaximo(int f)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region private
        private List<List<int>> IsCiclic(Graph gr, Node src)
        {
            List<List<int>> ammount = new List<List<int>>();
            src.path.Add(src.id);
            if (src.near.Count > 0)
            {
                foreach (int i in src.near.Keys)
                {
                    if (!src.path.Contains(i))
                    {
                        Node nd = gr.nodes.Select(x => x).Where(x => x.id == i).First();
                        if (nd.near.Count > 1)
                        {
                            nd.path = src.path;
                            ammount.Concat(IsCiclic(gr, nd));
                        }
                    }
                    else
                    {
                        src.path.Add(i);
                        ammount.Add(src.path);
                    }
                }
            }
            return ammount;
        }

        private List<int> Folhas()
        {
            return this.nodes.Select(x => x).Where(x => x.near.Count == 1).Select(x => x.id).ToList();
        }
        private List<int> Soltos()
        {
            return this.nodes.Select(x => x).Where(x => x.near.Count == 0).Select(x => x.id).ToList();
        }
        private List<int> GalhoMaximo(int first, ref int val)
        {
            Node nd, src;
            src = this.nodes.Select(x => x).Where(x => x.id == first).First();
            List<int> path = new List<int>();
            int maxVal = global.MIN_VALUE;
            int atualVal = global.MIN_VALUE;
            path.Add(src.id);
            nd = this.nodes.Select(x => x).Where(x => x.id == src.near.First().Key).First();
            path.Add(nd.id);
            while (nd.near.Count == 2)
            {
                nd = this.nodes.Select(x => x).Where(x => x.id == nd.near.First().Key).First();
                path.Add(nd.id);
            }

            //nd é o primeiro nó fora do galho
            //maxVal = atualVal = nd.value;

            //agora nd vai ser o ultimo no do galho
            nd = this.nodes.Select(x => x).Where(x => x.id == path[path.Count - 2]).First();

            int i = 2;
            maxVal = atualVal = nd.near[path[path.Count - 1]] + nd.value;
            while (nd.near.Count == 2)
            {
                i++;
                nd = this.nodes.Select(x => x).Where(x => x.id == path[path.Count - i]).First();
                
                atualVal += nd.near[path[path.Count - i+1]];
                atualVal += nd.value;
                maxVal = (atualVal > maxVal ? atualVal : maxVal);
            }
            val = maxVal;
            return path;
        }
        #endregion

    }

}
