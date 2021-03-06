﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class DadosClube
    {
        public string IdClube { get; set; }

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

        public override string ToString()
        {
            return $"{IdClube};{Nome};{Treinador};{Estadio}";
        }
    }
}
