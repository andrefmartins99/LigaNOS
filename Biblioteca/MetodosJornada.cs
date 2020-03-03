using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class MetodosJornada
    {
        //Procurar ficheiro xml jogoInfo, se não existir cria-se um novo ficheiro, se existir a lista Jogos vai ser preenchida com a informação que estiver contida no ficheiro
        public static List<DadosJogo> LerFicheiroJogos(DadosJornada dadosJornada)
        {
            dadosJornada.Jogos = new List<DadosJogo>();
            string ficheiro = "jogoInfo.xml";

            if (!File.Exists(ficheiro))
            {
                GravarInfoJogo(dadosJornada);
            }

            if (new FileInfo(ficheiro).Length == 0)
            {
                GravarInfoJogo(dadosJornada);
            }

            XmlSerializer serial = new XmlSerializer(typeof(List<DadosJogo>));
            StreamReader sr = new StreamReader(ficheiro);
            dadosJornada.Jogos = (List<DadosJogo>)(serial.Deserialize(sr));
            sr.Close();
            return dadosJornada.Jogos;
        }

        //Gravar informações da lista Jogos no ficheiro xml jogoInfo
        public static void GravarInfoJogo(DadosJornada dadosJornada)
        {
            string ficheiro = "jogoInfo.xml";
            XmlSerializer serial = new XmlSerializer(typeof(List<DadosJogo>));
            StreamWriter sw = new StreamWriter(ficheiro);
            serial.Serialize(sw, dadosJornada.Jogos);
            sw.Close();
        }

        //Gerar resultados da jornada selecionada na comboBox
        public static void GerarResultados(DadosJornada dadosJornada, string idJornada, DadosClube dadosClube)
        {
            Random rng = new Random();
            int casa;
            int fora;

            for (int i = 0; i < dadosJornada.Jogos.Count; i++)
            {
                foreach (var jogos in dadosJornada.Jogos)
                {
                    //Verificar se o jogo já foi jogado
                    if (jogos.ToString().Contains(idJornada) && jogos.JogoJogado == false)
                    {
                        casa = rng.Next(0, 6);
                        fora = rng.Next(0, 6);

                        jogos.GolosClubeCasa = casa;
                        jogos.GolosClubeFora = fora;
                        jogos.JogoJogado = true;

                        //Atualizar as estatísticas dos clubes após o jogo ser jogado
                        if (casa > fora)
                        {
                            MetodosClube.VitoriaClube(jogos.ClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora);
                            MetodosClube.DerrotaClube(jogos.ClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa);
                        }
                        else if (casa < fora)
                        {
                            MetodosClube.VitoriaClube(jogos.ClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa);
                            MetodosClube.DerrotaClube(jogos.ClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora);
                        }
                        else
                        {
                            MetodosClube.EmpateClube(jogos.ClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora);
                            MetodosClube.EmpateClube(jogos.ClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa);
                        }
                    }
                }
            }
        }

        public static string VerificarIdJornadaAtual(int numJogos)
        {
            if (numJogos < 9)
            {
                return $"J0{numJogos + 1}";
            }
            else
            {
                return $"J{numJogos + 1}";
            }
        }

        //Apagar ficheiro xml jogoInfo
        public static void ApagarInfoJogo()
        {
            string ficheiro = "jogoInfo.xml";
            File.Delete(ficheiro);
        }
    }
}
