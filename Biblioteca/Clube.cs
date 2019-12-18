using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Clube
    {
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
    }
}
