using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace FileSearch {
  public partial class frmMain : Form {
    private List<PredefinedPattern> _predefinedPatterns;
    private XElement _settings;
    private BackgroundWorker _searchThread;
    private List<string> _results;
    private System.Text.StringBuilder _searchLog;
    private List<SearchFolderHistory> _searchFolderHistory;
    private SearchFolderHistory _lastSelectedFolder;

    public frmMain() {
      InitializeComponent();

#if DEBUG
      cbFolder.Text = @"C:\Users\yo\Documents\FileSearch\FileSearch\bin\Debug";
#endif

      lstFilePattern.BringToFront();

      //Initialize private variables.
      _results = new List<string>();
      _searchLog = new System.Text.StringBuilder();
      _predefinedPatterns = new List<PredefinedPattern>();
      _searchFolderHistory = new List<SearchFolderHistory>();

      //Load the settings file.
      _settings = XElement.Load("settings.txt");

      //Parse each pattern and place it in the list box.
      foreach (var predefinedPattern in _settings.Element("predefinedPatterns").Elements("predefinedPattern")) {
        if (predefinedPattern.Attribute("Id") == null)
          predefinedPattern.Add(new XAttribute("Id", Guid.NewGuid().ToString()));

        var newPattern = new PredefinedPattern(predefinedPattern);

        _predefinedPatterns.Add(newPattern);
        lstFilePattern.Items.Add(newPattern);
      }

      if (_settings.Element("searchFolderHistory") == null) {
        //Search folder history node is missing from the settings file.
        //Add the node now. No need to save the settings file now.
        _settings.Add(new XElement("searchFolderHistory"));

      } else {
        //Parse each folder and place it in the ComboBox.
        foreach (var searchFolder in _settings.Element("searchFolderHistory").Elements("searchFolder")) {
          var newFolder = new SearchFolderHistory(searchFolder);

          _searchFolderHistory.Add(newFolder);
          cbFolder.Items.Add(newFolder);
        }
      }


      //Present program's version.
      this.Text += " v" + typeof(frmMain).Assembly.GetName().Version.ToString();

#if DEBUG
      this.Text += " BETA";
#endif
    }

    private void btnFindFolder_Click(object sender, EventArgs e) {
      //Present the user with a dialog to select a folder to search.
      using (var findFolder = new FolderBrowserDialog()) {
        findFolder.Description = "Select the root folder to begin searching from";

        if (findFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
          cbFolder.Text = findFolder.SelectedPath;
        }
      }
    }

    private void SetSearchMode(bool searching) {
      //Helper method to change the look of the screen to match whether a search is being performed.
      if (searching) {
        base.Cursor = Cursors.WaitCursor;

        lbFilesFound.Text = "Searching...";

        btnFindFolder.Enabled = false;
        btnChoosePatterns.Enabled = false;
        btnAddPattern.Enabled = false;
        btnRemovePattern.Enabled = false;
        lstResults.Enabled = false;
        cbFolder.Enabled = false;
        txSelectedPattern.Enabled = false;
        chkSearchSubfolders.Enabled = false;
        pbSearchProgress.Visible = true;

      } else {
        btnFindFolder.Enabled = true;
        btnChoosePatterns.Enabled = true;
        btnAddPattern.Enabled = true;
        btnRemovePattern.Enabled = true;
        lstResults.Enabled = true;
        cbFolder.Enabled = true;
        txSelectedPattern.Enabled = true;
        chkSearchSubfolders.Enabled = true;
        pbSearchProgress.Visible = false;

        base.Cursor = Cursors.Default;

      }
    }

    private void btnFind_Click(object sender, EventArgs e) {
      if (_searchThread == null) {
        bool isValid = true;

        try {
          SetSearchMode(true);

          if (!System.IO.Directory.Exists(cbFolder.Text)) {
            isValid = false;
            MessageBox.Show("Folder '" + cbFolder.Text + "' does not exist.");
          }

          if (txSelectedPattern.Text.Length == 0) {
            isValid = false;
            MessageBox.Show("Enter or select a pattern to search.");
          }

          if (isValid) {
            var pattern = "(";
            var folder = cbFolder.Text;

            _searchLog.Clear();
            lstResults.Items.Clear();
            _results.Clear();

            //Check whether to concatenate selected patterns or use a pattern entered directly in the pattern TextBox.
            if (lstFilePattern.CheckedItems.Count == 0)
              pattern = txSelectedPattern.Text;
            else {
              foreach (PredefinedPattern item in lstFilePattern.CheckedItems) {
                pattern += item.Pattern + "|";
              }

              pattern = pattern.Substring(0, pattern.Length - 1) + ")";
            }

            //Check if the search folder is already in the history.
            var folderSearch = (from p in _searchFolderHistory
                                where p.Folder.ToLower() == folder.ToLower()
                                select p).ToArray();

            if (folderSearch.Length == 0) {
              //Search folder is new to the history.
              //Save the new folder in the settings file.
              var newFolder = new SearchFolderHistory(cbFolder.Text);
              var newFolderXml = new XElement("searchFolder");

              newFolderXml.Add(new XAttribute("Id", newFolder.Id));
              newFolderXml.Add(new XAttribute("Folder", newFolder.Folder));

              _settings.Element("searchFolderHistory").Add(newFolderXml);
              cbFolder.Items.Add(newFolder);
              _searchFolderHistory.Add(newFolder);

              _settings.Save("settings.txt");
            }


            //Prepare a background worker to perform the search in the background to prevent the screen
            //from locking up during search.
            _searchThread = new BackgroundWorker();
            _searchThread.WorkerSupportsCancellation = true;
            _searchThread.WorkerReportsProgress = true;

            _searchThread.DoWork += new DoWorkEventHandler(
              delegate(object backgroundSender, DoWorkEventArgs backgroundE) {
                //Execute the search.
                FindFiles(folder, pattern, chkSearchSubfolders.Checked, backgroundE);
              });

            _searchThread.ProgressChanged += new ProgressChangedEventHandler(
              delegate(object backgroundSender, ProgressChangedEventArgs backgroundE) {
                //Update the Label with folder being processed.
                lbFilesFound.Text = (string)backgroundE.UserState;
              });

            _searchThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
              delegate(object backgroundSender, RunWorkerCompletedEventArgs backgroundE) {
                //Show final search status to the user.
                if (backgroundE.Cancelled) {
                  lbFilesFound.Text = "Search cancelled";
                  _searchLog.AppendLine("Search cancelled");

                } else if (_results.Count == 0) {
                  lbFilesFound.Text = "No files were found.";
                  _searchLog.AppendLine("Search complete. No files were found.");

                } else {
                  lstResults.Items.AddRange(_results.ToArray());
                  lbFilesFound.Text = lstResults.Items.Count + " file(s) were found. Right-click on a line to see additional options.";
                  _searchLog.AppendLine("Search complete. " + lstResults.Items.Count + " file(s) were found.");
                }

                btnFind.Text = "Find";
                SetSearchMode(false);
                _searchThread = null;

                //Show the search log.
                var showSearchLog = new frmSearchLog();
                showSearchLog.RefreshLog(_searchLog.ToString());
                showSearchLog.ShowDialog();
              });

            //Execute the search in the background.
            _searchThread.RunWorkerAsync();

            btnFind.Text = "Cancel";

            base.Cursor = Cursors.Default;
          } else {
            SetSearchMode(false);
            lbFilesFound.Text = "Search cancelled";
          }
        } catch (Exception ex) {
          SetSearchMode(false);

          btnFind.Text = "Find";

          _searchThread = null;

          MessageBox.Show("An error occurred processing patterns.\nError message: " + ex.Message);
        }
      } else {
        //The user clicked the Find button while a search is performed.
        try {
          //Cancel the current search.
          _searchThread.CancelAsync();
        } catch (Exception ex) {
          MessageBox.Show("An error occurred cancelling the search.\nError message: " + ex.Message);
          SetSearchMode(false);
        }
      }
    }

    private void FindFiles(string folder, string pattern, bool searchSubfolders, DoWorkEventArgs backgroundArgs) {
      bool lineIsMissing = true;

      try {
        //Save the processed folder in the log and fire a progress update.
        _searchLog.Append("Searching in " + folder + "...");
        _searchThread.ReportProgress(0, "Searching in " + folder + "...");

        //Find files in the folder matching the pattern(s).
        var matches = System.IO.Directory.EnumerateFiles(folder).Where(path => Regex.Match(path, pattern).Success).ToArray();

        if (matches.Length == 1)
          _searchLog.AppendLine("  " + matches.Length + " file was found.");
        else
          _searchLog.AppendLine("  " + matches.Length + " files were found.");

        lineIsMissing = false;

        //For each match, add it to the results collection.
        foreach (var file in matches) {
          _results.Add(file);

          if (_searchThread.CancellationPending) {
            //Search has been cancelled. Mark the search as cancelled and exit the loop.
            backgroundArgs.Cancel = true;
            break;
          }
        }

        //Check if subfolders must be searched.
        if (searchSubfolders) {
          if (_searchThread.CancellationPending)
            //Search has been cancelled. Mark the search as cancelled and do not search subfolders.
            backgroundArgs.Cancel = true;
          else {
            //Get all subfolders.
            var folders = System.IO.Directory.GetDirectories(folder);

            //Perform search for each subfolder.
            foreach (var subfolder in folders) {
              FindFiles(subfolder, pattern, searchSubfolders, backgroundArgs);

              if (_searchThread.CancellationPending) {
                //Search has been cancelled. Mark the search as cancelled and exit the loop.
                backgroundArgs.Cancel = true;
                break;
              }
            }
          }
        }
      } catch (Exception ex) {
        if (lineIsMissing)
          _searchLog.AppendLine();

        _searchLog.AppendLine("An error occurred looking for matches. Check the pattern.\nError message: " + ex.Message);
      }
    }

    private void btnAddPattern_Click(object sender, EventArgs e) {
      //Ask the user for a name for the new pattern.
      var patternName = frmInput.ShowInput("Enter a name for new pattern:");

      if (patternName != null && patternName.Length > 0) {
        //With a name entered, save the pattern in the settings.
        var newPattern = new PredefinedPattern(patternName, txSelectedPattern.Text);
        var newPatternXml = new XElement("predefinedPattern");

        newPatternXml.Add(new XAttribute("Id", newPattern.Id));
        newPatternXml.Add(new XAttribute("Caption", newPattern.Caption));
        newPatternXml.Add(new XAttribute("Pattern", newPattern.Pattern));

        _settings.Element("predefinedPatterns").Add(newPatternXml);

        _settings.Save("settings.txt");

        _predefinedPatterns.Add(newPattern);
        lstFilePattern.Items.Add(newPattern, true);
      }
    }

    private void btnChoosePatterns_Click(object sender, EventArgs e) {
      lstFilePattern.Visible = true;
      lstFilePattern.Focus();
    }

    private void lstFilePattern_Leave(object sender, EventArgs e) {
      lstFilePattern.Visible = false;
    }

    private void txSelectedPattern_KeyPress(object sender, KeyPressEventArgs e) {
      //If the user changes the pattern TextBox directly, clear all selected patterns.
      foreach (int i in lstFilePattern.CheckedIndices) {
        lstFilePattern.SetItemChecked(i, false);
      }
    }

    private void lstFilePattern_ItemCheck(object sender, ItemCheckEventArgs e) {
      //Every time a pattern is checked, update the pattern TextBox to show all checked patterns.
      txSelectedPattern.Text = "";
      lstFilePattern.SelectedItems.Clear();

      //Concatenate all checked patterns, except the one that just changed checked state.
      foreach (PredefinedPattern item in lstFilePattern.CheckedItems) {
        if (item != lstFilePattern.Items[e.Index])
          txSelectedPattern.Text += item.Caption + " | ";
      }

      if (e.NewValue == CheckState.Checked)
        //Add the recently checked pattern.
        txSelectedPattern.Text += ((PredefinedPattern)lstFilePattern.Items[e.Index]).Caption;
      else if (txSelectedPattern.Text.Length > 0)
        //The pattern that changed checked state was unchecked.
        //Remove the final unnecessary " | " characters.
        txSelectedPattern.Text = txSelectedPattern.Text.Substring(0, txSelectedPattern.Text.Length - 3);
    }

    private void cmnuCopy_Click(object sender, EventArgs e) {
      if (lstResults.SelectedItem != null) {
        try {
          //Ask the user the folder where to save the current file.
          using (var saveFile = new SaveFileDialog()) {
            saveFile.Title = "Select the folder and file name where to copy the file";
            saveFile.FileName = (string)lstResults.SelectedItem;
            saveFile.InitialDirectory = System.IO.Path.GetDirectoryName((string)lstResults.SelectedItem);

            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              System.IO.File.Copy((string)lstResults.SelectedItem, saveFile.FileName, true);
          }
        } catch (Exception ex) {
          MessageBox.Show("An error occcurred copying the file.\nError message: " + ex.Message);
        }
      }
    }

    private void cmnuCopyFullResultToClipBoard_Click(object sender, EventArgs e) {
      if (lstResults.SelectedItem != null)
        Clipboard.SetData(DataFormats.Text, lstResults.SelectedItem);
    }

    private void cmnuOpenContainingFolder_Click(object sender, EventArgs e) {
      if (lstResults.SelectedItem != null)
        System.Diagnostics.Process.Start("explorer.exe", System.IO.Path.GetDirectoryName((string)lstResults.SelectedItem));
    }

    private void btnRemovePattern_Click(object sender, EventArgs e) {
      if (lstFilePattern.CheckedItems.Count == 0)
        MessageBox.Show("You must check at least one pattern to remove.");
      else if (MessageBox.Show("Do you want to remove the selectec pattern(s)?", null, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
        PredefinedPattern pattern;

        //For each checked pattern, remove it from the settings and from the screen.
        //Thus, keep removing checked items until there are no more.
        while (lstFilePattern.CheckedItems.Count > 0) {
          pattern = (PredefinedPattern)lstFilePattern.CheckedItems[0];

          //Find the pattern in the settings and remove it.
          var settingSearch = (from p in _settings.Element("predefinedPatterns").Elements()
                               where p.Attribute("Id").Value == pattern.Id
                               select p);

          //Remove the pattern using a loop to ensure complete removal,
          //taking into account possible duplicates.
          foreach (var setting in settingSearch) {
            setting.Remove();
          }

          _predefinedPatterns.Remove(pattern);
          lstFilePattern.Items.Remove(pattern);
        }

        //Save the settings file to sync the removals.
        _settings.Save("settings.txt");
        txSelectedPattern.Text = "";
      }
    } //End btnRemovePattern_Click

    private void cmnuCopyChecked_Click(object sender, EventArgs e) {
      CopyFiles(false);
    }

    private void lstResults_MouseUp(object sender, MouseEventArgs e) {
      if (e.Button == System.Windows.Forms.MouseButtons.Right) {
        var item = lstResults.IndexFromPoint(e.Location);

        if (item != ListBox.NoMatches) {
          lstResults.SelectedIndex = item;

          cmnuCopyChecked.Enabled = (lstResults.CheckedItems.Count > 0);
          cmnuMoveChecked.Enabled = cmnuCopyChecked.Enabled;

          cmnuResults.Show(System.Windows.Forms.Cursor.Position);
        }
      }
    } //End of lstResults_MouseUp

    private void chkCheckAllResults_CheckedChanged(object sender, EventArgs e) {
      if (chkCheckAllResults.Checked) {
        for (var i = 0; i < lstResults.Items.Count; i++) {
          lstResults.SetItemChecked(i, true);
        }
      } else {
        for (var i = 0; i < lstResults.Items.Count; i++) {
          lstResults.SetItemChecked(i, false);
        }
      }
    }

    private void cmnuMoveChecked_Click(object sender, EventArgs e) {
      CopyFiles(true);
    }

    private void CopyFiles(bool move) {
      if (lstResults.CheckedItems.Count > 0) {
        string destination;
        bool makeCopy, cancelCopy = false;

        try {
          using (var findFolder = new FolderBrowserDialog()) {
            if (move)
              findFolder.Description = "Select the folder where to move the file(s)";
            else
              findFolder.Description = "Select the folder where to copy the file(s)";

            if (findFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
              var overwrite = (MessageBox.Show("Do you wish to overwrite automatically all conflicts?\n(Answering No will raise a confirmation message for each conflict.)", "Automatic Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes);

              base.Cursor = Cursors.WaitCursor;
              pbSearchProgress.Visible = true;
              Application.DoEvents();

              foreach (var item in lstResults.CheckedItems) {
                destination = System.IO.Path.Combine(findFolder.SelectedPath, System.IO.Path.GetFileName((string)item));

                if (!overwrite && System.IO.File.Exists(destination)) {
                  switch (MessageBox.Show("File '" + destination + "' already exists. Do you wish to overwrite?\n(Answering Cancel will cancel the whole process.)", "File Exists", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)) {
                    case System.Windows.Forms.DialogResult.Yes:
                      makeCopy = true;
                      break;
                    case System.Windows.Forms.DialogResult.No:
                      makeCopy = false;
                      break;
                    default:
                      cancelCopy = true;
                      makeCopy = false;
                      break;
                  }
                } else
                  makeCopy = true;

                if (makeCopy) {
                  System.IO.File.Copy((string)item, destination, true);

                  if (move)
                    System.IO.File.Delete((string)item);

                }  else if (cancelCopy)
                  break;
              }
            }
          }
        } catch (Exception ex) {
          MessageBox.Show("An error occcurred copying the file(s).\nError message: " + ex.Message);
        } finally {
          pbSearchProgress.Visible = false;
          base.Cursor = Cursors.Default;
        }
      }
    }

    private void lnkPatternsHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      //Navigate to the URL.
      System.Diagnostics.Process.Start(lnkPatternsHelp.Text);
    }

    private void cbFolder_SelectionChangeCommitted(object sender, EventArgs e) {
      _lastSelectedFolder = (SearchFolderHistory)cbFolder.SelectedItem;
    }

    private void btnRemoveFolder_Click(object sender, EventArgs e) {
      if (_lastSelectedFolder != null) {
        //Remove the last selected folder from the settings and from the ComboBox.
        cbFolder.Items.Remove(_lastSelectedFolder);
        _searchFolderHistory.Remove(_lastSelectedFolder);

        //Find the folder in the settings and remove it.
        var settingSearch = (from p in _settings.Element("searchFolderHistory").Elements()
                             where p.Attribute("Id").Value == _lastSelectedFolder.Id
                             select p);

        //Remove the folder using a loop to ensure complete removal,
        //taking into account possible duplicates.
        foreach (var setting in settingSearch) {
          setting.Remove();
        }

        _settings.Save("settings.txt");
        _lastSelectedFolder = null;
      }
    }  //End of btnRemoveFolder_Click
  }
}
