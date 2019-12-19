using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Classificacao
    {
        public int Posicao { get; }

        public int Nome { get; }

        public int Pontos { get; }

        public int NumJogos { get; }

        public int NumVitorias { get; }

        public int NumDerrotas { get; }

        public int NumEmpates { get; }

        public int GolosMarcados { get; }

        public int GolosSofridos { get; }

        public int DiferencaGolos
        {
            get
            {
                return GolosMarcados - GolosSofridos;
            }
        }
    }
}
