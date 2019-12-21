using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Biblioteca
{
    public class Classificacao
    {
        //Propriedades

        public int Posicao { get; set; }

        public List<string> Classificacoes { get; set; }


        //Métodos

        private void PreencherListaClassificacoes()
        {
            string ficheiro = "estatisticaClube.txt";
            var linha = File.ReadAllLines(ficheiro);
            Classificacoes = new List<string>();

            foreach (var linhas in linha)
            {
                Classificacoes.Add(linhas);
            }
        }

        private void OrdenarClassificacoes()
        {
            Classificacoes.Sort();
        }
    }
}
