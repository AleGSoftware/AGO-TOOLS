// Decompiled with JetBrains decompiler
// Type: AGO_TOOLS.alegmanual
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
  public class alegmanual : Form
  {
    private IContainer components;
    private Microsoft.Web.WebView2.WinForms.WebView2 webView21;

    public alegmanual() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(alegmanual));
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
            this.webView21.Location = new System.Drawing.Point(1, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(683, 661);
            this.webView21.Source = new System.Uri("https://download.alegsoftware.ga/alegmanual/agotools/alegmanual-2.1-htmls/", System.UriKind.Absolute);
            this.webView21.TabIndex = 0;
            this.webView21.ZoomFactor = 1D;
            // 
            // alegmanual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.webView21);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "alegmanual";
            this.Text = "AleGManual: AGO Tools 2.1";
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

    }
  }
}
