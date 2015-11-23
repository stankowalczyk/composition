namespace Composition
{
    partial class frmFinish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFinish));
            this.lblProjectFileName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinished = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjectFileName
            // 
            this.lblProjectFileName.AutoSize = true;
            this.lblProjectFileName.BackColor = System.Drawing.Color.Transparent;
            this.lblProjectFileName.Location = new System.Drawing.Point(21, 115);
            this.lblProjectFileName.Name = "lblProjectFileName";
            this.lblProjectFileName.Size = new System.Drawing.Size(139, 13);
            this.lblProjectFileName.TabIndex = 0;
            this.lblProjectFileName.Text = "Composition Android Project";
            this.lblProjectFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProjectFileName.Click += new System.EventHandler(this.lblProjectFileName_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblProjectFileName);
            this.panel1.Location = new System.Drawing.Point(604, 193);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 157);
            this.panel1.TabIndex = 1;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnFinished
            // 
            this.btnFinished.Location = new System.Drawing.Point(787, 440);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(100, 29);
            this.btnFinished.TabIndex = 2;
            this.btnFinished.Text = "Finish";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // frmFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(899, 481);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(915, 520);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(915, 520);
            this.Name = "frmFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFinish_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProjectFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFinished;
    }
}