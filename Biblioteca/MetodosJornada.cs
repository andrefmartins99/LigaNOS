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
        public List<DadosJornada> PreencherListaJornadas(List<DadosJornada> Jornadas, DadosJornada dadosJornada, List<DadosJogo> Jogos, string IdJornada)
        {
            Jornadas = new List<DadosJornada>();

            foreach (var jogos in Jogos)
            {
                if (jogos.ToString().Contains(IdJornada))
                {
                    var campos = jogos.ToString().Split(';');

                    dadosJornada = new DadosJornada();

                    dadosJornada.IdJornada = IdJornada;
                    dadosJornada.NomeClubeCasa = campos[1];
                    dadosJornada.NomeClubeFora = campos[2];
                    dadosJornada.Dia = Convert.ToDateTime(campos[3]);
                    dadosJornada.Hora = Convert.ToDateTime(campos[4]);
                    dadosJornada.GolosClubeCasa = Convert.ToInt32(campos[7]);
                    dadosJornada.GolosClubeFora = Convert.ToInt32(campos[8]);

                    Jornadas.Add(dadosJornada);
                }
            }

            return Jornadas;
        }

        public string NumeroJornadas(List<DadosJogo> Jogos, DadosJogo dadosJogo, int i)
        {
            string IdJornada;

            var campos = Jogos[i].ToString().Split(';');

            IdJornada = campos[6];

            return IdJornada;
        }
    }
}
