using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class MetodosJogo
    {
        //Gravar informações da lista Jogos no ficheiro xml jogoInfo
        public void GravarInfoJogo(DadosJogo dadosJogo)
        {
            string ficheiro = "jogoInfo.xml";
            XmlSerializer serial = new XmlSerializer(typeof(List<DadosJogo>));
            StreamWriter sw = new StreamWriter(ficheiro);
            serial.Serialize(sw, dadosJogo.Jogos);
            sw.Close();
        }

        //Apagar ficheiro xml jogoInfo
        public void ApagarInfoJogo()
        {
            string ficheiro = "jogoInfo.xml";
            File.Delete(ficheiro);
        }

        //Gerar todos os jogos do campeonato
        public List<DadosJogo> CriarJogosCampeonato(List<DadosJogo> Jogos, DadosJogo dadosJogo, List<DadosClube> Clubes)
        {
            Jogos = new List<DadosJogo>();
            List<string> clubes = new List<string>();
            List<string> voltas1 = new List<string>();
            List<string> voltas2 = new List<string>();
            List<string> jogo = new List<string>();
            Random rng = new Random();
            int rnd;

            //Retirar os ids dos clubes criados da lista Clubes
            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(';');
                string id = campos[0];
                clubes.Add(id);
            }

            //Gerar jogos
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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
                            //Verificar se os clubes jogaram em casa ou fora na jornada anterior
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
                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}")))
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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

                                //Verificar se o jogo já foi criado alguma vez no campeonato
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
                            //Verificar se os clubes jogaram em casa ou fora na jornada anterior
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
                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}")))
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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

                                //Verificar se o jogo já foi criado alguma vez no campeonato
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
                            //Verificar se os clubes jogaram em casa ou fora na jornada anterior
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
                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}")))
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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

                                //Verificar se o jogo já foi criado alguma vez no campeonato
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
                            //Verificar se os clubes jogaram em casa ou fora na jornada anterior
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
                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}")))
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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

                                //Verificar se o jogo já foi criado alguma vez no campeonato
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
                            //Verificar se os clubes jogaram em casa ou fora na jornada anterior
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
                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}")))
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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

                                //Verificar se o jogo já foi criado alguma vez no campeonato
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
                            //Verificar se os clubes jogaram em casa ou fora na jornada anterior
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
                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains($"{clubes[i]};{clubes[j]}")) && !(voltas1.Contains($"{clubes[j]};{clubes[i]}")))
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
                                //Verificar se os clubes já estão em jogos nesta jornada
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

                                //Verificar se o jogo já foi criado alguma vez no campeonato
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

        //Identificar os nomes dos clubes através do seu id e adicionar às listas voltas1 e voltas2
        public void NomeClubes(List<string> voltas1, List<string> voltas2, List<DadosClube> Clubes)
        {
            //Clubes que jogam em casa
            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(';');
                string id = campos[0];
                string nome = campos[1];

                //Primeira volta
                for (int j = 0; j < voltas1.Count; j++)
                {
                    var info = voltas1[j].Split(';');
                    string casa = info[0];

                    if (casa == id)
                    {
                        voltas1[j] = voltas1[j] + ";" + nome;
                    }
                }

                //Segunda volta
                for (int j = 0; j < voltas2.Count; j++)
                {
                    var info = voltas2[j].Split(';');
                    string casa = info[0];

                    if (casa == id)
                    {
                        voltas2[j] = voltas2[j] + ";" + nome;
                    }
                }
            }

            //Clubes que jogam fora
            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(';');
                string id = campos[0];
                string nome = campos[1];

                //Primeira volta
                for (int j = 0; j < voltas1.Count; j++)
                {
                    var info = voltas1[j].Split(';');
                    string fora = info[1];

                    if (fora == id)
                    {
                        voltas1[j] = voltas1[j] + ";" + nome;
                    }
                }

                //Segunda volta
                for (int j = 0; j < voltas2.Count; j++)
                {
                    var info = voltas2[j].Split(';');
                    string fora = info[1];

                    if (fora == id)
                    {
                        voltas2[j] = voltas2[j] + ";" + nome;
                    }
                }
            }
        }

        //Adicionar a data dos jogos da primeria volta
        public void DataVolta1(List<string> voltas1)
        {
            //(ano, mes, dia, horas, minutos, segundos)
            DateTime data1 = new DateTime(2020, 2, 22, 15, 0, 0);
            DateTime data2 = new DateTime(2020, 2, 22, 13, 0, 0);
            DateTime data3 = new DateTime(2020, 2, 23, 14, 0, 0);
            DateTime data4 = new DateTime(2020, 2, 23, 16, 0, 0);
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

        //Adicionar a data dos jogos da segunda volta
        public void DataVolta2(List<string> voltas2)
        {
            DateTime data1 = new DateTime(2020, 4, 18, 15, 0, 0);
            DateTime data2 = new DateTime(2020, 4, 18, 13, 0, 0);
            DateTime data3 = new DateTime(2020, 4, 19, 14, 0, 0);
            DateTime data4 = new DateTime(2020, 4, 19, 16, 0, 0);
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

        //Ordenar a lista da primera volta pela data dos jogos
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

        //Ordenar a lista da segunda volta pela data dos jogos
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

        //Adicionar aos jogos o nome do estádio do clube que joga em casa
        public void EstadioVoltas(List<string> voltas1, List<string> voltas2, List<DadosClube> Clubes)
        {
            for (int i = 0; i < Clubes.Count; i++)
            {
                var campos = Clubes[i].ToString().Split(';');
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

        //Criar e adicionar aos jogos o número de id do jogo e o número do id da jornada
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
        }

        //Criar o id do jogo
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

        //Criar o id da jornada
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

        //Preencher a lista Jogos a partir das lista voltas1 e voltas2
        public List<DadosJogo> PreencherListaJogos(List<DadosJogo> Jogos, DadosJogo dadosJogo, List<string> voltas1, List<string> voltas2)
        {
            Jogos = new List<DadosJogo>();

            //Primeira volta
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

                Jogos.Add(dadosJogo);
            }

            //Segunda volta
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

                Jogos.Add(dadosJogo);
            }

            return Jogos;
        }

        //Procurar ficheiro xml jogoInfo, se não existir cria-se um novo ficheiro, se existir a lista Jogos vai ser preenchida com a informação que estiver contida no ficheiro
        public List<DadosJogo> LerFicheiroJogos(DadosJogo dadosJogo)
        {
            dadosJogo.Jogos = new List<DadosJogo>();
            string ficheiro = "jogoInfo.xml";

            if (!File.Exists(ficheiro))
            {
                GravarInfoJogo(dadosJogo);
            }

            if (new FileInfo(ficheiro).Length == 0)
            {
                GravarInfoJogo(dadosJogo);
            }

            XmlSerializer serial = new XmlSerializer(typeof(List<DadosJogo>));
            StreamReader sr = new StreamReader(ficheiro);
            dadosJogo.Jogos = (List<DadosJogo>)(serial.Deserialize(sr));
            sr.Close();
            return dadosJogo.Jogos;
        }

        //Gerar resultados da jornada selecionada na comboBox
        public void GerarResultados(DadosJornada dadosJornada, DadosJogo dadosJogo, List<DadosJogo> Jogos, string idJornada, MetodosClube metodosClube, DadosClube dadosClube)
        {
            Random rng = new Random();
            int casa;
            int fora;

            for (int i = 0; i < dadosJornada.Jornadas.Count; i++)
            {
                foreach (var jogos in Jogos)
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
                            metodosClube.VitoriaClube(dadosClube, jogos.NomeClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora);
                            metodosClube.DerrotaClube(dadosClube, jogos.NomeClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa);
                        }
                        else if (casa < fora)
                        {
                            metodosClube.VitoriaClube(dadosClube, jogos.NomeClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa);
                            metodosClube.DerrotaClube(dadosClube, jogos.NomeClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora);
                        }
                        else
                        {
                            metodosClube.EmpateClube(dadosClube, jogos.NomeClubeCasa, jogos.GolosClubeCasa, jogos.GolosClubeFora);
                            metodosClube.EmpateClube(dadosClube, jogos.NomeClubeFora, jogos.GolosClubeFora, jogos.GolosClubeCasa);
                        }
                    }
                }
            }
        }
    }
}

