using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using CM.VO;

namespace Caminho_Maximo1
{
    class BLL
    {

        public Double LongestCable(Graph gr, int raiz = -1)
        {
            // maximum length of cable among the connected
            // cities
            Double max_len = global.MIN_VALUE;
            Double curr_len = global.MIN_VALUE;
            // call DFS for each city to find maximum
            // length of cable
            if (raiz == -1)
            {
                foreach (Node nd in gr.nodes)
                {

                    //Console.WriteLine("novo " + nd.id);
                    // Call DFS for src vertex nd
                    curr_len = DFS(gr, nd);

                    max_len = (curr_len > max_len ? curr_len : max_len);
                    //clean paths 
                    foreach (Node no in gr.nodes)
                    {
                        no.path = new List<int>();
                        no.pathValue = 0;
                    }
                }
            }
            else
            {
                Node nd = gr.nodes.Select(x => x).Where(x => x.id == raiz).First();
                max_len = DFS(gr, nd);

                //max_len = (curr_len > max_len ? curr_len : max_len);
                //clean paths 
                foreach (Node no in gr.nodes)
                {
                    no.path = new List<int>();
                    no.pathValue = 0;
                }

            }

            return max_len;
        }



        // src is starting node for DFS traversal
        public Double DFS(Graph gr, Node src)
        {

            src.path.Add(src.id);

            Double curr_len = src.pathValue + src.value;
            Double Max_len = curr_len;
            Double Node_len = global.MIN_VALUE;

            // Traverse all adjacent
            foreach (int i in src.near.Keys)
            {

                // If node or city is not visited
                if (!src.path.Contains(i))
                {
                    // Adjacent element
                    Node adjacent = gr.nodes.Select(x => x).Where(x => x.id == i).FirstOrDefault();
                    // Total length of cable from src city
                    // to its adjacent
                    adjacent.path = src.path.ToList();
                    adjacent.pathValue = curr_len + src.near[i];
                    // Call DFS for adjacent city
                    Node_len = DFS(gr, adjacent);

                    Max_len = (Node_len > Max_len ? Node_len : Max_len);
                }

            }
            //Console.WriteLine("path id = "+ src.id );
            return Max_len;
        }

    }

    public class Grafos : Graph
    {
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
                Double val = global.MIN_VALUE;
                List<int> path = GalhoMaximo(f, ref val);
                if (path.Count > 2)
                {
                    Node newND = new Node() { id = this.nodes.Max(x => x.id) + 1, value = 0 };
                    newND.near.Add(path.Last(), val);
                    //Retirando a ligação entre o galho e o grafo
                    this.nodes.Select(x => x).Where(x => x.id == path.Last()).First().near.Remove(path[path.Count - 2]);
                    this.nodes.Select(x => x).Where(x => x.id == path[path.Count - 2]).First().near.Remove(path.Last());

                    this.nodes.Select(x => x).Where(x => x.id == path.Last()).First().near.Add(newND.id, val);

                    //path.Remove(path.Last());
                    //path.ForEach(x => this.nodes.Remove(this.nodes.Select(y => y).Where(y => y.id == x).First()));
                    this.nodes.Add(newND);
                }
            }
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
                            nd.path = src.path.ToList();
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

        private List<int> GalhoMaximo(int first, ref Double val)
        {
            Node nd, src;
            src = this.nodes.Select(x => x).Where(x => x.id == first).First();
            List<int> path = new List<int>();
            Double maxVal = global.MIN_VALUE;
            Double atualVal = global.MIN_VALUE;
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

                atualVal += nd.near[path[path.Count - i + 1]];
                atualVal += nd.value;
                maxVal = (atualVal > maxVal ? atualVal : maxVal);
            }
            val = maxVal;
            return path;
        }
        #endregion
    }

}
