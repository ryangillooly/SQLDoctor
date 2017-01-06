﻿using System;
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
                    break;
                }

                string PSScript = @"
                Param([Parameter(Mandatory = $true, ValueFromPipeline = $true)][string] $server)

                $localInstances = @()
                [array]$captions = GWMI Win32_Service -ComputerName $server | ?{$_.Name -match 'mssql *' -and $_.PathName -match 'sqlservr.exe'} | %{$_.Caption}

                ForEach($caption in $captions)
                {
                    if ($caption -eq 'MSSQLSERVER') 
                    {
                        $localInstances += 'MSSQLSERVER'
                    }    
                    else 
                    {
                        $temp = $caption | %{$_.split(' ')[-1]} | %{$_.trimStart('(')} | %{$_.trimEnd(')')}
                        $localInstances += ""$server\$temp""
                    }
                }
                $localInstances;
                ";
                
                using (PowerShell psInstance = PowerShell.Create())
                {
                    psInstance.AddScript(PSScript);
                    psInstance.AddParameter("server", Server);
                    Collection<PSObject> results = psInstance.Invoke();

                    //Error displays
                    if (psInstance.Streams.Error.Any())
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
