namespace Composition
{
    partial class frmActionBarAnalysis
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
            this.segmentPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGini = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtActionBarLabel = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // segmentPictureBox
            // 
            this.segmentPictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.segmentPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.segmentPictureBox.Location = new System.Drawing.Point(0, -1);
            this.segmentPictureBox.Name = "segmentPictureBox";
            this.segmentPictureBox.Size = new System.Drawing.Size(586, 169);
            this.segmentPictureBox.TabIndex = 0;
            this.segmentPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gini:";
            // 
            // lblGini
            // 
            this.lblGini.AutoSize = true;
            this.lblGini.Location = new System.Drawing.Point(46, 176);
            this.lblGini.Name = "lblGini";
            this.lblGini.Size = new System.Drawing.Size(68, 13);
            this.lblGini.TabIndex = 2;
            this.lblGini.Text = "Calculating...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(46, 198);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(68, 13);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Calculating...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(164, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Action bar text:";
            // 
            // txtActionBarLabel
            // 
            this.txtActionBarLabel.Location = new System.Drawing.Point(248, 173);
            this.txtActionBarLabel.Name = "txtActionBarLabel";
            this.txtActionBarLabel.Size = new System.Drawing.Size(324, 20);
            this.txtActionBarLabel.TabIndex = 6;
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(497, 226);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 25;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(416, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(282, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "The above text was scraped using OCR, correct if needed";
            // 
            // frmActionBarAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtActionBarLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGini);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.segmentPictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "frmActionBarAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Actionbar Analysis";
            this.Load += new System.EventHandler(this.frmActionBarAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox segmentPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtActionBarLabel;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
    }
}