
namespace _07_Snake
{
    partial class FormGame
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
            this.pictureBoxGameView = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameView)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxGameView
            // 
            this.pictureBoxGameView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxGameView.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGameView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBoxGameView.Name = "pictureBoxGameView";
            this.pictureBoxGameView.Size = new System.Drawing.Size(1176, 825);
            this.pictureBoxGameView.TabIndex = 0;
            this.pictureBoxGameView.TabStop = false;
            this.pictureBoxGameView.SizeChanged += new System.EventHandler(this.pictureBoxGameView_SizeChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 825);
            this.Controls.Add(this.pictureBoxGameView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGameView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxGameView;
    }
}

