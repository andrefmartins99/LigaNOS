using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Jornada
    {
        //Propriedades

        public int IdJornada { get; set; }

        public List<string> Jornadas { get; set; }


        //Métodos

        /// <summary>
        /// Preechimento da lista Jornadas com os jogos dessa jornada
        /// </summary>
        private void PreencherListaJornadas()
        {
            string ficheiro = "jogoInfo.txt";
            var linha = File.ReadAllLines(ficheiro);
            Jornadas = new List<string>();

            foreach (var linhas in linha)
            {
                if (linhas.Contains(IdJornada.ToString()))
                {
                    Jornadas.Add(linhas);
                }
            }
        }

    }
}
