using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class Jogo
    {
        public int IdJogo { get; set; }

        public int IdEquipaCasa { get; set; }

        public int IdEquipaFora { get; set; }

        public DateTime Data { get; set; }

        public int IdArbitro { get; set; }

        public string Estadio { get; set; }

        public int IdJornada { get; set; }

        public int GolosEquipaCasa { get; set; }

        public int GolosEquipaFora { get; set; }

        public string Resultado
        {
            get
            {
                return $"{GolosEquipaCasa}:{GolosEquipaFora}";
            }
        }
    }
}
