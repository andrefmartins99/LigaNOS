using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class Campeao : Form
    {
        DadosClassificacao dadosClassificacao;
        MetodosClassificacao metodosClassificacao;
        List<DadosClube> Clubes;
        MenuPrincipal form;

        public Campeao(MenuPrincipal Form, List<DadosClube> clubes)
        {
            InitializeComponent();
            form = Form;
            Clubes = clubes;
            dadosClassificacao = new DadosClassificacao();
            metodosClassificacao = new MetodosClassificacao();
            dadosClassificacao.Classificacoes = metodosClassificacao.PreencherListaClassificacoes(Clubes, dadosClassificacao.Classificacoes, dadosClassificacao);

            lblCampeao.Text = $"Parabéns!!! O campeão é o {dadosClassificacao.Classificacoes[0].Nome}";
        }

        private void Campeao_FormClosing(object sender, FormClosingEventArgs e)
        {
            form.NaoFinalizar();
        }

        private void btnTerminarCampeonato_Click(object sender, EventArgs e)
        {
            DialogResult resposta;

            resposta = MessageBox.Show("Ao terminar o campeonato todos os clubes, jogos e jornadas vão ser apagados e o programa vai terminar.", "Terminar campeonato", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resposta == DialogResult.Yes)
            {
                form.ApagarClubesJogosJornadas();
                Application.Exit();
            }
        }
    }
}
