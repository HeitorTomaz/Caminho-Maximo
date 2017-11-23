using System;
using System.Collections.Generic;
using System.Linq;
using CM.VO;
using System.Diagnostics;

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
                Stopwatch sw = new Stopwatch();

                gr = new Grafos();
                Console.WriteLine("Iniciando " + x);
                int arestas = Util.MontaGrafo(ref gr, x);
                Console.WriteLine();

                int vertices = gr.nodes.Count;
                Console.WriteLine(vertices + " Vértices");
                Console.WriteLine(arestas + " Arestas");

                Console.WriteLine("Início da execução simples: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sw.Start();
                Console.WriteLine("Caminho máximo: " + x + " = " + prog.LongestCable(gr));
                sw.Stop();
                Console.WriteLine("Fim da execução: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                TimeSpan tempo = sw.Elapsed;
                Console.WriteLine("Tempo de execução: " + tempo.ToString());
                Console.WriteLine();

                sw = new Stopwatch();
                gr = new Grafos();
                Console.WriteLine("Iniciando " + x);
                arestas = Util.MontaGrafo(ref gr, x);
                Console.WriteLine();


                Console.WriteLine("Início da limpeza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sw.Start();
                int limpou = gr.Clean();
                sw.Stop();
                tempo = sw.Elapsed;

                //Console.WriteLine("Limpados: " + limpou + "\nSobraram: " + (vertices - limpou));
                //Console.WriteLine("Caminhos: " + gr.QuantosCaminhos());
                Console.WriteLine("Fim da limpeza: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sw.Start();

                Console.WriteLine("Caminho máximo: " + x + " = " + prog.LongestCable(gr));
                sw.Stop();

                Console.WriteLine("Fim da execução: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                TimeSpan tempo2 = sw.Elapsed;
                Console.WriteLine("Tempo de execução Limpeza: " + tempo.ToString());
                Console.WriteLine("Tempo de execução Total: " + tempo2.ToString());

                Console.WriteLine();
            }

            //gr.Clean();
            //Console.WriteLine("Maximum length of cable = " + prog.LongestCable(gr));
            Console.WriteLine("ACABOUUU!!!");
            Console.ReadKey();
        }
        





    }
}
