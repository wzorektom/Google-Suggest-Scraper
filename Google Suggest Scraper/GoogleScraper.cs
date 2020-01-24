using ClassLibrary;
using Microsoft.Office.Interop.Excel;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace Google_Suggest_Scraper
{
    public partial class GoogleScraper : Form
    {
        public GoogleScraper()
        {
            InitializeComponent();
               

            // Default all controlls
            lblCountGrid1.Text = "0";
            lblCountGrid2.Text = "0";
            lblCountGrid3.Text = "0";

            lblProgressBar.Text = "";

            lblLoading1.Hide();
            lblLoading2.Hide();
            lblLoading3.Hide();

            progressBar1.Hide();

            timer1.Stop();
            timer2.Stop();
            timer3.Stop();

        }

        /// <summary>
        /// Initiate HelperClass
        /// </summary>
        readonly HelperClass HelpMeClass = new HelperClass();


        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search string
            HelpMeClass.SearchString = txtSearchQuery.Text;

            // Reset controls
            lblCountGrid1.Text = "0";
            lblCountGrid2.Text = "0";
            lblCountGrid3.Text = "0";

            // Clear DataGrid datasource
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            dataGridView3.DataSource = null;


            // Let the user know to type the search query first before pressing search button
            if (txtSearchQuery.Text == "")
            {
                MessageBox.Show("Please type the search phrase!", "Important Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            else
            {
                //InitializeTimer();
                timer1.Start();
                //InitializeTimer();
                timer2.Start();
                //InitializeTimer();
                timer3.Start();

                // Run the query
                GetAlphabet();
                GetQuestions();
                GetQuestionsAlphabet();

                // Disable the search button while the search is in progress
                btnSearch.Enabled = false;

                // Disable the Excel export button while the search is in progress
                btnExcellExport.Enabled = false;
            }

            


        }



        /// <summary>
        /// Run the Alphabet search
        /// </summary>
        private async void GetAlphabet()
        {
            // Initiate Alphabet search
            var task = new SearchAlphabetSoup().GetDataAsync(txtSearchQuery.Text);

            try
            {

                var result = await task;
                dataGridView1.DataSource = result;

                if (result.Count == 0)
                {
                    timer1.Stop();
                    lblLoading1.Hide();
                    lblCountGrid1.Text = "0 - No results found!";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check if you are connected to the internet. If you have not used the VPN Google may block your IP, stop using the app immediately! " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }




        private async void GetQuestions()
        {
            var task = new SearchQuestions().GetDataAsync(txtSearchQuery.Text);

            try
            {

                var result = await task;

                dataGridView2.DataSource = result;

                if (result.Count == 0)
                {
                    timer2.Stop();
                    lblLoading2.Hide();
                    lblCountGrid2.Text = "0 - No results found!";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check if you are connected to the internet. If you have not used the VPN Google may block your IP, stop using the app immediately! " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }




        private async void GetQuestionsAlphabet()
        {
            var task = new SearchQuestionsAlphabet().GetDataAsync(txtSearchQuery.Text);

            try
            {

                var result = await task;


                dataGridView3.DataSource = result;
                btnSearch.Enabled = true;
                btnExcellExport.Enabled = true;

                if (result.Count == 0)
                {
                    timer3.Stop();
                    lblLoading3.Hide();
                    lblCountGrid3.Text = "0 - No results found!";
                    btnSearch.Enabled = true;
                    btnExcellExport.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check if you are connected to the internet. If you have not used the VPN Google may block your IP, stop using the app immediately! " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }





        private void timer1_Tick(object sender, EventArgs e)
        {
            // Initiate Allowance arrow
            if (dataGridView1.Rows.Count == 0)
            {
                lblLoading1.Visible = !lblLoading1.Visible;
                timer1.Start();
            }
            else
            {
                lblLoading1.Visible = false;
                lblCountGrid1.Text = dataGridView1.RowCount.ToString();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Initiate Allowance arrow
            if (dataGridView2.Rows.Count == 0)
            {
                lblLoading2.Visible = !lblLoading2.Visible;
                timer2.Start();
            }
            else
            {
                lblLoading2.Visible = false;
                lblCountGrid2.Text = dataGridView2.RowCount.ToString();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // Initiate Allowance arrow
            if (dataGridView3.Rows.Count == 0)
            {
                lblLoading3.Visible = !lblLoading3.Visible;
                timer3.Start();
            }
            else
            {
                lblLoading3.Visible = false;
                lblCountGrid3.Text = dataGridView3.RowCount.ToString();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About AboutForm = new About();
            AboutForm.Show();
        }




        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSearchQuery.Text = dataGridView1.CurrentCell.Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSearchQuery.Text = dataGridView2.CurrentCell.Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSearchQuery.Text = dataGridView3.CurrentCell.Value.ToString();
        }




        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                string selectedValue = dataGridView1.SelectedCells[0].Value.ToString();
                Process.Start("http://www.google.com/search?q=" + selectedValue);
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                string selectedValue = dataGridView2.SelectedCells[0].Value.ToString();
                Process.Start("http://www.google.com/search?q=" + selectedValue);
            }
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
            {
                string selectedValue = dataGridView3.SelectedCells[0].Value.ToString();
                Process.Start("http://www.google.com/search?q=" + selectedValue);
            }
        }









        private void btnExcellExport_Click(object sender, EventArgs e)
        {
            if (!(dataGridView1.RowCount == 0))
            {
                if (backgroundWorker1.IsBusy)
                    return;
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", RestoreDirectory = true, InitialDirectory = HelpMeClass.ExcelSaveDirectory
                })
                {
                    
                    sfd.FileName = HelpMeClass.SearchString;
                    
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        HelpMeClass.ExcelSaveDirectory = Path.GetDirectoryName(sfd.FileName);
                        progressBar1.Show();
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 0;
                        backgroundWorker1.RunWorkerAsync();
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("Oops! Nothing to export!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }





        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;

            excel.Visible = true;
            int index = 0;
            
            int process = dataGridView1.Rows.Count;
            int process1 = dataGridView2.Rows.Count;
            int process2 = dataGridView3.Rows.Count;



            ws.get_Range("A1", "C1").Merge(); // Merge columns for header
            ws.Cells[1, 1] = "Keyword: " + HelpMeClass.SearchString;
            ws.Cells[1, 1].Font.Bold = true; // Bold font in header


            if (!backgroundWorker1.CancellationPending)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    backgroundWorker1.ReportProgress(index++ * 100 / process);

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ws.Cells[index + 1, 1] = cell.Value;
                    }
                }

                index = 0;
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    backgroundWorker1.ReportProgress(index++ * 100 / process1);

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ws.Cells[index + 1, 2] = cell.Value;
                    }
                }

                index = 0;
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    backgroundWorker1.ReportProgress(index++ * 100 / process2);

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        ws.Cells[index + 1, 3] = cell.Value;
                    }
                }
            }

            ws.Columns.AutoFit();



            try
            {
                ws.SaveAs(Path.Combine(HelpMeClass.ExcelSaveDirectory, HelpMeClass.SearchString), XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ooops! I can`t access the file. Make sure the excel file is closed and try again. " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }

            //excel.Quit();

        }



        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lblProgressBar.Text = string.Format("Processing... {0}%", e.ProgressPercentage + 1);
            progressBar1.Update();
        }



        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MessageBox.Show("Your data has been successfully exported.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                progressBar1.Value = 0;
                progressBar1.Hide();
                lblProgressBar.Text = "";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ooops! Something went wrong! " + ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }









    }
}
