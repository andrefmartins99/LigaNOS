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
        DadosJornada dadosJornada;
        MetodosJornada metodosJornada;
        int contaCLubes = 0;
        int contaJogos = 0;

        public MenuPrincipal()
        {
            dadosClube = new DadosClube();
            metodosClube = new MetodosClube();
            dadosJogo = new DadosJogo();
            metodosJogo = new MetodosJogo();
            dadosJornada = new DadosJornada();
            metodosJornada = new MetodosJornada();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dadosClube.Clubes = metodosClube.LerFicheiroClubes(dadosClube.Clubes, dadosClube);
            VerificarClubes();
            dadosJogo.Jogos = metodosJogo.LerFicheiroJogos(dadosJogo.Jogos, dadosJogo);
            verificarJogos();
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
            listBoxClubes.ClearSelected();
        }

        private void btnCriarClube_Click(object sender, EventArgs e)
        {
            CriarEquipa criarEquipa = new CriarEquipa(this, dadosClube.Clubes);
            criarEquipa.Show();
            btnCriarClube.Enabled = false;
            btnApagarClube.Enabled = false;
            btnEditarClube.Enabled = false;
            listBoxClubes.Enabled = false;
        }

        public void EstadobtnCriar()
        {
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            btnEditarClube.Enabled = true;
            listBoxClubes.Enabled = true;
        }

        public void EstadobtnEditar()
        {
            btnEditarClube.Enabled = true;
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            listBoxClubes.Enabled = true;
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
                    btnCriarClube.Enabled = false;
                    btnApagarClube.Enabled = false;
                    listBoxClubes.Enabled = false;
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
            dgvJornadas.Visible = true;
            lblJornadasInfo.Visible = true;
            cbJornadas.Visible = true;
            btnMostrarClassificacao.Visible = true;

            dadosJogo.Jogos = metodosJogo.CriarJogosCampeonato(dadosJogo.Jogos, dadosJogo, dadosClube.Clubes);
            PreencherComboBoxJornadas();
            cbJornadas.SelectedIndex = 0;
        }

        public void verificarJogos()
        {
            contaJogos = dadosJogo.Jogos.Count;

            if (contaJogos == 56)
            {
                listBoxClubes.Visible = false;
                lblclubeInfo.Visible = false;
                btnApagarClube.Visible = false;
                btnEditarClube.Visible = false;
                btnCriarClube.Visible = false;
                btnComecar.Visible = false;
                dgvJornadas.Visible = true;
                dgvJornadas.Enabled = false;
                lblJornadasInfo.Visible = true;
                cbJornadas.Visible = true;
                btnMostrarClassificacao.Visible = true;

                PreencherComboBoxJornadas();
                cbJornadas.SelectedIndex = 0;
            }
        }

        public void PreencherDataGridViewJornadas(string id)
        {
            dadosJornada.Jornadas = metodosJornada.PreencherListaJornadas(dadosJornada.Jornadas, dadosJornada, dadosJogo.Jogos, id);

            dgvJornadas.Columns.Clear();
            dgvJornadas.Rows.Clear();
            dgvJornadas.ColumnCount = 4;
            dgvJornadas.Columns[0].Name = "Data Jogo";
            dgvJornadas.Columns[1].Name = "Clube Casa";
            dgvJornadas.Columns[2].Name = "Clube Fora";
            dgvJornadas.Columns[3].Name = "Resultado";
            dgvJornadas.Columns[3].Width = 70;
            dgvJornadas.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvJornadas.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvJornadas.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvJornadas.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJornadas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJornadas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJornadas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJornadas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvJornadas.RowHeadersVisible = false;
            dgvJornadas.ScrollBars = ScrollBars.None;

            foreach (var jogos in dadosJornada.Jornadas)
            {
                var campos = jogos.ToString().Split(';');
                string[] row = { $"{campos[2]} {campos[3]}", campos[0], campos[1], campos[4] };
                dgvJornadas.Rows.Add(row);
            }

            dgvJornadas.ClearSelection();
        }

        public void PreencherComboBoxJornadas()
        {
            for (int i = 0; i < dadosJogo.Jogos.Count; i++)
            {
                if (i == 0)
                {
                    cbJornadas.Items.Add(metodosJornada.NumeroJornadas(dadosJogo.Jogos, dadosJogo, i));
                }
                else
                {
                    string id;

                    id = metodosJornada.NumeroJornadas(dadosJogo.Jogos, dadosJogo, i);

                    if (!cbJornadas.Items.Contains(id))
                    {
                        cbJornadas.Items.Add(id);
                    }
                }
            }
        }

        private void cbJornadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherDataGridViewJornadas(cbJornadas.SelectedItem.ToString());
        }

        private void btnMostrarClassificacao_Click(object sender, EventArgs e)
        {
            Classificacao classificacao = new Classificacao(this, dadosClube.Clubes);
            classificacao.Show();
            btnMostrarClassificacao.Enabled = false;
            cbJornadas.Enabled = false;
            dgvJornadas.Enabled = false;
        }
    }
}
