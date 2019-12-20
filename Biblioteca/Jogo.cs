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

        private void AtualizarInfoJogo(int Id)
        {
            string ficheiro = "jogoInfo.txt";
            string linha = File.ReadAllLines(ficheiro).LastOrDefault(linhas => linhas.StartsWith(Id.ToString()));
            string texto = File.ReadAllText(ficheiro);
            string linhaa;


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
