using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Arbitro
    {
        //Propriedades
        public int IdArbitro { get; set; }

        public string Nome { get; set; }


        //Métodos

        /// <summary>
        /// Gravar os árbitros num ficheiro de texto
        /// </summary>
        private void GravarInfoArbitro()
        {
            string ficheiro = "arbitroInfo.txt";
            string linha = $"{IdArbitro};{Nome}";

            StreamWriter sw = new StreamWriter(ficheiro, true);

            if (!File.Exists(ficheiro))
            {
                sw = File.CreateText(ficheiro);
            }

            sw.WriteLine(linha);
            sw.Close();
        }

        /// <summary>
        /// Apagar o ficheiro que contém a informação dos árbitros
        /// </summary>
        private void ApagarInfoArbitro()
        {
            string ficheiro = "arbitroInfo.txt";
            File.Delete(ficheiro);
        }
    }
}
