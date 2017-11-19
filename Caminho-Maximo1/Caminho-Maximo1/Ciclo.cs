using System;
using System.Collections.Generic;
using System.Linq;
using CM.VO;

namespace Caminho_Maximo1
{
    public class Ciclo
    {
        public Ciclo()
        {
        }

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

        public List<List<int>> IsCiclic(Graph gr)
        {
            List<List<int>> ammount = new List<List<int>>();
            foreach (Node nd in gr.nodes)
            {
                IsCiclic(gr, nd);
            }
            ammount = ammount.Select(x => x).Distinct().ToList();
            return ammount;
        }

    }
}
