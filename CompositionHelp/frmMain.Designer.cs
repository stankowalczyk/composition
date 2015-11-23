namespace CompositionHelp
{
    partial class fmrMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmrMain));
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.SuspendLayout();
            // 
            // wmp
            // 
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(0, 0);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(1280, 720);
            this.wmp.TabIndex = 0;
            this.wmp.StatusChange += new System.EventHandler(this.wmp_StatusChange);
            this.wmp.PositionChange += new AxWMPLib._WMPOCXEvents_PositionChangeEventHandler(this.wmp_PositionChange);
            this.wmp.CurrentMediaItemAvailable += new AxWMPLib._WMPOCXEvents_CurrentMediaItemAvailableEventHandler(this.wmp_CurrentMediaItemAvailable);
            this.wmp.ClickEvent += new AxWMPLib._WMPOCXEvents_ClickEventHandler(this.wmp_ClickEvent);
            this.wmp.Enter += new System.EventHandler(this.wmp_Enter);
            // 
            // tmr
            // 
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // fmrMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 720);
            this.Controls.Add(this.wmp);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1295, 759);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1295, 759);
            this.Name = "fmrMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer wmp;
        private System.Windows.Forms.Timer tmr;
    }
}

