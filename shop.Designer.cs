namespace WorldWines
{
    partial class shop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(shop));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.customColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBtn = new Guna.UI2.WinForms.Guna2Button();
            this.totalTextbox = new System.Windows.Forms.TextBox();
            this.backHomeBtn = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAlcohol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCurCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.numericUpDown = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.total2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.increaseBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.customColumn5,
            this.customColumn1,
            this.customColumn2,
            this.customColumn3,
            this.customColumn4,
            this.customColumn6,
            this.customColumn7,
            this.ID});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(293, 15);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1163, 631);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // customColumn5
            // 
            this.customColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn5.HeaderText = "สินค้า";
            this.customColumn5.Name = "customColumn5";
            this.customColumn5.ReadOnly = true;
            this.customColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.customColumn5.Width = 113;
            // 
            // customColumn1
            // 
            this.customColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn1.HeaderText = "ชื่อสินค้า";
            this.customColumn1.Name = "customColumn1";
            this.customColumn1.ReadOnly = true;
            this.customColumn1.Width = 200;
            // 
            // customColumn2
            // 
            this.customColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn2.HeaderText = "แอลกอฮอล์";
            this.customColumn2.Name = "customColumn2";
            this.customColumn2.ReadOnly = true;
            this.customColumn2.Width = 85;
            // 
            // customColumn3
            // 
            this.customColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn3.HeaderText = "แหล่งที่มา";
            this.customColumn3.Name = "customColumn3";
            this.customColumn3.ReadOnly = true;
            // 
            // customColumn4
            // 
            this.customColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn4.HeaderText = "ราคา";
            this.customColumn4.Name = "customColumn4";
            this.customColumn4.ReadOnly = true;
            // 
            // customColumn6
            // 
            this.customColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn6.HeaderText = "เพิ่มเติม";
            this.customColumn6.Name = "customColumn6";
            this.customColumn6.ReadOnly = true;
            this.customColumn6.Width = 470;
            // 
            // customColumn7
            // 
            this.customColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.customColumn7.HeaderText = "คงเหลือ";
            this.customColumn7.Name = "customColumn7";
            this.customColumn7.ReadOnly = true;
            this.customColumn7.Width = 96;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // addBtn
            // 
            this.addBtn.Animated = true;
            this.addBtn.AutoRoundedCorners = true;
            this.addBtn.BackColor = System.Drawing.Color.Transparent;
            this.addBtn.BorderColor = System.Drawing.Color.Transparent;
            this.addBtn.BorderRadius = 20;
            this.addBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.addBtn.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.addBtn.ForeColor = System.Drawing.Color.Snow;
            this.addBtn.Location = new System.Drawing.Point(1509, 94);
            this.addBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(151, 43);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add to cart";
            this.addBtn.UseTransparentBackground = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // totalTextbox
            // 
            this.totalTextbox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalTextbox.Font = new System.Drawing.Font("K2D Medium", 20F, System.Drawing.FontStyle.Bold);
            this.totalTextbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.totalTextbox.Location = new System.Drawing.Point(1574, 144);
            this.totalTextbox.Multiline = true;
            this.totalTextbox.Name = "totalTextbox";
            this.totalTextbox.ReadOnly = true;
            this.totalTextbox.Size = new System.Drawing.Size(164, 45);
            this.totalTextbox.TabIndex = 6;
            this.totalTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalTextbox.TextChanged += new System.EventHandler(this.totalTextbox_TextChanged);
            // 
            // backHomeBtn
            // 
            this.backHomeBtn.Animated = true;
            this.backHomeBtn.BackColor = System.Drawing.Color.Transparent;
            this.backHomeBtn.BorderColor = System.Drawing.Color.Transparent;
            this.backHomeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backHomeBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.backHomeBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.backHomeBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.backHomeBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.backHomeBtn.FillColor = System.Drawing.Color.Transparent;
            this.backHomeBtn.Font = new System.Drawing.Font("K2D", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.backHomeBtn.ForeColor = System.Drawing.Color.Snow;
            this.backHomeBtn.Location = new System.Drawing.Point(38, 716);
            this.backHomeBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.backHomeBtn.Name = "backHomeBtn";
            this.backHomeBtn.Size = new System.Drawing.Size(223, 60);
            this.backHomeBtn.TabIndex = 8;
            this.backHomeBtn.Text = "ย้อนกลับ";
            this.backHomeBtn.UseTransparentBackground = true;
            this.backHomeBtn.Click += new System.EventHandler(this.backHomeBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnName,
            this.columnDesc,
            this.columnAlcohol,
            this.columnCurCost,
            this.columnAmount,
            this.columnCost});
            this.dataGridView2.Location = new System.Drawing.Point(323, 765);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1163, 659);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // columnID
            // 
            this.columnID.HeaderText = "ID";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "สินค้า";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 257;
            // 
            // columnDesc
            // 
            this.columnDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.columnDesc.HeaderText = "เพิ่มเติม";
            this.columnDesc.Name = "columnDesc";
            this.columnDesc.ReadOnly = true;
            this.columnDesc.Width = 400;
            // 
            // columnAlcohol
            // 
            this.columnAlcohol.HeaderText = "ปริมาณแอลกอฮอล์(%)";
            this.columnAlcohol.Name = "columnAlcohol";
            this.columnAlcohol.ReadOnly = true;
            // 
            // columnCurCost
            // 
            this.columnCurCost.HeaderText = "ราคา";
            this.columnCurCost.Name = "columnCurCost";
            this.columnCurCost.ReadOnly = true;
            // 
            // columnAmount
            // 
            this.columnAmount.HeaderText = "จำนวน";
            this.columnAmount.Name = "columnAmount";
            this.columnAmount.ReadOnly = true;
            // 
            // columnCost
            // 
            this.columnCost.HeaderText = "Total";
            this.columnCost.Name = "columnCost";
            this.columnCost.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WorldWines.Properties.Resources.Screenshot_2024_04_02_133242;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(-5, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 200);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // numericUpDown
            // 
            this.numericUpDown.BackColor = System.Drawing.Color.Transparent;
            this.numericUpDown.BorderColor = System.Drawing.Color.RosyBrown;
            this.numericUpDown.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numericUpDown.Font = new System.Drawing.Font("K2D", 15.75F);
            this.numericUpDown.ForeColor = System.Drawing.Color.DimGray;
            this.numericUpDown.Location = new System.Drawing.Point(1605, 34);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(73, 30);
            this.numericUpDown.TabIndex = 11;
            this.numericUpDown.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.numericUpDown.UseTransparentBackground = true;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(1507, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "ปริมาณ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(1681, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 42);
            this.label2.TabIndex = 13;
            this.label2.Text = "ขวด";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(1494, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 42);
            this.label3.TabIndex = 14;
            this.label3.Text = "มูลค่า";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(1762, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 42);
            this.label4.TabIndex = 15;
            this.label4.Text = "บาท";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Animated = true;
            this.guna2Button1.AutoRoundedCorners = true;
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.guna2Button1.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.guna2Button1.ForeColor = System.Drawing.Color.Snow;
            this.guna2Button1.Location = new System.Drawing.Point(1496, 497);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(151, 43);
            this.guna2Button1.TabIndex = 16;
            this.guna2Button1.Text = "ชำระเงิน";
            this.guna2Button1.UseTransparentBackground = true;
            this.guna2Button1.Click += new System.EventHandler(this.payBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(1482, 430);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 42);
            this.label5.TabIndex = 17;
            this.label5.Text = "ยอดสุทธิ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label6.Location = new System.Drawing.Point(1762, 430);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 42);
            this.label6.TabIndex = 19;
            this.label6.Text = "บาท";
            // 
            // total2
            // 
            this.total2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.total2.Font = new System.Drawing.Font("K2D Medium", 20F, System.Drawing.FontStyle.Bold);
            this.total2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.total2.Location = new System.Drawing.Point(1582, 430);
            this.total2.Multiline = true;
            this.total2.Name = "total2";
            this.total2.ReadOnly = true;
            this.total2.Size = new System.Drawing.Size(182, 45);
            this.total2.TabIndex = 18;
            this.total2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.total2.TextChanged += new System.EventHandler(this.total2_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::WorldWines.Properties.Resources.Screenshot_2024_04_02_133242;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(1496, 204);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(307, 200);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // guna2Button2
            // 
            this.guna2Button2.Animated = true;
            this.guna2Button2.AutoRoundedCorners = true;
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 26;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.guna2Button2.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.guna2Button2.ForeColor = System.Drawing.Color.Snow;
            this.guna2Button2.Location = new System.Drawing.Point(1496, 864);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(192, 54);
            this.guna2Button2.TabIndex = 22;
            this.guna2Button2.Text = "ลบออกจากตะกร้า";
            this.guna2Button2.UseTransparentBackground = true;
            this.guna2Button2.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label7.Location = new System.Drawing.Point(313, 697);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(439, 42);
            this.label7.TabIndex = 23;
            this.label7.Text = "กรุณาตรวจสอบรายการสินค้าก่อนชำระเงิน";
            // 
            // guna2Button3
            // 
            this.guna2Button3.Animated = true;
            this.guna2Button3.AutoRoundedCorners = true;
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderRadius = 26;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.guna2Button3.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.guna2Button3.ForeColor = System.Drawing.Color.Snow;
            this.guna2Button3.Location = new System.Drawing.Point(1496, 1042);
            this.guna2Button3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(192, 54);
            this.guna2Button3.TabIndex = 24;
            this.guna2Button3.Text = "-";
            this.guna2Button3.UseTransparentBackground = true;
            this.guna2Button3.Click += new System.EventHandler(this.decreaseBtn_Click);
            // 
            // increaseBtn
            // 
            this.increaseBtn.Animated = true;
            this.increaseBtn.AutoRoundedCorners = true;
            this.increaseBtn.BackColor = System.Drawing.Color.Transparent;
            this.increaseBtn.BorderColor = System.Drawing.Color.Transparent;
            this.increaseBtn.BorderRadius = 26;
            this.increaseBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.increaseBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.increaseBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.increaseBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.increaseBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.increaseBtn.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.increaseBtn.ForeColor = System.Drawing.Color.Snow;
            this.increaseBtn.Location = new System.Drawing.Point(1496, 954);
            this.increaseBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.Size = new System.Drawing.Size(192, 54);
            this.increaseBtn.TabIndex = 25;
            this.increaseBtn.Text = "+";
            this.increaseBtn.UseTransparentBackground = true;
            this.increaseBtn.Click += new System.EventHandler(this.increaseBtn_Click);
            // 
            // shop
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1834, 821);
            this.Controls.Add(this.increaseBtn);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.total2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.backHomeBtn);
            this.Controls.Add(this.totalTextbox);
            this.Controls.Add(this.addBtn);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("K2D Medium", 10F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximumSize = new System.Drawing.Size(1850, 860);
            this.MinimumSize = new System.Drawing.Size(1850, 860);
            this.Name = "shop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "shop";
            this.Load += new System.EventHandler(this.shop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2Button addBtn;
        private System.Windows.Forms.TextBox totalTextbox;
        private Guna.UI2.WinForms.Guna2Button backHomeBtn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2NumericUpDown numericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn customColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAlcohol;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCurCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox total2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button increaseBtn;
    }
}