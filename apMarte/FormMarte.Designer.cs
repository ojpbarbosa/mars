namespace apMarte
{
  partial class FormMarte
  {
    /// <summary>
    /// Variável de designer necessária.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Limpar os recursos que estão sendo usados.
    /// </summary>
    /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Código gerado pelo Windows Form Designer

    /// <summary>
    /// Método necessário para suporte ao Designer - não modifique 
    /// o conteúdo deste método com o editor de código.
    /// </summary>
    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMarte));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mensagemStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.inicioButton = new System.Windows.Forms.ToolStripButton();
            this.anteriorButton = new System.Windows.Forms.ToolStripButton();
            this.proximoButton = new System.Windows.Forms.ToolStripButton();
            this.ultimoButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.procurarButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.novoButton = new System.Windows.Forms.ToolStripButton();
            this.cancelarButton = new System.Windows.Forms.ToolStripButton();
            this.salvarButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.excluirButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sairButton = new System.Windows.Forms.ToolStripButton();
            this.cidadesGroupBox = new System.Windows.Forms.GroupBox();
            this.cidadesListBox = new System.Windows.Forms.ListBox();
            this.yNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.xNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.nomeCidadeTextBox = new System.Windows.Forms.TextBox();
            this.codigoCidadeTextBox = new System.Windows.Forms.TextBox();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.nomeCidadeLabel = new System.Windows.Forms.Label();
            this.codigoCidadeLabel = new System.Windows.Forms.Label();
            this.caminhosGroupBox = new System.Windows.Forms.GroupBox();
            this.alterarLigacaoButton = new System.Windows.Forms.Button();
            this.excluirLigacaoButton = new System.Windows.Forms.Button();
            this.incluirLigacaoButton = new System.Windows.Forms.Button();
            this.custoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tempoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.distanciaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.custoLabel = new System.Windows.Forms.Label();
            this.tempoLabel = new System.Windows.Forms.Label();
            this.distanciaLabel = new System.Windows.Forms.Label();
            this.destinoLabel = new System.Windows.Forms.Label();
            this.origemLabel = new System.Windows.Forms.Label();
            this.destinoComboBox = new System.Windows.Forms.ComboBox();
            this.origemComboBox = new System.Windows.Forms.ComboBox();
            this.ligacoesLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mapaPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.cidadesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumericUpDown)).BeginInit();
            this.caminhosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempoNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanciaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mensagemStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 649);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1370, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // mensagemStatusLabel
            // 
            this.mensagemStatusLabel.Name = "mensagemStatusLabel";
            this.mensagemStatusLabel.Size = new System.Drawing.Size(76, 17);
            this.mensagemStatusLabel.Text = "Registro 1/23";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "first.bmp");
            this.imageList.Images.SetKeyName(1, "prior.bmp");
            this.imageList.Images.SetKeyName(2, "next.bmp");
            this.imageList.Images.SetKeyName(3, "last.bmp");
            this.imageList.Images.SetKeyName(4, "Oeil2.bmp");
            this.imageList.Images.SetKeyName(5, "Add.bmp");
            this.imageList.Images.SetKeyName(6, "UNDO.BMP");
            this.imageList.Images.SetKeyName(7, "Save.bmp");
            this.imageList.Images.SetKeyName(8, "Minus.bmp");
            this.imageList.Images.SetKeyName(9, "CLOSE1.BMP");
            // 
            // toolStrip
            // 
            this.toolStrip.BackColor = System.Drawing.Color.Silver;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioButton,
            this.anteriorButton,
            this.proximoButton,
            this.ultimoButton,
            this.toolStripSeparator1,
            this.procurarButton,
            this.toolStripSeparator3,
            this.novoButton,
            this.cancelarButton,
            this.salvarButton,
            this.toolStripSeparator2,
            this.excluirButton,
            this.toolStripSeparator5,
            this.sairButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1370, 42);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // inicioButton
            // 
            this.inicioButton.Image = ((System.Drawing.Image)(resources.GetObject("inicioButton.Image")));
            this.inicioButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inicioButton.Name = "inicioButton";
            this.inicioButton.Size = new System.Drawing.Size(40, 39);
            this.inicioButton.Text = "Início";
            this.inicioButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.inicioButton.Click += new System.EventHandler(this.inicioButton_Click);
            // 
            // anteriorButton
            // 
            this.anteriorButton.Image = ((System.Drawing.Image)(resources.GetObject("anteriorButton.Image")));
            this.anteriorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.anteriorButton.Name = "anteriorButton";
            this.anteriorButton.Size = new System.Drawing.Size(54, 39);
            this.anteriorButton.Text = "Anterior";
            this.anteriorButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.anteriorButton.Click += new System.EventHandler(this.anteriorButton_Click);
            // 
            // proximoButton
            // 
            this.proximoButton.Image = ((System.Drawing.Image)(resources.GetObject("proximoButton.Image")));
            this.proximoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.proximoButton.Name = "proximoButton";
            this.proximoButton.Size = new System.Drawing.Size(56, 39);
            this.proximoButton.Text = "Próximo";
            this.proximoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.proximoButton.Click += new System.EventHandler(this.proximoButton_Click);
            // 
            // ultimoButton
            // 
            this.ultimoButton.Image = ((System.Drawing.Image)(resources.GetObject("ultimoButton.Image")));
            this.ultimoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ultimoButton.Name = "ultimoButton";
            this.ultimoButton.Size = new System.Drawing.Size(47, 39);
            this.ultimoButton.Text = "Último";
            this.ultimoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ultimoButton.Click += new System.EventHandler(this.ultimoButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 42);
            // 
            // procurarButton
            // 
            this.procurarButton.Image = ((System.Drawing.Image)(resources.GetObject("procurarButton.Image")));
            this.procurarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.procurarButton.Name = "procurarButton";
            this.procurarButton.Size = new System.Drawing.Size(56, 39);
            this.procurarButton.Text = "Procurar";
            this.procurarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.procurarButton.Click += new System.EventHandler(this.procurarButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 42);
            // 
            // novoButton
            // 
            this.novoButton.Image = ((System.Drawing.Image)(resources.GetObject("novoButton.Image")));
            this.novoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.novoButton.Name = "novoButton";
            this.novoButton.Size = new System.Drawing.Size(40, 39);
            this.novoButton.Text = "Novo";
            this.novoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.novoButton.Click += new System.EventHandler(this.novoButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Enabled = false;
            this.cancelarButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelarButton.Image")));
            this.cancelarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(57, 39);
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // salvarButton
            // 
            this.salvarButton.Enabled = false;
            this.salvarButton.Image = ((System.Drawing.Image)(resources.GetObject("salvarButton.Image")));
            this.salvarButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.salvarButton.Name = "salvarButton";
            this.salvarButton.Size = new System.Drawing.Size(42, 39);
            this.salvarButton.Text = "Salvar";
            this.salvarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.salvarButton.Click += new System.EventHandler(this.salvarButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 42);
            // 
            // excluirButton
            // 
            this.excluirButton.Image = ((System.Drawing.Image)(resources.GetObject("excluirButton.Image")));
            this.excluirButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.excluirButton.Name = "excluirButton";
            this.excluirButton.Size = new System.Drawing.Size(46, 39);
            this.excluirButton.Text = "Excluir";
            this.excluirButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.excluirButton.Click += new System.EventHandler(this.excluirButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
            // 
            // sairButton
            // 
            this.sairButton.Image = ((System.Drawing.Image)(resources.GetObject("sairButton.Image")));
            this.sairButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sairButton.Name = "sairButton";
            this.sairButton.Size = new System.Drawing.Size(30, 39);
            this.sairButton.Text = "Sair";
            this.sairButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sairButton.Click += new System.EventHandler(this.sairButton_Click);
            // 
            // cidadesGroupBox
            // 
            this.cidadesGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cidadesGroupBox.Controls.Add(this.cidadesListBox);
            this.cidadesGroupBox.Controls.Add(this.yNumericUpDown);
            this.cidadesGroupBox.Controls.Add(this.xNumericUpDown);
            this.cidadesGroupBox.Controls.Add(this.nomeCidadeTextBox);
            this.cidadesGroupBox.Controls.Add(this.codigoCidadeTextBox);
            this.cidadesGroupBox.Controls.Add(this.yLabel);
            this.cidadesGroupBox.Controls.Add(this.xLabel);
            this.cidadesGroupBox.Controls.Add(this.nomeCidadeLabel);
            this.cidadesGroupBox.Controls.Add(this.codigoCidadeLabel);
            this.cidadesGroupBox.Location = new System.Drawing.Point(5, 45);
            this.cidadesGroupBox.Name = "cidadesGroupBox";
            this.cidadesGroupBox.Size = new System.Drawing.Size(320, 380);
            this.cidadesGroupBox.TabIndex = 8;
            this.cidadesGroupBox.TabStop = false;
            this.cidadesGroupBox.Text = "Cidades";
            // 
            // cidadesListBox
            // 
            this.cidadesListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cidadesListBox.FormattingEnabled = true;
            this.cidadesListBox.ItemHeight = 16;
            this.cidadesListBox.Items.AddRange(new object[] {
            "Cód Nome              X       Y"});
            this.cidadesListBox.Location = new System.Drawing.Point(5, 160);
            this.cidadesListBox.Name = "cidadesListBox";
            this.cidadesListBox.Size = new System.Drawing.Size(309, 212);
            this.cidadesListBox.TabIndex = 16;
            this.cidadesListBox.SelectedIndexChanged += new System.EventHandler(this.cidadesListBox_SelectedIndexChanged);
            // 
            // yNumericUpDown
            // 
            this.yNumericUpDown.DecimalPlaces = 5;
            this.yNumericUpDown.Location = new System.Drawing.Point(154, 126);
            this.yNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yNumericUpDown.Name = "yNumericUpDown";
            this.yNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.yNumericUpDown.TabIndex = 15;
            // 
            // xNumericUpDown
            // 
            this.xNumericUpDown.DecimalPlaces = 5;
            this.xNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.xNumericUpDown.Location = new System.Drawing.Point(154, 94);
            this.xNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xNumericUpDown.Name = "xNumericUpDown";
            this.xNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.xNumericUpDown.TabIndex = 14;
            // 
            // nomeCidadeTextBox
            // 
            this.nomeCidadeTextBox.Location = new System.Drawing.Point(154, 62);
            this.nomeCidadeTextBox.MaxLength = 15;
            this.nomeCidadeTextBox.Name = "nomeCidadeTextBox";
            this.nomeCidadeTextBox.Size = new System.Drawing.Size(158, 26);
            this.nomeCidadeTextBox.TabIndex = 13;
            // 
            // codigoCidadeTextBox
            // 
            this.codigoCidadeTextBox.Location = new System.Drawing.Point(154, 28);
            this.codigoCidadeTextBox.MaxLength = 3;
            this.codigoCidadeTextBox.Name = "codigoCidadeTextBox";
            this.codigoCidadeTextBox.Size = new System.Drawing.Size(47, 26);
            this.codigoCidadeTextBox.TabIndex = 12;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(12, 128);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(112, 20);
            this.yLabel.TabIndex = 11;
            this.yLabel.Text = "Coordenada y:";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(12, 96);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(112, 20);
            this.xLabel.TabIndex = 10;
            this.xLabel.Text = "Coordenada x:";
            // 
            // nomeCidadeLabel
            // 
            this.nomeCidadeLabel.AutoSize = true;
            this.nomeCidadeLabel.Location = new System.Drawing.Point(12, 65);
            this.nomeCidadeLabel.Name = "nomeCidadeLabel";
            this.nomeCidadeLabel.Size = new System.Drawing.Size(128, 20);
            this.nomeCidadeLabel.TabIndex = 9;
            this.nomeCidadeLabel.Text = "Nome da cidade:";
            // 
            // codigoCidadeLabel
            // 
            this.codigoCidadeLabel.AutoSize = true;
            this.codigoCidadeLabel.Location = new System.Drawing.Point(12, 31);
            this.codigoCidadeLabel.Name = "codigoCidadeLabel";
            this.codigoCidadeLabel.Size = new System.Drawing.Size(136, 20);
            this.codigoCidadeLabel.TabIndex = 8;
            this.codigoCidadeLabel.Text = "Código da cidade:";
            // 
            // caminhosGroupBox
            // 
            this.caminhosGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.caminhosGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.caminhosGroupBox.Controls.Add(this.alterarLigacaoButton);
            this.caminhosGroupBox.Controls.Add(this.excluirLigacaoButton);
            this.caminhosGroupBox.Controls.Add(this.incluirLigacaoButton);
            this.caminhosGroupBox.Controls.Add(this.custoNumericUpDown);
            this.caminhosGroupBox.Controls.Add(this.tempoNumericUpDown);
            this.caminhosGroupBox.Controls.Add(this.distanciaNumericUpDown);
            this.caminhosGroupBox.Controls.Add(this.custoLabel);
            this.caminhosGroupBox.Controls.Add(this.tempoLabel);
            this.caminhosGroupBox.Controls.Add(this.distanciaLabel);
            this.caminhosGroupBox.Controls.Add(this.destinoLabel);
            this.caminhosGroupBox.Controls.Add(this.origemLabel);
            this.caminhosGroupBox.Controls.Add(this.destinoComboBox);
            this.caminhosGroupBox.Controls.Add(this.origemComboBox);
            this.caminhosGroupBox.Controls.Add(this.ligacoesLabel);
            this.caminhosGroupBox.Location = new System.Drawing.Point(5, 430);
            this.caminhosGroupBox.Name = "caminhosGroupBox";
            this.caminhosGroupBox.Size = new System.Drawing.Size(320, 215);
            this.caminhosGroupBox.TabIndex = 9;
            this.caminhosGroupBox.TabStop = false;
            this.caminhosGroupBox.Text = "Caminhos";
            // 
            // alterarLigacaoButton
            // 
            this.alterarLigacaoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alterarLigacaoButton.Location = new System.Drawing.Point(265, 138);
            this.alterarLigacaoButton.Name = "alterarLigacaoButton";
            this.alterarLigacaoButton.Size = new System.Drawing.Size(36, 32);
            this.alterarLigacaoButton.TabIndex = 13;
            this.alterarLigacaoButton.Text = "#";
            this.alterarLigacaoButton.UseVisualStyleBackColor = true;
            // 
            // excluirLigacaoButton
            // 
            this.excluirLigacaoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excluirLigacaoButton.Location = new System.Drawing.Point(223, 138);
            this.excluirLigacaoButton.Name = "excluirLigacaoButton";
            this.excluirLigacaoButton.Size = new System.Drawing.Size(36, 32);
            this.excluirLigacaoButton.TabIndex = 12;
            this.excluirLigacaoButton.Text = "-";
            this.excluirLigacaoButton.UseVisualStyleBackColor = true;
            // 
            // incluirLigacaoButton
            // 
            this.incluirLigacaoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incluirLigacaoButton.Location = new System.Drawing.Point(181, 138);
            this.incluirLigacaoButton.Name = "incluirLigacaoButton";
            this.incluirLigacaoButton.Size = new System.Drawing.Size(36, 32);
            this.incluirLigacaoButton.TabIndex = 11;
            this.incluirLigacaoButton.Text = "+";
            this.incluirLigacaoButton.UseVisualStyleBackColor = true;
            // 
            // custoNumericUpDown
            // 
            this.custoNumericUpDown.Location = new System.Drawing.Point(91, 173);
            this.custoNumericUpDown.Name = "custoNumericUpDown";
            this.custoNumericUpDown.Size = new System.Drawing.Size(74, 26);
            this.custoNumericUpDown.TabIndex = 10;
            // 
            // tempoNumericUpDown
            // 
            this.tempoNumericUpDown.Location = new System.Drawing.Point(91, 142);
            this.tempoNumericUpDown.Name = "tempoNumericUpDown";
            this.tempoNumericUpDown.Size = new System.Drawing.Size(74, 26);
            this.tempoNumericUpDown.TabIndex = 9;
            // 
            // distanciaNumericUpDown
            // 
            this.distanciaNumericUpDown.Location = new System.Drawing.Point(91, 112);
            this.distanciaNumericUpDown.Maximum = new decimal(new int[] {
            12500,
            0,
            0,
            0});
            this.distanciaNumericUpDown.Name = "distanciaNumericUpDown";
            this.distanciaNumericUpDown.Size = new System.Drawing.Size(74, 26);
            this.distanciaNumericUpDown.TabIndex = 8;
            // 
            // custoLabel
            // 
            this.custoLabel.AutoSize = true;
            this.custoLabel.Location = new System.Drawing.Point(9, 175);
            this.custoLabel.Name = "custoLabel";
            this.custoLabel.Size = new System.Drawing.Size(55, 20);
            this.custoLabel.TabIndex = 7;
            this.custoLabel.Text = "Custo:";
            // 
            // tempoLabel
            // 
            this.tempoLabel.AutoSize = true;
            this.tempoLabel.Location = new System.Drawing.Point(9, 144);
            this.tempoLabel.Name = "tempoLabel";
            this.tempoLabel.Size = new System.Drawing.Size(62, 20);
            this.tempoLabel.TabIndex = 6;
            this.tempoLabel.Text = "Tempo:";
            // 
            // distanciaLabel
            // 
            this.distanciaLabel.AutoSize = true;
            this.distanciaLabel.Location = new System.Drawing.Point(9, 114);
            this.distanciaLabel.Name = "distanciaLabel";
            this.distanciaLabel.Size = new System.Drawing.Size(79, 20);
            this.distanciaLabel.TabIndex = 5;
            this.distanciaLabel.Text = "Distância:";
            // 
            // destinoLabel
            // 
            this.destinoLabel.AutoSize = true;
            this.destinoLabel.Location = new System.Drawing.Point(176, 50);
            this.destinoLabel.Name = "destinoLabel";
            this.destinoLabel.Size = new System.Drawing.Size(68, 20);
            this.destinoLabel.TabIndex = 4;
            this.destinoLabel.Text = "Destino:";
            // 
            // origemLabel
            // 
            this.origemLabel.AutoSize = true;
            this.origemLabel.Location = new System.Drawing.Point(9, 49);
            this.origemLabel.Name = "origemLabel";
            this.origemLabel.Size = new System.Drawing.Size(64, 20);
            this.origemLabel.TabIndex = 3;
            this.origemLabel.Text = "Origem:";
            // 
            // destinoComboBox
            // 
            this.destinoComboBox.FormattingEnabled = true;
            this.destinoComboBox.Location = new System.Drawing.Point(180, 72);
            this.destinoComboBox.Name = "destinoComboBox";
            this.destinoComboBox.Size = new System.Drawing.Size(135, 28);
            this.destinoComboBox.TabIndex = 2;
            // 
            // origemComboBox
            // 
            this.origemComboBox.FormattingEnabled = true;
            this.origemComboBox.Location = new System.Drawing.Point(13, 72);
            this.origemComboBox.Name = "origemComboBox";
            this.origemComboBox.Size = new System.Drawing.Size(135, 28);
            this.origemComboBox.TabIndex = 1;
            // 
            // ligacoesLabel
            // 
            this.ligacoesLabel.AutoSize = true;
            this.ligacoesLabel.Location = new System.Drawing.Point(9, 24);
            this.ligacoesLabel.Name = "ligacoesLabel";
            this.ligacoesLabel.Size = new System.Drawing.Size(73, 20);
            this.ligacoesLabel.TabIndex = 0;
            this.ligacoesLabel.Text = "Ligações";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "*.txt";
            this.openFileDialog.InitialDirectory = "c:\\temp";
            // 
            // mapaPictureBox
            // 
            this.mapaPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapaPictureBox.ErrorImage = null;
            this.mapaPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("mapaPictureBox.Image")));
            this.mapaPictureBox.InitialImage = null;
            this.mapaPictureBox.Location = new System.Drawing.Point(330, 45);
            this.mapaPictureBox.Name = "mapaPictureBox";
            this.mapaPictureBox.Size = new System.Drawing.Size(1200, 600);
            this.mapaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mapaPictureBox.TabIndex = 10;
            this.mapaPictureBox.TabStop = false;
            this.mapaPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapaPictureBox_Paint);
            // 
            // FormMarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 671);
            this.Controls.Add(this.mapaPictureBox);
            this.Controls.Add(this.caminhosGroupBox);
            this.Controls.Add(this.cidadesGroupBox);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "FormMarte";
            this.Text = "    ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMarte_FormClosing);
            this.Load += new System.EventHandler(this.FormMarte_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.cidadesGroupBox.ResumeLayout(false);
            this.cidadesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xNumericUpDown)).EndInit();
            this.caminhosGroupBox.ResumeLayout(false);
            this.caminhosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempoNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanciaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton inicioButton;
        private System.Windows.Forms.ToolStripButton anteriorButton;
        private System.Windows.Forms.ToolStripButton proximoButton;
        private System.Windows.Forms.ToolStripButton ultimoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton procurarButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton novoButton;
        private System.Windows.Forms.ToolStripButton cancelarButton;
        private System.Windows.Forms.ToolStripButton salvarButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton excluirButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton sairButton;
        private System.Windows.Forms.GroupBox cidadesGroupBox;
        private System.Windows.Forms.NumericUpDown yNumericUpDown;
        private System.Windows.Forms.NumericUpDown xNumericUpDown;
        private System.Windows.Forms.TextBox nomeCidadeTextBox;
        private System.Windows.Forms.TextBox codigoCidadeTextBox;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label nomeCidadeLabel;
        private System.Windows.Forms.Label codigoCidadeLabel;
        private System.Windows.Forms.GroupBox caminhosGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label ligacoesLabel;
        private System.Windows.Forms.ListBox cidadesListBox;
        private System.Windows.Forms.ComboBox destinoComboBox;
        private System.Windows.Forms.ComboBox origemComboBox;
        private System.Windows.Forms.NumericUpDown custoNumericUpDown;
        private System.Windows.Forms.NumericUpDown tempoNumericUpDown;
        private System.Windows.Forms.NumericUpDown distanciaNumericUpDown;
        private System.Windows.Forms.Label custoLabel;
        private System.Windows.Forms.Label tempoLabel;
        private System.Windows.Forms.Label distanciaLabel;
        private System.Windows.Forms.Label destinoLabel;
        private System.Windows.Forms.Label origemLabel;
        private System.Windows.Forms.Button alterarLigacaoButton;
        private System.Windows.Forms.Button excluirLigacaoButton;
        private System.Windows.Forms.Button incluirLigacaoButton;
        private System.Windows.Forms.ToolStripStatusLabel mensagemStatusLabel;
        private System.Windows.Forms.PictureBox mapaPictureBox;
    }
}

