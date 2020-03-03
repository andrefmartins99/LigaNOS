using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class Classificacao : Form
    {
        public MenuPrincipal MenuPrincipal { get; set; }

        public DadosClassificacao DadosClassificacao { get; set; }

        public int Posicao { get; set; }

        public Classificacao(MenuPrincipal Form)
        {
            InitializeComponent();
            MenuPrincipal = Form;
            DadosClassificacao = new DadosClassificacao();
            MetodosClassificacao.OrdenarListaClubes(DadosClassificacao.Clubes);
            PreencherDataGridViewClassificacao();
        }

        //Preencher as linhas da datagridview com as estatísticas dos clubes
        public void PreencherDataGridViewClassificacao()
        {
            Posicao = 1;

            foreach (var clube in DadosClassificacao.Clubes)
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
