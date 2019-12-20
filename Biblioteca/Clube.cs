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
        /// Gravar os clubes num ficheiro de texto após a sua criação
        /// </summary>
        private void GravarInfoClube()
        {
            string ficheiro = "clubeInfo.txt";
            string linha = $"{IdClube};{Nome};{Treinador};{Estadio};{Pontos};{NumJogos};{NumVitorias};{NumDerrotas};{NumEmpates};{GolosMarcados};{GolosSofridos};{DiferencaGolos}";

            StreamWriter sw = new StreamWriter(ficheiro, true);

            if (!File.Exists(ficheiro))
            {
                sw = File.CreateText(ficheiro);
            }

            sw.WriteLine(linha);
            sw.Close();
        }

        /// <summary>
        /// Atualizar a info do clube após o jogo
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="pontos"></param>
        /// <param name="numjogos"></param>
        /// <param name="numvitorias"></param>
        /// <param name="numderrotas"></param>
        /// <param name="numempates"></param>
        /// <param name="golosmarcados"></param>
        /// <param name="golossofridos"></param>
        private void AtualizarInfoClube(int Id, int pontos, int numjogos, int numvitorias, int numderrotas, int numempates, int golosmarcados, int golossofridos)
        {
            string ficheiro = "clubeInfo.txt";
            string linha = File.ReadAllLines(ficheiro).LastOrDefault(linhas => linhas.StartsWith(Id.ToString()));
            string texto = File.ReadAllText(ficheiro);
            string linhaa;

            if (linha != null)
            {
                IdClube = IdClube;
                Nome = Nome;
                Treinador = Treinador;
                Estadio = Estadio;
                Pontos += pontos;
                NumJogos += numjogos;
                NumVitorias += numvitorias;
                NumDerrotas += numderrotas;
                NumEmpates += numempates;
                GolosMarcados += golosmarcados;
                GolosSofridos += golossofridos;

                linhaa = $"{IdClube};{Nome};{Treinador};{Estadio};{Pontos};{NumJogos};{NumVitorias};{NumDerrotas};{NumEmpates};{GolosMarcados};{GolosSofridos};{DiferencaGolos}";

                texto = texto.Replace(linha, linhaa);
                File.WriteAllText(ficheiro, texto);
            }
        }

        /// <summary>
        /// Apagar o ficheiro que contém a informação dos clubes
        /// </summary>
        private void ApagarInfoClube()
        {
            string ficheiro = "clubeInfo.txt";
            File.Delete(ficheiro);
        }
    }
}
