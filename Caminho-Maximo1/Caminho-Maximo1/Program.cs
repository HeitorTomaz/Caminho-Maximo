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
            BLL prog = new BLL();
            Console.WriteLine("Tá saindo da Jaula o MONSTRO!");

            Grafos gr = new Grafos();

            //Util.MakePair(ref gr, 1, 2, 3);
            //Util.MakePair(ref gr, 2, 3, 4);
            //Util.MakePair(ref gr, 2, 6, 2);
            //Util.MakePair(ref gr, 4, 6, 6);
            //Util.MakePair(ref gr, 5, 6, -25);
            //Util.MakePair(ref gr, 5, 7, 10);
            //Util.MakePair(ref gr, 7, 8, 4);
            //Util.MakePair(ref gr, 8, 9, -3);
            //Util.MakePair(ref gr, 9, 10, 13);
            //Util.MakePair(ref gr, 4, 11, 5);
            List<string> csvs = Util.BuscaGrafos();
            foreach ( string x in csvs)
            {
                gr = new Grafos();
                Console.WriteLine("Iniciando " + x);
                int arestas = Util.MontaGrafo(ref gr, x);
                Console.WriteLine();
                
                
                Console.WriteLine(gr.nodes.Count + " Vértices");
                Console.WriteLine(arestas + " Arestas");

                Console.WriteLine("Início da limpeza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                gr.Clean();
                Console.WriteLine("Fim da limpeza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine("Maximum length of " + x + " = " + prog.LongestCable(gr));
                Console.WriteLine("Fim da execução: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.WriteLine();
            }

            //gr.Clean();
            //Console.WriteLine("Maximum length of cable = " + prog.LongestCable(gr));
            Console.WriteLine("ACABOUUU!!!");
            Console.ReadKey();
        }
        





    }
}
