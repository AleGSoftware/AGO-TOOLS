// Decompiled with JetBrains decompiler
// Type: AGO_TOOLS.Program
// Assembly: AGO-TOOLS, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17959627-35CD-47A5-B4C2-C98F4A112650
// Assembly location: C:\AGO-Tools\AGO-TOOLS.exe

using System;
using System.Windows.Forms;

namespace AGO_TOOLS
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
      new Form1().Hide();
    }
  }
}
