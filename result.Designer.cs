namespace WorldWines
{
    partial class paymentform
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.totalCost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.finishBtn = new Guna.UI2.WinForms.Guna2Button();
            this.showQrBtn = new Guna.UI2.WinForms.Guna2Button();
            this.printBtn = new Guna.UI2.WinForms.Guna2Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.CodeBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.cashBtn = new Guna.UI2.WinForms.Guna2Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnName,
            this.columnAmount,
            this.columnCost,
            this.columnTotal});
            this.dataGridView1.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridView1.Location = new System.Drawing.Point(310, 11);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(704, 820);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // columnID
            // 
            this.columnID.HeaderText = "รหัสสินค้า";
            this.columnID.Name = "columnID";
            this.columnID.ReadOnly = true;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "สินค้า";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 300;
            // 
            // columnAmount
            // 
            this.columnAmount.HeaderText = "จำนวน";
            this.columnAmount.Name = "columnAmount";
            this.columnAmount.ReadOnly = true;
            // 
            // columnCost
            // 
            this.columnCost.HeaderText = "ราคา/ขวด";
            this.columnCost.Name = "columnCost";
            this.columnCost.ReadOnly = true;
            // 
            // columnTotal
            // 
            this.columnTotal.HeaderText = "ราคารวม";
            this.columnTotal.Name = "columnTotal";
            this.columnTotal.ReadOnly = true;
            // 
            // guna2TextBox1
            // 
            this.guna2TextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.guna2TextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox1.DefaultText = "";
            this.guna2TextBox1.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Font = new System.Drawing.Font("K2D Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TextBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox1.Location = new System.Drawing.Point(1528, 1101);
            this.guna2TextBox1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.guna2TextBox1.Name = "guna2TextBox1";
            this.guna2TextBox1.PasswordChar = '\0';
            this.guna2TextBox1.PlaceholderText = "";
            this.guna2TextBox1.SelectedText = "";
            this.guna2TextBox1.Size = new System.Drawing.Size(528, 112);
            this.guna2TextBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label3.Location = new System.Drawing.Point(1123, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 42);
            this.label3.TabIndex = 15;
            this.label3.Text = "ยอดสุทธิ";
            // 
            // totalCost
            // 
            this.totalCost.Location = new System.Drawing.Point(1092, 49);
            this.totalCost.Name = "totalCost";
            this.totalCost.Size = new System.Drawing.Size(167, 28);
            this.totalCost.TabIndex = 16;
            this.totalCost.TextChanged += new System.EventHandler(this.totalCost_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(1273, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 42);
            this.label1.TabIndex = 17;
            this.label1.Text = "บาท";
            // 
            // finishBtn
            // 
            this.finishBtn.Animated = true;
            this.finishBtn.AutoRoundedCorners = true;
            this.finishBtn.BackColor = System.Drawing.Color.Transparent;
            this.finishBtn.BorderColor = System.Drawing.Color.Transparent;
            this.finishBtn.BorderRadius = 20;
            this.finishBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.finishBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.finishBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.finishBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.finishBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.finishBtn.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.finishBtn.ForeColor = System.Drawing.Color.Snow;
            this.finishBtn.Location = new System.Drawing.Point(1108, 520);
            this.finishBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.finishBtn.Name = "finishBtn";
            this.finishBtn.Size = new System.Drawing.Size(151, 43);
            this.finishBtn.TabIndex = 18;
            this.finishBtn.Text = "เสร็จสิ้น";
            this.finishBtn.UseTransparentBackground = true;
            this.finishBtn.Click += new System.EventHandler(this.finishBtn_Click);
            // 
            // showQrBtn
            // 
            this.showQrBtn.Animated = true;
            this.showQrBtn.AutoRoundedCorners = true;
            this.showQrBtn.BackColor = System.Drawing.Color.Transparent;
            this.showQrBtn.BorderColor = System.Drawing.Color.Transparent;
            this.showQrBtn.BorderRadius = 20;
            this.showQrBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.showQrBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.showQrBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.showQrBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.showQrBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.showQrBtn.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.showQrBtn.ForeColor = System.Drawing.Color.Snow;
            this.showQrBtn.Location = new System.Drawing.Point(1108, 282);
            this.showQrBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.showQrBtn.Name = "showQrBtn";
            this.showQrBtn.Size = new System.Drawing.Size(151, 43);
            this.showQrBtn.TabIndex = 19;
            this.showQrBtn.Text = "QR ชำระเงิน";
            this.showQrBtn.UseTransparentBackground = true;
            this.showQrBtn.Click += new System.EventHandler(this.showQrBtn_Click);
            // 
            // printBtn
            // 
            this.printBtn.Animated = true;
            this.printBtn.AutoRoundedCorners = true;
            this.printBtn.BackColor = System.Drawing.Color.Transparent;
            this.printBtn.BorderColor = System.Drawing.Color.Transparent;
            this.printBtn.BorderRadius = 20;
            this.printBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.printBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.printBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.printBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.printBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.printBtn.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.printBtn.ForeColor = System.Drawing.Color.Snow;
            this.printBtn.Location = new System.Drawing.Point(1108, 443);
            this.printBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(151, 43);
            this.printBtn.TabIndex = 21;
            this.printBtn.Text = "พิมพ์ใบเสร็จ";
            this.printBtn.UseTransparentBackground = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.AllowCurrentPage = true;
            this.printDialog1.UseEXDialog = true;
            // 
            // CodeBox
            // 
            this.CodeBox.Location = new System.Drawing.Point(1092, 169);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(167, 28);
            this.CodeBox.TabIndex = 22;
            this.CodeBox.TextChanged += new System.EventHandler(this.CodeBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("K2D Medium", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(1085, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 42);
            this.label2.TabIndex = 23;
            this.label2.Text = "โค้ดส่วนลด(หากมี)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.Animated = true;
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.Brown;
            this.guna2CircleButton1.FocusedColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(1279, 159);
            this.guna2CircleButton1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.PressedColor = System.Drawing.Color.MistyRose;
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(55, 52);
            this.guna2CircleButton1.TabIndex = 24;
            this.guna2CircleButton1.TabStop = false;
            this.guna2CircleButton1.Text = "ใช้";
            this.guna2CircleButton1.Click += new System.EventHandler(this.discount_Click);
            // 
            // cashBtn
            // 
            this.cashBtn.Animated = true;
            this.cashBtn.AutoRoundedCorners = true;
            this.cashBtn.BackColor = System.Drawing.Color.Transparent;
            this.cashBtn.BorderColor = System.Drawing.Color.Transparent;
            this.cashBtn.BorderRadius = 20;
            this.cashBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.cashBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.cashBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.cashBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.cashBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(27)))), ((int)(((byte)(60)))));
            this.cashBtn.Font = new System.Drawing.Font("K2D", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cashBtn.ForeColor = System.Drawing.Color.Snow;
            this.cashBtn.Location = new System.Drawing.Point(1108, 364);
            this.cashBtn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cashBtn.Name = "cashBtn";
            this.cashBtn.Size = new System.Drawing.Size(151, 43);
            this.cashBtn.TabIndex = 25;
            this.cashBtn.Text = "เงินสด";
            this.cashBtn.UseTransparentBackground = true;
            this.cashBtn.Click += new System.EventHandler(this.cashBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(1087, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 30);
            this.label4.TabIndex = 26;
            this.label4.Text = "กรุณากรอกโค้ดส่วนลดที่มี";
            this.label4.TextChanged += new System.EventHandler(this.label4_TextChanged);
            // 
            // paymentform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WorldWines.Properties.Resources.userbuy;
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cashBtn);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CodeBox);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.showQrBtn);
            this.Controls.Add(this.finishBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.totalCost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2TextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("K2D SemiBold", 12F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.Name = "paymentform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "payment";
            this.Load += new System.EventHandler(this.payment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox totalCost;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button finishBtn;
        private Guna.UI2.WinForms.Guna2Button showQrBtn;
        private Guna.UI2.WinForms.Guna2Button printBtn;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.TextBox CodeBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnTotal;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2Button cashBtn;
        private System.Windows.Forms.Label label4;
    }
}