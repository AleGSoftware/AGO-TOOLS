// Decompiled with JetBrains decompiler
// Type: AGO_TOOLS.Form1
// Assembly: AGO-TOOLS, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17959627-35CD-47A5-B4C2-C98F4A112650
// Assembly location: C:\AGO-Tools\AGO-TOOLS.exe

using AGO_TOOLS.Properties;
using Microsoft.Web.WebView2.WinForms;
using Renci.SshNet;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AGO_TOOLS
{
  public class Form1 : Form
  {
    public const int WM_NCLBUTTONDOWN = 161;
    public const int HT_CAPTION = 2;
    private IContainer components;
    private NotifyIcon notifyIcon1;
    private ContextMenuStrip menuTray;
    private ToolStripMenuItem aGOToolsToolStripMenuItem;
    private ToolStripMenuItem aleGSoftwareToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem riavvia1ToolStripMenuItem;
    private ToolStripMenuItem riavvia2ToolStripMenuItem;
    private Button button2;
    private Button button3;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem riavviaToolStripMenuItem;
    private ToolStripMenuItem aGOToolStripMenuItem;
    private ToolStripMenuItem mIPToolStripMenuItem;
    private ToolStripMenuItem accediToolStripMenuItem;
    private ToolStripMenuItem sSHToolStripMenuItem;
    private ToolStripMenuItem eseguiToolStripMenuItem;
    private ToolStripMenuItem funzionalitàPluginToolStripMenuItem;
    private ToolStripMenuItem impostaToolStripMenuItem;
    private ToolStripMenuItem backupToolStripMenuItem;
    private ToolStripMenuItem impostazioniToolStripMenuItem;
    private ToolStripMenuItem notizieAGOTOOLSToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem4;
    private ToolStripMenuItem informazioniSuToolStripMenuItem;
    private PictureBox pictureBox1;
    private ToolStripMenuItem pluginMaToolStripMenuItem;
    private PictureBox pictureBox2;
    private ToolStripMenuItem statoServizioAGOToolStripMenuItem;
    private ToolStripMenuItem statoServizioMIPToolStripMenuItem;
    private ToolStripMenuItem aggiornaImpostazioniToolStripMenuItem;
    private ToolStripMenuItem chiudiToolStripMenuItem;
    private ToolStripMenuItem rilanciaToolStripMenuItem;
    private ToolStripMenuItem chiudiApplicazioneToolStripMenuItem;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private ToolStripProgressBar toolStripProgressBar1;
    private ToolStripMenuItem aleGManualToolStripMenuItem;
    private Button button1;
    private Button button4;
    private ToolStripMenuItem mintrayTSMI;
    private Label label1;
    private ToolStripMenuItem iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem;
        private WebView2 webView22;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    public Form1()
    {
      this.InitializeComponent();
      this.Hide();
      this.WindowState = FormWindowState.Minimized;
      if (Directory.Exists("C:\\AGO-Tools\\Plugins"))
      {
        foreach (FileSystemInfo file in new DirectoryInfo("C:\\AGO-Tools\\Plugins").GetFiles("*.atp.*"))
          this.funzionalitàPluginToolStripMenuItem.DropDownItems.Add(file.Name);
      }
      if (!Directory.Exists("C:\\Program Files (x86)\\Microsoft\\EdgeWebView"))
        Process.Start("C:\\AGO-Tools\\MicrosoftEdgeWebview2Setup.exe");
      try
      {
        if (new Ping().Send("download.alegsoftware.ga", 1000) != null)
        {
          Console.WriteLine("SW: OK");
          this.aleGManualToolStripMenuItem.Visible = true;
          this.notizieAGOTOOLSToolStripMenuItem.Visible = true;
          this.pluginMaToolStripMenuItem.Visible = true;
          this.webView21.Visible = true;
          this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Visible = false;
        }
      }
      catch
      {
        Console.WriteLine("SW: ERR - Disabling web features");
        this.aleGManualToolStripMenuItem.Visible = false;
        this.notizieAGOTOOLSToolStripMenuItem.Visible = false;
        this.pluginMaToolStripMenuItem.Visible = false;
        this.webView21.Visible = false;
        Console.WriteLine("disabled.");
        this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Visible = true;
        this.notifyIcon1.BalloonTipTitle = "AGO Tools: ATTENZIONE!";
        this.notifyIcon1.BalloonTipText = "Impossibile contattare Web Services di AGO Tools. Aprire AGO Tools per maggiori informazioni.";
        this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
        this.notifyIcon1.ShowBalloonTip(3600);
      }
      using (WebClient webClient = new WebClient())
      {
        if (!AGO_TOOLS.Properties.Settings.Default.WsSwitchesDisabled)
        {
          System.IO.File.Delete(Path.GetTempPath() + "\\aN.txt");
          System.IO.File.Delete(Path.GetTempPath() + "\\aAM.txt");
          System.IO.File.Delete(Path.GetTempPath() + "\\aPM.txt");
          webClient.DownloadFile("https://download.alegsoftware.ga/ws_switches/ago_tools/aN.html", Path.GetTempPath() + "\\aN.html");
          webClient.DownloadFile("https://download.alegsoftware.ga/ws_switches/ago_tools/aAM.html", Path.GetTempPath() + "\\aAM.html");
          webClient.DownloadFile("https://download.alegsoftware.ga/ws_switches/ago_tools/aPM.html", Path.GetTempPath() + "\\aPM.html");
          System.IO.File.Move(Path.GetTempPath() + "\\aN.html", Path.GetTempPath() + "\\aN.txt");
          System.IO.File.Move(Path.GetTempPath() + "\\aAM.html", Path.GetTempPath() + "\\aAM.txt");
          System.IO.File.Move(Path.GetTempPath() + "\\aPM.html", Path.GetTempPath() + "\\aPM.txt");
          if (System.IO.File.ReadAllText(Path.GetTempPath() + "\\aN.txt") == "false")
          {
            this.notizieAGOTOOLSToolStripMenuItem.Visible = false;
            this.webView21.Visible = false;
          }
          if (System.IO.File.ReadAllText(Path.GetTempPath() + "\\aAM.txt") == "false")
            this.aleGManualToolStripMenuItem.Visible = false;
          if (System.IO.File.ReadAllText(Path.GetTempPath() + "\\aPM.txt") == "false")
            this.pluginMaToolStripMenuItem.Visible = false;
        }
        else if (MessageBox.Show("Attenzione. E' stata disattivata una funzione importante per il funzionamento di AGO Tools. Premere OK per riattivare", "Attenzione.", MessageBoxButtons.OK, MessageBoxIcon.Hand) == DialogResult.OK)
        {
          AGO_TOOLS.Properties.Settings.Default.WsSwitchesDisabled = false;
          AGO_TOOLS.Properties.Settings.Default.Save();
          int num = (int) MessageBox.Show("Modifica effettuata. Premere OK per riavviare AGO Tools");
          Application.Restart();
        }
      }
      this.Hide();
    }

    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      this.WindowState = FormWindowState.Normal;
      this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Right - this.Width, Screen.PrimaryScreen.WorkingArea.Bottom - this.Height);
      this.Show();
      this.Activate();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e) => Application.Exit();

    private void label2_Click(object sender, EventArgs e)
    {
    }

    private void button1_Click(object sender, EventArgs e) => this.Hide();

    private void button5_Click(object sender, EventArgs e) => new Settings().Show();

    private void riavvia1ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl restart " + descA);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl restart " + descA);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl restart " + descB);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void riavvia2ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl restart " + descB);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void button6_Click(object sender, EventArgs e)
    {
      string server = AGO_TOOLS.Properties.Settings.Default.server;
      string user = AGO_TOOLS.Properties.Settings.Default.user;
      string password = AGO_TOOLS.Properties.Settings.Default.password;
      string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
      Process.Start("C:\\AGO-Tools\\putty.exe", " " + user + "@" + server + " -pw " + password);
    }

    private void toolStripMenuItem3_Click(object sender, EventArgs e)
    {
      string server = AGO_TOOLS.Properties.Settings.Default.server;
      string user = AGO_TOOLS.Properties.Settings.Default.user;
      string password = AGO_TOOLS.Properties.Settings.Default.password;
      string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
      Process.Start("C:\\AGO-Tools\\putty.exe", " " + user + "@" + server + " -pw " + password);
    }

    private void button4_Click(object sender, EventArgs e)
    {
      string server = AGO_TOOLS.Properties.Settings.Default.server;
      string user = AGO_TOOLS.Properties.Settings.Default.user;
      string password = AGO_TOOLS.Properties.Settings.Default.password;
      string pathBak = AGO_TOOLS.Properties.Settings.Default.path_bak;
      Process.Start("cmd", "/c echo y | C:\\AGO-Tools\\plink.exe " + user + "@" + server + " -pw " + password + " bash " + pathBak);
    }

    private void toolStripMenuItem2_Click(object sender, EventArgs e)
    {
      string server = AGO_TOOLS.Properties.Settings.Default.server;
      string user = AGO_TOOLS.Properties.Settings.Default.user;
      string password = AGO_TOOLS.Properties.Settings.Default.password;
      string pathBak = AGO_TOOLS.Properties.Settings.Default.path_bak;
      Process.Start("cmd", "/c echo y | C:\\AGO-Tools\\plink.exe " + user + "@" + server + " -pw " + password + " bash " + pathBak);
    }

    private void aGOToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl restart " + descB);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void mIPToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl restart " + descA);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void sSHToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string server = AGO_TOOLS.Properties.Settings.Default.server;
      string user = AGO_TOOLS.Properties.Settings.Default.user;
      string password = AGO_TOOLS.Properties.Settings.Default.password;
      string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
      Process.Start("C:\\AGO-Tools\\putty.exe", " " + user + "@" + server + " -pw " + password);
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {
    }

    private void impostazioniToolStripMenuItem_Click(object sender, EventArgs e) => new Settings().Show();

    private void button7_Click(object sender, EventArgs e) => this.Hide();

    private void notizieAGOTOOLSToolStripMenuItem_Click(object sender, EventArgs e) => new news().Show();

    private void backupToolStripMenuItem_Click(object sender, EventArgs e)
    {
      string server = AGO_TOOLS.Properties.Settings.Default.server;
      string user = AGO_TOOLS.Properties.Settings.Default.user;
      string password = AGO_TOOLS.Properties.Settings.Default.password;
      string pathBak = AGO_TOOLS.Properties.Settings.Default.path_bak;
      Process.Start("cmd", "/c echo y | C:\\AGO-Tools\\plink.exe " + user + "@" + server + " -pw " + password + " bash " + pathBak);
    }

    private void informazioniSuToolStripMenuItem_Click(object sender, EventArgs e) => new about().Show();

    private void atpToolStripMenuItem_Click(object sender, ToolStripItemClickedEventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (Convert.ToString((object) e.ClickedItem) == "Plugin Marketplace")
        new Marketplace().Show();
      else
        Process.Start("C:\\AGO-Tools\\Plugins\\" + e.ClickedItem?.ToString());
    }

    private void pluginMaToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void statoServizioAGOToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl status " + descB);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void statoServizioMIPToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl status " + descA);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void aggiornaImpostazioniToolStripMenuItem_Click(object sender, EventArgs e) => AGO_TOOLS.Properties.Settings.Default.Upgrade();

    private void pictureBox2_Click(object sender, EventArgs e) => Process.Start("http://www.alegsoftware.ga");

    private void rilanciaToolStripMenuItem_Click(object sender, EventArgs e) => Application.Restart();

    private void chiudiApplicazioneToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();

    private void aleGManualToolStripMenuItem_Click(object sender, EventArgs e) => new alegmanual().Show();

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
    }

    private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      Form1.ReleaseCapture();
      Form1.SendMessage(this.Handle, 161, 2, 0);
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl status " + descB);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void button4_Click_1(object sender, EventArgs e)
    {
      this.toolStripProgressBar1.MarqueeAnimationSpeed = 30;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
      this.toolStripStatusLabel1.Text = "Connetto ed eseguo il comando...";
      new Thread((ThreadStart) (() =>
      {
        try
        {
          using (SshClient sshClient = new SshClient(AGO_TOOLS.Properties.Settings.Default.server, AGO_TOOLS.Properties.Settings.Default.user, AGO_TOOLS.Properties.Settings.Default.password))
          {
            string descB = AGO_TOOLS.Properties.Settings.Default.desc_b;
            string descA = AGO_TOOLS.Properties.Settings.Default.desc_a;
            sshClient.Connect();
            SshCommand command = sshClient.CreateCommand("systemctl status " + descA);
            command.Execute();
            sshClient.Disconnect();
            sshClient.Disconnect();
            string result = command.Result;
            if (result == "")
            {
              int num1 = (int) MessageBox.Show("Il comando non ha restituito nessun risultato. Di solito questo vuol dire che è andato a buon fine. Si prega di controllare lo stato del servizio riavviato");
            }
            else
            {
              int num2 = (int) MessageBox.Show(result);
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show("Si è verificato un problema. Consultare il manuale di AGO Tools oppure contattare AleGSoftware. Errore: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      })).Start();
      this.toolStripProgressBar1.Value = 100;
      this.toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
      this.toolStripStatusLabel1.Text = "PRONTO";
    }

    private void mintrayTSMI_Click(object sender, EventArgs e) => this.Hide();

    private void label1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      Form1.ReleaseCapture();
      Form1.SendMessage(this.Handle, 161, 2, 0);
    }

    private void iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show("Errore di connessione Web Services. Le funzionalità web sono state disattivate automaticamente per prevenire qualsiasi errore. Provare a connettersi a Internet nuovamente o aggiungere un eccezione al firewall, in altri casi la connessione al server è caduta ed è necessario attendere il ripristino di esso. Eseguire test di connessione e, in caso di successo, riabilitare funzionalità web?", "ATTENZIONE! Si è verificato un errore.", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) != DialogResult.Yes)
        return;
      try
      {
        if (new Ping().Send("download.alegsoftware.ga", 1000) == null)
          return;
        Console.WriteLine("SW: OK");
        this.aleGManualToolStripMenuItem.Visible = true;
        this.notizieAGOTOOLSToolStripMenuItem.Visible = true;
        this.pluginMaToolStripMenuItem.Visible = true;
        this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Visible = false;
        this.notifyIcon1.BalloonTipTitle = "AGO Tools: Connesso";
        this.notifyIcon1.BalloonTipText = "AGO Tools ha stabilito la connessione ad AGO Tools Web Services";
        this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
        this.notifyIcon1.ShowBalloonTip(3600);
      }
      catch
      {
        Console.WriteLine("SW: ERR - Disabling web features");
        this.aleGManualToolStripMenuItem.Visible = false;
        this.notizieAGOTOOLSToolStripMenuItem.Visible = false;
        this.pluginMaToolStripMenuItem.Visible = false;
        Console.WriteLine("disabled.");
        this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Visible = true;
        this.notifyIcon1.BalloonTipTitle = "AGO Tools: ATTENZIONE!";
        this.notifyIcon1.BalloonTipText = "Impossibile contattare Web Services di AGO Tools. Aprire AGO Tools per maggiori informazioni.";
        this.notifyIcon1.BalloonTipIcon = ToolTipIcon.Error;
        this.notifyIcon1.ShowBalloonTip(3600);
      }
    }

    private void label1_Click_1(object sender, EventArgs e)
    {
    }

    private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aGOToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aleGSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.riavvia1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riavvia2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.riavviaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aGOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statoServizioAGOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statoServizioMIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eseguiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funzionalitàPluginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginMaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impostaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impostazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aggiornaImpostazioniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rilanciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiudiApplicazioneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notizieAGOTOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.aleGManualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informazioniSuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mintrayTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webView22 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.menuTray.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView22)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "L\'azione richiesta è stata inviata al server tramite SSH";
            this.notifyIcon1.BalloonTipTitle = "AGO Tools";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AGO Tools è in funzione!";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuTray
            // 
            this.menuTray.Enabled = false;
            this.menuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aGOToolsToolStripMenuItem,
            this.aleGSoftwareToolStripMenuItem,
            this.toolStripSeparator1,
            this.riavvia1ToolStripMenuItem,
            this.riavvia2ToolStripMenuItem});
            this.menuTray.Name = "menuTray";
            this.menuTray.Size = new System.Drawing.Size(146, 98);
            // 
            // aGOToolsToolStripMenuItem
            // 
            this.aGOToolsToolStripMenuItem.Enabled = false;
            this.aGOToolsToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.agoton;
            this.aGOToolsToolStripMenuItem.Name = "aGOToolsToolStripMenuItem";
            this.aGOToolsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aGOToolsToolStripMenuItem.Text = "AGO Tools";
            this.aGOToolsToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // aleGSoftwareToolStripMenuItem
            // 
            this.aleGSoftwareToolStripMenuItem.Enabled = false;
            this.aleGSoftwareToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.logo_small_icon_only;
            this.aleGSoftwareToolStripMenuItem.Name = "aleGSoftwareToolStripMenuItem";
            this.aleGSoftwareToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aleGSoftwareToolStripMenuItem.Text = "AleGSoftware";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // riavvia1ToolStripMenuItem
            // 
            this.riavvia1ToolStripMenuItem.Enabled = false;
            this.riavvia1ToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot;
            this.riavvia1ToolStripMenuItem.Name = "riavvia1ToolStripMenuItem";
            this.riavvia1ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.riavvia1ToolStripMenuItem.Text = "Riavvia MIP";
            this.riavvia1ToolStripMenuItem.Click += new System.EventHandler(this.riavvia1ToolStripMenuItem_Click);
            // 
            // riavvia2ToolStripMenuItem
            // 
            this.riavvia2ToolStripMenuItem.Enabled = false;
            this.riavvia2ToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot;
            this.riavvia2ToolStripMenuItem.Name = "riavvia2ToolStripMenuItem";
            this.riavvia2ToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.riavvia2ToolStripMenuItem.Text = "Riavvia AGO";
            this.riavvia2ToolStripMenuItem.Click += new System.EventHandler(this.riavvia2ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.riavviaToolStripMenuItem,
            this.accediToolStripMenuItem,
            this.eseguiToolStripMenuItem,
            this.funzionalitàPluginToolStripMenuItem,
            this.impostaToolStripMenuItem,
            this.notizieAGOTOOLSToolStripMenuItem,
            this.toolStripMenuItem4,
            this.mintrayTSMI,
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(506, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown);
            // 
            // riavviaToolStripMenuItem
            // 
            this.riavviaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aGOToolStripMenuItem,
            this.mIPToolStripMenuItem});
            this.riavviaToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot;
            this.riavviaToolStripMenuItem.Name = "riavviaToolStripMenuItem";
            this.riavviaToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // aGOToolStripMenuItem
            // 
            this.aGOToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot;
            this.aGOToolStripMenuItem.Name = "aGOToolStripMenuItem";
            this.aGOToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.aGOToolStripMenuItem.Text = "AGO";
            this.aGOToolStripMenuItem.Click += new System.EventHandler(this.aGOToolStripMenuItem_Click);
            // 
            // mIPToolStripMenuItem
            // 
            this.mIPToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot;
            this.mIPToolStripMenuItem.Name = "mIPToolStripMenuItem";
            this.mIPToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.mIPToolStripMenuItem.Text = "MIP";
            this.mIPToolStripMenuItem.Click += new System.EventHandler(this.mIPToolStripMenuItem_Click);
            // 
            // accediToolStripMenuItem
            // 
            this.accediToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sSHToolStripMenuItem,
            this.statoServizioAGOToolStripMenuItem,
            this.statoServizioMIPToolStripMenuItem});
            this.accediToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.binoculars;
            this.accediToolStripMenuItem.Name = "accediToolStripMenuItem";
            this.accediToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // sSHToolStripMenuItem
            // 
            this.sSHToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.chevron_right;
            this.sSHToolStripMenuItem.Name = "sSHToolStripMenuItem";
            this.sSHToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.sSHToolStripMenuItem.Text = "SSH";
            this.sSHToolStripMenuItem.Click += new System.EventHandler(this.sSHToolStripMenuItem_Click);
            // 
            // statoServizioAGOToolStripMenuItem
            // 
            this.statoServizioAGOToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.binoculars;
            this.statoServizioAGOToolStripMenuItem.Name = "statoServizioAGOToolStripMenuItem";
            this.statoServizioAGOToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.statoServizioAGOToolStripMenuItem.Text = "AGO";
            this.statoServizioAGOToolStripMenuItem.Click += new System.EventHandler(this.statoServizioAGOToolStripMenuItem_Click);
            // 
            // statoServizioMIPToolStripMenuItem
            // 
            this.statoServizioMIPToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.binoculars;
            this.statoServizioMIPToolStripMenuItem.Name = "statoServizioMIPToolStripMenuItem";
            this.statoServizioMIPToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.statoServizioMIPToolStripMenuItem.Text = "MIP";
            this.statoServizioMIPToolStripMenuItem.Click += new System.EventHandler(this.statoServizioMIPToolStripMenuItem_Click);
            // 
            // eseguiToolStripMenuItem
            // 
            this.eseguiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.eseguiToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.card_checklist;
            this.eseguiToolStripMenuItem.Name = "eseguiToolStripMenuItem";
            this.eseguiToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.upload;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // funzionalitàPluginToolStripMenuItem
            // 
            this.funzionalitàPluginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginMaToolStripMenuItem});
            this.funzionalitàPluginToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.plug;
            this.funzionalitàPluginToolStripMenuItem.Name = "funzionalitàPluginToolStripMenuItem";
            this.funzionalitàPluginToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.funzionalitàPluginToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.atpToolStripMenuItem_Click);
            // 
            // pluginMaToolStripMenuItem
            // 
            this.pluginMaToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.shop1600;
            this.pluginMaToolStripMenuItem.Name = "pluginMaToolStripMenuItem";
            this.pluginMaToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pluginMaToolStripMenuItem.Text = "Plugin Marketplace";
            this.pluginMaToolStripMenuItem.Click += new System.EventHandler(this.pluginMaToolStripMenuItem_Click);
            // 
            // impostaToolStripMenuItem
            // 
            this.impostaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.impostazioniToolStripMenuItem,
            this.aggiornaImpostazioniToolStripMenuItem,
            this.chiudiToolStripMenuItem});
            this.impostaToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.gear;
            this.impostaToolStripMenuItem.Name = "impostaToolStripMenuItem";
            this.impostaToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // impostazioniToolStripMenuItem
            // 
            this.impostazioniToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.gear;
            this.impostazioniToolStripMenuItem.Name = "impostazioniToolStripMenuItem";
            this.impostazioniToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.impostazioniToolStripMenuItem.Text = "Impostazioni";
            this.impostazioniToolStripMenuItem.Click += new System.EventHandler(this.impostazioniToolStripMenuItem_Click);
            // 
            // aggiornaImpostazioniToolStripMenuItem
            // 
            this.aggiornaImpostazioniToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.upload;
            this.aggiornaImpostazioniToolStripMenuItem.Name = "aggiornaImpostazioniToolStripMenuItem";
            this.aggiornaImpostazioniToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.aggiornaImpostazioniToolStripMenuItem.Text = "Aggiorna Impostazioni";
            this.aggiornaImpostazioniToolStripMenuItem.Click += new System.EventHandler(this.aggiornaImpostazioniToolStripMenuItem_Click);
            // 
            // chiudiToolStripMenuItem
            // 
            this.chiudiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rilanciaToolStripMenuItem,
            this.chiudiApplicazioneToolStripMenuItem});
            this.chiudiToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.x_octagon;
            this.chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
            this.chiudiToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.chiudiToolStripMenuItem.Text = "Opzioni di chiusura";
            // 
            // rilanciaToolStripMenuItem
            // 
            this.rilanciaToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot;
            this.rilanciaToolStripMenuItem.Name = "rilanciaToolStripMenuItem";
            this.rilanciaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.rilanciaToolStripMenuItem.Text = "Riavvia applicazione";
            this.rilanciaToolStripMenuItem.Click += new System.EventHandler(this.rilanciaToolStripMenuItem_Click);
            // 
            // chiudiApplicazioneToolStripMenuItem
            // 
            this.chiudiApplicazioneToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.x_octagon;
            this.chiudiApplicazioneToolStripMenuItem.Name = "chiudiApplicazioneToolStripMenuItem";
            this.chiudiApplicazioneToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.chiudiApplicazioneToolStripMenuItem.Text = "Chiudi applicazione";
            this.chiudiApplicazioneToolStripMenuItem.Click += new System.EventHandler(this.chiudiApplicazioneToolStripMenuItem_Click);
            // 
            // notizieAGOTOOLSToolStripMenuItem
            // 
            this.notizieAGOTOOLSToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.newspaper;
            this.notizieAGOTOOLSToolStripMenuItem.Name = "notizieAGOTOOLSToolStripMenuItem";
            this.notizieAGOTOOLSToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.notizieAGOTOOLSToolStripMenuItem.Click += new System.EventHandler(this.notizieAGOTOOLSToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aleGManualToolStripMenuItem,
            this.informazioniSuToolStripMenuItem});
            this.toolStripMenuItem4.Image = global::AGO_TOOLS.Properties.Resources.question_circle;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(28, 20);
            // 
            // aleGManualToolStripMenuItem
            // 
            this.aleGManualToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.book;
            this.aleGManualToolStripMenuItem.Name = "aleGManualToolStripMenuItem";
            this.aleGManualToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.aleGManualToolStripMenuItem.Text = "AleGManual";
            this.aleGManualToolStripMenuItem.Click += new System.EventHandler(this.aleGManualToolStripMenuItem_Click);
            // 
            // informazioniSuToolStripMenuItem
            // 
            this.informazioniSuToolStripMenuItem.Image = global::AGO_TOOLS.Properties.Resources.question_circle;
            this.informazioniSuToolStripMenuItem.Name = "informazioniSuToolStripMenuItem";
            this.informazioniSuToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.informazioniSuToolStripMenuItem.Text = "Informazioni su...";
            this.informazioniSuToolStripMenuItem.Click += new System.EventHandler(this.informazioniSuToolStripMenuItem_Click);
            // 
            // mintrayTSMI
            // 
            this.mintrayTSMI.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mintrayTSMI.Image = global::AGO_TOOLS.Properties.Resources.dash_circle;
            this.mintrayTSMI.Name = "mintrayTSMI";
            this.mintrayTSMI.Size = new System.Drawing.Size(28, 20);
            this.mintrayTSMI.Click += new System.EventHandler(this.mintrayTSMI_Click);
            // 
            // iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem
            // 
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Name = "iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem";
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Text = "!! ERRORE !!";
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Visible = false;
            this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem.Click += new System.EventHandler(this.iMPOSSIBILECONNETTEREWebServicesToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 296);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(506, 24);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(57, 19);
            this.toolStripStatusLabel1.Text = "PRONTO";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.BackColor = System.Drawing.Color.White;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 18);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(341, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "AGO Tools";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.button4.Image = global::AGO_TOOLS.Properties.Resources.binoculars_MidRes;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(372, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 62);
            this.button4.TabIndex = 16;
            this.button4.Text = "MIP";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 20.25F);
            this.button1.Image = global::AGO_TOOLS.Properties.Resources.binoculars_MidRes;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(372, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 62);
            this.button1.TabIndex = 15;
            this.button1.Text = "AGO";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AGO_TOOLS.Properties.Resources.logo_large;
            this.pictureBox2.Location = new System.Drawing.Point(372, 296);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot_MidRes;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 126);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 62);
            this.button3.TabIndex = 3;
            this.button3.Text = "MIP";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::AGO_TOOLS.Properties.Resources.bootstrap_reboot_MidRes;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 194);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 62);
            this.button2.TabIndex = 2;
            this.button2.Text = "AGO";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::AGO_TOOLS.Properties.Resources.agoton;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(505, 261);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // webView21
            // 
            this.webView21.BackColor = System.Drawing.Color.White;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(0, 262);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(523, 30);
            this.webView21.Source = new System.Uri("https://download.alegsoftware.ga/notizie/agotoMiniNews.html", System.UriKind.Absolute);
            this.webView21.TabIndex = 18;
            this.webView21.ZoomFactor = 1D;
            // 
            // webView22
            // 
            this.webView22.CreationProperties = null;
            this.webView22.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView22.Location = new System.Drawing.Point(0, 262);
            this.webView22.Name = "webView22";
            this.webView22.Size = new System.Drawing.Size(532, 31);
            this.webView22.Source = new System.Uri("https://download.alegsoftware.ga/notizie/agotoMiniNews.html", System.UriKind.Absolute);
            this.webView22.TabIndex = 18;
            this.webView22.ZoomFactor = 1D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(506, 320);
            this.Controls.Add(this.webView22);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "AGO Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.menuTray.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView22)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
  }
}
