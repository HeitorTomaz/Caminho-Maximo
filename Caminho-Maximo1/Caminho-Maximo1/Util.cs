using System;
using System.Collections.Generic;
using System.Text;
using CM.VO;
using System.Linq;

namespace Caminho_Maximo1
{
    public class Util
    {
        public static void MakePair(ref Graph gr, int a, int b, int val)
        {

            if (gr.nodes.Select(x => x).Where(x => x.id == a).Count() == 0)
            {
                gr.nodes.Add(new Node() { id = a, value = 0, pathValue = 0 });
            }
            if (gr.nodes.Select(x => x).Where(x => x.id == b).Count() == 0)
            {
                gr.nodes.Add(new Node() { id = b, value = 0, pathValue = 0 });
            }

            if (a == b)
            {
                foreach (Node nd in gr.nodes)
                    if (nd.id == a)
                        nd.value = val;
            }
            else
            {
                foreach (Node nd in gr.nodes)
                    if (nd.id == a)
                        nd.near.Add(b, val);
                    else if (nd.id == b)
                        nd.near.Add(a, val);
            }

        }
    }
}
