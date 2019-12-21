using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Biblioteca
{
    public class Jogo
    {
        //Propriedades

        public int IdJogo { get; set; }

        public string NomeEquipaCasa { get; set; }

        public string NomeEquipaFora { get; set; }

        public DateTime Data { get; set; }

        public string NomeArbitro { get; set; }

        public string Estadio { get; set; }

        public int IdJornada { get; set; }

        public int GolosEquipaCasa { get; set; }

        public int GolosEquipaFora { get; set; }

        public string Resultado
        {
            get
            {
                return $"{GolosEquipaCasa}:{GolosEquipaFora}";
            }
        }


        //Métodos

        /// <summary>
        /// Gravar os jogos num ficheiro de texto
        /// </summary>
        private void GravarInfoJogo()
        {
            string ficheiro = "jogoInfo.txt";
            string linha = $"{IdJogo};{NomeEquipaCasa};{NomeEquipaFora};{Data};{NomeArbitro};{Estadio};{IdJornada};{GolosEquipaCasa};{GolosEquipaFora};{Resultado}";

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
        private void AtualizarInfoJogo(int id, int golosEquipaCasa, int golosEquipaFora)
        {
            string ficheiro = "jogoInfo.txt";
            string linha = File.ReadAllLines(ficheiro).LastOrDefault(linhas => linhas.StartsWith(id.ToString()));
            string texto = File.ReadAllText(ficheiro);
            string linhaa;

            if (linha != null)
            {
                GolosEquipaCasa = golosEquipaCasa;
                GolosEquipaFora = golosEquipaFora;

                linhaa = $"{IdJogo};{NomeEquipaCasa};{NomeEquipaFora};{Data};{NomeArbitro};{Estadio};{IdJornada};{GolosEquipaCasa};{GolosEquipaFora};{Resultado}";

                texto = texto.Replace(linha, linhaa);
                File.WriteAllText(ficheiro, texto);
            }
        }

        /// <summary>
        /// Apagar o ficheiro que contém a informação dos jogos 
        /// </summary>
        private void ApagarInfoJogo()
        {
            string ficheiro = "jogoInfo.txt";
            File.Delete(ficheiro);
        }
    }
}
