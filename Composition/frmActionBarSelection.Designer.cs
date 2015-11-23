namespace Composition
{
    partial class frmActionBarSelection
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.firstClickViewPanel = new System.Windows.Forms.Panel();
            this.btnClearFirstPoint = new System.Windows.Forms.Button();
            this.lblFirstPoint = new System.Windows.Forms.Label();
            this.panelReminder = new System.Windows.Forms.Panel();
            this.pbBackgroundColour = new System.Windows.Forms.PictureBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnSkip = new System.Windows.Forms.Button();
            this.instructionTextBox = new System.Windows.Forms.RichTextBox();
            this.lblStepTitle = new System.Windows.Forms.Label();
            this.btnBackgroundColour = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pbVideoHelp = new System.Windows.Forms.PictureBox();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.pbPrecisionImage = new System.Windows.Forms.PictureBox();
            this.zoomedImageBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundWriteProjectWorker = new System.ComponentModel.BackgroundWorker();
            this.tmrPreviewUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.firstClickViewPanel.SuspendLayout();
            this.panelReminder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundColour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoHelp)).BeginInit();
            this.selectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrecisionImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer1.Panel1MinSize = 279;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectionPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 611);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.AllowDrop = true;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.firstClickViewPanel);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer3.Panel2.Controls.Add(this.panelReminder);
            this.splitContainer3.Panel2.Controls.Add(this.btnGenerate);
            this.splitContainer3.Panel2.Controls.Add(this.btnSkip);
            this.splitContainer3.Panel2.Controls.Add(this.instructionTextBox);
            this.splitContainer3.Panel2.Controls.Add(this.lblStepTitle);
            this.splitContainer3.Panel2.Controls.Add(this.btnBackgroundColour);
            this.splitContainer3.Panel2.Controls.Add(this.label12);
            this.splitContainer3.Panel2.Controls.Add(this.pbVideoHelp);
            this.splitContainer3.Size = new System.Drawing.Size(279, 611);
            this.splitContainer3.SplitterDistance = 153;
            this.splitContainer3.TabIndex = 0;
            // 
            // firstClickViewPanel
            // 
            this.firstClickViewPanel.AllowDrop = true;
            this.firstClickViewPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.firstClickViewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.firstClickViewPanel.Controls.Add(this.btnClearFirstPoint);
            this.firstClickViewPanel.Controls.Add(this.lblFirstPoint);
            this.firstClickViewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.firstClickViewPanel.Location = new System.Drawing.Point(0, 0);
            this.firstClickViewPanel.Name = "firstClickViewPanel";
            this.firstClickViewPanel.Size = new System.Drawing.Size(279, 153);
            this.firstClickViewPanel.TabIndex = 0;
            // 
            // btnClearFirstPoint
            // 
            this.btnClearFirstPoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFirstPoint.Location = new System.Drawing.Point(77, 130);
            this.btnClearFirstPoint.Name = "btnClearFirstPoint";
            this.btnClearFirstPoint.Size = new System.Drawing.Size(113, 23);
            this.btnClearFirstPoint.TabIndex = 27;
            this.btnClearFirstPoint.Text = "Clear first point";
            this.btnClearFirstPoint.UseVisualStyleBackColor = true;
            this.btnClearFirstPoint.Visible = false;
            this.btnClearFirstPoint.Click += new System.EventHandler(this.btnClearFirstPoint_Click);
            // 
            // lblFirstPoint
            // 
            this.lblFirstPoint.AutoSize = true;
            this.lblFirstPoint.ForeColor = System.Drawing.Color.White;
            this.lblFirstPoint.Location = new System.Drawing.Point(12, 9);
            this.lblFirstPoint.Name = "lblFirstPoint";
            this.lblFirstPoint.Size = new System.Drawing.Size(113, 13);
            this.lblFirstPoint.TabIndex = 26;
            this.lblFirstPoint.Text = "First point not selected";
            // 
            // panelReminder
            // 
            this.panelReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelReminder.BackColor = System.Drawing.SystemColors.Control;
            this.panelReminder.BackgroundImage = global::Composition.Properties.Resources.Composition_Overlay;
            this.panelReminder.Controls.Add(this.pbBackgroundColour);
            this.panelReminder.Location = new System.Drawing.Point(1, 207);
            this.panelReminder.Name = "panelReminder";
            this.panelReminder.Size = new System.Drawing.Size(279, 248);
            this.panelReminder.TabIndex = 39;
            this.panelReminder.Click += new System.EventHandler(this.panelReminder_Click);
            // 
            // pbBackgroundColour
            // 
            this.pbBackgroundColour.BackColor = System.Drawing.Color.Transparent;
            this.pbBackgroundColour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbBackgroundColour.Location = new System.Drawing.Point(162, 136);
            this.pbBackgroundColour.Name = "pbBackgroundColour";
            this.pbBackgroundColour.Size = new System.Drawing.Size(113, 58);
            this.pbBackgroundColour.TabIndex = 28;
            this.pbBackgroundColour.TabStop = false;
            this.pbBackgroundColour.Click += new System.EventHandler(this.pbBackgroundColour_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerate.Location = new System.Drawing.Point(12, 419);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(254, 23);
            this.btnGenerate.TabIndex = 25;
            this.btnGenerate.Text = "I\'m Done, Generate XML";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSkip.Location = new System.Drawing.Point(15, 276);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(251, 23);
            this.btnSkip.TabIndex = 24;
            this.btnSkip.Text = "Skip this step";
            this.btnSkip.UseVisualStyleBackColor = true;
            this.btnSkip.Visible = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // instructionTextBox
            // 
            this.instructionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.instructionTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.instructionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionTextBox.Location = new System.Drawing.Point(15, 34);
            this.instructionTextBox.Name = "instructionTextBox";
            this.instructionTextBox.ReadOnly = true;
            this.instructionTextBox.Size = new System.Drawing.Size(251, 138);
            this.instructionTextBox.TabIndex = 20;
            this.instructionTextBox.Text = "";
            // 
            // lblStepTitle
            // 
            this.lblStepTitle.AutoSize = true;
            this.lblStepTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepTitle.Location = new System.Drawing.Point(12, 15);
            this.lblStepTitle.Name = "lblStepTitle";
            this.lblStepTitle.Size = new System.Drawing.Size(81, 16);
            this.lblStepTitle.TabIndex = 19;
            this.lblStepTitle.Text = "Step 2 of 4";
            // 
            // btnBackgroundColour
            // 
            this.btnBackgroundColour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBackgroundColour.BackColor = System.Drawing.Color.White;
            this.btnBackgroundColour.Location = new System.Drawing.Point(171, 358);
            this.btnBackgroundColour.Name = "btnBackgroundColour";
            this.btnBackgroundColour.Size = new System.Drawing.Size(95, 39);
            this.btnBackgroundColour.TabIndex = 18;
            this.btnBackgroundColour.Text = "Not Set";
            this.btnBackgroundColour.UseVisualStyleBackColor = false;
            this.btnBackgroundColour.Click += new System.EventHandler(this.btnBackgroundColour_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(168, 341);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "Background Colour";
            // 
            // pbVideoHelp
            // 
            this.pbVideoHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbVideoHelp.BackColor = System.Drawing.SystemColors.Control;
            this.pbVideoHelp.BackgroundImage = global::Composition.Properties.Resources.VideoHelp;
            this.pbVideoHelp.Location = new System.Drawing.Point(15, 178);
            this.pbVideoHelp.Name = "pbVideoHelp";
            this.pbVideoHelp.Size = new System.Drawing.Size(251, 92);
            this.pbVideoHelp.TabIndex = 38;
            this.pbVideoHelp.TabStop = false;
            this.pbVideoHelp.Click += new System.EventHandler(this.pbVideoHelp_Click);
            // 
            // selectionPanel
            // 
            this.selectionPanel.AllowDrop = true;
            this.selectionPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.selectionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.selectionPanel.Controls.Add(this.pbPrecisionImage);
            this.selectionPanel.Controls.Add(this.zoomedImageBox);
            this.selectionPanel.Controls.Add(this.label3);
            this.selectionPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionPanel.Location = new System.Drawing.Point(0, 0);
            this.selectionPanel.Name = "selectionPanel";
            this.selectionPanel.Size = new System.Drawing.Size(901, 611);
            this.selectionPanel.TabIndex = 1;
            this.selectionPanel.MouseEnter += new System.EventHandler(this.selectionPanel_MouseEnter);
            this.selectionPanel.Resize += new System.EventHandler(this.selectionPanel_Resize);
            // 
            // pbPrecisionImage
            // 
            this.pbPrecisionImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbPrecisionImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPrecisionImage.Location = new System.Drawing.Point(689, 399);
            this.pbPrecisionImage.MaximumSize = new System.Drawing.Size(200, 200);
            this.pbPrecisionImage.MinimumSize = new System.Drawing.Size(200, 200);
            this.pbPrecisionImage.Name = "pbPrecisionImage";
            this.pbPrecisionImage.Size = new System.Drawing.Size(200, 200);
            this.pbPrecisionImage.TabIndex = 3;
            this.pbPrecisionImage.TabStop = false;
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
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // backgroundWriteProjectWorker
            // 
            this.backgroundWriteProjectWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWriteProjectWorker_DoWork);
            this.backgroundWriteProjectWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWriteProjectWorker_RunWorkerCompleted);
            // 
            // tmrPreviewUpdate
            // 
            this.tmrPreviewUpdate.Interval = 25;
            this.tmrPreviewUpdate.Tick += new System.EventHandler(this.tmrPreviewUpdate_Tick);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Composition";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.firstClickViewPanel.ResumeLayout(false);
            this.firstClickViewPanel.PerformLayout();
            this.panelReminder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundColour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVideoHelp)).EndInit();
            this.selectionPanel.ResumeLayout(false);
            this.selectionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrecisionImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel firstClickViewPanel;
        private System.Windows.Forms.Panel selectionPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox zoomedImageBox;
        private System.Windows.Forms.Button btnBackgroundColour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox instructionTextBox;
        private System.Windows.Forms.Label lblStepTitle;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnClearFirstPoint;
        private System.Windows.Forms.Label lblFirstPoint;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.ComponentModel.BackgroundWorker backgroundWriteProjectWorker;
        private System.Windows.Forms.PictureBox pbBackgroundColour;
        private System.Windows.Forms.PictureBox pbVideoHelp;
        private System.Windows.Forms.Panel panelReminder;
        private System.Windows.Forms.PictureBox pbPrecisionImage;
        private System.Windows.Forms.Timer tmrPreviewUpdate;
    }
}

