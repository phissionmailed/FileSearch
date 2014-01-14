using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace FileSearch {
  static class Program {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      //If the settings file is not available, create it and load it with default settings.
      if (!System.IO.File.Exists("settings.txt")) {
        var settings = new XElement("settings");
        var patterns = new XElement("predefinedPatterns");
        XElement pattern;

        settings.Add(patterns);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", "All files"));
        pattern.Add(new XAttribute("Pattern", @"\S+"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", "All .txt files"));
        pattern.Add(new XAttribute("Pattern", @"\S.txt$"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", "All .dat files"));
        pattern.Add(new XAttribute("Pattern", @"\S.dat$"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", "All .xml files"));
        pattern.Add(new XAttribute("Pattern", @"\S.xml$"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", "All files with a digit somewhere"));
        pattern.Add(new XAttribute("Pattern", @"\d+"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", @"All files with pattern DD-MM-YYYY"));
        pattern.Add(new XAttribute("Pattern", @"\d{2}-\d{2}-\d{4}"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", @"All XPOLL files"));
        pattern.Add(new XAttribute("Pattern", @"(?i)xpoll\d+"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", @"All MSALES files"));
        pattern.Add(new XAttribute("Pattern", @"(?i)msales\d+_\d+"));
        patterns.Add(pattern);

        pattern = new XElement("predefinedPattern");
        pattern.Add(new XAttribute("Caption", @"All DailyReport files"));
        pattern.Add(new XAttribute("Pattern", @"(?i)dailyreport_\d+_\d+"));
        patterns.Add(pattern);

        settings.Save("settings.txt");
      }

      //Show main screen.
      Application.Run(new frmMain());
    }
  }
}
