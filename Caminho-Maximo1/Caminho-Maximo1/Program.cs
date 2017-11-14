using System;
using System.Collections.Generic;
using System.Linq;
using CM.VO;

namespace Caminho_Maximo1
{

    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            Console.WriteLine("Tá saindo da Jaula o MONSTRO!");

            Graph gr = new Graph();

            Util.MakePair(ref gr, 1, 2, 3);
            Util.MakePair(ref gr, 2, 3, 4);
            Util.MakePair(ref gr, 2, 6, 2);
            Util.MakePair(ref gr, 4, 6, 6);
            Util.MakePair(ref gr, 5, 6, -25);
            Util.MakePair(ref gr, 5, 7, 10);
            Util.MakePair(ref gr, 7, 8, 4);
            Util.MakePair(ref gr, 8, 9, -3);
            Util.MakePair(ref gr, 9, 10, 13);
            Util.MakePair(ref gr, 4, 11, 5);




            gr.Clean();
            Console.WriteLine("Maximum length of cable = " + prog.LongestCable(gr));
            Console.ReadKey();
        }
        
        public int? LongestCable(Graph gr)
        {
            // maximum length of cable among the connected
            // cities
            int? max_len = global.MIN_VALUE;
            int? curr_len = global.MIN_VALUE;
            // call DFS for each city to find maximum
            // length of cable
            foreach (Node nd in gr.nodes)
            {

                //Console.WriteLine("novo " + nd.id);
                // Call DFS for src vertex nd
                curr_len = DFS(gr, nd);

                max_len = (curr_len> max_len ? curr_len : max_len);
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
        public int? DFS(Graph gr, Node src)
        {

            src.path.Add(src.id);

            int? curr_len = src.pathValue + src.value;
            int? Max_len = curr_len;
            int? Node_len = global.MIN_VALUE;

            // Traverse all adjacent
            foreach( int i in src.near.Keys)
            {

                // If node or city is not visited
                if (!src.path.Contains(i))
                {
                    // Adjacent element
                    Node adjacent = gr.nodes.Select(x=> x).Where(x=> x.id == i).FirstOrDefault();
                    // Total length of cable from src city
                    // to its adjacent
                    adjacent.path = src.path;
                    adjacent.pathValue = curr_len + src.near[i];
                    // Call DFS for adjacent city
                    Node_len = DFS(gr
                                    , adjacent);

                    Max_len = (Node_len > Max_len ? Node_len : Max_len);
                }

            }
            //Console.WriteLine("path id = "+ src.id );
            return Max_len;
        }

    }
}
