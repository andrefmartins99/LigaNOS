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
            dadosClube.Clubes = metodosClube.LerFicheiroClubes(dadosClube);
            metodosClube.AtualizarListaClubes(dadosClube.Clubes, dadosClube);
            VerificarClubes();
            dadosJogo.Jogos = metodosJogo.LerFicheiroJogos(dadosJogo);
            VerificarJogos();
        }

        //Verificar se foram criados os 8 clubes
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

        //Preencher listBox com a lista Clubes
        public void PreencherListBoxClubes()
        {
            listBoxClubes.DataSource = null;
            listBoxClubes.DataSource = dadosClube.Clubes;
            listBoxClubes.ClearSelected();
        }

        //Criar um clube
        private void btnCriarClube_Click(object sender, EventArgs e)
        {
            CriarClube criarClube = new CriarClube(this, dadosClube.Clubes);
            criarClube.Show();
            btnCriarClube.Enabled = false;
            btnApagarClube.Enabled = false;
            btnEditarClube.Enabled = false;
            listBoxClubes.Enabled = false;
        }

        //Mudar o estado dos botões quando se sai do form criar clube
        public void EstadobtnCriar()
        {
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            btnEditarClube.Enabled = true;
            listBoxClubes.Enabled = true;
        }

        //Mudar o estado dos botões quando se sai do form editar clube
        public void EstadobtnEditar()
        {
            btnEditarClube.Enabled = true;
            btnCriarClube.Enabled = true;
            btnApagarClube.Enabled = true;
            listBoxClubes.Enabled = true;
            btnComecar.Enabled = true;
        }

        //Apagar um clube
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
                foreach (DadosClube dadosClube in dadosClube.Clubes)
                {
                    if (ClubeAEditar.IdClube == dadosClube.IdClube)
                    {
                        editado = dadosClube;
                    }
                }

                if (editado != null)
                {
                    EditarClube editarClube = new EditarClube(this, editado, dadosClube.Clubes);
                    editarClube.Show();
                    btnEditarClube.Enabled = false;
                    btnCriarClube.Enabled = false;
                    btnApagarClube.Enabled = false;
                    listBoxClubes.Enabled = false;
                    btnComecar.Enabled = false;
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
            dadosClube.Clubes = VerificarResetClubes();

            dadosJogo.Jogos = metodosJogo.CriarJogosCampeonato(dadosJogo.Jogos, dadosJogo, dadosClube.Clubes);
            PreencherComboBoxJornadas();
            cbJornadas.SelectedIndex = 0;
        }

        //Verificar se o campeonato já foi iniciado
        public void VerificarJogos()
        {
            contaJogos = dadosJogo.Jogos.Count;

            if (contaJogos == 56 && contaCLubes == 8)
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
            dadosJornada.Jornadas = metodosJornada.PreencherListaJornadas(dadosJornada.Jornadas, dadosJornada, dadosJogo.Jogos, id);

            dgvJornadas.Rows.Clear();

            foreach (var jogos in dadosJornada.Jornadas)
            {
                string[] row = { $"{jogos.Dia.ToString("dd MMM").ToUpper()} {jogos.Hora.ToShortTimeString()}", jogos.NomeClubeCasa, jogos.NomeClubeFora, jogos.Resultado };

                dgvJornadas.Rows.Add(row);
            }

            dgvJornadas.ClearSelection();
        }

        //Preencher comboBox com os ids das jornadas
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

        //Ajustar o estado do botão gerarResultados de acordo com a jornada selecionada na comboBox
        private void cbJornadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherDataGridViewJornadas(cbJornadas.SelectedItem.ToString());
            EstadoBtnGerarResultados();
        }

        //Mostrar classificação
        private void btnMostrarClassificacao_Click(object sender, EventArgs e)
        {
            Classificacao classificacao = new Classificacao(this, dadosClube.Clubes);
            classificacao.Show();
            btnMostrarClassificacao.Enabled = false;
            btnGerarResultados.Enabled = false;
            cbJornadas.Enabled = false;
            btnInfo1.Enabled = false;
            btnInfo2.Enabled = false;
            btnInfo3.Enabled = false;
            btnInfo4.Enabled = false;
            btnFinalizar.Enabled = false;
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
            EstadoBtnGerarResultados();
        }

        private void btnGerarResultados_Click(object sender, EventArgs e)
        {
            metodosJogo.GerarResultados(dadosJornada, dadosJogo, dadosJogo.Jogos, cbJornadas.SelectedItem.ToString(), metodosClube, dadosClube);
            PreencherDataGridViewJornadas(cbJornadas.SelectedItem.ToString());
            btnGerarResultados.Enabled = false;
            FinalizarCampeonato();
        }

        //Mostrar informação sobre o 1º jogo da jornada
        private void btnInfo1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {dadosJornada.Jornadas[0].Dia.ToShortDateString()} {dadosJornada.Jornadas[0].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {dadosJornada.Jornadas[0].NomeClubeCasa}" + Environment.NewLine + $"Clube Fora: {dadosJornada.Jornadas[0].NomeClubeFora}" + Environment.NewLine + $"Estádio: {dadosJornada.Jornadas[0].Estadio}" + Environment.NewLine + $"Resultado: {dadosJornada.Jornadas[0].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 2º jogo da jornada
        private void btnInfo2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {dadosJornada.Jornadas[1].Dia.ToShortDateString()} {dadosJornada.Jornadas[1].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {dadosJornada.Jornadas[1].NomeClubeCasa}" + Environment.NewLine + $"Clube Fora: {dadosJornada.Jornadas[1].NomeClubeFora}" + Environment.NewLine + $"Estádio: {dadosJornada.Jornadas[1].Estadio}" + Environment.NewLine + $"Resultado: {dadosJornada.Jornadas[1].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 3º jogo da jornada
        private void btnInfo3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {dadosJornada.Jornadas[2].Dia.ToShortDateString()} {dadosJornada.Jornadas[2].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {dadosJornada.Jornadas[2].NomeClubeCasa}" + Environment.NewLine + $"Clube Fora: {dadosJornada.Jornadas[2].NomeClubeFora}" + Environment.NewLine + $"Estádio: {dadosJornada.Jornadas[2].Estadio}" + Environment.NewLine + $"Resultado: {dadosJornada.Jornadas[2].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar informação sobre o 4º jogo da jornada
        private void btnInfo4_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Data: {dadosJornada.Jornadas[3].Dia.ToShortDateString()} {dadosJornada.Jornadas[3].Hora.ToShortTimeString()}" + Environment.NewLine + $"Clube Casa: {dadosJornada.Jornadas[3].NomeClubeCasa}" + Environment.NewLine + $"Clube Fora: {dadosJornada.Jornadas[3].NomeClubeFora}" + Environment.NewLine + $"Estádio: {dadosJornada.Jornadas[3].Estadio}" + Environment.NewLine + $"Resultado: {dadosJornada.Jornadas[3].Resultado}", "Informação do jogo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Gravar os clubes e os jogos quando se fecha o programa
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            metodosClube.GravarClube(dadosClube);
            metodosJogo.GravarInfoJogo(dadosJogo);
        }

        //Mudar o estado do botão gerarResultados dependendo da jornada selecionada na comboBox e o número de jornadas jogadas pelos clubes
        public void EstadoBtnGerarResultados()
        {
            foreach (var jornada in dadosJornada.Jornadas)
            {
                if (jornada.IdJornada == VerificarIdJornada(dadosClube.Clubes[0].NumJogos))
                {
                    btnGerarResultados.Enabled = true;
                }
                else
                {
                    btnGerarResultados.Enabled = false;
                }
            }
        }

        public string VerificarIdJornada(int numJogos)
        {
            if (numJogos < 9)
            {
                return $"J0{numJogos + 1}";
            }
            else
            {
                return $"J{numJogos + 1}";
            }
        }

        //Mudar o estado do botão finalizar de acordo com as jornadas jogadas
        public void FinalizarCampeonato()
        {
            if (dadosClube.Clubes[0].NumJogos == 14)
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
            foreach (var jogos in dadosJogo.Jogos)
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
            Campeao campeao = new Campeao(this, dadosClube.Clubes);
            campeao.Show();
            btnMostrarClassificacao.Enabled = false;
            btnInfo1.Enabled = false;
            btnInfo2.Enabled = false;
            btnInfo3.Enabled = false;
            btnInfo4.Enabled = false;
            btnFinalizar.Enabled = false;
            cbJornadas.Enabled = false;


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
        }

        //Apagar os ficheiros xml que contêm a informação dos clubes e dos jogos e limpar as listas Clubes e Jogos
        public void ApagarClubesJogosJornadas()
        {
            metodosClube.ApagarClube();
            metodosJogo.ApagarInfoJogo();
            dadosClube.Clubes.Clear();
            dadosJogo.Jogos.Clear();
        }

        //Dar reset às estatísticas dos clubes
        public List<DadosClube> VerificarResetClubes()
        {
            for (int i = 0; i < dadosClube.Clubes.Count; i++)
            {
                if (dadosClube.Clubes[i].NumJogos != 0)
                {
                    dadosClube.Clubes = metodosClube.ResetClubes(dadosClube);
                    return dadosClube.Clubes;
                }
            }

            return dadosClube.Clubes;
        }

        private void btnAmigavel_Click(object sender, EventArgs e)
        {
            var consola = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:/Users/André/source/repos/CET/C#/UFCD 5412/LigaNOS/Amigavel/obj/Debug/Amigavel.exe"
                }
            };

            if (File.Exists("C:/Users/André/source/repos/CET/C#/UFCD 5412/LigaNOS/Amigavel/obj/Debug/Amigavel.exe"))
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
    }
}
