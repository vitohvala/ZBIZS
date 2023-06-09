namespace ZastitaBZ
{
    partial class Upozorenje
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
            this.lblPoruka = new System.Windows.Forms.Label();
            this.btnDa = new System.Windows.Forms.Button();
            this.btnNe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPoruka
            // 
            this.lblPoruka.AutoSize = true;
            this.lblPoruka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoruka.Location = new System.Drawing.Point(12, 66);
            this.lblPoruka.Name = "lblPoruka";
            this.lblPoruka.Size = new System.Drawing.Size(51, 20);
            this.lblPoruka.TabIndex = 11;
            this.lblPoruka.Text = "label1";
            // 
            // btnDa
            // 
            this.btnDa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDa.Location = new System.Drawing.Point(83, 149);
            this.btnDa.Name = "btnDa";
            this.btnDa.Size = new System.Drawing.Size(100, 33);
            this.btnDa.TabIndex = 10;
            this.btnDa.Text = "Da";
            this.btnDa.UseVisualStyleBackColor = true;
            // 
            // btnNe
            // 
            this.btnNe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNe.Location = new System.Drawing.Point(235, 149);
            this.btnNe.Name = "btnNe";
            this.btnNe.Size = new System.Drawing.Size(100, 33);
            this.btnNe.TabIndex = 9;
            this.btnNe.Text = "Ne";
            this.btnNe.UseVisualStyleBackColor = true;
            // 
            // Upozorenje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 218);
            this.Controls.Add(this.lblPoruka);
            this.Controls.Add(this.btnDa);
            this.Controls.Add(this.btnNe);
            this.Name = "Upozorenje";
            this.Text = "Upozorenje";
            this.Load += new System.EventHandler(this.Upozorenje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPoruka;
        private System.Windows.Forms.Button btnDa;
        private System.Windows.Forms.Button btnNe;
    }
}