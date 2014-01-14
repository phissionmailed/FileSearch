using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSearch {
  public partial class frmSearchLog : Form {
    public frmSearchLog() {
      InitializeComponent();
    }

    public void RefreshLog(string searchLog) {
      txSearchLog.Text = searchLog;
    }
  }
}
