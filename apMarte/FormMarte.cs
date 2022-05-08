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

                if (lista.Tamanho > 0)
                {
                    cidadesListBox.SetSelected(lista.PosicaoAtual, true); // define o item selecionado no list box
                    mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}"; // define a status label 
                }
            }
        }

        private void inicioButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoPrimeiro();

            Cidade cidade = lista.DadoAtual(); // cidade recebe o dado atual

            PopularCampos(cidade); // popula os campos com a cidade em questão
        }

        private void ultimoButton_Click(object sender, EventArgs e)
        {
            lista.PosicionarNoUltimo();

            Cidade cidade = lista.DadoAtual(); // cidade recebe o dado atual

            PopularCampos(cidade); // popula os campos com a cidade em questão
        }

        private void anteriorButton_Click(object sender, EventArgs e)
        {
            lista.RetrocederPosicao();

            Cidade cidade = lista.DadoAtual(); // cidade recebe o dado atual

            if (cidade == null)
            {
                lista.PosicionarNoUltimo(); // posiciona o dado no último elemento

                cidade = lista.DadoAtual(); // cidade recebe o dado atual
            }

            PopularCampos(cidade); // popula os campos com a cidade em questão
        }

        private void proximoButton_Click(object sender, EventArgs e)
        {
            lista.AvancarPosicao();

            Cidade cidade = lista.DadoAtual(); // cidade recebe o dado atual

            if (cidade == null)
            {
                lista.PosicionarNoPrimeiro(); // posiciona o dado no primeiro elemento

                cidade = lista.DadoAtual(); // cidade recebe o dado atual
            }

            PopularCampos(cidade); // popula os campos com a cidade em questão
        }

        private void procurarButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "")
            {
                MessageBox.Show("Código de cidade inválido!");
            }

            else
            {
                Cidade cidadeASerProcurada = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                ); // cidade é instânciada com os valores dos campos

                if (lista.Existe(cidadeASerProcurada, out int ondeEsta)) // se a cidade existe
                {
                    lista.PosicionarEm(ondeEsta);
                    
                    PopularCampos(lista.DadoAtual()); // os campos são populados
                }

                else
                {
                    LimparCampos();
                    mensagemStatusLabel.Text = "Registro inexistente!";
                    MessageBox.Show("Registro inexistente!");
                }
            }
        }

        private void excluirButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "")
            {
                MessageBox.Show("Código de cidade inválido!");
            }

            else
            {
                Cidade cidadeASerExcluida = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                lista.Excluir(cidadeASerExcluida);
                lista.ExibirDados(cidadesListBox);
                lista.PosicionarNoPrimeiro();

                if (lista.PosicaoAtual != -1)
                {
                    cidadesListBox.SetSelected(lista.PosicaoAtual, true);
                    mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
                }

                else if (lista.Tamanho == 0)
                {
                    LimparCampos();
                }

                mapaPictureBox.Refresh();
            }
        }

        private void novoButton_Click(object sender, EventArgs e)
        {
            cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                    novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = false; // desativa o list box e os botões

            cancelarButton.Enabled = salvarButton.Enabled = true;

            LimparCampos(); // limpa os campos

            codigoCidadeTextBox.Focus();
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                    proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                        novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = true; // ativa o list box e os botões

            cancelarButton.Enabled = salvarButton.Enabled = false;

            LimparCampos(); // limpa os campos

            lista.PosicionarNoPrimeiro();
            
            cidadesListBox.SetSelected(lista.PosicaoAtual, true);
            mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
        }

        private void salvarButton_Click(object sender, EventArgs e)
        {
            if (codigoCidadeTextBox.Text == "" || nomeCidadeTextBox.Text == "" ||
                xNumericUpDown.Value == 0 || yNumericUpDown.Value == 0)
            {
                MessageBox.Show("Campos inválidos!");
            }

            else
            {
                Cidade cidadeASerCriada = new Cidade(
                    codigoCidadeTextBox.Text.PadLeft(3, ' '),
                    nomeCidadeTextBox.Text.PadRight(15, ' '),
                    xNumericUpDown.Value,
                    yNumericUpDown.Value
                );

                if (!lista.Existe(cidadeASerCriada, out _))
                {
                    if (lista.Incluir(cidadeASerCriada))
                    {
                        cidadesListBox.Enabled = inicioButton.Enabled = anteriorButton.Enabled =
                        proximoButton.Enabled = ultimoButton.Enabled = procurarButton.Enabled =
                            novoButton.Enabled = excluirButton.Enabled = sairButton.Enabled = true; // ativa o list box e os botões

                        cancelarButton.Enabled = salvarButton.Enabled = false;

                        lista.ExibirDados(cidadesListBox);

                        mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";

                        mapaPictureBox.Refresh();
                    }
                }

                else
                {
                    MessageBox.Show($"Cidade com código {cidadeASerCriada.Codigo.Trim()} já existente!");
                }
            }
        }

        private void sairButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName != "")
            {
                lista.GravarDados(openFileDialog.FileName);
            }

            Close();
        }

        private void cidadesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lista.Tamanho > 0)
            {
                lista.PosicionarEm(cidadesListBox.SelectedIndex);

                Cidade cidadeSelecionada = lista.DadoAtual();

                if (lista.SituacaoAtual == Situacao.navegando) // TODO: resolver problema
                {
                    PopularCampos(cidadeSelecionada);
                }
            }
        }

        private void mapaPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (openFileDialog.FileName != "")
            {
                lista.PosicionarNoPrimeiro();

                while (lista.DadoAtual() != null)
                {
                    Cidade cidade = lista.DadoAtual();

                    int x = (int)(cidade.X * mapaPictureBox.Width);
                    int y = (int)(cidade.Y * mapaPictureBox.Height);

                    RectangleF rectangle = new RectangleF(x, y, 8, 8);

                    Font font = new Font(codigoCidadeLabel.Font.FontFamily, 12);

                    e.Graphics.FillEllipse(Brushes.Black, rectangle);
                    e.Graphics.DrawEllipse(Pens.Black, rectangle);
                    e.Graphics.DrawString(cidade.Nome, font, Brushes.Black, x - cidade.Nome.Length, y + 6); ;

                    lista.AvancarPosicao();
                }
            }
        }

        private void FormMarte_FormClosing(object sender, FormClosingEventArgs e) // evento de fechamento do forms
        {
            if (openFileDialog.FileName != "") // se um arquivo foi aberto
            {
                lista.Ordenar(); // a lista é ordenada
                lista.GravarDados(openFileDialog.FileName); // e depois tem seus nós gravados
            }
        }

        private void PopularCampos(Cidade cidade) // popula os campos do forms
        {
            if (cidade != null)
            {
                codigoCidadeTextBox.Text = cidade.Codigo; // popula o text box do código da cidade
                nomeCidadeTextBox.Text = cidade.Nome; // popula o text box do nome da cidade
                xNumericUpDown.Value = cidade.X; // popula o numeric up down da coordenada X da cidade
                yNumericUpDown.Value = cidade.Y; // popula o numeric up down da coordenada Y da cidade

                cidadesListBox.SetSelected(lista.PosicaoAtual, true);
                mensagemStatusLabel.Text = $"Registro {lista.PosicaoAtual + 1}/{lista.Tamanho}";
            }

            else
            {
                LimparCampos();
            }
        }

        private void LimparCampos() // limpa os campos do forms
        {
            codigoCidadeTextBox.Text = ""; // limpa o text box do código da cidade
            nomeCidadeTextBox.Text = ""; // limpa o text box do nome da cidade
            xNumericUpDown.Value = 0; // limpa o numeric up down da coordenada X da cidade
            yNumericUpDown.Value = 0; // limpa o numeric up down da coordenada Y da cidade
        }
    }
}
