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
        public DadosClube DadosClube { get; set; }

        public DadosJogo DadosJogo { get; set; }

        public DadosJornada DadosJornada { get; set; }

        public CriarClube CriarClubeForm { get; set; }

        public EditarClube EditarClubeForm { get; set; }

        public Classificacao ClassificacaoForm { get; set; }

        public Campeao CampeaoForm { get; set; }

        public MenuPrincipal()
        {
            InitializeComponent();
            DadosClube = new DadosClube();
            DadosJogo = new DadosJogo();
            DadosJornada = new DadosJornada();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DadosClube.Clubes = MetodosClube.LerFicheiroClubes(DadosClube);
            MetodosClube.AtualizarListaClubes(DadosClube);
            VerificarClubes();
            DadosJornada.Jogos = MetodosJornada.LerFicheiroJogos(DadosJornada);
            VerificarJogos();
        }

        //Verificar se foram criados os 8 clubes
        public void VerificarClubes()
        {
            lblclubeInfo.Text = $"{DadosClube.Clubes.Count.ToString()} de 8 clubes";
            PreencherListBoxClubes();

            if (DadosClube.Clubes.Count < 8)
            {
                btnCriarClube.Visible = true;
                btnComecar.Visible = false;
            }
            else
            {
                btnCriarClube.Visible = false;
                btnComecar.Visible = true;
            }

            if (DadosClube.Clubes.Count > 0)
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

        //Preencher listBox com a lista Clubes
        public void PreencherListBoxClubes()
        {
            listBoxClubes.DataSource = null;
            listBoxClubes.DataSource = DadosClube.Clubes;
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

        //Mudar o estado dos botões quando se sai do form criar clube
        public void EstadobtnCriar()
        {
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            btnEditarClube.Enabled = true;
            listBoxClubes.Enabled = true;
            btnAmigavel.Enabled = true;
            btnInfo.Enabled = true;
        }

        //Mudar o estado dos botões quando se sai do form editar clube
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
                foreach (DadosClube dadosClube in DadosClube.Clubes)
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
                        DadosClube.Clubes.Remove(apagado);
                        MetodosClube.AtualizarListaClubes(DadosClube);
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
                foreach (DadosClube dadosClube in DadosClube.Clubes)
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

            DadosClube.Clubes = VerificarResetClubes();

            DadosJornada.Jogos = MetodosJogo.CriarJogosCampeonato(DadosJogo, DadosClube, DadosJornada);
            PreencherComboBoxJornadas();
            cbJornadas.SelectedIndex = 0;
        }

        //Verificar se o campeonato já foi iniciado
        public void VerificarJogos()
        {
            if (DadosJornada.Jogos.Count == 56 && DadosClube.Clubes.Count == 8)
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

        //Preencher dataGridViewJornadas com a list Jornadas
        public void PreencherDataGridViewJornadas(string id)
        {
            dgvJornadas.Rows.Clear();

            foreach (var jogos in DadosJornada.Jogos)
            {
                if (jogos.IdJornada == id)
                {
                    string[] row = { $"{jogos.Dia.ToString("dd MMM").ToUpper()} {jogos.Hora.ToShortTimeString()}", jogos.ClubeCasa.Nome, jogos.ClubeFora.Nome, jogos.Resultado };

                    dgvJornadas.Rows.Add(row);
                }
            }

            dgvJornadas.ClearSelection();
        }

        //Preencher comboBox com os ids das jornadas
        public void PreencherComboBoxJornadas()
        {
            for (int i = 0; i < DadosJornada.Jogos.Count; i++)
            {
                string id;

                id = DadosJornada.Jogos[i].IdJornada;

                if (!cbJornadas.Items.Contains(id))
                {
                    cbJornadas.Items.Add(id);
                }
            }
        }

        //Ajustar o estado do botão gerarResultados de acordo com a jornada selecionada na comboBox
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

        //Mudar o estado dos botões quando se sai do form classificacao
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
            MetodosJornada.GerarResultados(DadosJornada, cbJornadas.SelectedItem.ToString(), DadosClube);
            PreencherDataGridViewJornadas(cbJornadas.SelectedItem.ToString());
            btnGerarResultados.Enabled = false;
            FinalizarCampeonato();
        }

        //Mostrar informação sobre o 1º jogo da jornada
        private void btnInfo1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {DadosJornada.Jogos[0].Dia.ToShortDateString()} {DadosJornada.Jogos[0].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {DadosJornada.Jogos[0].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {DadosJornada.Jogos[0].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {DadosJornada.Jogos[0].Estadio}" + Environment.NewLine + $"Resultado: {DadosJornada.Jogos[0].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 2º jogo da jornada
        private void btnInfo2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {DadosJornada.Jogos[1].Dia.ToShortDateString()} {DadosJornada.Jogos[1].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {DadosJornada.Jogos[1].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {DadosJornada.Jogos[1].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {DadosJornada.Jogos[1].Estadio}" + Environment.NewLine + $"Resultado: {DadosJornada.Jogos[1].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 3º jogo da jornada
        private void btnInfo3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {DadosJornada.Jogos[2].Dia.ToShortDateString()} {DadosJornada.Jogos[2].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {DadosJornada.Jogos[2].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {DadosJornada.Jogos[2].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {DadosJornada.Jogos[2].Estadio}" + Environment.NewLine + $"Resultado: {DadosJornada.Jogos[2].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 4º jogo da jornada
        private void btnInfo4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {DadosJornada.Jogos[3].Dia.ToShortDateString()} {DadosJornada.Jogos[3].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {DadosJornada.Jogos[3].ClubeCasa.Nome}" + Environment.NewLine + $"Clube Fora: {DadosJornada.Jogos[3].ClubeFora.Nome}" + Environment.NewLine + $"Estádio: {DadosJornada.Jogos[3].Estadio}" + Environment.NewLine + $"Resultado: {DadosJornada.Jogos[3].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Gravar os clubes e os jogos quando se fecha o programa
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            MetodosClube.GravarClube(DadosClube);
            MetodosJornada.GravarInfoJogo(DadosJornada);
        }

        //Mudar o estado do botão gerarResultados dependendo da jornada selecionada na comboBox e o número de jornadas jogadas pelos clubes
        public void EstadoBtnGerarResultados()
        {
            foreach (var jornada in DadosJornada.Jogos)
            {
                if (jornada.IdJornada == MetodosJornada.VerificarIdJornadaAtual(DadosClube.Clubes[0].NumJogos))
                {
                    btnGerarResultados.Enabled = true;
                }
                else
                {
                    btnGerarResultados.Enabled = false;
                }
            }
        }

        //Mudar o estado do botão finalizar de acordo com as jornadas jogadas
        public void FinalizarCampeonato()
        {
            if (DadosClube.Clubes[0].NumJogos == 14)
            {
                btnFinalizar.Visible = true;
            }
            else
            {
                btnFinalizar.Visible = false;
            }
        }

        //Iniciar o programa na jornada correta se o campeonato já tiver começado
        public string IniciarJornadaCorreta()
        {
            foreach (var jogos in DadosJornada.Jogos)
            {
                if (jogos.JogoJogado == false)
                {
                    return jogos.IdJornada;
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

        //Mudar estado dos botões quando se sai do form campeao
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

        //Apagar os ficheiros xml que contêm a informação dos clubes e dos jogos e limpar as listas Clubes e Jogos
        public void ApagarClubesJogosJornadas()
        {
            MetodosClube.ApagarClube();
            MetodosJornada.ApagarInfoJogo();
            DadosClube.Clubes.Clear();
            DadosJornada.Jogos.Clear();
        }

        //Dar reset às estatísticas dos clubes
        public List<DadosClube> VerificarResetClubes()
        {
            for (int i = 0; i < DadosClube.Clubes.Count; i++)
            {
                if (DadosClube.Clubes[i].NumJogos != 0)
                {
                    DadosClube.Clubes = MetodosClube.ResetClubes(DadosClube);
                    return DadosClube.Clubes;
                }
            }

            return DadosClube.Clubes;
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
