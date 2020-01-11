using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    public class MetodosClube
    {
        /// <summary>
        /// Ler ficheiro dos clubes e criar uma lista para saber quantos clubes foram criados
        /// </summary>
        public List<DadosClube> LerFicheiroClubes(List<DadosClube> Clubes, DadosClube dadosClube)
        {
            string ficheiro = "clubeInfo.txt";
            Clubes = new List<DadosClube>();

            StreamReader sr;

            if (File.Exists(ficheiro))
            {
                sr = File.OpenText(ficheiro);

                string linha = string.Empty;

                while ((linha = sr.ReadLine()) != null)
                {
                    var campos = linha.Split(';');

                    dadosClube = new DadosClube();

                    dadosClube.IdClube = campos[0];
                    dadosClube.Nome = campos[1];
                    dadosClube.Treinador = campos[2];
                    dadosClube.Estadio = campos[3];


                    Clubes.Add(dadosClube);
                }

                sr.Close();
            }

            return Clubes;
        }

        /// <summary>
        /// Gravar os clubes e as suas estatísticas num ficheiro de texto
        /// </summary>
        public void GravarClube(DadosClube dadosClube)
        {
            //Info do clube
            string ficheiro = "clubeInfo.txt";
            string linha = $"{dadosClube.IdClube};{dadosClube.Nome};{dadosClube.Treinador};{dadosClube.Estadio}";

            StreamWriter sw = new StreamWriter(ficheiro, true);

            if (!File.Exists(ficheiro))
            {
                sw = File.CreateText(ficheiro);
            }

            sw.WriteLine(linha);
            sw.Close();

            //Estatística do clube
            string ficheiros = "estatisticaClube.txt";
            string linhas = $"{dadosClube.Nome};{dadosClube.Pontos};{dadosClube.NumJogos};{dadosClube.NumVitorias};{dadosClube.NumDerrotas};{dadosClube.NumEmpates};{dadosClube.GolosMarcados};{dadosClube.GolosSofridos};{dadosClube.DiferencaGolos}";

            StreamWriter sws = new StreamWriter(ficheiros, true);

            if (!File.Exists(ficheiros))
            {
                sw = File.CreateText(ficheiros);
            }

            sw.WriteLine(linhas);
            sw.Close();
        }

        /// <summary>
        /// Atualizar a estatística do clube após o jogo
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="pontos"></param>
        /// <param name="numJogos"></param>
        /// <param name="numVitorias"></param>
        /// <param name="numDerrotas"></param>
        /// <param name="numEmpates"></param>
        /// <param name="golosMarcados"></param>
        /// <param name="golosSofridos"></param>
        public void AtualizarEstatisticaClube(DadosClube dadosClube, string nome, int pontos, int numJogos, int numVitorias, int numDerrotas, int numEmpates, int golosMarcados, int golosSofridos)
        {
            string ficheiro = "estatisticaClube.txt";
            string linha = File.ReadAllLines(ficheiro).LastOrDefault(linhas => linhas.StartsWith(nome));
            string texto = File.ReadAllText(ficheiro);
            string linhaa;

            if (linha != null)
            {
                dadosClube.Pontos += pontos;
                dadosClube.NumJogos += numJogos;
                dadosClube.NumVitorias += numVitorias;
                dadosClube.NumDerrotas += numDerrotas;
                dadosClube.NumEmpates += numEmpates;
                dadosClube.GolosMarcados += golosMarcados;
                dadosClube.GolosSofridos += golosSofridos;

                linhaa = $"{dadosClube.Nome};{dadosClube.Pontos};{dadosClube.NumJogos};{dadosClube.NumVitorias};{dadosClube.NumDerrotas};{dadosClube.NumEmpates};{dadosClube.GolosMarcados};{dadosClube.GolosSofridos};{dadosClube.DiferencaGolos}";

                texto = texto.Replace(linha, linhaa);
                File.WriteAllText(ficheiro, texto);
            }
        }

        /// <summary>
        /// Apagar os ficheiros que contêm a informação e a estatística dos clubes
        /// </summary>
        public void ApagarClube()
        {
            string ficheiro = "clubeInfo.txt";
            string ficheiros = "estatisticaClube.txt";
            File.Delete(ficheiro);
            File.Delete(ficheiros);
        }

        /// <summary>
        /// Gerar o Id do clube a ser criado
        /// </summary>
        /// <param name="Clubes"></param>
        /// <returns></returns>
        public string GerarIdClube(List<DadosClube> Clubes)
        {
            int id = Clubes.Count;
            string idClube = string.Empty;

            idClube = "C0" + $"{id + 1}";

            return idClube;
        }

        /// <summary>
        /// Atualizar a lista Clubes após um clube ser apagado
        /// </summary>
        /// <param name="Clubes"></param>
        /// <param name="dadosClube"></param>
        public void AtualizarListaClubes(List<DadosClube> Clubes, DadosClube dadosClube)
        {
            dadosClube = new DadosClube();

            if (Clubes.Count > 1)
            {
                for (int i = 0; i < Clubes.Count; i++)
                {
                    dadosClube = Clubes[i];
                    dadosClube.IdClube = AtualizarIdClube(Clubes, i);
                    dadosClube.Nome = dadosClube.Nome;
                    dadosClube.Treinador = dadosClube.Treinador;
                    dadosClube.Estadio = dadosClube.Estadio;

                    Clubes[i] = dadosClube;
                }
            }
            else
            {
                for (int i = 0; i < Clubes.Count; i++)
                {
                    dadosClube = Clubes[i];
                    dadosClube.IdClube = "C01";
                    dadosClube.Nome = dadosClube.Nome;
                    dadosClube.Treinador = dadosClube.Treinador;
                    dadosClube.Estadio = dadosClube.Estadio;

                    Clubes[i] = dadosClube;
                }
            }
        }

        /// <summary>
        /// Atualizar o Id dos clubes da lista Clubes após um clube ser apagado
        /// </summary>
        /// <param name="Clubes"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public string AtualizarIdClube(List<DadosClube> Clubes, int l)
        {
            string idClube = string.Empty;
            int id = l;

            for (int i = 0; Clubes[i].ToString().StartsWith(idClube); i++)
            {
                idClube = "C0" + $"{id + 1}";
            }

            return idClube;
        }
    }
}
