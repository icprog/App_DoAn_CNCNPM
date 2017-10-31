namespace DoAn_CNCNPM
{
    partial class Thi
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblmon = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.pnllistcauhoi = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblmon);
            this.panel1.Controls.Add(this.lbltime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 41);
            this.panel1.TabIndex = 0;
            // 
            // lblmon
            // 
            this.lblmon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblmon.AutoSize = true;
            this.lblmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmon.ForeColor = System.Drawing.Color.Lime;
            this.lblmon.Location = new System.Drawing.Point(295, 8);
            this.lblmon.Name = "lblmon";
            this.lblmon.Size = new System.Drawing.Size(140, 26);
            this.lblmon.TabIndex = 1;
            this.lblmon.Text = "Bài thi môn:";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.Red;
            this.lbltime.Location = new System.Drawing.Point(3, 9);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(73, 28);
            this.lbltime.TabIndex = 0;
            this.lbltime.Text = "00:00";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnsubmit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 41);
            this.panel2.TabIndex = 1;
            // 
            // btnsubmit
            // 
            this.btnsubmit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnsubmit.Location = new System.Drawing.Point(290, 2);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(145, 32);
            this.btnsubmit.TabIndex = 0;
            this.btnsubmit.Text = "Nộp bài";
            this.btnsubmit.UseVisualStyleBackColor = true;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // pnllistcauhoi
            // 
            this.pnllistcauhoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnllistcauhoi.Location = new System.Drawing.Point(0, 41);
            this.pnllistcauhoi.Name = "pnllistcauhoi";
            this.pnllistcauhoi.Size = new System.Drawing.Size(818, 348);
            this.pnllistcauhoi.TabIndex = 2;
            // 
            // Thi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 430);
            this.Controls.Add(this.pnllistcauhoi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Thi";
            this.Text = "Thi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Thi_FormClosing);
            this.Load += new System.EventHandler(this.Thi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblmon;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Panel pnllistcauhoi;
    }
}