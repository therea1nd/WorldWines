namespace WorldWines
{
    partial class promotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(promotion));
            this.hideBtn = new ePOSOne.btnProduct.Button_WOC();
            this.exitBtn = new ePOSOne.btnProduct.Button_WOC();
            this.SuspendLayout();
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
            this.hideBtn.Location = new System.Drawing.Point(355, 0);
            this.hideBtn.Margin = new System.Windows.Forms.Padding(1);
            this.hideBtn.Name = "hideBtn";
            this.hideBtn.OnHoverBorderColor = System.Drawing.Color.DarkGoldenrod;
            this.hideBtn.OnHoverButtonColor = System.Drawing.Color.DarkGoldenrod;
            this.hideBtn.OnHoverTextColor = System.Drawing.Color.Snow;
            this.hideBtn.Size = new System.Drawing.Size(21, 21);
            this.hideBtn.TabIndex = 16;
            this.hideBtn.Text = "-";
            this.hideBtn.TextColor = System.Drawing.Color.White;
            this.hideBtn.UseVisualStyleBackColor = false;
            this.hideBtn.Click += new System.EventHandler(this.hideBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitBtn.BorderColor = System.Drawing.Color.Transparent;
            this.exitBtn.ButtonColor = System.Drawing.Color.Brown;
            this.exitBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.exitBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(4)))), ((int)(((byte)(16)))));
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Font = new System.Drawing.Font("K2D Medium", 5.25F, System.Drawing.FontStyle.Bold);
            this.exitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.exitBtn.Location = new System.Drawing.Point(378, 0);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(1);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.OnHoverBorderColor = System.Drawing.Color.Brown;
            this.exitBtn.OnHoverButtonColor = System.Drawing.Color.Brown;
            this.exitBtn.OnHoverTextColor = System.Drawing.Color.Snow;
            this.exitBtn.Size = new System.Drawing.Size(21, 21);
            this.exitBtn.TabIndex = 15;
            this.exitBtn.Text = "X";
            this.exitBtn.TextColor = System.Drawing.Color.White;
            this.exitBtn.UseVisualStyleBackColor = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // promotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WorldWines.Properties.Resources.winepromotion;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 650);
            this.Controls.Add(this.hideBtn);
            this.Controls.Add(this.exitBtn);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "promotion";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "promotion";
            this.ResumeLayout(false);

        }

        #endregion

        private ePOSOne.btnProduct.Button_WOC exitBtn;
        private ePOSOne.btnProduct.Button_WOC hideBtn;
    }
}