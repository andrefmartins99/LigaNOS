using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class DadosJornada
    {
        public string IdJornada { get; set; }

        public string NomeClubeCasa { get; set; }

        public string NomeClubeFora { get; set; }

        public DateTime Dia { get; set; }

        public DateTime Hora { get; set; }

        public int GolosClubeCasa { get; set; }

        public int GolosClubeFora { get; set; }

        public string Resultado
        {
            get
            {
                return $"{GolosClubeCasa}:{GolosClubeFora}";
            }
        }

        public string Estadio { get; set; }

        public List<DadosJornada> Jornadas { get; set; }
    }
}
