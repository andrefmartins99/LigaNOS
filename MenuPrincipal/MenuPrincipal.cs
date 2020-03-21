using Biblioteca;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MenuPrincipal
{
    public partial class MenuPrincipal : Form
    {
        public List<DadosClube> Clubes { get; set; }

        public List<DadosJornada> Jornadas { get; set; }

        public CriarClube CriarClubeForm { get; set; }

        public EditarClube EditarClubeForm { get; set; }

        public Classificacao ClassificacaoForm { get; set; }

        public Campeao CampeaoForm { get; set; }

        public MenuPrincipal()
        {
            InitializeComponent();
            Clubes = new List<DadosClube>();
            Jornadas = new List<DadosJornada>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Clubes = MetodosClube.LerFicheiroClubes(Clubes);
            MetodosClube.AtualizarListaClubes(Clubes);
            VerificarClubes();
            Jornadas = MetodosJornada.LerFicheiroJogos(Jornadas);
            VerificarJogos();
        }

        /// <summary>
        /// Verificar se foram criados os 8 clubes
        /// </summary>
        public void VerificarClubes()
        {
            lblclubeInfo.Text = $"{Clubes.Count} de 8 clubes";
            PreencherListBoxClubes();

            if (Clubes.Count < 8)
            {
                btnCriarClube.Visible = true;
                btnComecar.Visible = false;
            }
            else
            {
                btnCriarClube.Visible = false;
                btnComecar.Visible = true;
            }

            if (Clubes.Count > 0)
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

        /// <summary>
        /// Preencher listBox com a lista Clubes
        /// </summary>
        public void PreencherListBoxClubes()
        {
            listBoxClubes.DataSource = null;
            listBoxClubes.DataSource = Clubes;
            listBoxClubes.ClearSelected();
        }

        //Criar um clube
        private void btnCriarClube_Click(object sender, EventArgs e)
        {
            CriarClubeForm = new CriarClube(this);
            CriarClubeForm.Show();
            btnCriarClube.Enabled = false;
            btnApagarClube.Enabled = false;
            btnEditarClube.Enabled = false;
            listBoxClubes.Enabled = false;
            btnAmigavel.Enabled = false;
            btnInfo.Enabled = false;
        }

        /// <summary>
        /// Mudar o estado dos botões quando se sai do form criar clube
        /// </summary>
        public void EstadobtnCriar()
        {
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            btnEditarClube.Enabled = true;
            listBoxClubes.Enabled = true;
            btnAmigavel.Enabled = true;
            btnInfo.Enabled = true;
        }

        /// <summary>
        /// Mudar o estado dos botões quando se sai do form editar clube
        /// </summary>
        public void EstadobtnEditar()
        {
            btnEditarClube.Enabled = true;
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            listBoxClubes.Enabled = true;
            btnComecar.Enabled = true;
            btnAmigavel.Enabled = true;
            btnInfo.Enabled = true;
        }

        //Apagar um clube
        private void btnApagarClube_Click(object sender, EventArgs e)
        {
            DadosClube clubeAApagar = (DadosClube)listBoxClubes.SelectedItem;
            DadosClube apagado = null;

            if (clubeAApagar != null)
            {
                foreach (DadosClube dadosClube in Clubes)
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
                        Clubes.Remove(apagado);
                        MetodosClube.AtualizarListaClubes(Clubes);
                        PreencherListBoxClubes();
                        VerificarClubes();
                    }
                }
            }
            else
            {
                MessageBox.Show("Tem de selecionar um clube!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Editar um clube
        private void btnEditarClube_Click(object sender, EventArgs e)
        {
            DadosClube ClubeAEditar = (DadosClube)listBoxClubes.SelectedItem;
            DadosClube editado = null;

            if (ClubeAEditar != null)
            {
                foreach (DadosClube dadosClube in Clubes)
                {
                    if (ClubeAEditar.IdClube == dadosClube.IdClube)
                    {
                        editado = dadosClube;
                    }
                }

                if (editado != null)
                {
                    EditarClubeForm = new EditarClube(this, editado);
                    EditarClubeForm.Show();
                    btnEditarClube.Enabled = false;
                    btnCriarClube.Enabled = false;
                    btnApagarClube.Enabled = false;
                    listBoxClubes.Enabled = false;
                    btnComecar.Enabled = false;
                    btnAmigavel.Enabled = false;
                    btnInfo.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Tem de selecionar um clube!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Iniciar campeonato
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
            btnGerarResultados.Visible = true;
            btnInfo1.Visible = true;
            btnInfo2.Visible = true;
            btnInfo3.Visible = true;
            btnInfo4.Visible = true;

            Clubes = VerificarResetClubes();

            Jornadas = MetodosJogo.CriarJogosCampeonato(Clubes);
            PreencherComboBoxJornadas();
            cbJornadas.SelectedIndex = 0;
        }

        /// <summary>
        /// Verificar se o campeonato já foi iniciado
        /// </summary>
        public void VerificarJogos()
        {
            if (Jornadas.Count == 14 && Clubes.Count == 8)
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
                btnGerarResultados.Visible = true;
                btnInfo1.Visible = true;
                btnInfo2.Visible = true;
                btnInfo3.Visible = true;
                btnInfo4.Visible = true;

                FinalizarCampeonato();
                PreencherComboBoxJornadas();
                cbJornadas.SelectedItem = IniciarJornadaCorreta();
            }
        }

        /// <summary>
        /// Preencher dataGridViewJornadas com a list Jornadas
        /// </summary>
        /// <param name="id"></param>
        public void PreencherDataGridViewJornadas(string id)
        {
            dgvJornadas.Rows.Clear();

            foreach (var jogos in Jornadas)
            {
                if (jogos.Jogos[0].IdJornada == id)
                {
                    for (int i = 0; i < jogos.Jogos.Count; i++)
                    {
                        string[] row = { $"{jogos.Jogos[i].Dia.ToString("dd MMM").ToUpper()} {jogos.Jogos[i].Hora.ToShortTimeString()}", jogos.Jogos[i].ClubeCasa.Nome, jogos.Jogos[i].ClubeFora.Nome, jogos.Jogos[i].Resultado };

                        dgvJornadas.Rows.Add(row);
                    }
                }
            }

            dgvJornadas.ClearSelection();
        }

        /// <summary>
        /// Preencher comboBox com os ids das jornadas
        /// </summary>
        public void PreencherComboBoxJornadas()
        {
            for (int i = 0; i < Jornadas.Count; i++)
            {
                string id;

                for (int j = 0; j < Jornadas[i].Jogos.Count; j++)
                {
                    id = Jornadas[i].Jogos[j].IdJornada;

                    if (!cbJornadas.Items.Contains(id))
                    {
                        cbJornadas.Items.Add(id);
                    }
                }
            }
        }

        /// <summary>
        /// Ajustar o estado do botão gerarResultados de acordo com a jornada selecionada na comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbJornadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherDataGridViewJornadas(cbJornadas.SelectedItem.ToString());
            EstadoBtnGerarResultados();
        }

        //Mostrar classificação
        private void btnMostrarClassificacao_Click(object sender, EventArgs e)
        {
            ClassificacaoForm = new Classificacao(this);
            ClassificacaoForm.Show();
            btnMostrarClassificacao.Enabled = false;
            btnGerarResultados.Enabled = false;
            cbJornadas.Enabled = false;
            btnInfo1.Enabled = false;
            btnInfo2.Enabled = false;
            btnInfo3.Enabled = false;
            btnInfo4.Enabled = false;
            btnFinalizar.Enabled = false;
            btnAmigavel.Enabled = false;
            btnInfo.Enabled = false;
        }

        /// <summary>
        /// Mudar o estado dos botões quando se sai do form classificacao
        /// </summary>
        public void EstadoBtnVoltar()
        {
            btnMostrarClassificacao.Enabled = true;
            cbJornadas.Enabled = true;
            btnGerarResultados.Enabled = true;
            btnInfo1.Enabled = true;
            btnInfo2.Enabled = true;
            btnInfo3.Enabled = true;
            btnInfo4.Enabled = true;
            btnFinalizar.Enabled = true;
            btnAmigavel.Enabled = true;
            btnInfo.Enabled = true;
            EstadoBtnGerarResultados();
        }

        private void btnGerarResultados_Click(object sender, EventArgs e)
        {
            MetodosJornada.GerarResultados(Jornadas, cbJornadas.SelectedItem.ToString(), Clubes);
            PreencherDataGridViewJornadas(cbJornadas.SelectedItem.ToString());
            btnGerarResultados.Enabled = false;
            FinalizarCampeonato();
        }

        //Mostrar informação sobre o 1º jogo da jornada
        private void btnInfo1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {Jornadas[cbJornadas.SelectedIndex].Jogos[0].Dia.ToShortDateString()} {Jornadas[cbJornadas.SelectedIndex].Jogos[0].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {Jornadas[cbJornadas.SelectedIndex].Jogos[0].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {Jornadas[cbJornadas.SelectedIndex].Jogos[0].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {Jornadas[cbJornadas.SelectedIndex].Jogos[0].Estadio}" + Environment.NewLine + $"Resultado: {Jornadas[cbJornadas.SelectedIndex].Jogos[0].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 2º jogo da jornada
        private void btnInfo2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {Jornadas[cbJornadas.SelectedIndex].Jogos[1].Dia.ToShortDateString()} {Jornadas[cbJornadas.SelectedIndex].Jogos[1].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {Jornadas[cbJornadas.SelectedIndex].Jogos[1].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {Jornadas[cbJornadas.SelectedIndex].Jogos[1].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {Jornadas[cbJornadas.SelectedIndex].Jogos[1].Estadio}" + Environment.NewLine + $"Resultado: {Jornadas[cbJornadas.SelectedIndex].Jogos[1].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 3º jogo da jornada
        private void btnInfo3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {Jornadas[cbJornadas.SelectedIndex].Jogos[2].Dia.ToShortDateString()} {Jornadas[cbJornadas.SelectedIndex].Jogos[2].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {Jornadas[cbJornadas.SelectedIndex].Jogos[2].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {Jornadas[cbJornadas.SelectedIndex].Jogos[2].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {Jornadas[cbJornadas.SelectedIndex].Jogos[2].Estadio}" + Environment.NewLine + $"Resultado: {Jornadas[cbJornadas.SelectedIndex].Jogos[2].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 4º jogo da jornada
        private void btnInfo4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {Jornadas[cbJornadas.SelectedIndex].Jogos[3].Dia.ToShortDateString()} {Jornadas[cbJornadas.SelectedIndex].Jogos[3].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {Jornadas[cbJornadas.SelectedIndex].Jogos[3].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {Jornadas[cbJornadas.SelectedIndex].Jogos[3].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {Jornadas[cbJornadas.SelectedIndex].Jogos[3].Estadio}" + Environment.NewLine + $"Resultado: {Jornadas[cbJornadas.SelectedIndex].Jogos[3].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Gravar os clubes e os jogos quando se fecha o programa
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            MetodosClube.GravarClube(Clubes);
            MetodosJornada.GravarInfoJogo(Jornadas);
        }

        /// <summary>
        /// Mudar o estado do botão gerarResultados dependendo da jornada selecionada na comboBox e o número de jornadas jogadas pelos clubes
        /// </summary>
        public void EstadoBtnGerarResultados()
        {
            if (cbJornadas.SelectedItem.ToString() == MetodosJornada.VerificarIdJornadaAtual(Clubes[0].NumJogos))
            {
                btnGerarResultados.Enabled = true;
            }
            else
            {
                btnGerarResultados.Enabled = false;
            }
        }

        /// <summary>
        /// Mudar o estado do botão finalizar de acordo com as jornadas jogadas
        /// </summary>
        public void FinalizarCampeonato()
        {
            if (Clubes[0].NumJogos == 14)
            {
                btnFinalizar.Visible = true;
            }
            else
            {
                btnFinalizar.Visible = false;
            }
        }

        /// <summary>
        /// Iniciar o programa na jornada correta se o campeonato já tiver começado
        /// </summary>
        /// <returns></returns>
        public string IniciarJornadaCorreta()
        {
            for (int i = 0; i < Jornadas.Count; i++)
            {
                for (int j = 0; j < Jornadas[i].Jogos.Count; j++)
                {
                    if (Jornadas[i].Jogos[j].JogoJogado == false)
                    {
                        return Jornadas[i].Jogos[j].IdJornada;
                    }
                }
            }

            return "J14";
        }

        //Mostrar o campeão do campeonato
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            CampeaoForm = new Campeao(this);
            CampeaoForm.Show();
            btnMostrarClassificacao.Enabled = false;
            btnInfo1.Enabled = false;
            btnInfo2.Enabled = false;
            btnInfo3.Enabled = false;
            btnInfo4.Enabled = false;
            btnFinalizar.Enabled = false;
            cbJornadas.Enabled = false;
            btnAmigavel.Enabled = false;
            btnInfo.Enabled = false;
        }

        /// <summary>
        /// Mudar estado dos botões quando se sai do form campeao
        /// </summary>
        public void NaoFinalizar()
        {
            btnMostrarClassificacao.Enabled = true;
            btnInfo1.Enabled = true;
            btnInfo2.Enabled = true;
            btnInfo3.Enabled = true;
            btnInfo4.Enabled = true;
            btnFinalizar.Enabled = true;
            cbJornadas.Enabled = true;
            btnAmigavel.Enabled = true;
            btnInfo.Enabled = true;
        }

        /// <summary>
        /// Apagar os ficheiros xml que contêm a informação dos clubes e dos jogos e limpar as listas Clubes e Jornadas
        /// </summary>
        public void ApagarClubesJogosJornadas()
        {
            MetodosClube.ApagarClube();
            MetodosJornada.ApagarInfoJogo();
            Clubes.Clear();
            Jornadas.Clear();
        }

        /// <summary>
        /// Dar reset às estatísticas dos clubes
        /// </summary>
        /// <returns></returns>
        public List<DadosClube> VerificarResetClubes()
        {
            for (int i = 0; i < Clubes.Count; i++)
            {
                if (Clubes[i].NumJogos != 0)
                {
                    Clubes = MetodosClube.ResetClubes(Clubes);
                    return Clubes;
                }
            }

            return Clubes;
        }

        private void btnAmigavel_Click(object sender, EventArgs e)
        {
            var consola = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "Amigavel.exe"
                }
            };

            if (File.Exists("Amigavel.exe"))
            {
                consola.Start();
                this.Enabled = false;
                consola.WaitForExit();
                this.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ficheiro não existe", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Mostrar info
        private void btnInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Feito por André Martins{Environment.NewLine}Versão 1.3{Environment.NewLine}Data: 15/02/2020", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
