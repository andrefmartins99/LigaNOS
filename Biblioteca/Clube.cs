using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    public class Clube
    {
        //Propriedades
        public int IdClube { get; set; }

        public string Nome { get; set; }

        public string Treinador { get; set; }

        public string Estadio { get; set; }

        public int Pontos { get; set; }

        public int NumJogos { get; set; }

        public int NumVitorias { get; set; }

        public int NumDerrotas { get; set; }

        public int NumEmpates { get; set; }

        public int GolosMarcados { get; set; }

        public int GolosSofridos { get; set; }

        public int DiferencaGolos
        {
            get
            {
                return GolosMarcados - GolosSofridos;
            }
        }


        //Métodos

        /// <summary>
        /// Gravar os clubes e as suas estatísticas num ficheiro de texto
        /// </summary>
        private void GravarClube()
        {
            //Info do clube
            string ficheiro = "clubeInfo.txt";
            string linha = $"{IdClube};{Nome};{Treinador};{Estadio}";

            StreamWriter sw = new StreamWriter(ficheiro, true);

            if (!File.Exists(ficheiro))
            {
                sw = File.CreateText(ficheiro);
            }

            sw.WriteLine(linha);
            sw.Close();

            //Estatística do clube
            string ficheiros = "estatisticaClube.txt";
            string linhas = $"{Nome};{Pontos};{NumJogos};{NumVitorias};{NumDerrotas};{NumEmpates};{GolosMarcados};{GolosSofridos};{DiferencaGolos}";

            StreamWriter sws = new StreamWriter(ficheiros, true);

            if (!File.Exists(ficheiros))
            {
                sw = File.CreateText(ficheiros);
            }

            sw.WriteLine(linhas);
            sw.Close();
        }

        /// <summary>
        /// Atualizar a estatística do clube após o jogo
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="pontos"></param>
        /// <param name="numJogos"></param>
        /// <param name="numVitorias"></param>
        /// <param name="numDerrotas"></param>
        /// <param name="numEmpates"></param>
        /// <param name="golosMarcados"></param>
        /// <param name="golosSofridos"></param>
        private void AtualizarEstatisticaClube(string nome, int pontos, int numJogos, int numVitorias, int numDerrotas, int numEmpates, int golosMarcados, int golosSofridos)
        {
            string ficheiro = "estatisticaClube.txt";
            string linha = File.ReadAllLines(ficheiro).LastOrDefault(linhas => linhas.StartsWith(nome));
            string texto = File.ReadAllText(ficheiro);
            string linhaa;

            if (linha != null)
            {
                Pontos += pontos;
                NumJogos += numJogos;
                NumVitorias += numVitorias;
                NumDerrotas += numDerrotas;
                NumEmpates += numEmpates;
                GolosMarcados += golosMarcados;
                GolosSofridos += golosSofridos;

                linhaa = $"{Nome};{Pontos};{NumJogos};{NumVitorias};{NumDerrotas};{NumEmpates};{GolosMarcados};{GolosSofridos};{DiferencaGolos}";

                texto = texto.Replace(linha, linhaa);
                File.WriteAllText(ficheiro, texto);
            }
        }

        /// <summary>
        /// Apagar os ficheiros que contêm a informação e a estatística dos clubes
        /// </summary>
        private void ApagarClube()
        {
            string ficheiro = "clubeInfo.txt";
            string ficheiros = "estatisticaClube.txt";
            File.Delete(ficheiro);
            File.Delete(ficheiros);
        }
    }
}
