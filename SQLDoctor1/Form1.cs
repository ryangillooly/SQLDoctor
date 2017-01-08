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
//--------------------------------------- MAIN CODE ----------------------------------------------------------//


        private void button1_Click(object sender, EventArgs e)
        {
           if (button1.Text == "Parse Server Names")
           {
                parseServerNames_Button();
           }
           else if (button1.Text == "Move to SQL Checks")
           {
                moveToSQLChecks_Button();
           }
        }
                private void parseServerNames_Button()
                {
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
                            
                            if (Server1 == "localhost")
                            {
                                Server1 = System.Environment.MachineName;
                            }

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
                                listBox3.Items.Add(result);
                            }
                        }
                    }

            if (listBox3.Items.Count > 0)
            {
                tabControl1.SelectedIndex = 1;
                button1.Text = "Move to SQL Checks";
            }
        }
                private void moveToSQLChecks_Button()
                {
                    tabControl1.SelectedIndex = 2;
                }
                private void SQLChecks(string Server)
        {
            using (PowerShell psInstance = PowerShell.Create())
            {
                //Declare variable strings outside of the IF blocks
                string PS_sqlVersionScript = @"";
                string PS_healthCheckScript = @"";

                if ((sqlCheckedListBox.GetItemCheckState(0).ToString() == "Checked") || (sqlCheckedListBox.GetItemCheckState(1).ToString() == "Checked"))
                {
                    //--------------------------------------------------------------------------------------------------------
                    if (sqlCheckedListBox.GetItemCheckState(0).ToString() == "Checked")
                    {
                        //begin work on Full SQL Health Check
                        PS_healthCheckScript = @"
                        Param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                        Import-Module SQLPS;

                        $Test = ""This is the health check...""
                        $Test;
                        ";

                        psInstance.AddScript(PS_healthCheckScript);
                    }
                    //--------------------------------------------------------------------------------------------------------
                    else if (sqlCheckedListBox.GetItemCheckState(1).ToString() == "Checked")
                    {
                        //begin work on SQL Versions Check
                        PS_sqlVersionScript = @"
                        Param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                        Import-Module SQLPS;

                        $sqlVersionQuery = Invoke-Sqlcmd -ServerInstance ""$server"" -Username ""SQLDoctor"" -Password ""SQLDoc"" -Query ""EXEC SQLDoctor.dba.sp_dba_GetServerVersion;""
                        $sqlVersion = $sqlVersionQuery.ProductVersion.ToString();
                        $sqlVersion;
                        ";

                        psInstance.AddScript(PS_sqlVersionScript);
                    }
                    //--------------------------------------------------------------------------------------------------------
                    psInstance.AddParameter("server", Server);
                    Collection<PSObject> results = psInstance.Invoke();

                    //Error displays
                    if (psInstance.Streams.Error.Any())
                    {
                        foreach (var errorRecord in psInstance.Streams.Error)
                        {
                            {
                                MessageBox.Show(errorRecord.ToString());
                            }
                        }
                    }

                    foreach (PSObject result in results)
                    {
                        if (result != null)
                        {
                            MessageBox.Show(result.ToString());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No SQL Checks Selected. Please select Checks to be performed.");
                }
                //--------------------------------------------------------------------------------------------------------
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Clear all items from ListBox1
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            SQLChecks("HomePC\\SQL01");
        }


//--------------------------------------- MAIN CODE ---------------------------------------------------------//
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
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
        private void sqlCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
