namespace Composition
{
    partial class frmColourChooser
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnGenerateAutomatically = new System.Windows.Forms.Button();
            this.pbVideoHelp = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnAccentColour = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrimaryDarkColour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrimaryColour = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.instructionTextBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.zoomedImageBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoHelp)).BeginInit();
            this.selectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnClearAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerateAutomatically);
            this.splitContainer1.Panel1.Controls.Add(this.pbVideoHelp);
            this.splitContainer1.Panel1.Controls.Add(this.btnDone);
            this.splitContainer1.Panel1.Controls.Add(this.btnAccentColour);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrimaryDarkColour);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrimaryColour);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.instructionTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectionPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 611);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(92, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "* Optional";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(113, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "* Optional";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(92, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "* Required";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(11, 449);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(251, 23);
            this.btnClearAll.TabIndex = 40;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnGenerateAutomatically
            // 
            this.btnGenerateAutomatically.Location = new System.Drawing.Point(116, 348);
            this.btnGenerateAutomatically.Name = "btnGenerateAutomatically";
            this.btnGenerateAutomatically.Size = new System.Drawing.Size(96, 39);
            this.btnGenerateAutomatically.TabIndex = 3;
            this.btnGenerateAutomatically.Text = "Generate Primary Dark Colour";
            this.btnGenerateAutomatically.UseVisualStyleBackColor = true;
            this.btnGenerateAutomatically.Click += new System.EventHandler(this.btnGenerateAutomatically_Click);
            // 
            // pbVideoHelp
            // 
            this.pbVideoHelp.BackColor = System.Drawing.SystemColors.Control;
            this.pbVideoHelp.BackgroundImage = global::Composition.Properties.Resources.VideoHelp;
            this.pbVideoHelp.Location = new System.Drawing.Point(11, 478);
            this.pbVideoHelp.Name = "pbVideoHelp";
            this.pbVideoHelp.Size = new System.Drawing.Size(251, 92);
            this.pbVideoHelp.TabIndex = 39;
            this.pbVideoHelp.TabStop = false;
            this.pbVideoHelp.Click += new System.EventHandler(this.pbVideoHelp_Click);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(11, 576);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(251, 23);
            this.btnDone.TabIndex = 27;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnAccentColour
            // 
            this.btnAccentColour.BackColor = System.Drawing.Color.White;
            this.btnAccentColour.Location = new System.Drawing.Point(15, 408);
            this.btnAccentColour.Name = "btnAccentColour";
            this.btnAccentColour.Size = new System.Drawing.Size(95, 39);
            this.btnAccentColour.TabIndex = 26;
            this.btnAccentColour.UseVisualStyleBackColor = false;
            this.btnAccentColour.Click += new System.EventHandler(this.btnAccentColour_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Accent Colour";
            // 
            // btnPrimaryDarkColour
            // 
            this.btnPrimaryDarkColour.BackColor = System.Drawing.Color.White;
            this.btnPrimaryDarkColour.Location = new System.Drawing.Point(15, 348);
            this.btnPrimaryDarkColour.Name = "btnPrimaryDarkColour";
            this.btnPrimaryDarkColour.Size = new System.Drawing.Size(95, 39);
            this.btnPrimaryDarkColour.TabIndex = 24;
            this.btnPrimaryDarkColour.UseVisualStyleBackColor = false;
            this.btnPrimaryDarkColour.Click += new System.EventHandler(this.btnPrimaryDarkColour_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Primary Dark Colour";
            // 
            // btnPrimaryColour
            // 
            this.btnPrimaryColour.BackColor = System.Drawing.Color.White;
            this.btnPrimaryColour.Location = new System.Drawing.Point(15, 287);
            this.btnPrimaryColour.Name = "btnPrimaryColour";
            this.btnPrimaryColour.Size = new System.Drawing.Size(95, 39);
            this.btnPrimaryColour.TabIndex = 22;
            this.btnPrimaryColour.UseVisualStyleBackColor = false;
            this.btnPrimaryColour.Click += new System.EventHandler(this.btnPrimaryColour_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Primary Colour";
            // 
            // instructionTextBox
            // 
            this.instructionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.instructionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionTextBox.Location = new System.Drawing.Point(15, 28);
            this.instructionTextBox.Name = "instructionTextBox";
            this.instructionTextBox.ReadOnly = true;
            this.instructionTextBox.Size = new System.Drawing.Size(251, 232);
            this.instructionTextBox.TabIndex = 20;
            this.instructionTextBox.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Step 3 of 4";
            // 
            // selectionPanel
            // 
            this.selectionPanel.AllowDrop = true;
            this.selectionPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.selectionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectionPanel.Controls.Add(this.zoomedImageBox);
            this.selectionPanel.Controls.Add(this.label3);
            this.selectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionPanel.Location = new System.Drawing.Point(0, 0);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(901, 611);
            this.selectionPanel.TabIndex = 1;
            this.selectionPanel.MouseEnter += new System.EventHandler(this.selectionPanel_MouseEnter);
            // 
            // zoomedImageBox
            // 
            this.zoomedImageBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.zoomedImageBox.Location = new System.Drawing.Point(103, 102);
            this.zoomedImageBox.Name = "zoomedImageBox";
            this.zoomedImageBox.Size = new System.Drawing.Size(100, 50);
            this.zoomedImageBox.TabIndex = 2;
            this.zoomedImageBox.TabStop = false;
            this.zoomedImageBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.zoomedImageBox_MouseClick);
            this.zoomedImageBox.MouseEnter += new System.EventHandler(this.zoomedImageBox_MouseEnter);
            this.zoomedImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.zoomedImageBox_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Selection Area";
            // 
            // frmColourChooser
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 650);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1200, 650);
            this.Name = "frmColourChooser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Composition";
            this.Load += new System.EventHandler(this.frmColourChooser_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoHelp)).EndInit();
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox zoomedImageBox;
        private System.Windows.Forms.RichTextBox instructionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccentColour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrimaryDarkColour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrimaryColour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.PictureBox pbVideoHelp;
        private System.Windows.Forms.Button btnGenerateAutomatically;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

