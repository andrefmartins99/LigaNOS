using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class MetodosJornada
    {
        /// <summary>
        /// Preencher a lista Jornadas com os jogos dessa jornada
        /// </summary>
        public void PreencherListaJornadas(DadosJornada jornada)
        {
            string ficheiro = "jogoInfo.txt";
            var linha = File.ReadAllLines(ficheiro);
            jornada.Jornadas = new List<string>();

            foreach (var linhas in linha)
            {
                if (linhas.Contains(jornada.IdJornada.ToString()))
                {
                    jornada.Jornadas.Add(linhas);
                }
            }
        }
    }
}
