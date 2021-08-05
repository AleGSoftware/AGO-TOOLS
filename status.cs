// Decompiled with JetBrains decompiler
// Type: AGO_TOOLS.status
// Assembly: AGO-TOOLS, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17959627-35CD-47A5-B4C2-C98F4A112650
// Assembly location: C:\AGO-Tools\AGO-TOOLS.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AGO_TOOLS
{
  public class status : Form
  {
    private IContainer components;
    private Label label2;
    private ProgressBar progressBar1;

    public status() => this.InitializeComponent();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (status));
      this.label2 = new Label();
      this.progressBar1 = new ProgressBar();
      this.SuspendLayout();
      this.label2.AutoSize = true;
      this.label2.Location = new Point(21, 22);
      this.label2.Name = "label2";
      this.label2.Size = new Size(38, 13);
      this.label2.TabIndex = 16;
      this.label2.Text = "Pronto";
      this.progressBar1.Location = new Point(287, 12);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(329, 23);
      this.progressBar1.TabIndex = 15;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(634, 51);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.progressBar1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      //this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.Name = "status";
      this.Text = "Stato";
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
