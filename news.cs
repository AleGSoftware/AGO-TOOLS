// Decompiled with JetBrains decompiler
// Type: AGO_TOOLS.news
// Assembly: AGO-TOOLS, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17959627-35CD-47A5-B4C2-C98F4A112650
// Assembly location: C:\AGO-Tools\AGO-TOOLS.exe

using Microsoft.Web.WebView2.WinForms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AGO_TOOLS
{
  public class news : Form
  {
    private IContainer components;
    private BackgroundWorker backgroundWorker1;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;

    public news() => this.InitializeComponent();

    private void webBrowser1_DocumentCompleted(
      object sender,
      WebBrowserDocumentCompletedEventArgs e)
    {
    }

    private void webView21_Click(object sender, EventArgs e)
    {
    }

    private void news_Load(object sender, EventArgs e)
    {
    }

    private void webView21_Click_1(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(news));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(-1, -2);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(686, 663);
            this.webView21.Source = new System.Uri("https://download.alegsoftware.ga/notizie/agotoNews.html", System.UriKind.Absolute);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            // 
            // news
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.webView21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "news";
            this.Text = "Centro Notizie di AGO Tools";
            this.Load += new System.EventHandler(this.news_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

    }
  }
}
