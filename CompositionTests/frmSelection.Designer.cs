namespace CompositionTests
{
    partial class frmSelection
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
            this.btnPrimaryColour = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackgroundColour = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.btnClearFirstPoint = new System.Windows.Forms.Button();
            this.lblFirstPoint = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.selectionPanel = new System.Windows.Forms.Panel();
            this.zoomedImageBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentImageIndex = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.lblCurrentImageIndex);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrimaryColour);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lblCount);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnBackgroundColour);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.lblType);
            this.splitContainer1.Panel1.Controls.Add(this.btnClearFirstPoint);
            this.splitContainer1.Panel1.Controls.Add(this.lblFirstPoint);
            this.splitContainer1.Panel1.Controls.Add(this.btnNext);
            this.splitContainer1.Panel1.Controls.Add(this.btnSave);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectionPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1184, 611);
            this.splitContainer1.SplitterDistance = 279;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnPrimaryColour
            // 
            this.btnPrimaryColour.BackColor = System.Drawing.Color.White;
            this.btnPrimaryColour.Location = new System.Drawing.Point(11, 456);
            this.btnPrimaryColour.Name = "btnPrimaryColour";
            this.btnPrimaryColour.Size = new System.Drawing.Size(95, 39);
            this.btnPrimaryColour.TabIndex = 37;
            this.btnPrimaryColour.UseVisualStyleBackColor = false;
            this.btnPrimaryColour.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 439);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Primary Colour";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(65, 215);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 35;
            this.lblCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Count = ";
            // 
            // btnBackgroundColour
            // 
            this.btnBackgroundColour.BackColor = System.Drawing.Color.White;
            this.btnBackgroundColour.Location = new System.Drawing.Point(167, 456);
            this.btnBackgroundColour.Name = "btnBackgroundColour";
            this.btnBackgroundColour.Size = new System.Drawing.Size(95, 39);
            this.btnBackgroundColour.TabIndex = 33;
            this.btnBackgroundColour.UseVisualStyleBackColor = false;
            this.btnBackgroundColour.Click += new System.EventHandler(this.btnBackgroundColour_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(164, 439);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Background Colour";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 202);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 31;
            this.lblType.Text = "label1";
            // 
            // btnClearFirstPoint
            // 
            this.btnClearFirstPoint.Location = new System.Drawing.Point(15, 25);
            this.btnClearFirstPoint.Name = "btnClearFirstPoint";
            this.btnClearFirstPoint.Size = new System.Drawing.Size(113, 23);
            this.btnClearFirstPoint.TabIndex = 30;
            this.btnClearFirstPoint.Text = "Clear first point";
            this.btnClearFirstPoint.UseVisualStyleBackColor = true;
            this.btnClearFirstPoint.Visible = false;
            this.btnClearFirstPoint.Click += new System.EventHandler(this.btnClearFirstPoint_Click);
            // 
            // lblFirstPoint
            // 
            this.lblFirstPoint.AutoSize = true;
            this.lblFirstPoint.ForeColor = System.Drawing.Color.Black;
            this.lblFirstPoint.Location = new System.Drawing.Point(12, 9);
            this.lblFirstPoint.Name = "lblFirstPoint";
            this.lblFirstPoint.Size = new System.Drawing.Size(113, 13);
            this.lblFirstPoint.TabIndex = 29;
            this.lblFirstPoint.Text = "First point not selected";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(11, 513);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(251, 23);
            this.btnNext.TabIndex = 28;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(11, 576);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(251, 23);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // lblCurrentImageIndex
            // 
            this.lblCurrentImageIndex.AutoSize = true;
            this.lblCurrentImageIndex.Location = new System.Drawing.Point(79, 240);
            this.lblCurrentImageIndex.Name = "lblCurrentImageIndex";
            this.lblCurrentImageIndex.Size = new System.Drawing.Size(13, 13);
            this.lblCurrentImageIndex.TabIndex = 39;
            this.lblCurrentImageIndex.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "CurrImage=";
            // 
            // frmSelection
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Composition";
            this.Load += new System.EventHandler(this.frmColourChooser_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.onKeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClearFirstPoint;
        private System.Windows.Forms.Label lblFirstPoint;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnBackgroundColour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrimaryColour;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentImageIndex;
        private System.Windows.Forms.Label label5;
    }
}

