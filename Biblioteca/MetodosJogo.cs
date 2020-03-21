using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public static class MetodosJogo
    {
        /// <summary>
        /// Gerar todos os jogos do campeonato
        /// </summary>
        /// <param name="Clubes">Lista de clubes</param>
        /// <returns>Retorna uma lista de objetos do tipo jornada, tendo cada jornada uma lista de jogos a jogar nessa jornada</returns>
        public static List<DadosJornada> CriarJogosCampeonato(List<DadosClube> Clubes)
        {
            List<DadosJogo> voltas1 = new List<DadosJogo>();
            List<DadosJogo> voltas2 = new List<DadosJogo>();
            DadosJornada dadosJornada = new DadosJornada();
            Random rng = new Random();
            int rnd;

            int max = 28;//número máximo de jogos por volta, verificações
            int maxJornada = 3;//número máximo do Count por jornada, verificações
            int jogosPrimeiraJornada = 4;//número de jogos da primeira jornada, verificações
            int inicioJornada = 0;//número correspondente ao primeiro jogo de cada jornada(Count), verificações
            int jornadaAnterior = 0;//número correspondente ao primeiro jogo da jornada anterior(Count), verificações
            int mesmaJornada = 4;//número correspondente ao primeiro jogo da jornada(Count), verificações
            int novaJornada = 8;//verificações
            int numJogosPorJornada = 4;//número de jogos por jornada, verificações

            do
            {
                for (int i = 0; i < Clubes.Count - 1; i++)
                {
                    for (int j = i + 1; j < Clubes.Count; j++)
                    {
                        int contador = 0;
                        rnd = rng.Next(1, 11);

                        //1º jornda
                        if (voltas1.Count < jogosPrimeiraJornada)
                        {
                            primeriaJornada(voltas1, voltas2, Clubes, contador, maxJornada, inicioJornada, rnd, i, j);

                            if (voltas1.Count == jogosPrimeiraJornada)
                            {
                                maxJornada += 4;
                                inicioJornada += 4;
                            }
                        }
                        else
                        {
                            //jornadas restantes
                            outrasJornadas(voltas1, voltas2, Clubes, contador, maxJornada, inicioJornada, rnd, i, j, jornadaAnterior, mesmaJornada);

                            if (voltas1.Count % numJogosPorJornada == 0 && voltas1.Count != jogosPrimeiraJornada && voltas1.Count == novaJornada)
                            {
                                maxJornada += 4;
                                mesmaJornada += 4;
                                inicioJornada += 4;
                                jornadaAnterior += 4;
                                novaJornada += 4;
                            }
                        }
                    }
                }

            } while (voltas1.Count != max);

            DataVolta1(voltas1);
            DataVolta2(voltas2);
            OrdenarListaVoltas(voltas1, voltas2);
            EstadioVoltas(voltas1, voltas2);
            FinalizarVoltas(voltas1, voltas2);
            dadosJornada.Jogos = PreencherListaJogos(dadosJornada, voltas1, voltas2);

            return MetodosJornada.OrganizarJornadas(dadosJornada.Jogos);
        }

        /// <summary>
        /// Gerar os jogos da primeira jornada
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        /// <param name="Clubes"></param>
        /// <param name="contador"></param>
        /// <param name="maxJornada"></param>
        /// <param name="inicioJornada"></param>
        /// <param name="rnd"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void primeriaJornada(List<DadosJogo> voltas1, List<DadosJogo> voltas2, List<DadosClube> Clubes, int contador, int maxJornada, int inicioJornada, int rnd, int i, int j)
        {
            DadosJogo jogo;

            //1º jornada
            if (voltas1.Count <= maxJornada)
            {
                //1º jogo
                if (voltas1.Count == inicioJornada)
                {
                    if (rnd > 5)
                    {
                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[i],
                            ClubeFora = Clubes[j],
                        };

                        voltas1.Add(jogo);//1º volta

                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[j],
                            ClubeFora = Clubes[i],
                        };

                        voltas2.Add(jogo);//2º volta
                    }
                    else
                    {
                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[j],
                            ClubeFora = Clubes[i],
                        };

                        voltas1.Add(jogo);//1º volta

                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[i],
                            ClubeFora = Clubes[j],
                        };

                        voltas2.Add(jogo);//2º volta
                    }
                }
                else
                {
                    //verificar se jogo já existe na jornada
                    for (int l = 0; l < voltas1.Count; l++)
                    {
                        string clube1 = voltas1[l].ClubeCasa.IdClube;
                        string clube2 = voltas1[l].ClubeFora.IdClube;

                        if (clube1 == Clubes[i].IdClube || clube1 == Clubes[j].IdClube)
                        {
                            contador++;
                        }

                        if (clube2 == Clubes[i].IdClube || clube2 == Clubes[j].IdClube)
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
                                ClubeCasa = Clubes[i],
                                ClubeFora = Clubes[j],
                            };

                            voltas1.Add(jogo);//1º volta

                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[j],
                                ClubeFora = Clubes[i],
                            };

                            voltas2.Add(jogo);//2º volta
                        }
                        else
                        {
                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[j],
                                ClubeFora = Clubes[i],
                            };

                            voltas1.Add(jogo);//1º volta

                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[i],
                                ClubeFora = Clubes[j],
                            };

                            voltas2.Add(jogo);//2º volta
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gerar jogos das restantes jornadas
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        /// <param name="Clubes"></param>
        /// <param name="contador"></param>
        /// <param name="maxJornada"></param>
        /// <param name="inicioJornada"></param>
        /// <param name="rnd"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="jornadaAnterior"></param>
        /// <param name="mesmaJornada"></param>
        public static void outrasJornadas(List<DadosJogo> voltas1, List<DadosJogo> voltas2, List<DadosClube> Clubes, int contador, int maxJornada, int inicioJornada, int rnd, int i, int j, int jornadaAnterior, int mesmaJornada)
        {
            DadosJogo jogo;
            DadosJogo verificaJogo1;
            DadosJogo verificaJogo2;

            //2º jornada
            if (voltas1.Count <= maxJornada)
            {
                int contadorCasa1 = 0;
                int contadorCasa2 = 0;
                int contadorFora1 = 0;
                int contadorFora2 = 0;

                //verificar se os clubes jogaram em casa ou fora na última jornada
                for (int l = jornadaAnterior; l < voltas1.Count; l++)
                {
                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                    string clube2 = voltas1[l].ClubeFora.IdClube;

                    if (clube1 == Clubes[i].IdClube)
                    {
                        contadorCasa1++;
                    }
                    else if (clube2 == Clubes[i].IdClube)
                    {
                        contadorFora1++;
                    }

                    if (clube1 == Clubes[j].IdClube)
                    {
                        contadorCasa2++;
                    }
                    else if (clube2 == Clubes[j].IdClube)
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

                //1º jogo
                if (voltas1.Count == inicioJornada)
                {
                    verificaJogo1 = new DadosJogo
                    {
                        ClubeCasa = Clubes[i],
                        ClubeFora = Clubes[j],
                    };

                    verificaJogo2 = new DadosJogo
                    {
                        ClubeCasa = Clubes[j],
                        ClubeFora = Clubes[i],
                    };

                    //Verificar se o jogo já foi criado alguma vez no campeonato
                    if (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2)))
                    {
                        if (rnd > 5)
                        {
                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[i],
                                ClubeFora = Clubes[j],
                            };

                            voltas1.Add(jogo);//1º volta

                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[j],
                                ClubeFora = Clubes[i],
                            };

                            voltas2.Add(jogo);//2º volta
                        }
                        else
                        {
                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[j],
                                ClubeFora = Clubes[i],
                            };

                            voltas1.Add(jogo);//1º volta

                            jogo = new DadosJogo
                            {
                                ClubeCasa = Clubes[i],
                                ClubeFora = Clubes[j],
                            };

                            voltas2.Add(jogo);//2º volta
                        }
                    }
                }

                //verificar se jogo já existe na jornada
                for (int l = mesmaJornada; l < voltas1.Count; l++)
                {
                    string clube1 = voltas1[l].ClubeCasa.IdClube;
                    string clube2 = voltas1[l].ClubeFora.IdClube;

                    if (clube1 == Clubes[i].IdClube || clube1 == Clubes[j].IdClube)
                    {
                        contador++;
                    }

                    if (clube2 == Clubes[i].IdClube || clube2 == Clubes[j].IdClube)
                    {
                        contador++;
                    }
                }

                verificaJogo1 = new DadosJogo
                {
                    ClubeCasa = Clubes[i],
                    ClubeFora = Clubes[j],
                };

                verificaJogo2 = new DadosJogo
                {
                    ClubeCasa = Clubes[j],
                    ClubeFora = Clubes[i],
                };

                //Verificar se o jogo já foi criado alguma vez no campeonato
                if (contador == 0 && (!(voltas1.Contains(verificaJogo1)) && !(voltas1.Contains(verificaJogo2))))
                {
                    if (rnd > 5)
                    {
                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[i],
                            ClubeFora = Clubes[j],
                        };

                        voltas1.Add(jogo);//1º volta

                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[j],
                            ClubeFora = Clubes[i],
                        };

                        voltas2.Add(jogo);//2º volta
                    }
                    else
                    {
                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[j],
                            ClubeFora = Clubes[i],
                        };

                        voltas1.Add(jogo);//1º volta

                        jogo = new DadosJogo
                        {
                            ClubeCasa = Clubes[i],
                            ClubeFora = Clubes[j],
                        };

                        voltas2.Add(jogo);//2º volta
                    }
                }
            }
        }

        /// <summary>
        /// Adicionar a data dos jogos da primeria volta
        /// </summary>
        /// <param name="voltas1"></param>
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

        /// <summary>
        /// Adicionar a data dos jogos da segunda volta
        /// </summary>
        /// <param name="voltas2"></param>
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

        /// <summary>
        /// Ordenar as listas pela data dos jogos
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        public static void OrdenarListaVoltas(List<DadosJogo> voltas1, List<DadosJogo> voltas2)
        {
            voltas1.OrderBy(x => x.Dia).ThenBy(x => x.Hora);
            voltas2.OrderBy(x => x.Dia).ThenBy(x => x.Hora);
        }

        /// <summary>
        /// Adicionar aos jogos o nome do estádio do clube que joga em casa
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
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

        /// <summary>
        /// Criar e adicionar aos jogos o número de id do jogo e o número do id da jornada
        /// </summary>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
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
                voltas2[i].IdJogo = CriarIdJogoVoltas(i + 29);
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
                    voltas2[i].IdJornada = CriarIdJornadaVoltas(jornada2);
                }

                min2 += 4;
                max2 += 4;
                jornada2++;

            } while (max2 != 32);
        }

        /// <summary>
        /// Criar o id do jogo
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Criar o id da jornada
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Preencher a lista Jogos a partir das lista voltas1 e voltas2
        /// </summary>
        /// <param name="dadosJornada"></param>
        /// <param name="voltas1"></param>
        /// <param name="voltas2"></param>
        /// <returns></returns>
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

