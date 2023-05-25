
namespace CarGame
{
    partial class gameover
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
            this.cancel = new System.Windows.Forms.PictureBox();
            this.restart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restart)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.Image = global::CarGame.Properties.Resources.Close_BTN;
            this.cancel.Location = new System.Drawing.Point(12, 12);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(153, 159);
            this.cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cancel.TabIndex = 0;
            this.cancel.TabStop = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // restart
            // 
            this.restart.Image = global::CarGame.Properties.Resources.Play_BTN;
            this.restart.Location = new System.Drawing.Point(700, 12);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(153, 159);
            this.restart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.restart.TabIndex = 1;
            this.restart.TabStop = false;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // gameover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CarGame.Properties.Resources.gameover2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(895, 618);
            this.Controls.Add(this.restart);
            this.Controls.Add(this.cancel);
            this.Name = "gameover";
            this.Text = "gameover";
            this.Load += new System.EventHandler(this.gameover_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cancel;
        private System.Windows.Forms.PictureBox restart;
    }
}