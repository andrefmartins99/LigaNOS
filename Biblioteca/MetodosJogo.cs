using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class MetodosJogo
    {
        //Gerar todos os jogos do campeonato
        public static List<DadosJogo> CriarJogosCampeonato(DadosJogo dadosJogo, DadosClube dadosClube, DadosJornada dadosJornada)
        {
            List<DadosJogo> voltas1 = new List<DadosJogo>();
            List<DadosJogo> voltas2 = new List<DadosJogo>();
            DadosJogo jogo;
            DadosJogo verificaJogo1;
            DadosJogo verificaJogo2;
            Random rng = new Random();
            int rnd;

            //Gerar jogos
            do
            {
                for (int i = 0; i < dadosClube.Clubes.Count - 1; i++)
                {
                    for (int j = i + 1; j < dadosClube.Clubes.Count; j++)
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
                                    jogo = new DadosJogo
                                    {
                                        ClubeCasa = dadosClube.Clubes[i],
                                        ClubeFora = dadosClube.Clubes[j],

                                    };

                                    voltas1.Add(jogo);//1º volta

                                    jogo = new DadosJogo
                                    {
                                        ClubeCasa = dadosClube.Clubes[j],
                                        ClubeFora = dadosClube.Clubes[i],
                                    };

                                    voltas2.Add(jogo);//2º volta
                                }
                                else
                                {
                                    jogo = new DadosJogo
                                    {
                                        ClubeCasa = dadosClube.Clubes[j],
                                        ClubeFora = dadosClube.Clubes[i],
                                    };

                                    voltas1.Add(jogo);//1º volta

                                    jogo = new DadosJogo
                                    {
                                        ClubeCasa = dadosClube.Clubes[i],
                                        ClubeFora = dadosClube.Clubes[j],
                                    };

                                    voltas2.Add(jogo);//2º volta
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 0; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                if (contador == 0)
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
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
                                string clube1 = voltas1[l].ClubeCasa.IdClube;
                                string clube2 = voltas1[l].ClubeFora.IdClube;

                                if (clube1 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == dadosClube.Clubes[j].IdClube)
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == dadosClube.Clubes[j].IdClube)
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
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 4; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
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
                                string clube1 = voltas1[l].ClubeCasa.IdClube;
                                string clube2 = voltas1[l].ClubeFora.IdClube;

                                if (clube1 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == dadosClube.Clubes[j].IdClube)
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == dadosClube.Clubes[j].IdClube)
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
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 8; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
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
                                string clube1 = voltas1[l].ClubeCasa.IdClube;
                                string clube2 = voltas1[l].ClubeFora.IdClube;

                                if (clube1 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == dadosClube.Clubes[j].IdClube)
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == dadosClube.Clubes[j].IdClube)
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
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 12; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
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
                                string clube1 = voltas1[l].ClubeCasa.IdClube;
                                string clube2 = voltas1[l].ClubeFora.IdClube;

                                if (clube1 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == dadosClube.Clubes[j].IdClube)
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == dadosClube.Clubes[j].IdClube)
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
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 16; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
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
                                string clube1 = voltas1[l].ClubeCasa.IdClube;
                                string clube2 = voltas1[l].ClubeFora.IdClube;

                                if (clube1 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == dadosClube.Clubes[j].IdClube)
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == dadosClube.Clubes[j].IdClube)
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
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 20; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
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
                                string clube1 = voltas1[l].ClubeCasa.IdClube;
                                string clube2 = voltas1[l].ClubeFora.IdClube;

                                if (clube1 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorCasa1++;
                                }
                                else if (clube2 == dadosClube.Clubes[i].IdClube)
                                {
                                    contadorFora1++;
                                }

                                if (clube1 == dadosClube.Clubes[j].IdClube)
                                {
                                    contadorCasa2++;
                                }
                                else if (clube2 == dadosClube.Clubes[j].IdClube)
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
                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                            else
                            {
                                //Verificar se os clubes já estão em jogos nesta jornada
                                for (int l = 24; l < voltas1.Count; l++)
                                {
                                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                                    string clube2 = voltas1[l].ClubeFora.IdClube;

                                    if (clube1 == dadosClube.Clubes[i].IdClube || clube1 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }

                                    if (clube2 == dadosClube.Clubes[i].IdClube || clube2 == dadosClube.Clubes[j].IdClube)
                                    {
                                        contador++;
                                    }
                                }

                                verificaJogo1 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[i],
                                    ClubeFora = dadosClube.Clubes[j],
                                };

                                verificaJogo2 = new DadosJogo
                                {
                                    ClubeCasa = dadosClube.Clubes[j],
                                    ClubeFora = dadosClube.Clubes[i],
                                };

                                //Verificar se o jogo já foi criado alguma vez no campeonato
                                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                                {
                                    if (rnd > 5)
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                    else
                                    {
                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[j],
                                            ClubeFora = dadosClube.Clubes[i],
                                        };

                                        voltas1.Add(jogo);//1º volta

                                        jogo = new DadosJogo
                                        {
                                            ClubeCasa = dadosClube.Clubes[i],
                                            ClubeFora = dadosClube.Clubes[j],
                                        };

                                        voltas2.Add(jogo);//2º volta
                                    }
                                }
                            }
                        }
                    }
                }

            } while (voltas1.Count != 28);

            DataVolta1(voltas1);
            DataVolta2(voltas2);
            OrdenarListaVoltas(voltas1, voltas2);
            EstadioVoltas(voltas1, voltas2);
            FinalizarVoltas(voltas1, voltas2);
            dadosJornada.Jogos = PreencherListaJogos(dadosJornada, voltas1, voltas2);

            return dadosJornada.Jogos;
        }

        //Adicionar a data dos jogos da primeria volta
        public static void DataVolta1(List<DadosJogo> voltas1)
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

                for (int i = tamanhoi, contador; i < tamanhof; i++, reset++)
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
                                if (voltas1[l].Dia.Equals(Convert.ToDateTime(horario.ToShortDateString())) && voltas1[l].Hora.Equals(Convert.ToDateTime(horario.ToShortTimeString())))
                                {
                                    contador++;
                                }
                            }
                        }

                    } while (contador != 0);

                    //Adicionar data ao jogo
                    voltas1[i].Dia = Convert.ToDateTime(horario.ToShortDateString());
                    voltas1[i].Hora = Convert.ToDateTime(horario.ToShortTimeString());

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
        public static void DataVolta2(List<DadosJogo> voltas2)
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

                for (int i = tamanhoi, contador; i < tamanhof; i++, reset++)
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
                                if (voltas2[l].Dia.Equals(Convert.ToDateTime(horario.ToShortDateString())) && voltas2[l].Hora.Equals(Convert.ToDateTime(horario.ToShortTimeString())))
                                {
                                    contador++;
                                }
                            }
                        }

                    } while (contador != 0);

                    //Adicionar data ao jogo
                    voltas2[i].Dia = Convert.ToDateTime(horario.ToShortDateString());
                    voltas2[i].Hora = Convert.ToDateTime(horario.ToShortTimeString());

                }

                tamanhoi += 4;
                tamanhof += 4;
                data1 = data1.AddDays(7);
                data2 = data2.AddDays(7);
                data3 = data3.AddDays(7);
                data4 = data4.AddDays(7);

            } while (tamanhoi != 28);
        }

        //Ordenar as listas pela data dos jogos
        public static void OrdenarListaVoltas(List<DadosJogo> voltas1, List<DadosJogo> voltas2)
        {
            voltas1.OrderBy(x => x.Dia).ThenBy(x => x.Hora);
            voltas2.OrderBy(x => x.Dia).ThenBy(x => x.Hora);
        }

        //Adicionar aos jogos o nome do estádio do clube que joga em casa
        public static void EstadioVoltas(List<DadosJogo> voltas1, List<DadosJogo> voltas2)
        {
            //Primeira volta
            for (int i = 0; i < voltas1.Count; i++)
            {
                voltas1[i].Estadio = voltas1[i].ClubeCasa.Estadio;
            }

            //Segunda volta
            for (int i = 0; i < voltas2.Count; i++)
            {
                voltas2[i].Estadio = voltas2[i].ClubeCasa.Estadio;
            }
        }

        //Criar e adicionar aos jogos o número de id do jogo e o número do id da jornada
        public static void FinalizarVoltas(List<DadosJogo> voltas1, List<DadosJogo> voltas2)
        {
            //Adicionar o número dos jogos da primeira volta
            for (int i = 0; i < voltas1.Count; i++)
            {
                voltas1[i].IdJogo = CriarIdJogoVoltas(i + 1);
            }

            //Adicionar o número dos jogos da segunda volta
            for (int i = 0; i < voltas2.Count; i++)
            {
                voltas2[i].IdJogo = CriarIdJogoVoltas(i + 1);
            }

            //Adicionar o número da jornada aos jogos da primeira volta
            int min1 = 0;
            int max1 = 4;
            int jornada1 = 1;

            do
            {
                for (int i = min1; i < max1; i++)
                {
                    voltas1[i].IdJornada = CriarIdJornadaVoltas(jornada1);
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
                    voltas2[i].IdJornada = CriarIdJornadaVoltas(jornada1);
                }

                min2 += 4;
                max2 += 4;
                jornada2++;

            } while (max2 != 32);
        }

        //Criar o id do jogo
        public static string CriarIdJogoVoltas(int i)
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
        public static string CriarIdJornadaVoltas(int jornada)
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
        public static List<DadosJogo> PreencherListaJogos(DadosJornada dadosJornada, List<DadosJogo> voltas1, List<DadosJogo> voltas2)
        {
            dadosJornada.Jogos = new List<DadosJogo>();

            //Primeira volta
            for (int i = 0; i < voltas1.Count; i++)
            {
                dadosJornada.Jogos.Add(voltas1[i]);
            }

            //Segunda volta
            for (int i = 0; i < voltas2.Count; i++)
            {
                dadosJornada.Jogos.Add(voltas2[i]);
            }

            return dadosJornada.Jogos;
        }
    }
}

