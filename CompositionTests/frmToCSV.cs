using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using Newtonsoft.Json;

namespace CompositionTests
{
    /// <summary>
    /// Form To CSV
    /// Form showing user indeterminant progress whilst converting JSON results to CSV, so that it can be read and manipulated in Excel
    /// </summary>
    public partial class frmToCSV : Form
    {
        public frmToCSV()
        {
            InitializeComponent();
        }

        private void frmToCSV_Load(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> jsonFilePaths = new List<string>();

            string[] files = Directory.GetFiles(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].EndsWith(".json") && files[i].Contains("result"))
                    jsonFilePaths.Add(files[i]);
            }

            for (int i = 0; i < jsonFilePaths.Count; i++)
            {
                List<Result> results = JsonConvert.DeserializeObject<List<Result>>(File.ReadAllText(jsonFilePaths[i]));

                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Correct Type,Was Correct,Analysed Type,");

                for (int x = 0; x < results.Count; x++)
                {
                    sb.AppendLine(results[x].WidgetType.ToString() + "," + results[x].Correct.ToString() + "," + results[x].AnalsisResultWidgetType.ToString() + ",");
                }

                if (File.Exists(jsonFilePaths[i] + ".csv"))
                    File.Delete(jsonFilePaths[i] + ".csv");

                File.WriteAllText(jsonFilePaths[i] + ".csv", sb.ToString());

                backgroundWorker.ReportProgress((int)(i / jsonFilePaths.Count * 100));
            }

            Thread.Sleep(1000);

            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate() { this.Close(); });
            }
            else
            {
                this.Close();
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
    }
}
