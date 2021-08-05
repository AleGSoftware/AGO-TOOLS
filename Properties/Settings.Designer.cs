// Decompiled with JetBrains decompiler
// Type: AGO_TOOLS.Properties.Settings
// Assembly: AGO-TOOLS, Version=2.1.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 17959627-35CD-47A5-B4C2-C98F4A112650
// Assembly location: C:\AGO-Tools\AGO-TOOLS.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AGO_TOOLS.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string server
    {
      get => (string) this[nameof (server)];
      set => this[nameof (server)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string user
    {
      get => (string) this[nameof (user)];
      set => this[nameof (user)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string password
    {
      get => (string) this[nameof (password)];
      set => this[nameof (password)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string desc_a
    {
      get => (string) this[nameof (desc_a)];
      set => this[nameof (desc_a)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string desc_b
    {
      get => (string) this[nameof (desc_b)];
      set => this[nameof (desc_b)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string path_bak
    {
      get => (string) this[nameof (path_bak)];
      set => this[nameof (path_bak)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool WsSwitchesDisabled
    {
      get => (bool) this[nameof (WsSwitchesDisabled)];
      set => this[nameof (WsSwitchesDisabled)] = (object) value;
    }
  }
}
