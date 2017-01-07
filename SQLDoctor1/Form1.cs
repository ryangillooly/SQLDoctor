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
            //string logPath = "\\\\localhost\\Output.Log";
            //if (File.Exists(logPath))
            //{
            //    File.Delete(logPath);
            //}

            string[] Servers = richTextBox1.Text.Split('\n');
            foreach (string Server in Servers)
            {
                if (String.IsNullOrEmpty(Server))
                {
                    continue;
                }

                string PSScript = @"
                Param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                $localInstances = @();
                $instName = ""MSSQL*"";
                $hostName = $server;

                if ($server -like '*\*')      #Host & SQLInstance
                {
                    $hostName = $server | %{$_.Split('\')[-2]}
                    $instName = $server | %{$_.Split('\')[-1]}
                    if ($instName -ne ""MSSQLSERVER"")
                    {
                        $instName = ""MSSQL*"" +$instName;
                    }
                }

                [array]$captions = GWMI Win32_Service -ComputerName $hostName | ?{$_.Name -like $instName -and $_.PathName -match 'sqlservr.exe'} | %{$_.Caption}

                ForEach($caption in $captions)
                {
                    if ($caption -eq 'MSSQLSERVER') 
                    {
                        $localInstances += 'MSSQLSERVER'
                    }    
                    else 
                    {
                        $temp = $caption | %{$_.split(' ')[-1]} | %{$_.trimStart('(')} | %{$_.trimEnd(')')}
                        $localInstances += ""$hostName\$temp""
                    }
                }
                $localInstances;
                ";
                
                using (PowerShell psInstance = PowerShell.Create())
                {
                    psInstance.AddScript(PSScript);
                    string Server1 = Server.Trim().ToString();
                    psInstance.AddParameter("server", Server1);
                    Collection<PSObject> results = psInstance.Invoke();

                    //Error displays
                    if (psInstance.Streams.Error.Any())
                    {   
                        foreach (var errorRecord in psInstance.Streams.Error)
                        {   //If the error contains an RPC error, input Server1 into the failed box or else Messagebox with error
                            if (errorRecord.ToString().Contains("The RPC server is unavailable"))
                            {
                                listBox2.Items.Add(Server1);
                            }
                            else
                            {
                                MessageBox.Show(errorRecord.ToString());
                            }
                        }
                    }
                    
                    foreach (PSObject result in results)
                    {
                        //File.AppendAllText(logpath, result + Environment.NewLine);
                        listBox3.Items.Add(result);
                    }
                }
            }

            tabControl1.SelectedIndex = 1;
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
