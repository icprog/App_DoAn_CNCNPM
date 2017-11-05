namespace DoAn_CNCNPM
{
    partial class CauHoi
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
            this.lblcauhoi = new System.Windows.Forms.Label();
            this.pnldapan = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblcauhoi
            // 
            this.lblcauhoi.AutoSize = true;
            this.lblcauhoi.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblcauhoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcauhoi.Location = new System.Drawing.Point(0, 0);
            this.lblcauhoi.Name = "lblcauhoi";
            this.lblcauhoi.Size = new System.Drawing.Size(46, 17);
            this.lblcauhoi.TabIndex = 0;
            this.lblcauhoi.Text = "label1";
            // 
            // pnldapan
            // 
            this.pnldapan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnldapan.Location = new System.Drawing.Point(0, 17);
            this.pnldapan.Name = "pnldapan";
            this.pnldapan.Size = new System.Drawing.Size(767, 75);
            this.pnldapan.TabIndex = 1;
            // 
            // CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnldapan);
            this.Controls.Add(this.lblcauhoi);
            this.Name = "CauHoi";
            this.Size = new System.Drawing.Size(767, 92);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblcauhoi;
        private System.Windows.Forms.Panel pnldapan;
    }
}
