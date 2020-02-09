using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class MetodosClube
    {
        //Procurar ficheiro xml clubeInfo, se não existir cria-se um novo ficheiro, se existir a lista Clubes vai ser preenchida com a informação que estiver contida no ficheiro
        public List<DadosClube> LerFicheiroClubes(DadosClube dadosClube)
        {
            dadosClube.Clubes = new List<DadosClube>();
            string ficheiro = "clubeInfo.xml";

            if (!File.Exists(ficheiro))
            {
                GravarClube(dadosClube);
            }

            if (new FileInfo(ficheiro).Length == 0)
            {
                GravarClube(dadosClube);
            }

            XmlSerializer serial = new XmlSerializer(typeof(List<DadosClube>));
            StreamReader sr = new StreamReader(ficheiro);
            dadosClube.Clubes = (List<DadosClube>)(serial.Deserialize(sr));
            sr.Close();
            return dadosClube.Clubes;
        }

        //Gravar informação da lista Clubes no ficheiro xml clubeInfo
        public void GravarClube(DadosClube dadosClube)
        {
            string ficheiro = "clubeInfo.xml";
            XmlSerializer serial = new XmlSerializer(typeof(List<DadosClube>));
            StreamWriter sw = new StreamWriter(ficheiro);
            serial.Serialize(sw, dadosClube.Clubes);
            sw.Close();
        }

        //Apagar o ficheiro xml clubeInfo
        public void ApagarClube()
        {
            string ficheiro = "clubeInfo.xml";
            File.Delete(ficheiro);
        }

        //Gerar Id do clube a ser criado
        public string GerarIdClube(List<DadosClube> Clubes)
        {
            int id = Clubes.Count;
            string idClube = string.Empty;

            idClube = "C0" + $"{id + 1}";

            return idClube;
        }

        //Atualizar, se necessário, o Id dos clubes após um ser eliminado
        public void AtualizarListaClubes(List<DadosClube> Clubes, DadosClube dadosClube)
        {
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

        //Adicionar ao clube vitorioso 1 jogo jogado, 1 vitória, 3 pontos, os golos marcados e os golos sofridos
        public void VitoriaClube(DadosClube dadosClube, string clubeCasa, int golosMarcados, int golosSofridos)
        {
            foreach (var clube in dadosClube.Clubes)
            {
                if (clube.Nome == clubeCasa)
                {
                    clube.NumJogos++;
                    clube.NumVitorias++;
                    clube.Pontos += 3;
                    clube.GolosMarcados += golosMarcados;
                    clube.GolosSofridos += golosSofridos;
                }
            }
        }

        //Adicionar ao clube derrotado 1 jogo jogado, 1 derrota, os golos marcados e os golos sofridos
        public void DerrotaClube(DadosClube dadosClube, string clubeCasa, int golosMarcados, int golosSofridos)
        {
            foreach (var clube in dadosClube.Clubes)
            {
                if (clube.Nome == clubeCasa)
                {
                    clube.NumJogos++;
                    clube.NumDerrotas++;
                    clube.GolosMarcados += golosMarcados;
                    clube.GolosSofridos += golosSofridos;
                }
            }
        }

        //Adicionar aos clubes que empataram 1 jogo jogado, 1 empate, 1 ponto, os golos marcados e os golos sofridos
        public void EmpateClube(DadosClube dadosClube, string clubeCasa, int golosMarcados, int golosSofridos)
        {
            foreach (var clube in dadosClube.Clubes)
            {
                if (clube.Nome == clubeCasa)
                {
                    clube.NumJogos++;
                    clube.NumEmpates++;
                    clube.Pontos += 1;
                    clube.GolosMarcados += golosMarcados;
                    clube.GolosSofridos += golosSofridos;
                }
            }
        }

        //Dar reset às estatísticas dos clubes
        public List<DadosClube> ResetClubes(DadosClube dadosClube)
        {
            foreach (var clube in dadosClube.Clubes)
            {
                clube.Pontos = 0;
                clube.NumJogos = 0;
                clube.NumVitorias = 0;
                clube.NumDerrotas = 0;
                clube.NumEmpates = 0;
                clube.GolosMarcados = 0;
                clube.GolosSofridos = 0;
            }

            return dadosClube.Clubes;
        }
    }
}
