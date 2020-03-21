using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class MetodosClube
    {
        /// <summary>
        /// Procurar ficheiro xml clubeInfo, se não existir cria-se um novo ficheiro, se existir a lista Clubes vai ser preenchida com a informação que estiver contida no ficheiro
        /// </summary>
        /// <param name="Clubes"></param>
        /// <returns></returns>
        public static List<DadosClube> LerFicheiroClubes(List<DadosClube> Clubes)
        {
            string ficheiro = "clubeInfo.xml";

            if (!File.Exists(ficheiro))
            {
                GravarClube(Clubes);
            }

            if (new FileInfo(ficheiro).Length == 0)
            {
                GravarClube(Clubes);
            }

            XmlSerializer serial = new XmlSerializer(typeof(List<DadosClube>));
            StreamReader sr = new StreamReader(ficheiro);
            Clubes = (List<DadosClube>)(serial.Deserialize(sr));
            sr.Close();
            return Clubes;
        }

        /// <summary>
        /// Gravar informação da lista Clubes no ficheiro xml clubeInfo
        /// </summary>
        /// <param name="Clubes"></param>
        public static void GravarClube(List<DadosClube> Clubes)
        {
            string ficheiro = "clubeInfo.xml";
            XmlSerializer serial = new XmlSerializer(typeof(List<DadosClube>));
            StreamWriter sw = new StreamWriter(ficheiro);
            serial.Serialize(sw, Clubes);
            sw.Close();
        }

        /// <summary>
        /// Apagar o ficheiro xml clubeInfo
        /// </summary>
        public static void ApagarClube()
        {
            string ficheiro = "clubeInfo.xml";
            File.Delete(ficheiro);
        }

        /// <summary>
        /// Gerar Id do clube a ser criado
        /// </summary>
        /// <param name="Clubes"></param>
        /// <returns></returns>
        public static string GerarIdClube(List<DadosClube> Clubes)
        {
            int id = Clubes.Count;
            string idClube = "C0" + $"{id + 1}";
            return idClube;
        }

        /// <summary>
        /// Atualizar, se necessário, o Id dos clubes após um ser eliminado
        /// </summary>
        /// <param name="Clubes"></param>
        public static void AtualizarListaClubes(List<DadosClube> Clubes)
        {
            DadosClube dadosClube;

            for (int i = 0; i < Clubes.Count; i++)
            {
                dadosClube = Clubes[i];
                dadosClube.IdClube = $"C0" + $"{i + 1}";
                dadosClube.Nome = dadosClube.Nome;
                dadosClube.Treinador = dadosClube.Treinador;
                dadosClube.Estadio = dadosClube.Estadio;

                Clubes[i] = dadosClube;
            }
        }

        /// <summary>
        /// Adicionar ao clube vitorioso 1 jogo jogado, 1 vitória, 3 pontos, os golos marcados e os golos sofridos
        /// </summary>
        /// <param name="dadosClube"></param>
        /// <param name="golosMarcados"></param>
        /// <param name="golosSofridos"></param>
        /// <param name="Clubes"></param>
        public static void VitoriaClube(DadosClube dadosClube, int golosMarcados, int golosSofridos, List<DadosClube> Clubes)
        {
            foreach (var clube in Clubes)
            {
                if (clube.Nome == dadosClube.Nome)
                {
                    clube.NumJogos++;
                    clube.NumVitorias++;
                    clube.Pontos += 3;
                    clube.GolosMarcados += golosMarcados;
                    clube.GolosSofridos += golosSofridos;
                }
            }
        }

        /// <summary>
        /// Adicionar ao clube derrotado 1 jogo jogado, 1 derrota, os golos marcados e os golos sofridos
        /// </summary>
        /// <param name="dadosClube"></param>
        /// <param name="golosMarcados"></param>
        /// <param name="golosSofridos"></param>
        /// <param name="Clubes"></param>
        public static void DerrotaClube(DadosClube dadosClube, int golosMarcados, int golosSofridos, List<DadosClube> Clubes)
        {
            foreach (var clube in Clubes)
            {
                if (clube.Nome == dadosClube.Nome)
                {
                    clube.NumJogos++;
                    clube.NumDerrotas++;
                    clube.GolosMarcados += golosMarcados;
                    clube.GolosSofridos += golosSofridos;
                }
            }
        }

        /// <summary>
        /// Adicionar aos clubes que empataram 1 jogo jogado, 1 empate, 1 ponto, os golos marcados e os golos sofridos
        /// </summary>
        /// <param name="dadosClube"></param>
        /// <param name="golosMarcados"></param>
        /// <param name="golosSofridos"></param>
        /// <param name="Clubes"></param>
        public static void EmpateClube(DadosClube dadosClube, int golosMarcados, int golosSofridos, List<DadosClube> Clubes)
        {
            foreach (var clube in Clubes)
            {
                if (clube.Nome == dadosClube.Nome)
                {
                    clube.NumJogos++;
                    clube.NumEmpates++;
                    clube.Pontos += 1;
                    clube.GolosMarcados += golosMarcados;
                    clube.GolosSofridos += golosSofridos;
                }
            }
        }

        /// <summary>
        /// Dar reset às estatísticas dos clubes
        /// </summary>
        /// <param name="Clubes"></param>
        /// <returns></returns>
        public static List<DadosClube> ResetClubes(List<DadosClube> Clubes)
        {
            foreach (var clube in Clubes)
            {
                clube.Pontos = 0;
                clube.NumJogos = 0;
                clube.NumVitorias = 0;
                clube.NumDerrotas = 0;
                clube.NumEmpates = 0;
                clube.GolosMarcados = 0;
                clube.GolosSofridos = 0;
            }

            return Clubes;
        }
    }
}
