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
            //If the logPath exists, delete the file
            string logPath = "\\\\RGCloud\\Ryan\\TechData\\SQLDoctor1\\Output.Log";
            if (File.Exists(logPath))
            {
                File.Delete(logPath);
            }

            //Delimiter to split items in the Server List Input Box
            string[] Servers = richTextBox1.Text.Split('\n');

            //Pass each server name from the server list to the 'Server' variable
            foreach (string Server in Servers)
            {
                //PowerShell Script
                string PSScript1 = @"
                param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned -Force;
                Import-Module SQLServer;
                Try 
                {
                    Set-Location SQLServer:\\SQL\\$server -ErrorAction Stop; 
                    Get-ChildItem | Select-Object -ExpandProperty Name;
                } 
                Catch 
                {
                    echo 'No SQL Server Instances'; 
                    echo $?;
                }
                ";

                string PSScript = @"
                param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)
                Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned -Force;
                Import-Module SQLServer;
                Try 
                {
                    Set-Location SQLServer:\\SQL\\"+Server+@" -ErrorAction Stop; 
                    Get-ChildItem | Select-Object -ExpandProperty Name;
                } 
                Catch 
                {
                    echo 'No SQL Server Instances'; 
                    echo $?;
                }
                ";

                //Create PowerShell Instance
                PowerShell psInstance = PowerShell.Create();

                //Add PowerShell Script
                psInstance.AddCommand(PSScript);

                //Pass the Server variable in to the $server parameter within the PS script
                psInstance.AddParameter("server", Server);

                //Execute Script
                Collection<PSObject> results = new Collection<PSObject>();
                try
                {
                    results = psInstance.Invoke();
                }
                catch (Exception ex)
                {
                    results.Add(new PSObject((Object)ex.Message));
                }

                //Loop through each of the results in the PowerShell window
                foreach (PSObject result in results)
                {
                   //File.AppendAllText(logPath, result + Environment.NewLine);
                    listBox1.Items.Add(result);
                }

                psInstance.Dispose();
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
