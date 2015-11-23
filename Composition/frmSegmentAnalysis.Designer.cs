namespace Composition
{
    partial class frmSegmentAnalysis
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
            this.lblNotes = new System.Windows.Forms.Label();
            this.btnDone = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.txtText = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // segmentPictureBox
            // 
            this.segmentPictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.segmentPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.segmentPictureBox.Location = new System.Drawing.Point(0, -1);
            this.segmentPictureBox.Name = "segmentPictureBox";
            this.segmentPictureBox.Size = new System.Drawing.Size(180, 264);
            this.segmentPictureBox.TabIndex = 0;
            this.segmentPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gini:";
            // 
            // lblGini
            // 
            this.lblGini.AutoSize = true;
            this.lblGini.Location = new System.Drawing.Point(220, 91);
            this.lblGini.Name = "lblGini";
            this.lblGini.Size = new System.Drawing.Size(68, 13);
            this.lblGini.TabIndex = 2;
            this.lblGini.Text = "Calculating...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(186, 9);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(68, 13);
            this.lblNotes.TabIndex = 4;
            this.lblNotes.Text = "Calculating...";
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(497, 226);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(186, 134);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(28, 13);
            this.lblText.TabIndex = 6;
            this.lblText.Text = "Text";
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(223, 131);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(349, 20);
            this.txtText.TabIndex = 7;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(223, 106);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 8;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(416, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Location = new System.Drawing.Point(189, 226);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(75, 23);
            this.btnRedo.TabIndex = 10;
            this.btnRedo.Text = "Re-Analyse";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // frmSegmentAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGini);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.segmentPictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "frmSegmentAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Segment Analysis";
            this.Load += new System.EventHandler(this.frmSegmentAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.segmentPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox segmentPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGini;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRedo;
    }
}