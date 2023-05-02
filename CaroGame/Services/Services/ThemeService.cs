using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;

namespace CaroGame.Services.Services
{
  public enum Theme
  {
    LIGHT, DARK
  }

  public enum Schema
  {
    BLUE, RED, BROWN
  }

  public class ThemeService
  {
    private MaterialSkinManager materialSkinManager;

    public ThemeService(params MaterialForm[] forms)
    {
      materialSkinManager = MaterialSkinManager.Instance;
      foreach (MaterialForm form in forms)
        materialSkinManager.AddFormToManage(form);
      SetTheme(Theme.LIGHT);
      SetSchema(Schema.RED);
    }

    public ThemeService(IEnumerable<MaterialForm> forms)
    {
      materialSkinManager = MaterialSkinManager.Instance;
      foreach (MaterialForm form in forms)
        materialSkinManager.AddFormToManage(form);
    }

    public void SetTheme(Theme theme)
    {
      if (theme == Theme.LIGHT) materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
      else materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
    }

    public void SetSchema(Schema schema)
    {
      switch (schema)
      {
        case Schema.BLUE:
          materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue500, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
          break;
        case Schema.RED:
          materialSkinManager.ColorScheme = new ColorScheme(Primary.Red500, Primary.Red700, Primary.Red700, Accent.LightBlue400, TextShade.WHITE);
          break;
        case Schema.BROWN:
          materialSkinManager.ColorScheme = new ColorScheme(Primary.Brown400, Primary.Brown500, Primary.Brown500, Accent.LightBlue200, TextShade.WHITE);
          break;
        default:
          throw new Exception();
      }
    }
  }
}
