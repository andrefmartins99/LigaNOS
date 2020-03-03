using Biblioteca;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class Campeao : Form
    {
        public MenuPrincipal MenuPrincipal { get; set; }

        public DadosClassificacao DadosClassificacao { get; set; }

        public Campeao(MenuPrincipal Form)
        {
            InitializeComponent();
            MenuPrincipal = Form;
            DadosClassificacao = new DadosClassificacao();

            lblCampeao.Text = $"Parabéns!!! O campeão é o {DadosClassificacao.Clubes[0].Nome}";
            lblEstatisticaCampeao.Text = $"Pontos: {DadosClassificacao.Clubes[0].Pontos}{Environment.NewLine}" +
                $"Número de vitórias: {DadosClassificacao.Clubes[0].NumVitorias}{Environment.NewLine}" +
                $"Número de derrotas: {DadosClassificacao.Clubes[0].NumDerrotas}{Environment.NewLine}" +
                $"Número de empates: {DadosClassificacao.Clubes[0].NumEmpates}{Environment.NewLine}" +
                $"Golos Marcados / Golos sofridos: {DadosClassificacao.Clubes[0].GolosMarcados} / {DadosClassificacao.Clubes[0].GolosSofridos}{Environment.NewLine}" +
                $"Diferença de golos: {DadosClassificacao.Clubes[0].DiferencaGolos}";
        }

        private void Campeao_FormClosing(object sender, FormClosingEventArgs e)
        {
            MenuPrincipal.NaoFinalizar();
        }

        private void btnTerminarCampeonato_Click(object sender, EventArgs e)
        {
            DialogResult resposta;

            resposta = MessageBox.Show("Ao terminar o campeonato todos os clubes, jogos e jornadas vão ser apagados e o programa vai terminar.", "Terminar campeonato", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (resposta == DialogResult.Yes)
            {
                MenuPrincipal.ApagarClubesJogosJornadas();
                Application.Exit();
            }
        }
    }
}
