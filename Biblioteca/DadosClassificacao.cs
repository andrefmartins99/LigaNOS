using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class DadosClassificacao
    {
        public string Nome { get; set; }

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

        public List<DadosClassificacao> Classificacoes { get; set; }

        public override string ToString()
        {
            return $"{Nome};{Pontos};{NumJogos};{NumVitorias};{NumDerrotas};{NumEmpates};{GolosMarcados};{GolosSofridos};{DiferencaGolos}";
        }
    }
}
