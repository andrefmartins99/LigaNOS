using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class DadosJogo
    {
        public string IdJogo { get; set; }

        public string IdClubeCasa { get; set; }

        public string IdClubeFora { get; set; }

        public string NomeClubeCasa { get; set; }

        public string NomeClubeFora { get; set; }

        public DateTime Dia { get; set; }

        public DateTime Hora { get; set; }

        public string Estadio { get; set; }

        public string IdJornada { get; set; }

        public int GolosClubeCasa { get; set; }

        public int GolosClubeFora { get; set; }

        public string Resultado
        {
            get
            {
                return $"{GolosClubeCasa}:{GolosClubeFora}";
            }
        }

        public List<DadosJogo> Jogos { get; set; }

        public bool JogoJogado { get; set; }

        public override string ToString()
        {
            return $"{IdJogo};{NomeClubeCasa};{NomeClubeFora};{Dia.ToString("dd MMM").ToUpper()};{Hora.ToShortTimeString()};{Estadio};{IdJornada};{GolosClubeCasa};{GolosClubeFora};{Resultado};{JogoJogado}";
        }
    }
}
