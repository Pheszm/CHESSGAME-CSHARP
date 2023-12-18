namespace CHESS_GAME__GALLARDO_.Panels
{
    partial class NamingArea
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PLAYBUTTON = new System.Windows.Forms.PictureBox();
            this.BlackTextBox = new System.Windows.Forms.TextBox();
            this.WhiteTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PLAYBUTTON)).BeginInit();
            this.SuspendLayout();
            // 
            // PLAYBUTTON
            // 
            this.PLAYBUTTON.BackColor = System.Drawing.Color.Transparent;
            this.PLAYBUTTON.Location = new System.Drawing.Point(161, 521);
            this.PLAYBUTTON.Name = "PLAYBUTTON";
            this.PLAYBUTTON.Size = new System.Drawing.Size(190, 63);
            this.PLAYBUTTON.TabIndex = 0;
            this.PLAYBUTTON.TabStop = false;
            this.PLAYBUTTON.Click += new System.EventHandler(this.PLAYBUTTON_Click);
            // 
            // BlackTextBox
            // 
            this.BlackTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackTextBox.Location = new System.Drawing.Point(127, 340);
            this.BlackTextBox.Name = "BlackTextBox";
            this.BlackTextBox.Size = new System.Drawing.Size(255, 44);
            this.BlackTextBox.TabIndex = 1;
            // 
            // WhiteTextBox
            // 
            this.WhiteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteTextBox.Location = new System.Drawing.Point(127, 191);
            this.WhiteTextBox.Name = "WhiteTextBox";
            this.WhiteTextBox.Size = new System.Drawing.Size(255, 44);
            this.WhiteTextBox.TabIndex = 2;
            // 
            // NamingArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CHESS_GAME__GALLARDO_.Properties.Resources.USERNAMEAREA;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.WhiteTextBox);
            this.Controls.Add(this.BlackTextBox);
            this.Controls.Add(this.PLAYBUTTON);
            this.DoubleBuffered = true;
            this.Name = "NamingArea";
            this.Size = new System.Drawing.Size(513, 678);
            ((System.ComponentModel.ISupportInitialize)(this.PLAYBUTTON)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PLAYBUTTON;
        private System.Windows.Forms.TextBox BlackTextBox;
        private System.Windows.Forms.TextBox WhiteTextBox;
    }
}
