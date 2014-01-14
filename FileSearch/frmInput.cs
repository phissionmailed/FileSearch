using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSearch {
  public partial class frmInput : Form {
    public frmInput() {
      InitializeComponent();
    }

    public static string ShowInput(string instructions) {
      string retVal = null;

      using (var form = new frmInput()) {
        form.lbInstructions.Text = instructions;

        if (form.ShowDialog() == DialogResult.OK)
          retVal = form.txInput.Text;
      }

      return retVal;
    }

    public string Instructions {
      get {
        return lbInstructions.Text;
      }
      set {
        lbInstructions.Text = value;
      }
    }

    public string Input {
      get {
        return txInput.Text;
      }
      set {
        txInput.Text = "";
      }
    }

    private void btnOk_Click(object sender, EventArgs e) {
      base.DialogResult = System.Windows.Forms.DialogResult.OK;
    }
  }
}
