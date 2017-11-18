using System;
using System.Collections.Generic;
using System.Text;
using CM.VO;
using System.Linq;
using System.IO;

namespace Caminho_Maximo1
{
    public static class Util
    {

        public static List<Aresta> Arestas = new List<Aresta>();

        public static void MakePair(ref Grafos gr, int a, int b, Double val)
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
                    {
                        if (!nd.near.ContainsKey(b))
                        {
                            nd.near.Add(b, val);
                        }
                        else if (nd.near[b] < val)
                        {
                            nd.near[b] = val;
                        }
                    }
                    else if (nd.id == b)
                    {
                        if (!nd.near.ContainsKey(a))
                        {
                            nd.near.Add(a, val);
                        }
                        else if (nd.near[a] < val)
                        {
                            nd.near[a] = val;
                        }
                    }
                Arestas.Add(new Aresta() { A = a, B = b, val = val});
            }

        }

        public static int MontaGrafo(ref Grafos gr, string path)
        {
            //Declaro o StreamReader para o caminho onde se encontra o arquivo
            StreamReader rd = new StreamReader(@"" + path);
            //Declaro uma string que será utilizada para receber a linha completa do arquivo
            string linha = null;
            //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado
            string[] linhaseparada = null;
            //realizo o while para ler o conteudo da linha
            int arestas = 0, linhas =  0;
            while ((linha = rd.ReadLine()) != null)
            {
                arestas++;
                linhas++;
                try
                {
                    //com o split adiciono a string 'quebrada' dentro do array
                    linhaseparada = linha.Split(' ');
                    //aqui incluo o método necessário para continuar o trabalho
                    int a, b;
                    Double val;
                    a = Convert.ToInt32(linhaseparada[0]);
                    b = Convert.ToInt32(linhaseparada[1]);
                    //Console.WriteLine(linhaseparada[2]);
                    if (linhaseparada[2].Length > 12)
                    {
                        string x = linhaseparada[2].Substring(0, 6);
                        string y = linhaseparada[2].Substring(linhaseparada[2].Length - 5);
                        linhaseparada[2] = x + y;
                    }
                    //Console.WriteLine(linhaseparada[2]);
                    val = Convert.ToDouble( Double.Parse(linhaseparada[2], System.Globalization.NumberStyles.Any));
                    //Console.WriteLine(val);
                    MakePair(ref gr, a, b, val);

                }
                catch(Exception ex)
                {
                    
                    Console.WriteLine("Linha " + linhas + " não lida. " + ex.InnerException + ex.Message);
                }
            }
            rd.Close();
            return arestas;
        }

        public static List<string> BuscaGrafos()
        {
            List<string> files;
            try
            {
                files = Directory.EnumerateFiles(@"..\Grafos\", "*.csv", SearchOption.AllDirectories).ToList();
                files.ForEach(x=> Console.WriteLine(x));
                return files;
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine("Erro ao buscar grafos \n" + UAEx.Message + "\n" + UAEx.InnerException + "\n");
                return null;
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine("Erro ao buscar grafos \n" + PathEx.Message + "\n" + PathEx.InnerException + "\n");
                return null;
            }
            
        }
    }
}
