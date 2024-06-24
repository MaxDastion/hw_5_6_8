using System.ComponentModel;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {

        BackgroundWorker worker;
        public Form1()
        {
            InitializeComponent();
            worker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            worker.DoWork += Yes_Sir_yes_I_Working;
            worker.ProgressChanged += BackgroundWorker_ProgressChanged;
            worker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    
                    listBox1.Items.Clear();
                    worker.RunWorkerAsync(new string[] { dialog.SelectedPath, "*.*" });

                }
            }


        }

        private void Yes_Sir_yes_I_Working(object sender, DoWorkEventArgs e)
        {
            var args = (string[])e.Argument;
            string directory = args[0];
            string pattern = args[1];
            var files = Directory.EnumerateFiles(directory, pattern, SearchOption.AllDirectories).ToList();
            int totalFiles = files.Count;
            int processedFiles = 0;

            foreach (var file in files)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }

                string fileName = Path.GetFileName(file);
                worker.ReportProgress((processedFiles * 100) / totalFiles, fileName);
                processedFiles++;
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            listBox1.Items.Add(e.UserState.ToString());
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("Search was canceled.");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("An error occurred: " + e.Error.Message);
            }
            else
            {
                MessageBox.Show("Search completed successfully.");
            }
        }

    }
}
