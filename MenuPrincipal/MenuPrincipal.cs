using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        DadosClube dadosClube;
        MetodosClube metodosClube;
        DadosJogo dadosJogo;
        MetodosJogo metodosJogo;
        int contaCLubes = 0;

        public MenuPrincipal()
        {
            dadosClube = new DadosClube();
            metodosClube = new MetodosClube();
            dadosJogo = new DadosJogo();
            metodosJogo = new MetodosJogo();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dadosClube.Clubes = metodosClube.LerFicheiroClubes(dadosClube.Clubes, dadosClube);
            VerificarClubes();
        }

        public void VerificarClubes()
        {
            contaCLubes = dadosClube.Clubes.Count;
            lblclubeInfo.Text = $"{contaCLubes.ToString()} de 8 clubes";
            PreencherListBoxClubes();

            if (contaCLubes < 8)
            {
                btnCriarClube.Visible = true;
                btnComecar.Visible = false;
            }
            else
            {
                btnCriarClube.Visible = false;
                btnComecar.Visible = true;
            }

            if (contaCLubes > 0)
            {
                btnEditarClube.Visible = true;
                btnApagarClube.Visible = true;
            }
            else
            {
                btnEditarClube.Visible = false;
                btnApagarClube.Visible = false;
            }
        }

        public void PreencherListBoxClubes()
        {
            listBoxClubes.DataSource = null;
            listBoxClubes.DataSource = dadosClube.Clubes;
        }

        private void btnCriarClube_Click(object sender, EventArgs e)
        {
            CriarEquipa criarEquipa = new CriarEquipa(this, dadosClube.Clubes);
            criarEquipa.Show();
            btnCriarClube.Enabled = false;
        }

        public void EstadobtnCriar()
        {
            btnCriarClube.Enabled = true;
        }

        public void EstadobtnEditar()
        {
            btnEditarClube.Enabled = true;
        }

        private void btnApagarClube_Click(object sender, EventArgs e)
        {
            DadosClube clubeAApagar = (DadosClube)listBoxClubes.SelectedItem;
            DadosClube apagado = null;

            if (clubeAApagar != null)
            {
                foreach (DadosClube dadosClube in dadosClube.Clubes)
                {
                    if (clubeAApagar.IdClube == dadosClube.IdClube)
                    {
                        apagado = dadosClube;
                    }
                }

                if (apagado != null)
                {
                    DialogResult resposta;

                    resposta = MessageBox.Show($"Tem a certeza que pretende apagar o clube {apagado.Nome}?", "Apagar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (DialogResult.OK == resposta)
                    {
                        dadosClube.Clubes.Remove(apagado);
                        metodosClube.AtualizarListaClubes(dadosClube.Clubes, dadosClube);
                        PreencherListBoxClubes();
                        VerificarClubes();
                    }
                }
            }
        }

        private void btnEditarClube_Click(object sender, EventArgs e)
        {
            DadosClube ClubeAEditar = (DadosClube)listBoxClubes.SelectedItem;
            DadosClube editado = null;

            if (ClubeAEditar != null)
            {
                foreach (DadosClube dadosClube in dadosClube.Clubes)
                {
                    if (ClubeAEditar.IdClube == dadosClube.IdClube)
                    {
                        editado = dadosClube;
                    }
                }

                if (editado != null)
                {
                    EditarEquipa editarEquipa = new EditarEquipa(this, editado, dadosClube.Clubes);
                    editarEquipa.Show();
                    btnEditarClube.Enabled = false;
                }
            }
        }

        private void btnComecar_Click(object sender, EventArgs e)
        {
            listBoxClubes.Visible = false;
            lblclubeInfo.Visible = false;
            btnApagarClube.Visible = false;
            btnEditarClube.Visible = false;
            btnComecar.Visible = false;

            dadosJogo.Jogos = metodosJogo.CriarJogosCampeonato(dadosJogo.Jogos, dadosJogo, dadosClube.Clubes);
        }
    }
}
