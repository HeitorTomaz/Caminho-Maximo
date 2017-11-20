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


            List<string> csvs = Util.BuscaGrafos();
            foreach ( string x in csvs)
            {
                gr = new Grafos();
                Console.WriteLine("Iniciando " + x);
                int arestas = Util.MontaGrafo(ref gr, x);
                Console.WriteLine();

                int vertices = gr.nodes.Count;
                Console.WriteLine(vertices + " Vértices");
                Console.WriteLine(arestas + " Arestas");

                Console.WriteLine("Início da limpeza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                int limpou = gr.Clean();
                //Console.WriteLine("Limpados: " + limpou + "\nSobraram: " + (vertices - limpou));
                //Console.WriteLine("Caminhos: " + gr.QuantosCaminhos());
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
