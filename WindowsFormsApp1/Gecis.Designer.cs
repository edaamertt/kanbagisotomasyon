namespace WindowsFormsApp1
{
    partial class Gecis
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.GecisProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GecisProgressBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(173, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kan Bankası Yönetim Sistemi";
            // 
            // GecisProgressBar
            // 
            this.GecisProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.GecisProgressBar.Controls.Add(this.pictureBox1);
            this.GecisProgressBar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.GecisProgressBar.FillThickness = 10;
            this.GecisProgressBar.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.GecisProgressBar.ForeColor = System.Drawing.Color.White;
            this.GecisProgressBar.Location = new System.Drawing.Point(239, 127);
            this.GecisProgressBar.Minimum = 0;
            this.GecisProgressBar.Name = "GecisProgressBar";
            this.GecisProgressBar.ProgressColor = System.Drawing.Color.Red;
            this.GecisProgressBar.ProgressColor2 = System.Drawing.Color.Red;
            this.GecisProgressBar.ProgressThickness = 10;
            this.GecisProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GecisProgressBar.Size = new System.Drawing.Size(282, 282);
            this.GecisProgressBar.TabIndex = 1;
            this.GecisProgressBar.Text = "guna2CircleProgressBar1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.kandamlasi;
            this.pictureBox1.Location = new System.Drawing.Point(85, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Gecis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(811, 497);
            this.Controls.Add(this.GecisProgressBar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Gecis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Gecis_Load);
            this.GecisProgressBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar GecisProgressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
    }
}

