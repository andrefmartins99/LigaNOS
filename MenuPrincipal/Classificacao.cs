using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class Classificacao : Form
    {
        public MenuPrincipal MenuPrincipal { get; set; }

        public int Posicao { get; set; }

        public Classificacao(MenuPrincipal Form)
        {
            InitializeComponent();
            MenuPrincipal = Form;

            DadosClassificacao classificacao = new DadosClassificacao()
            {
                Clubes = MetodosClassificacao.OrdenarListaClubes(MenuPrincipal.Clubes)
            };

            PreencherDataGridViewClassificacao(classificacao);
        }

        //Preencher as linhas da datagridview com as estatísticas dos clubes
        public void PreencherDataGridViewClassificacao(DadosClassificacao classificacao)
        {
            Posicao = 1;

            foreach (var clube in classificacao.Clubes)
            {

                string[] row = { Posicao.ToString(), clube.Nome, clube.Pontos.ToString(), clube.NumJogos.ToString(), clube.NumVitorias.ToString(), clube.NumDerrotas.ToString(), clube.NumEmpates.ToString(), clube.GolosMarcados.ToString(), clube.GolosSofridos.ToString(), clube.DiferencaGolos.ToString() };

                dgvClassificacao.Rows.Add(row);
                Posicao++;
            }

            dgvClassificacao.ClearSelection();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            MenuPrincipal.EstadoBtnVoltar();
            this.Close();
        }

        private void Classificacao_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.EstadoBtnVoltar();
        }
    }
}
