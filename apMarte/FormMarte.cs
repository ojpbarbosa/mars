// Gabriel Willian Bartmanovicz - 21234
// João Pedro Ferreira Barbosa - 21687

using System;
using System.Drawing;
using System.Windows.Forms;

namespace apMarte
{
    public partial class FormMarte : Form
    {
        private ListaDupla<Cidade> lista;

        public FormMarte()
        {
            InitializeComponent();
        }

        private void FormMarte_Load(object sender, EventArgs e)
        {
            int indice = 0;
            toolStrip.ImageList = imageList;

            foreach (ToolStripItem item in toolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).ImageIndex = indice++;
                }
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                lista = new ListaDupla<Cidade>(); // instancia a lista

                lista.LerDados(openFileDialog.FileName); // lê os dados
                lista.ExibirDados(cidadesListBox); // exibe os dados

                lista.PosicionarNoPrimeiro(); // posiciona no primeiro

                lista.SituacaoAtual = Situacao.navegando;

                PopularCampos(lista.DadoAtual()); // popula os campos com a primeira cidade
            }
        }

        private void inicioButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoPrimeiro();

            Cidade cidadeInicial = lista.DadoAtual(); // cidade recebe o dado atual

            PopularCampos(cidadeInicial); // popula os campos com a cidade inicial
        }

        private void ultimoButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoUltimo();

            Cidade ultimaCidade = lista.DadoAtual(); // cidade recebe o dado atual

            PopularCampos(ultimaCidade); // popula os campos com a última cidade
        }

        private void anteriorButton_Click(object sender, EventArgs e)
        {
            lista.RetrocederPosicao();

            Cidade cidadeAnterior = lista.DadoAtual(); // cidade recebe o dado atual

            if (cidadeAnterior == null)
            {
                lista.PosicionarNoUltimo(); // posiciona o dado no último elemento

                cidadeAnterior = lista.DadoAtual(); // cidade recebe o dado atual
            }

            PopularCampos(cidadeAnterior); // popula os campos com a cidade anterior
        }

        private void proximoButton_Click(object sender, EventArgs e)
        {
            lista.AvancarPosicao();

            Cidade proximaCidade = lista.DadoAtual(); // cidade recebe o dado atual

            if (proximaCidade == null)
            {
                lista.PosicionarNoPrimeiro(); // posiciona o dado no primeiro elemento

                proximaCidade = lista.DadoAtual(); // cidade recebe o dado atual
            }

            PopularCampos(proximaCidade); // popula os campos com a próxima cidade
        }

        private void procurarButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "") // se o código é inválido
            {
                MessageBox.Show(
                    "Código de cidade inválido!",
                    "Procurar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                ); // mensagem informando sobre o código inválido
            }

            else
            {
                Cidade cidadeASerProcurada = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                ); // instancia a cidade a ser procurada

                if (lista.Existe(cidadeASerProcurada, out _)) // se a cidade existe
                {
                    PopularCampos(lista.DadoAtual()); // popula os campos com a cidade procurada
                }

                else // senão
                {
                    LimparCampos(); // limpa os campos

                    mensagemStatusLabel.Text = "Cidade inexistente!"; // define a status label

                    MessageBox.Show(
                        "Cidade inexistente!",
                        "Procurar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    ); // mensagem informando sobre a inexistência da cidade
                }
            }
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "") // se o código é inválido
            {
                MessageBox.Show(
                    "Código de cidade inválido!",
                    "Excluir",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                ); // mensagem informando sobre o código inválido
            }

            else // senão
            {
                Cidade cidadeASerExcluida = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                ); // instancia a cidade a ser excluída

                if (MessageBox.Show(
                   "Exluir?",
                   "Excluir",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes) // mensagem confirmando a exclusão
                {
                    if (lista.Excluir(cidadeASerExcluida)) // se a cidade foi excluída
                    {
                        lista.ExibirDados(cidadesListBox); // exibe os dados

                        LimparCampos(); // limpa os campos

                        mapaPictureBox.Refresh(); // atualiza o picture box

                        MessageBox.Show(
                            "Cidade excluída!",
                            "Excluir",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        ); // mensagem informando sobre o êxito ao excluir
                    }

                    else // senão
                    {
                        MessageBox.Show(
                           "Erro ao excluir!",
                           "Excluir",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error
                       ); // mensagem informando sobre o erro ao excluir
                    }
                }
            }
        }

        private void novoButton_Click(object sender, EventArgs e) // modo de inclusão
        {
            cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                    novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = false; // desativa o list box e os botões

            cancelarButton.Enabled = salvarButton.Enabled = true; // ativa o botão cancelar e salvar

            LimparCampos(); // limpa os campos

            codigoCidadeTextBox.Focus(); // ativa no text box do código da cidade
        }

        private void cancelarButton_Click(object sender, EventArgs e) // modo normal
        {
            if (MessageBox.Show(
                "Cancelar?",
                "Cancelar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) // mensagem confirmando o cancelamento
            {
                cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                   proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                       novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = true; // ativa o list box e os botões

                cancelarButton.Enabled = salvarButton.Enabled = false; // desativa o botão cancelar e salvar

                LimparCampos(); // limpa os campos

                lista.PosicionarNoPrimeiro(); // posiciona no primeiro

                cidadesListBox.SetSelected(lista.PosicaoAtual, true); // define o item selecionado no list box
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}"; // define a status label
            }
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "" || nomeCidadeTextBox.Text == "" ||
                xNumericUpDown.Value == 0 || yNumericUpDown.Value == 0) // se os campos são inválidos
            {
                MessageBox.Show(
                    "Campos inválidos!",
                    "Salvar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                ); // mensagem informando sobre os campos inválidos
            }

            else // senão
            {
                if (MessageBox.Show(
                    "Salvar?",
                    "Salvar",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes) // mensagem confirmando o salvamento
                {
                    Cidade cidadeASerSalva = new Cidade(
                        codigoCidadeTextBox.Text.PadLeft(3, ' '),
                        nomeCidadeTextBox.Text.PadRight(15, ' '),
                        xNumericUpDown.Value,
                        yNumericUpDown.Value
                    ); // instancia uma nova cidade com os campos

                    if (!lista.Existe(cidadeASerSalva, out _)) // se a cidade não existe
                    {
                        if (lista.Incluir(cidadeASerSalva)) // se a inclusão ocorreu
                        {
                            cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                            proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                                novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = true; // ativa o list box e os botões

                            cancelarButton.Enabled = salvarButton.Enabled = false; // desativa o botão cancelar e salvar

                            lista.Ordenar(); // ordena a lista
                            lista.ExibirDados(cidadesListBox); // exibe os dados

                            PopularCampos(cidadeASerSalva); // popula os campos com a cidade a ser salva

                            mapaPictureBox.Refresh(); // atualiza o picture box

                            MessageBox.Show(
                                "Cidade salva!",
                                "Salvar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            ); // mensagem informando sobre o êxito ao salvar
                        }

                        else
                        {
                            MessageBox.Show(
                                "Erro ao salvar!",
                                "Salvar",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            ); // mensagem informando sobre o erro ao salvar
                        }
                    }

                    else
                    {
                        MessageBox.Show(
                            "Cidade já existente!",
                            "Salvar",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        ); // mensagem informando sobre a existência da cidade

                        PopularCampos(lista.DadoAtual()); // popula os campos com a cidade existente
                    }
                }
            }
        }

        private void sairButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Sair?",
                "Sair",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) // mensagem confirmando a saída
            {
                Close(); // fecha o form
            }
        }

        private void cidadesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lista != null && lista.Tamanho > 0) // se lista não for null e há elementos na lista
            {
                lista.PosicionarEm(cidadesListBox.SelectedIndex); // posiciona o atual no indíce selecionado

                Cidade cidadeSelecionada = lista.DadoAtual(); // cidade recebe o dado atual relativo ao indíce

                codigoCidadeTextBox.Text = cidadeSelecionada.Codigo; // popula o text box do código da cidade
                nomeCidadeTextBox.Text = cidadeSelecionada.Nome; // popula o text box do nome da cidade
                xNumericUpDown.Value = cidadeSelecionada.X; // popula o numeric up down da coordenada X da cidade
                yNumericUpDown.Value = cidadeSelecionada.Y; // popula o numeric up down da coordenada Y da cidade

                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}"; // define a status label
            }
        }

        private void mapaPictureBox_Paint(object sender, PaintEventArgs e) // evento paint do picture box
        {
            if (lista != null && lista.Tamanho > 0) // se lista não for null e há elementos na lista
            {
                lista.PosicionarNoPrimeiro(); // posiciona o atual no primeiro

                while (lista.DadoAtual() != null) // enquanto atual for diferente de null
                {
                    Cidade cidadeASerDesenhada = lista.DadoAtual(); // cidade recebe o dado atual

                    int x = (int)(cidadeASerDesenhada.X * mapaPictureBox.Width); // calcula a coordenada relativa ao X
                    int y = (int)(cidadeASerDesenhada.Y * mapaPictureBox.Height); // calcula a coordenada relativa ao Y

                    e.Graphics.FillEllipse(Brushes.Black, new Rectangle(x, y, 8, 8)); // desenha a cidade

                    Font font = new Font("Arial", 12); // instancia uma font Arial
                    e.Graphics.DrawString(
                        cidadeASerDesenhada.Nome,
                        font, Brushes.Black,
                        x - cidadeASerDesenhada.Nome.Length * 2,
                        y - 20
                    ); // desenha o nome da cidade

                    lista.AvancarPosicao(); // avança o atual
                }
            }
        }

        private void FormMarte_FormClosing(object sender, FormClosingEventArgs e) // evento de fechamento do forms
        {
            if (lista != null && openFileDialog.FileName != "") // se lista não foi null e um arquivo foi aberto
            {
                lista.Ordenar(); // a lista é ordenada
                lista.GravarDados(openFileDialog.FileName); // e depois tem seus dados gravados
            }
        }

        private void PopularCampos(Cidade cidade) // popula os campos do forms
        {
            if (cidade != null) // se a cidade não é null
            {
                codigoCidadeTextBox.Text = cidade.Codigo; // popula o text box do código da cidade
                nomeCidadeTextBox.Text = cidade.Nome; // popula o text box do nome da cidade
                xNumericUpDown.Value = cidade.X; // popula o numeric up down da coordenada X da cidade
                yNumericUpDown.Value = cidade.Y; // popula o numeric up down da coordenada Y da cidade

                if (lista.PosicaoAtual != -1) // se a posição não for inválida
                {
                    cidadesListBox.SetSelected(lista.PosicaoAtual, true); // define o item selecionado do list box
                    mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}"; // define a status label
                }
            }

            else // senão
            {
                LimparCampos(); // limpa os campos
            }
        }

        private void LimparCampos() // limpa os campos do forms
        {
            codigoCidadeTextBox.Clear(); // limpa o text box do código da cidade
            nomeCidadeTextBox.Clear(); // limpa o text box do nome da cidade
            xNumericUpDown.Value = 0; // limpa o numeric up down da coordenada X da cidade
            yNumericUpDown.Value = 0; // limpa o numeric up down da coordenada Y da cidade
        }
    }
}
