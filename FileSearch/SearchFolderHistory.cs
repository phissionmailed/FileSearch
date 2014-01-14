using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace FileSearch {
  class SearchFolderHistory {
    public SearchFolderHistory()
      : base() {

      Id = Guid.NewGuid().ToString();
    }

    public SearchFolderHistory(string folder)
      : this() {

      Folder = folder;
    }

    public SearchFolderHistory(XElement setting)
      : this() {

      Id = setting.Attribute("Id").Value;
      Folder = setting.Attribute("Folder").Value;
    }

    public string Id {
      get;
      set;
    }

    public string Folder {
      get;
      set;
    }

    public override string ToString() {
      return Folder;
    }
  }
}
