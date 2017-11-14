using System;
using System.Collections.Generic;
using System.Text;
using CM.VO;
using System.Linq;
using System.IO;

namespace Caminho_Maximo1
{
    public class Util
    {
        public static void MakePair(ref Graph gr, int a, int b, Double val)
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

        public static void MontaGrafo(ref Graph gr, string path)
        {
            //Declaro o StreamReader para o caminho onde se encontra o arquivo
            StreamReader rd = new StreamReader(@"" + path);
            //Declaro uma string que será utilizada para receber a linha completa do arquivo
            string linha = null;
            //Declaro um array do tipo string que será utilizado para adicionar o conteudo da linha separado
            string[] linhaseparada = null;
            //realizo o while para ler o conteudo da linha
            int i = 0;
            while ((linha = rd.ReadLine()) != null)
            {
                i++;
                try
                {
                    //com o split adiciono a string 'quebrada' dentro do array
                    linhaseparada = linha.Split(' ');
                    //aqui incluo o método necessário para continuar o trabalho
                    int a, b;
                    Double val;
                    a = Convert.ToInt32(linhaseparada[0]);
                    b = Convert.ToInt32(linhaseparada[1]);
                    val = Convert.ToDouble(linhaseparada[2]);

                    MakePair(ref gr, a, b, val);

                }
                catch
                {
                    Console.WriteLine("Linha " + i + " não lida.");
                }
            }
            rd.Close();
        }
        public static List<string> BuscaGrafos()
        {
            List<string> files;
            try
            {
                files = Directory.EnumerateFiles(@"..\Grafos\", "*.csv", SearchOption.AllDirectories).ToList();
                //from file in Directory.EnumerateFiles(@"..\Grafos\", "*.csv", SearchOption.AllDirectories)
                //from line in File.ReadLines(file)
                //where line.Contains("Microsoft")
                //select new
                //{
                //    File = file,
                //    //Line = line
                //};


                //foreach (var f in files)
                //{
                //    Console.WriteLine("{0}\t{1}", f.File, f.Line);
                //}
                //Console.WriteLine("{0} files found.", files.Count().ToString());
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
