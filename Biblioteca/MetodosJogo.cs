using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    public class MetodosJogo
    {
        /// <summary>
        /// Gravar os jogos num ficheiro de texto
        /// </summary>
        public void GravarInfoJogo(DadosJogo jogo)
        {
            string ficheiro = "jogoInfo.txt";
            string linha = $"{jogo.IdJogo};{jogo.IdClubeCasa};{jogo.IdClubeFora};{jogo.Dia};{jogo.Hora};{jogo.Estadio};{jogo.IdJornada};{jogo.GolosClubeCasa};{jogo.GolosClubeFora};{jogo.Resultado}";

            StreamWriter sw = new StreamWriter(ficheiro, true);

            if (!File.Exists(ficheiro))
            {
                sw = File.CreateText(ficheiro);
            }

            sw.WriteLine(linha);
            sw.Close();
        }

        /// <summary>
        /// Atualizar a info do jogo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="golosEquipaCasa"></param>
        /// <param name="golosEquipaFora"></param>
        public void AtualizarInfoJogo(DadosJogo jogo, int id, int golosEquipaCasa, int golosEquipaFora)
        {
            string ficheiro = "jogoInfo.txt";
            string linha = File.ReadAllLines(ficheiro).LastOrDefault(linhas => linhas.StartsWith(id.ToString()));
            string texto = File.ReadAllText(ficheiro);
            string linhaa;

            if (linha != null)
            {
                jogo.GolosClubeCasa = golosEquipaCasa;
                jogo.GolosClubeFora = golosEquipaFora;

                linhaa = $"{jogo.IdJogo};{jogo.IdClubeCasa};{jogo.IdClubeFora};{jogo.Dia};{jogo.Hora};{jogo.Estadio};{jogo.IdJornada};{jogo.GolosClubeCasa};{jogo.GolosClubeFora};{jogo.Resultado}";

                texto = texto.Replace(linha, linhaa);
                File.WriteAllText(ficheiro, texto);
            }
        }

        /// <summary>
        /// Apagar o ficheiro que contém a informação dos jogos 
        /// </summary>
        public void ApagarInfoJogo()
        {
            string ficheiro = "jogoInfo.txt";
            File.Delete(ficheiro);
        }

        /// <summary>
        /// Gerar os jogos do campeonato, com as respetivas informações (data, estadio)
        /// </summary>
        /// <param name="Clubes"></param>
        public List<DadosJogo> CriarJogosCampeonato(List<DadosJogo> Jogos, DadosJogo dadosJogo, List<DadosClube> Clubes)
        {
            Jogos = new List<DadosJogo>();
            List<string> clubes = new List<string>();
            List<string> voltas1 = new List<string>();
            List<string> voltas2 = new List<string>();
            List<string> jogo = new List<string>();
            Random rng = new Random();
            int rnd;

            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(',');
                string id = campos[0];
                clubes.Add(id);
            }

            //Gerar os jogos do campeonato
            do
            {
                for (int i = 0; i < clubes.Count - 1; i++)
                {
                    for (int j = i + 1; j < clubes.Count; j++)
                    {
                        int contador = 0;
                        rnd = rng.Next(1, 11);

                        //1º Jornada
                        if (voltas1.Count <= 3)
                        {
                            //1º Jogo da Jornada
                            if (voltas1.Count == 0)
                            {
                                if (rnd > 5)
                                {
                                    voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                    jogo.Add("clube[i];clube[j]");
                                    voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                }
                                else
                                {
                                    voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                    jogo.Add("clube[j];clube[i]");
                                    voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 0; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0)
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                        //2º Jornada
                        else if (voltas1.Count <= 7)
                        {
                            //Verificação de jogos anteriores realizados em casa ou fora
                            int contadorCasa1 = 0;
                            int contadorCasa2 = 0;
                            int contadorFora1 = 0;
                            int contadorFora2 = 0;

                            for (int l = 0; l < voltas1.Count; l++)
                            {
                                var clube = voltas1[l].Split(';');
                                string clube1 = clube[0];
                                string clube2 = clube[1];

                                if (clube1 == clubes[i])
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == clubes[i])
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == clubes[j])
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == clubes[j])
                                {
                                    contadorFora2++;
                                }
                            }

                            if (contadorCasa1 == 1 || contadorFora2 == 1)
                            {
                                rnd = 1;
                            }
                            else if (contadorFora1 == 1 || contadorCasa2 == 1)
                            {
                                rnd = 8;
                            }

                            //1º Jogo da Jornada
                            if (voltas1.Count == 4)
                            {
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))) //Verificação de equipas repetidas em todas as jornadas
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 4; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0 && (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))))
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                        //3º Jornada
                        else if (voltas1.Count <= 11)
                        {
                            //Verificação de jogos anteriores realizados em casa ou fora
                            int contadorCasa1 = 0;
                            int contadorCasa2 = 0;
                            int contadorFora1 = 0;
                            int contadorFora2 = 0;

                            for (int l = 4; l < voltas1.Count; l++)
                            {
                                var clube = voltas1[l].Split(';');
                                string clube1 = clube[0];
                                string clube2 = clube[1];

                                if (clube1 == clubes[i])
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == clubes[i])
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == clubes[j])
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == clubes[j])
                                {
                                    contadorFora2++;
                                }
                            }

                            if (contadorCasa1 == 1 || contadorFora2 == 1)
                            {
                                rnd = 1;
                            }
                            else if (contadorFora1 == 1 || contadorCasa2 == 1)
                            {
                                rnd = 8;
                            }

                            //1º Jogo da Jornada
                            if (voltas1.Count == 8)
                            {
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))) //Verificação de equipas repetidas em todas as jornadas
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 8; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0 && (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))))
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                        //4º Jornada
                        else if (voltas1.Count <= 15)
                        {
                            //Verificação de jogos anteriores realizados em casa ou fora
                            int contadorCasa1 = 0;
                            int contadorCasa2 = 0;
                            int contadorFora1 = 0;
                            int contadorFora2 = 0;

                            for (int l = 8; l < voltas1.Count; l++)
                            {
                                var clube = voltas1[l].Split(';');
                                string clube1 = clube[0];
                                string clube2 = clube[1];

                                if (clube1 == clubes[i])
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == clubes[i])
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == clubes[j])
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == clubes[j])
                                {
                                    contadorFora2++;
                                }
                            }

                            if (contadorCasa1 == 1 || contadorFora2 == 1)
                            {
                                rnd = 1;
                            }
                            else if (contadorFora1 == 1 || contadorCasa2 == 1)
                            {
                                rnd = 8;
                            }

                            //1º Jogo da Jornada
                            if (voltas1.Count == 12)
                            {
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))) //Verificação de equipas repetidas em todas as jornadas
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 12; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0 && (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))))
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                        //5º Jornada
                        else if (voltas1.Count <= 19)
                        {
                            //Verificação de jogos anteriores realizados em casa ou fora
                            int contadorCasa1 = 0;
                            int contadorCasa2 = 0;
                            int contadorFora1 = 0;
                            int contadorFora2 = 0;

                            for (int l = 12; l < voltas1.Count; l++)
                            {
                                var clube = voltas1[l].Split(';');
                                string clube1 = clube[0];
                                string clube2 = clube[1];

                                if (clube1 == clubes[i])
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == clubes[i])
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == clubes[j])
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == clubes[j])
                                {
                                    contadorFora2++;
                                }
                            }

                            if (contadorCasa1 == 1 || contadorFora2 == 1)
                            {
                                rnd = 1;
                            }
                            else if (contadorFora1 == 1 || contadorCasa2 == 1)
                            {
                                rnd = 8;
                            }

                            //1º Jogo da Jornada
                            if (voltas1.Count == 16)
                            {
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))) //Verificação de equipas repetidas em todas as jornadas
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 16; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0 && (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))))
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                        //6º Jornada
                        else if (voltas1.Count <= 23)
                        {
                            //Verificação de jogos anteriores realizados em casa ou fora
                            int contadorCasa1 = 0;
                            int contadorCasa2 = 0;
                            int contadorFora1 = 0;
                            int contadorFora2 = 0;

                            for (int l = 16; l < voltas1.Count; l++)
                            {
                                var clube = voltas1[l].Split(';');
                                string clube1 = clube[0];
                                string clube2 = clube[1];

                                if (clube1 == clubes[i])
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == clubes[i])
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == clubes[j])
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == clubes[j])
                                {
                                    contadorFora2++;
                                }
                            }

                            if (contadorCasa1 == 1 || contadorFora2 == 1)
                            {
                                rnd = 1;
                            }
                            else if (contadorFora1 == 1 || contadorCasa2 == 1)
                            {
                                rnd = 8;
                            }

                            //1º Jogo da Jornada
                            if (voltas1.Count == 20)
                            {
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))) //Verificação de equipas repetidas em todas as jornadas
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 20; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0 && (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))))
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                        //7º Jornada
                        else
                        {
                            //Verificação de jogos anteriores realizados em casa ou fora
                            int contadorCasa1 = 0;
                            int contadorCasa2 = 0;
                            int contadorFora1 = 0;
                            int contadorFora2 = 0;

                            for (int l = 20; l < voltas1.Count; l++)
                            {
                                var clube = voltas1[l].Split(';');
                                string clube1 = clube[0];
                                string clube2 = clube[1];

                                if (clube1 == clubes[i])
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == clubes[i])
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == clubes[j])
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == clubes[j])
                                {
                                    contadorFora2++;
                                }
                            }

                            if (contadorCasa1 == 1 || contadorFora2 == 1)
                            {
                                rnd = 1;
                            }
                            else if (contadorFora1 == 1 || contadorCasa2 == 1)
                            {
                                rnd = 8;
                            }

                            //1º Jogo da Jornada
                            if (voltas1.Count == 24)
                            {
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))) //Verificação de equipas repetidas em todas as jornadas
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificação de equipas repetidas na jornada
                                for (int l = 24; l < voltas1.Count; l++)
                                {
                                    var clube = voltas1[l].Split(';');
                                    string clube1 = clube[0];
                                    string clube2 = clube[1];

                                    if (clube1 == clubes[i] || clube1 == clubes[j])
                                    {
                                        contador++;
                                    }

                                    if (clube2 == clubes[i] || clube2 == clubes[j])
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0 && (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}"))))
                                {
                                    if (rnd > 5)
                                    {
                                        voltas1.Add($"{clubes[i]};{clubes[j]}");//1º volta
                                        jogo.Add("clube[i];clube[j]");
                                        voltas2.Add($"{clubes[j]};{clubes[i]}");//2º volta
                                    }
                                    else
                                    {
                                        voltas1.Add($"{clubes[j]};{clubes[i]}");//1º volta
                                        jogo.Add("clube[j];clube[i]");
                                        voltas2.Add($"{clubes[i]};{clubes[j]}");//2º volta
                                    }
                                }
                            }
                        }
                    }
                }

            } while (voltas1.Count != 28);

            NomeClubes(voltas1, voltas2, Clubes);
            DataVolta1(voltas1);
            DataVolta2(voltas2);
            OrdenarListaVoltas1(voltas1);
            OrdenarListaVoltas2(voltas2);
            EstadioVoltas(voltas1, voltas2, Clubes);
            FinalizarVoltas(voltas1, voltas2);
            Jogos = PreencherListaJogos(Jogos, dadosJogo, voltas1, voltas2);

            return Jogos;
        }

        /// <summary>
        /// Adicionar à informação do jogo o nome das equipas
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        /// <param name="Clubes"></param>
        public void NomeClubes(List<string> voltas1, List<string> voltas2, List<DadosClube> Clubes)
        {
            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(',');
                string id = campos[0];
                string nome = campos[1];

                //Primeira volta
                for (int j = 0; j < voltas1.Count; j++)
                {
                    var info = voltas1[j].Split(';');
                    string casa = info[0];
                    string fora = info[1];

                    if (casa == id)
                    {
                        voltas1[j] = voltas1[j] + ";" + nome;
                    }

                    if (fora == id)
                    {
                        voltas1[j] = voltas1[j] + ";" + nome;
                    }
                }

                //Segunda volta
                for (int j = 0; j < voltas2.Count; j++)
                {
                    var info = voltas2[j].Split(';');
                    string casa = info[0];
                    string fora = info[1];

                    if (casa == id)
                    {
                        voltas2[j] = voltas2[j] + ";" + nome;
                    }

                    if (fora == id)
                    {
                        voltas2[j] = voltas2[j] + ";" + nome;
                    }
                }
            }
        }

        /// <summary>
        /// Gerar as datas dos jogos da primeira volta
        /// </summary>
        /// <param name="voltas1"></param>
        public void DataVolta1(List<string> voltas1)
        {
            //(ano, mes, dia, horas, minutos, segundos)
            DateTime data1 = new DateTime(2020, 1, 4, 15, 0, 0);
            DateTime data2 = new DateTime(2020, 1, 4, 13, 0, 0);
            DateTime data3 = new DateTime(2020, 1, 5, 14, 0, 0);
            DateTime data4 = new DateTime(2020, 1, 5, 16, 0, 0);
            int tamanhoi = 0;
            int tamanhof = 4;
            int reset;

            Random horas = new Random();
            int hora;
            DateTime horario = new DateTime(1, 1, 1, 1, 1, 1);

            do
            {
                reset = 0;

                for (int i = tamanhoi, contador = 0; i < tamanhof; i++, reset++)
                {
                    do
                    {
                        contador = 0;
                        hora = horas.Next(1, 5);

                        if (hora == 1)
                        {
                            horario = data1;
                        }
                        else if (hora == 2)
                        {
                            horario = data2;
                        }
                        else if (hora == 3)
                        {
                            horario = data3;
                        }
                        else if (hora == 4)
                        {
                            horario = data4;
                        }

                        if (reset > 0)
                        {
                            for (int l = tamanhoi; l < i; l++)
                            {
                                //Verificar se a data selecionada pelo random já foi utilizada
                                if (voltas1[l].Contains($"{horario.ToShortDateString()};{horario.ToShortTimeString()}"))
                                {
                                    contador++;
                                }
                            }
                        }

                    } while (contador != 0);

                    //Adicionar data ao jogo
                    voltas1[i] = voltas1[i] + ";" + horario.ToShortDateString() + ";" + horario.ToShortTimeString();

                }

                tamanhoi += 4;
                tamanhof += 4;
                data1 = data1.AddDays(7);
                data2 = data2.AddDays(7);
                data3 = data3.AddDays(7);
                data4 = data4.AddDays(7);

            } while (tamanhoi != 28);
        }

        /// <summary>
        /// Gerar as datas dos jogos da segunda volta
        /// </summary>
        /// <param name="voltas2"></param>
        public void DataVolta2(List<string> voltas2)
        {
            DateTime data1 = new DateTime(2020, 3, 7, 15, 0, 0);
            DateTime data2 = new DateTime(2020, 3, 7, 13, 0, 0);
            DateTime data3 = new DateTime(2020, 3, 8, 14, 0, 0);
            DateTime data4 = new DateTime(2020, 3, 8, 16, 0, 0);
            int tamanhoi = 0;
            int tamanhof = 4;
            int reset;

            Random horas = new Random();
            int hora;
            DateTime horario = new DateTime(1, 1, 1, 1, 1, 1);

            do
            {
                reset = 0;

                for (int i = tamanhoi, contador = 0; i < tamanhof; i++, reset++)
                {
                    do
                    {
                        contador = 0;
                        hora = horas.Next(1, 5);

                        if (hora == 1)
                        {
                            horario = data1;
                        }
                        else if (hora == 2)
                        {
                            horario = data2;
                        }
                        else if (hora == 3)
                        {
                            horario = data3;
                        }
                        else if (hora == 4)
                        {
                            horario = data4;
                        }

                        if (reset > 0)
                        {
                            for (int l = tamanhoi; l < i; l++)
                            {
                                //Verificar se a data selecionada pelo random já foi utilizada
                                if (voltas2[l].Contains($"{horario.ToShortDateString()};{horario.ToShortTimeString()}"))
                                {
                                    contador++;
                                }
                            }
                        }

                    } while (contador != 0);

                    //Adicionar data ao jogo
                    voltas2[i] = voltas2[i] + ";" + horario.ToShortDateString() + ";" + horario.ToShortTimeString();

                }

                tamanhoi += 4;
                tamanhof += 4;
                data1 = data1.AddDays(7);
                data2 = data2.AddDays(7);
                data3 = data3.AddDays(7);
                data4 = data4.AddDays(7);

            } while (tamanhoi != 28);
        }

        /// <summary>
        /// Ordenar a lista da primeira volta de acordo com a data dos jogos
        /// </summary>
        /// <param name="voltas1"></param>
        public void OrdenarListaVoltas1(List<string> voltas1)
        {
            int min = 0;
            int max = 4;

            do
            {
                for (int i = min; i < max; i++)
                {
                    var datai = voltas1[i].Split(';');
                    DateTime diai = Convert.ToDateTime(datai[4]);
                    DateTime horai = Convert.ToDateTime(datai[5]);

                    for (int j = i + 1; j < max; j++)
                    {
                        var dataj = voltas1[j].Split(';');
                        DateTime diaj = Convert.ToDateTime(dataj[4]);
                        DateTime horaj = Convert.ToDateTime(dataj[5]);
                        string aux;

                        if (diai > diaj)
                        {
                            aux = voltas1[i];
                            voltas1[i] = voltas1[j];
                            voltas1[j] = aux;
                            diai = diaj;
                        }
                        else if (diai == diaj)
                        {
                            if (horai > horaj)
                            {
                                aux = voltas1[i];
                                voltas1[i] = voltas1[j];
                                voltas1[j] = aux;
                                horai = horaj;
                            }
                        }
                    }
                }

                min += 4;
                max += 4;

            } while (max != 32);
        }

        /// <summary>
        /// Ordenar a lista da segunda volta de acordo com a data dos jogos
        /// </summary>
        /// <param name="voltas2"></param>
        public void OrdenarListaVoltas2(List<string> voltas2)
        {
            int min = 0;
            int max = 4;

            do
            {
                for (int i = min; i < max; i++)
                {
                    var datai = voltas2[i].Split(';');
                    DateTime diai = Convert.ToDateTime(datai[4]);
                    DateTime horai = Convert.ToDateTime(datai[5]);

                    for (int j = i + 1; j < max; j++)
                    {
                        var dataj = voltas2[j].Split(';');
                        DateTime diaj = Convert.ToDateTime(dataj[4]);
                        DateTime horaj = Convert.ToDateTime(dataj[5]);
                        string aux;

                        if (diai > diaj)
                        {
                            aux = voltas2[i];
                            voltas2[i] = voltas2[j];
                            voltas2[j] = aux;
                            diai = diaj;
                        }
                        else if (diai == diaj)
                        {
                            if (horai > horaj)
                            {
                                aux = voltas2[i];
                                voltas2[i] = voltas2[j];
                                voltas2[j] = aux;
                                horai = horaj;
                            }
                        }
                    }
                }

                min += 4;
                max += 4;

            } while (max != 32);
        }

        /// <summary>
        /// Adicionar à informação do jogo o estádio da equipa que joga em casa
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        /// <param name="Clubes"></param>
        public void EstadioVoltas(List<string> voltas1, List<string> voltas2, List<DadosClube> Clubes)
        {
            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(',');
                string id = campos[0];
                string estadio = campos[3];

                //Primeira volta
                for (int j = 0; j < voltas1.Count; j++)
                {
                    var info = voltas1[j].Split(';');
                    string casa = info[0];

                    if (casa == id)
                    {
                        voltas1[j] = voltas1[j] + ";" + estadio;
                    }
                }

                //Segunda volta
                for (int j = 0; j < voltas2.Count; j++)
                {
                    var info = voltas2[j].Split(';');
                    string casa = info[0];

                    if (casa == id)
                    {
                        voltas2[j] = voltas2[j] + ";" + estadio;
                    }
                }
            }
        }

        /// <summary>
        /// Adicionar aos jogos o número do jogo, número da jornada e o resultado a zeros
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        public void FinalizarVoltas(List<string> voltas1, List<string> voltas2)
        {
            //Adicionar o número dos jogos da primeira volta
            for (int i = 0; i < voltas1.Count; i++)
            {
                voltas1[i] = CriarIdJogoVoltas(i + 1) + ";" + voltas1[i];
            }

            //Adicionar o número dos jogos da segunda volta
            for (int i = 0; i < voltas2.Count; i++)
            {
                voltas2[i] = CriarIdJogoVoltas(i + 29) + ";" + voltas2[i];
            }

            //Adicionar o número da jornada aos jogos da primeira volta
            int min1 = 0;
            int max1 = 4;
            int jornada1 = 1;

            do
            {
                for (int i = min1; i < max1; i++)
                {
                    voltas1[i] = voltas1[i] + ";" + CriarIdJornadaVoltas(jornada1);
                }

                min1 += 4;
                max1 += 4;
                jornada1++;

            } while (max1 != 32);

            //Adicionar o número da jornada aos jogos da segunda volta
            int min2 = 0;
            int max2 = 4;
            int jornada2 = 8;

            do
            {
                for (int i = min2; i < max2; i++)
                {
                    voltas2[i] = voltas2[i] + ";" + CriarIdJornadaVoltas(jornada2);
                }

                min2 += 4;
                max2 += 4;
                jornada2++;

            } while (max2 != 32);

            //Adicionar o resultado a zeros
            for (int i = 0; i < voltas1.Count; i++)
            {
                voltas1[i] = voltas1[i] + ";" + 0 + ";" + 0 + ";" + 0 + ":" + 0;
                voltas2[i] = voltas2[i] + ";" + 0 + ";" + 0 + ";" + 0 + ":" + 0;
            }
        }

        /// <summary>
        /// Criar o número do jogo
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string CriarIdJogoVoltas(int i)
        {
            string idJogo;

            if (i.ToString().Length == 1)
            {
                idJogo = "j0" + $"{i}";
            }
            else
            {
                idJogo = "j" + $"{i}";
            }

            return idJogo;
        }

        /// <summary>
        /// Criar o número da jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public string CriarIdJornadaVoltas(int jornada)
        {
            string idJornada;

            if (jornada.ToString().Length == 1)
            {
                idJornada = "J0" + $"{jornada}";
            }
            else
            {
                idJornada = "J" + $"{jornada}";
            }

            return idJornada;
        }

        /// <summary>
        /// Preencher a lista Jogos com os jogos do campeonato
        /// </summary>
        /// <param name="Jogos"></param>
        /// <param name="dadosJogo"></param>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        /// <returns></returns>
        public List<DadosJogo> PreencherListaJogos(List<DadosJogo> Jogos, DadosJogo dadosJogo, List<string> voltas1, List<string> voltas2)
        {
            Jogos = new List<DadosJogo>();

            for (int i = 0; i < voltas1.Count; i++)
            {
                var campos = voltas1[i].Split(';');

                dadosJogo = new DadosJogo();

                dadosJogo.IdJogo = campos[0];
                dadosJogo.IdClubeCasa = campos[1];
                dadosJogo.IdClubeFora = campos[2];
                dadosJogo.NomeClubeCasa = campos[3];
                dadosJogo.NomeClubeFora = campos[4];
                dadosJogo.Dia = Convert.ToDateTime(campos[5]);
                dadosJogo.Hora = Convert.ToDateTime(campos[6]);
                dadosJogo.Estadio = campos[7];
                dadosJogo.IdJornada = campos[8];
                dadosJogo.GolosClubeCasa = Convert.ToInt32(campos[9]);
                dadosJogo.GolosClubeFora = Convert.ToInt32(campos[10]);

                Jogos.Add(dadosJogo);
            }

            for (int i = 0; i < voltas2.Count; i++)
            {
                var campos = voltas2[i].Split(';');

                dadosJogo = new DadosJogo();

                dadosJogo.IdJogo = campos[0];
                dadosJogo.IdClubeCasa = campos[1];
                dadosJogo.IdClubeFora = campos[2];
                dadosJogo.NomeClubeCasa = campos[3];
                dadosJogo.NomeClubeFora = campos[4];
                dadosJogo.Dia = Convert.ToDateTime(campos[5]);
                dadosJogo.Hora = Convert.ToDateTime(campos[6]);
                dadosJogo.Estadio = campos[7];
                dadosJogo.IdJornada = campos[8];
                dadosJogo.GolosClubeCasa = Convert.ToInt32(campos[9]);
                dadosJogo.GolosClubeFora = Convert.ToInt32(campos[10]);

                Jogos.Add(dadosJogo);
            }

            return Jogos;
        }
    }
}

