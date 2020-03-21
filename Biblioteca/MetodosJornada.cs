using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class MetodosJornada
    {
        /// <summary>
        /// Procurar ficheiro xml jogoInfo, se não existir cria-se um novo ficheiro, se existir a lista Jornadas vai ser preenchida com a informação que estiver contida no ficheiro
        /// </summary>
        /// <param name="Jornadas"></param>
        /// <returns></returns>
        public static List<DadosJornada> LerFicheiroJogos(List<DadosJornada> Jornadas)
        {
            DadosJornada dadosJornada = new DadosJornada();
            string ficheiro = "jogoInfo.xml";

            if (!File.Exists(ficheiro))
            {
                GravarInfoJogo(Jornadas);
            }

            if (new FileInfo(ficheiro).Length == 0)
            {
                GravarInfoJogo(Jornadas);
            }

            XmlSerializer serial = new XmlSerializer(typeof(List<DadosJogo>));
            StreamReader sr = new StreamReader(ficheiro);
            dadosJornada.Jogos = (List<DadosJogo>)(serial.Deserialize(sr));
            sr.Close();

            return OrganizarJornadas(dadosJornada.Jogos);
        }

        /// <summary>
        /// Gravar informações da lista Jornadas no ficheiro xml jogoInfo
        /// </summary>
        /// <param name="Jornadas"></param>
        public static void GravarInfoJogo(List<DadosJornada> Jornadas)
        {
            string ficheiro = "jogoInfo.xml";
            XmlSerializer serial = new XmlSerializer(typeof(List<DadosJogo>));
            StreamWriter sw = new StreamWriter(ficheiro);

            if (Jornadas.Count == 0)
            {
                DadosJornada jornada = new DadosJornada();

                serial.Serialize(sw, jornada.Jogos);
            }
            else
            {
                DadosJornada jornada = new DadosJornada()
                {
                    Jogos = new List<DadosJogo>()
                };

                for (int i = 0; i < Jornadas.Count; i++)
                {
                    for (int j = 0; j < Jornadas[i].Jogos.Count; j++)
                    {
                        jornada.Jogos.Add(Jornadas[i].Jogos[j]);
                    }
                }
                serial.Serialize(sw, jornada.Jogos);
            }

            sw.Close();
        }

        /// <summary>
        /// Gerar resultados da jornada selecionada na comboBox
        /// </summary>
        /// <param name="Jornadas"></param>
        /// <param name="idJornada"></param>
        /// <param name="Clubes"></param>
        public static void GerarResultados(List<DadosJornada> Jornadas, string idJornada, List<DadosClube> Clubes)
        {
            Random rng = new Random();
            int casa;
            int fora;

            for (int i = 0; i < Jornadas.Count; i++)
            {

                foreach (var jogos in Jornadas[i].Jogos)
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
                            MetodosClube.VitoriaClube(jogos.ClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora, Clubes);
                            MetodosClube.DerrotaClube(jogos.ClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa, Clubes);
                        }
                        else if (casa < fora)
                        {
                            MetodosClube.VitoriaClube(jogos.ClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa, Clubes);
                            MetodosClube.DerrotaClube(jogos.ClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora, Clubes);
                        }
                        else
                        {
                            MetodosClube.EmpateClube(jogos.ClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora, Clubes);
                            MetodosClube.EmpateClube(jogos.ClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa, Clubes);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Verificar o id da jornada atual
        /// </summary>
        /// <param name="numJogos"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Apagar ficheiro xml jogoInfo
        /// </summary>
        public static void ApagarInfoJogo()
        {
            string ficheiro = "jogoInfo.xml";
            File.Delete(ficheiro);
        }

        /// <summary>
        /// Organizar a lista Jornadas de modo a que esta tenha as jornadas e as jornadas uma lista de Jogos a seres jogados nessas jornadas
        /// </summary>
        /// <param name="Jogos"></param>
        /// <returns></returns>
        public static List<DadosJornada> OrganizarJornadas(List<DadosJogo> Jogos)
        {
            List<DadosJornada> Jornadas = new List<DadosJornada>();

            if (Jogos.Count != 0)
            {
                int numJogosJornada = 4;
                int numJogo = 0;

                do
                {
                    DadosJornada jornada = new DadosJornada
                    {
                        Jogos = new List<DadosJogo>()
                    };

                    do
                    {
                        jornada.Jogos.Add(Jogos[numJogo]);
                        numJogo++;

                    } while (numJogo < numJogosJornada);

                    Jornadas.Add(jornada);
                    numJogosJornada += 4;

                } while (numJogo != 56);

                return Jornadas;
            }

            return Jornadas;
        }
    }
}
