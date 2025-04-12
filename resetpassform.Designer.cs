namespace WorldWines
{
    partial class resetpassform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(resetpassform));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.findUsernameTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SendOTPButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.txtVerify = new System.Windows.Forms.TextBox();
            this.btnVerify = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("K2D Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username/ Telephone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("K2D Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(12, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "New Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("K2D Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Brown;
            this.label3.Location = new System.Drawing.Point(12, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 52);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password";
            // 
            // findUsernameTextBox
            // 
            this.findUsernameTextBox.Font = new System.Drawing.Font("K2D Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findUsernameTextBox.Location = new System.Drawing.Point(27, 87);
            this.findUsernameTextBox.Name = "findUsernameTextBox";
            this.findUsernameTextBox.Size = new System.Drawing.Size(407, 39);
            this.findUsernameTextBox.TabIndex = 3;
            this.findUsernameTextBox.TextChanged += new System.EventHandler(this.findusernameTextBox_TextChanged);
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Enabled = false;
            this.newPasswordTextBox.Font = new System.Drawing.Font("K2D Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTextBox.Location = new System.Drawing.Point(27, 302);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(407, 39);
            this.newPasswordTextBox.TabIndex = 4;
            this.newPasswordTextBox.UseSystemPasswordChar = true;
            this.newPasswordTextBox.TextChanged += new System.EventHandler(this.newpassTextBox_TextChanged);
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Enabled = false;
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("K2D Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(27, 414);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(407, 39);
            this.confirmPasswordTextBox.TabIndex = 5;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            this.confirmPasswordTextBox.TextChanged += new System.EventHandler(this.confirmpassTextBox_TextChanged);
            // 
            // SendOTPButton
            // 
            this.SendOTPButton.Font = new System.Drawing.Font("K2D Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendOTPButton.Location = new System.Drawing.Point(455, 83);
            this.SendOTPButton.Name = "SendOTPButton";
            this.SendOTPButton.Size = new System.Drawing.Size(118, 46);
            this.SendOTPButton.TabIndex = 6;
            this.SendOTPButton.Text = "ส่ง OTP";
            this.SendOTPButton.UseVisualStyleBackColor = true;
            this.SendOTPButton.Click += new System.EventHandler(this.SendOTPButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(29, 347);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(91, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "แสดงรหัสผ่าน";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Enabled = false;
            this.confirmBtn.Font = new System.Drawing.Font("K2D Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(21, 518);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(118, 46);
            this.confirmBtn.TabIndex = 8;
            this.confirmBtn.Text = "ยืนยัน";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // txtVerify
            // 
            this.txtVerify.Font = new System.Drawing.Font("K2D Medium", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVerify.Location = new System.Drawing.Point(262, 164);
            this.txtVerify.Name = "txtVerify";
            this.txtVerify.Size = new System.Drawing.Size(172, 39);
            this.txtVerify.TabIndex = 9;
            // 
            // btnVerify
            // 
            this.btnVerify.Font = new System.Drawing.Font("K2D Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.Location = new System.Drawing.Point(455, 158);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(118, 46);
            this.btnVerify.TabIndex = 10;
            this.btnVerify.Text = "ตรวจสอบ";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // resetpassform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(601, 593);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtVerify);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.SendOTPButton);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.findUsernameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Brown;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "resetpassform";
            this.Text = "Reset Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox findUsernameTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Button SendOTPButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.TextBox txtVerify;
        private System.Windows.Forms.Button btnVerify;
    }
}