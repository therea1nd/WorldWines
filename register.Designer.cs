namespace WorldWines
{
    partial class regisPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(regisPage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.submitBtn = new ePOSOne.btnProduct.Button_WOC();
            this.userCheckBtn = new System.Windows.Forms.LinkLabel();
            this.emailCheckBtn = new System.Windows.Forms.LinkLabel();
            this.telCheckBtn = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("K2D", 20F);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(199, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("K2D", 20F);
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(759, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lastname";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("K2D", 20F);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(199, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 52);
            this.label3.TabIndex = 2;
            this.label3.Text = "Username";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("K2D", 20F);
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(759, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 52);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtName.Font = new System.Drawing.Font("K2D", 18F);
            this.txtName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtName.Location = new System.Drawing.Point(187, 293);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(400, 39);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "Name";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Enter += new System.EventHandler(this.txtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtLastName.Font = new System.Drawing.Font("K2D", 18F);
            this.txtLastName.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLastName.Location = new System.Drawing.Point(740, 293);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(400, 39);
            this.txtLastName.TabIndex = 5;
            this.txtLastName.Text = "Lastname";
            this.txtLastName.Enter += new System.EventHandler(this.txtLastName_Enter);
            this.txtLastName.Leave += new System.EventHandler(this.txtLastName_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUsername.Font = new System.Drawing.Font("K2D", 18F);
            this.txtUsername.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUsername.Location = new System.Drawing.Point(187, 409);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(400, 39);
            this.txtUsername.TabIndex = 6;
            this.txtUsername.Text = "Username";
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPassword.Font = new System.Drawing.Font("K2D", 18F);
            this.txtPassword.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtPassword.Location = new System.Drawing.Point(740, 407);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(400, 39);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("K2D", 20F);
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(199, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 52);
            this.label5.TabIndex = 9;
            this.label5.Text = "E-mail";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtEmail.Font = new System.Drawing.Font("K2D", 18F);
            this.txtEmail.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEmail.Location = new System.Drawing.Point(187, 532);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 39);
            this.txtEmail.TabIndex = 8;
            this.txtEmail.Text = "e-mail";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("K2D", 20F);
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(759, 477);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 52);
            this.label6.TabIndex = 11;
            this.label6.Text = "Telephone";
            // 
            // txtTelephone
            // 
            this.txtTelephone.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtTelephone.Font = new System.Drawing.Font("K2D", 18F);
            this.txtTelephone.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTelephone.Location = new System.Drawing.Point(740, 532);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(400, 39);
            this.txtTelephone.TabIndex = 9;
            this.txtTelephone.Text = "0000000000";
            this.txtTelephone.TextChanged += new System.EventHandler(this.txtTelephone_TextChanged);
            this.txtTelephone.Enter += new System.EventHandler(this.txtTelophone_Enter);
            this.txtTelephone.Leave += new System.EventHandler(this.txtTelephone_Leave);
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.Transparent;
            this.submitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.submitBtn.BorderColor = System.Drawing.Color.Black;
            this.submitBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.submitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("K2D", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.submitBtn.Location = new System.Drawing.Point(573, 653);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(0);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.OnHoverBorderColor = System.Drawing.Color.White;
            this.submitBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.submitBtn.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.submitBtn.Size = new System.Drawing.Size(206, 79);
            this.submitBtn.TabIndex = 10;
            this.submitBtn.Text = "Submit";
            this.submitBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // userCheckBtn
            // 
            this.userCheckBtn.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.userCheckBtn.AutoSize = true;
            this.userCheckBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.userCheckBtn.Font = new System.Drawing.Font("K2D", 10.25F);
            this.userCheckBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.userCheckBtn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.userCheckBtn.Location = new System.Drawing.Point(518, 416);
            this.userCheckBtn.Name = "userCheckBtn";
            this.userCheckBtn.Size = new System.Drawing.Size(69, 27);
            this.userCheckBtn.TabIndex = 12;
            this.userCheckBtn.TabStop = true;
            this.userCheckBtn.Text = "ตรวจสอบ";
            this.userCheckBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.userCheckBtn_LinkClicked);
            // 
            // emailCheckBtn
            // 
            this.emailCheckBtn.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.emailCheckBtn.AutoSize = true;
            this.emailCheckBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.emailCheckBtn.Font = new System.Drawing.Font("K2D", 10.25F);
            this.emailCheckBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.emailCheckBtn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.emailCheckBtn.Location = new System.Drawing.Point(517, 537);
            this.emailCheckBtn.Name = "emailCheckBtn";
            this.emailCheckBtn.Size = new System.Drawing.Size(69, 27);
            this.emailCheckBtn.TabIndex = 13;
            this.emailCheckBtn.TabStop = true;
            this.emailCheckBtn.Text = "ตรวจสอบ";
            this.emailCheckBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.emailCheckBtn_LinkClicked);
            // 
            // telCheckBtn
            // 
            this.telCheckBtn.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.telCheckBtn.AutoSize = true;
            this.telCheckBtn.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.telCheckBtn.Font = new System.Drawing.Font("K2D", 10.25F);
            this.telCheckBtn.ForeColor = System.Drawing.SystemColors.MenuText;
            this.telCheckBtn.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.telCheckBtn.Location = new System.Drawing.Point(1071, 537);
            this.telCheckBtn.Name = "telCheckBtn";
            this.telCheckBtn.Size = new System.Drawing.Size(69, 27);
            this.telCheckBtn.TabIndex = 14;
            this.telCheckBtn.TabStop = true;
            this.telCheckBtn.Text = "ตรวจสอบ";
            this.telCheckBtn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.telCheckBtn_LinkClicked);
            // 
            // regisPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.BackgroundImage = global::WorldWines.Properties.Resources.ไม่มีชื่อ__1312_x_860_px_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1284, 821);
            this.Controls.Add(this.telCheckBtn);
            this.Controls.Add(this.emailCheckBtn);
            this.Controls.Add(this.userCheckBtn);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "regisPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldWines - Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ePOSOne.btnProduct.Button_WOC submitBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtLastName;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.LinkLabel userCheckBtn;
        private System.Windows.Forms.LinkLabel emailCheckBtn;
        private System.Windows.Forms.LinkLabel telCheckBtn;
    }
}