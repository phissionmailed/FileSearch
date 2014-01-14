using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace FileSearch {
  class PredefinedPattern {
    public PredefinedPattern(string caption, string pattern) {
      Caption = caption;
      Pattern = pattern;
      Id = Guid.NewGuid().ToString();
    }

    public PredefinedPattern(XElement setting)
      : this(setting.Attribute("Caption").Value, setting.Attribute("Pattern").Value) {
      if (setting.Attribute("Id") != null)
        Id = setting.Attribute("Id").Value;
    }

    public string Id {
      get;
      set;
    }

    public string Caption {
      get;
      set;
    }

    public string Pattern {
      get;
      set;
    }

    public override string ToString() {
      return Caption + " (" + Pattern + ")";
    }
  }
}
