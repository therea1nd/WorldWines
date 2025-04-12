namespace WorldWines
{
    partial class welcomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(welcomePage));
            this.bswBtn = new ePOSOne.btnProduct.Button_WOC();
            this.abwBtn = new ePOSOne.btnProduct.Button_WOC();
            this.SuspendLayout();
            // 
            // bswBtn
            // 
            this.bswBtn.BackColor = System.Drawing.Color.Transparent;
            this.bswBtn.BorderColor = System.Drawing.Color.White;
            this.bswBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.bswBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bswBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.bswBtn.FlatAppearance.BorderSize = 0;
            this.bswBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.bswBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.bswBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bswBtn.Font = new System.Drawing.Font("K2D Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bswBtn.Location = new System.Drawing.Point(621, 394);
            this.bswBtn.Name = "bswBtn";
            this.bswBtn.OnHoverBorderColor = System.Drawing.Color.White;
            this.bswBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.bswBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.bswBtn.Size = new System.Drawing.Size(317, 80);
            this.bswBtn.TabIndex = 1;
            this.bswBtn.Text = "Buy some Wine?";
            this.bswBtn.TextColor = System.Drawing.Color.White;
            this.bswBtn.UseVisualStyleBackColor = false;
            this.bswBtn.Click += new System.EventHandler(this.bswBtn_Click);
            // 
            // abwBtn
            // 
            this.abwBtn.BackColor = System.Drawing.Color.Transparent;
            this.abwBtn.BorderColor = System.Drawing.Color.White;
            this.abwBtn.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.abwBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abwBtn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.abwBtn.FlatAppearance.BorderSize = 0;
            this.abwBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.abwBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.abwBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.abwBtn.Font = new System.Drawing.Font("K2D Medium", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.abwBtn.Location = new System.Drawing.Point(686, 494);
            this.abwBtn.Name = "abwBtn";
            this.abwBtn.OnHoverBorderColor = System.Drawing.Color.White;
            this.abwBtn.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.abwBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.abwBtn.Size = new System.Drawing.Size(191, 54);
            this.abwBtn.TabIndex = 0;
            this.abwBtn.Text = "Promotion";
            this.abwBtn.TextColor = System.Drawing.Color.White;
            this.abwBtn.UseVisualStyleBackColor = false;
            this.abwBtn.Click += new System.EventHandler(this.abwBtn_Click);
            // 
            // welcomePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::WorldWines.Properties.Resources.WorldWineLogIn;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 821);
            this.Controls.Add(this.bswBtn);
            this.Controls.Add(this.abwBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "welcomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorldWines - Welcome";
            this.ResumeLayout(false);

        }

        #endregion

        private ePOSOne.btnProduct.Button_WOC abwBtn;
        private ePOSOne.btnProduct.Button_WOC bswBtn;
    }
}