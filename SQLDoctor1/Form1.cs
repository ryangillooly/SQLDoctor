using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;


namespace SQLDoctor1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string logPath = "\\\\RGCloud\\Ryan\\TechData\\SQLDoctor1\\Output.Log";
            //if (File.Exists(logPath))
            //{
            //    File.Delete(logPath);
            //}

            string[] Servers = richTextBox1.Text.Split('\n');
            foreach (string Server in Servers)
            {
                string PSScript = @"
                param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned -Force;
                Import-Module SQLPS;
                Try 
                {
                    Set-Location SQLServer:\\SQL\\$server -ErrorAction Stop; 
                    Get-ChildItem | Select-Object -ExpandProperty Name;
                } 
                Catch 
                {
                    echo 'No SQL Server Instances'; 
                }
                ";

                using (PowerShell psInstance = PowerShell.Create())
                {
                    psInstance.AddScript(PSScript);
                    psInstance.AddParameter("server", Server);
                    Collection<PSObject> results = psInstance.Invoke();
                    
                    if (psInstance.Streams.Error.Count > 0)
                    {
                        foreach (var errorRecord in psInstance.Streams.Error)
                        {
                            MessageBox.Show(errorRecord.ToString());
                        }
                    }

                    foreach (PSObject result in results)
                    {
                        //File.AppendAllText(logpath, result + Environment.NewLine);
                        listBox1.Items.Add(result);
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Clear all items from ListBox1
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
