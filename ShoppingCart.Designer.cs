namespace WorldWines
{
    partial class ShoppingCart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShoppingCart));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.payBtn = new Guna.UI2.WinForms.Guna2Button();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.exitBtn = new ePOSOne.btnProduct.Button_WOC();
            this.hideBtn = new ePOSOne.btnProduct.Button_WOC();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("K2D", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 61);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shopping Cart/ ตะกร้าสินค้าของคุณ";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.BackgroundImage = global::WorldWines.Properties.Resources.bgsale1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 811);
            this.panel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(24, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1169, 830);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("K2D Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.ForeColor = System.Drawing.Color.Brown;
            this.lblSubtotal.Location = new System.Drawing.Point(1292, 418);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(138, 52);
            this.lblSubtotal.TabIndex = 4;
            this.lblSubtotal.Text = "ราคาสุทธิ";
            this.lblSubtotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // payBtn
            // 
            this.payBtn.BorderRadius = 15;
            this.payBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.payBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.payBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.payBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.payBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.payBtn.Font = new System.Drawing.Font("K2D", 13F);
            this.payBtn.ForeColor = System.Drawing.Color.White;
            this.payBtn.Location = new System.Drawing.Point(1576, 527);
            this.payBtn.Name = "payBtn";
            this.payBtn.Size = new System.Drawing.Size(161, 46);
            this.payBtn.TabIndex = 8;
            this.payBtn.Text = "ชำระเงิน";
            this.payBtn.Click += new System.EventHandler(this.payBtn_Click);
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.Font = new System.Drawing.Font("K2D Medium", 20.25F, System.Drawing.FontStyle.Bold);
            this.subtotalTextBox.ForeColor = System.Drawing.Color.Brown;
            this.subtotalTextBox.Location = new System.Drawing.Point(1456, 418);
            this.subtotalTextBox.Multiline = true;
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.Size = new System.Drawing.Size(281, 62);
            this.subtotalTextBox.TabIndex = 9;
            this.subtotalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("K2D Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(1743, 418);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 52);
            this.label2.TabIndex = 10;
            this.label2.Text = "บาท";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BorderColor = System.Drawing.Color.Transparent;
            this.exitBtn.ButtonColor = System.Drawing.Color.Brown;
            this.exitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("K2D Medium", 5.25F, System.Drawing.FontStyle.Bold);
            this.exitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.exitBtn.Location = new System.Drawing.Point(1881, 1);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(1);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.OnHoverBorderColor = System.Drawing.Color.Brown;
            this.exitBtn.OnHoverButtonColor = System.Drawing.Color.Brown;
            this.exitBtn.OnHoverTextColor = System.Drawing.Color.Snow;
            this.exitBtn.Size = new System.Drawing.Size(21, 21);
            this.exitBtn.TabIndex = 14;
            this.exitBtn.Text = "X";
            this.exitBtn.TextColor = System.Drawing.Color.White;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // hideBtn
            // 
            this.hideBtn.BackColor = System.Drawing.Color.Transparent;
            this.hideBtn.BorderColor = System.Drawing.Color.Transparent;
            this.hideBtn.ButtonColor = System.Drawing.Color.DarkGoldenrod;
            this.hideBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.hideBtn.FlatAppearance.BorderSize = 0;
            this.hideBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.hideBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.hideBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hideBtn.Font = new System.Drawing.Font("K2D Medium", 5.25F, System.Drawing.FontStyle.Bold);
            this.hideBtn.ForeColor = System.Drawing.Color.Transparent;
            this.hideBtn.Location = new System.Drawing.Point(1858, 1);
            this.hideBtn.Margin = new System.Windows.Forms.Padding(1);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.OnHoverBorderColor = System.Drawing.Color.DarkGoldenrod;
            this.hideBtn.OnHoverButtonColor = System.Drawing.Color.DarkGoldenrod;
            this.hideBtn.OnHoverTextColor = System.Drawing.Color.Snow;
            this.hideBtn.Size = new System.Drawing.Size(21, 21);
            this.hideBtn.TabIndex = 17;
            this.hideBtn.Text = "-";
            this.hideBtn.TextColor = System.Drawing.Color.White;
            this.hideBtn.UseVisualStyleBackColor = false;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WorldWines.Properties.Resources.bgshop;
            this.ClientSize = new System.Drawing.Size(1904, 971);
            this.Controls.Add(this.hideBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subtotalTextBox);
            this.Controls.Add(this.payBtn);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShoppingCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShoppingCart";
            this.Load += new System.EventHandler(this.ShoppingCart_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblSubtotal;
        private Guna.UI2.WinForms.Guna2Button payBtn;
        private System.Windows.Forms.TextBox subtotalTextBox;
        private System.Windows.Forms.Label label2;
        private ePOSOne.btnProduct.Button_WOC exitBtn;
        private ePOSOne.btnProduct.Button_WOC hideBtn;
    }
}
