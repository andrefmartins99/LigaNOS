using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Arbitro
    {
        public int IdArbitro { get; set; }

        public string Nome { get; set; }


        private void GravarInfoArbitro()
        {
            string ficheiro = "ArbitroInfo.txt";
            string linha = $"{IdArbitro};{Nome}";

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
