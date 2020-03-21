using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca
{
    public class DadosJogo
    {
        public string IdJogo { get; set; }

        public DadosClube ClubeCasa { get; set; }

        public DadosClube ClubeFora { get; set; }

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

        public bool JogoJogado { get; set; }

        public override string ToString()
        {
            return $"{IdJogo};{ClubeCasa.Nome};{ClubeFora.Nome};{Dia.ToString("dd MMM").ToUpper()};{Hora.ToShortTimeString()};{Estadio};{IdJornada};{GolosClubeCasa};{GolosClubeFora};{Resultado};{JogoJogado}";
        }

        public override bool Equals(object obj)
        {
            DadosJogo jogo = obj as DadosJogo;

            if (jogo == null)
            {
                return false;
            }

            return jogo.ClubeCasa == this.ClubeCasa && jogo.ClubeFora == this.ClubeFora;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
