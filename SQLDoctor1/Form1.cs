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


        private void parseServerNames_Button_Click(object sender, EventArgs e)
        {
            string[] Servers = serverNameList.Text.Split('\n');
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
                                unvalSQLInst_ListBox.Items.Add(Server1);
                            }
                            else
                            {
                                MessageBox.Show(errorRecord.ToString());
                            }
                        }
                    }

                    foreach (var result in results)
                    {
                        valSQLInst_ListBox.Items.Add(result);
                    }
                }
            }

            tabControl1.SelectTab("Instances");
        }

        private void moveToSQLChecks_Button_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("Checks");
        }

        private void runSQLChecks_Button_Click(object sender, EventArgs e)
        {
            foreach (object Server in valSQLInst_ListBox.Items)
            {
                sqlChecks(Server.ToString());
            }
        }


        private void sqlChecks(string Server)
        {
            string getSQLVersion = "SELECT @@VERSION;";

            using (PowerShell psInstance = PowerShell.Create())
            {
                //Declare variable strings outside of the IF blocks
                string PS_sqlVersionScript = @"";
                string PS_healthCheckScript = @"";

                if ((sqlChecks_CheckedListBox.GetItemCheckState(0).ToString() == "Checked") || (sqlChecks_CheckedListBox.GetItemCheckState(1).ToString() == "Checked"))
                {
                    //--------------------------------------------------------------------------------------------------------
                    if (sqlChecks_CheckedListBox.GetItemCheckState(0).ToString() == "Checked")
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
                    else if (sqlChecks_CheckedListBox.GetItemCheckState(1).ToString() == "Checked")
                    {
                        //begin work on SQL Versions Check
                        PS_sqlVersionScript = $@"
                        Param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                        Import-Module SQLPS -DisableNameChecking;

                        $sqlVersionQuery = Invoke-Sqlcmd -ServerInstance ""windows10\sqlexpress"" -Query ""{getSQLVersion}""
                        $sqlVersion = $sqlVersionQuery | foreach {{$_.Column1}};
                        $sqlVersion;
                        ";

                        string PS_sqlVersionScript1 = $@"
                        Param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                        Import-Module SQLPS -DisableNameChecking;

                        $sqlVersionQuery = Invoke-Sqlcmd -ServerInstance ""$server"" -Query ""{getSQLVersion}""
                        $sqlVersionQuery;
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



        private void clearResults_Button_Click(object sender, EventArgs e)
        {
            listbox1.Items.Clear();
            unvalSQLInst_ListBox.Items.Clear();
            valSQLInst_ListBox.Items.Clear();
        }


        //--------------------------------------- MAIN CODE ---------------------------------------------------------//
    }
}
