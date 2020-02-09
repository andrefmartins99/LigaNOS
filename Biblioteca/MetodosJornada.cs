using System.Collections.Generic;

namespace Biblioteca
{
    public class MetodosJornada
    {
        //Preencher lista Jornadas a partir da lista Jogos dependendo da jornada selecionada na comboBox
        public List<DadosJornada> PreencherListaJornadas(List<DadosJornada> Jornadas, DadosJornada dadosJornada, List<DadosJogo> Jogos, string IdJornada)
        {
            Jornadas = new List<DadosJornada>();

            foreach (var jogos in Jogos)
            {
                if (jogos.ToString().Contains(IdJornada))
                {
                    dadosJornada = new DadosJornada();

                    dadosJornada.IdJornada = IdJornada;
                    dadosJornada.NomeClubeCasa = jogos.NomeClubeCasa;
                    dadosJornada.NomeClubeFora = jogos.NomeClubeFora;
                    dadosJornada.Dia = jogos.Dia;
                    dadosJornada.Hora = jogos.Hora;
                    dadosJornada.GolosClubeCasa = jogos.GolosClubeCasa;
                    dadosJornada.GolosClubeFora = jogos.GolosClubeFora;
                    dadosJornada.Estadio = jogos.Estadio;

                    Jornadas.Add(dadosJornada);
                }
            }

            return Jornadas;
        }

        //Retorna o id da jornada de um jogo da lista Jogos
        public string NumeroJornadas(List<DadosJogo> Jogos, DadosJogo dadosJogo, int i)
        {
            string IdJornada;

            var campos = Jogos[i].ToString().Split(';');

            IdJornada = campos[6];

            return IdJornada;
        }
    }
}
