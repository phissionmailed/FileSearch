namespace FileSearch {
  partial class frmMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.label1 = new System.Windows.Forms.Label();
      this.chkSearchSubfolders = new System.Windows.Forms.CheckBox();
      this.btnFindFolder = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.cmnuResults = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmnuCopy = new System.Windows.Forms.ToolStripMenuItem();
      this.cmnuCopyFullResultToClipBoard = new System.Windows.Forms.ToolStripMenuItem();
      this.cmnuOpenContainingFolder = new System.Windows.Forms.ToolStripMenuItem();
      this.cmnuCopyChecked = new System.Windows.Forms.ToolStripMenuItem();
      this.cmnuMoveChecked = new System.Windows.Forms.ToolStripMenuItem();
      this.btnFind = new System.Windows.Forms.Button();
      this.lnkPatternsHelp = new System.Windows.Forms.LinkLabel();
      this.label3 = new System.Windows.Forms.Label();
      this.btnAddPattern = new System.Windows.Forms.Button();
      this.lbFilesFound = new System.Windows.Forms.Label();
      this.lstFilePattern = new System.Windows.Forms.CheckedListBox();
      this.btnChoosePatterns = new System.Windows.Forms.Button();
      this.txSelectedPattern = new System.Windows.Forms.TextBox();
      this.pbSearchProgress = new System.Windows.Forms.ProgressBar();
      this.btnRemovePattern = new System.Windows.Forms.Button();
      this.lstResults = new System.Windows.Forms.CheckedListBox();
      this.chkCheckAllResults = new System.Windows.Forms.CheckBox();
      this.cbFolder = new System.Windows.Forms.ComboBox();
      this.btnRemoveFolder = new System.Windows.Forms.Button();
      this.cmnuResults.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(89, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Folder To Search";
      // 
      // chkSearchSubfolders
      // 
      this.chkSearchSubfolders.AutoSize = true;
      this.chkSearchSubfolders.Location = new System.Drawing.Point(107, 40);
      this.chkSearchSubfolders.Name = "chkSearchSubfolders";
      this.chkSearchSubfolders.Size = new System.Drawing.Size(127, 17);
      this.chkSearchSubfolders.TabIndex = 2;
      this.chkSearchSubfolders.Text = "Search All Subfolders";
      this.chkSearchSubfolders.UseVisualStyleBackColor = true;
      // 
      // btnFindFolder
      // 
      this.btnFindFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFindFolder.Location = new System.Drawing.Point(578, 12);
      this.btnFindFolder.Name = "btnFindFolder";
      this.btnFindFolder.Size = new System.Drawing.Size(31, 23);
      this.btnFindFolder.TabIndex = 1;
      this.btnFindFolder.Text = "...";
      this.btnFindFolder.UseVisualStyleBackColor = true;
      this.btnFindFolder.Click += new System.EventHandler(this.btnFindFolder_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 66);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(65, 13);
      this.label2.TabIndex = 4;
      this.label2.Text = "File Patterns";
      // 
      // cmnuResults
      // 
      this.cmnuResults.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuCopy,
            this.cmnuCopyFullResultToClipBoard,
            this.cmnuOpenContainingFolder,
            this.cmnuCopyChecked,
            this.cmnuMoveChecked});
      this.cmnuResults.Name = "cmnuResults";
      this.cmnuResults.Size = new System.Drawing.Size(292, 136);
      // 
      // cmnuCopy
      // 
      this.cmnuCopy.Name = "cmnuCopy";
      this.cmnuCopy.Size = new System.Drawing.Size(291, 22);
      this.cmnuCopy.Text = "Copy Single File To Another Location";
      this.cmnuCopy.Click += new System.EventHandler(this.cmnuCopy_Click);
      // 
      // cmnuCopyFullResultToClipBoard
      // 
      this.cmnuCopyFullResultToClipBoard.Name = "cmnuCopyFullResultToClipBoard";
      this.cmnuCopyFullResultToClipBoard.Size = new System.Drawing.Size(291, 22);
      this.cmnuCopyFullResultToClipBoard.Text = "Copy Full Path To Clipboard";
      this.cmnuCopyFullResultToClipBoard.Click += new System.EventHandler(this.cmnuCopyFullResultToClipBoard_Click);
      // 
      // cmnuOpenContainingFolder
      // 
      this.cmnuOpenContainingFolder.Name = "cmnuOpenContainingFolder";
      this.cmnuOpenContainingFolder.Size = new System.Drawing.Size(291, 22);
      this.cmnuOpenContainingFolder.Text = "Open Containing Folder";
      this.cmnuOpenContainingFolder.Click += new System.EventHandler(this.cmnuOpenContainingFolder_Click);
      // 
      // cmnuCopyChecked
      // 
      this.cmnuCopyChecked.Name = "cmnuCopyChecked";
      this.cmnuCopyChecked.Size = new System.Drawing.Size(291, 22);
      this.cmnuCopyChecked.Text = "Copy Checked Files To Another Location";
      this.cmnuCopyChecked.Click += new System.EventHandler(this.cmnuCopyChecked_Click);
      // 
      // cmnuMoveChecked
      // 
      this.cmnuMoveChecked.Name = "cmnuMoveChecked";
      this.cmnuMoveChecked.Size = new System.Drawing.Size(291, 22);
      this.cmnuMoveChecked.Text = "Move Checked Files To Another Location";
      this.cmnuMoveChecked.Click += new System.EventHandler(this.cmnuMoveChecked_Click);
      // 
      // btnFind
      // 
      this.btnFind.Location = new System.Drawing.Point(12, 118);
      this.btnFind.Name = "btnFind";
      this.btnFind.Size = new System.Drawing.Size(95, 23);
      this.btnFind.TabIndex = 8;
      this.btnFind.Text = "Find";
      this.btnFind.UseVisualStyleBackColor = true;
      this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
      // 
      // lnkPatternsHelp
      // 
      this.lnkPatternsHelp.AutoSize = true;
      this.lnkPatternsHelp.Location = new System.Drawing.Point(12, 102);
      this.lnkPatternsHelp.Name = "lnkPatternsHelp";
      this.lnkPatternsHelp.Size = new System.Drawing.Size(267, 13);
      this.lnkPatternsHelp.TabIndex = 6;
      this.lnkPatternsHelp.TabStop = true;
      this.lnkPatternsHelp.Text = "http://msdn.microsoft.com/en-us/library/az24scfc.aspx";
      this.lnkPatternsHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkPatternsHelp_LinkClicked);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 87);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(437, 13);
      this.label3.TabIndex = 7;
      this.label3.Text = "Use the following link to read about Regular expressions so you can add your own " +
          "patterns.";
      // 
      // btnAddPattern
      // 
      this.btnAddPattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddPattern.Location = new System.Drawing.Point(514, 61);
      this.btnAddPattern.Name = "btnAddPattern";
      this.btnAddPattern.Size = new System.Drawing.Size(95, 23);
      this.btnAddPattern.TabIndex = 6;
      this.btnAddPattern.Text = "Add Pattern";
      this.btnAddPattern.UseVisualStyleBackColor = true;
      this.btnAddPattern.Click += new System.EventHandler(this.btnAddPattern_Click);
      // 
      // lbFilesFound
      // 
      this.lbFilesFound.AutoSize = true;
      this.lbFilesFound.Location = new System.Drawing.Point(9, 335);
      this.lbFilesFound.Name = "lbFilesFound";
      this.lbFilesFound.Size = new System.Drawing.Size(312, 13);
      this.lbFilesFound.TabIndex = 8;
      this.lbFilesFound.Text = "N files were found. Right-Click on a line to see additional options.";
      // 
      // lstFilePattern
      // 
      this.lstFilePattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lstFilePattern.CheckOnClick = true;
      this.lstFilePattern.FormattingEnabled = true;
      this.lstFilePattern.Location = new System.Drawing.Point(107, 85);
      this.lstFilePattern.Name = "lstFilePattern";
      this.lstFilePattern.Size = new System.Drawing.Size(401, 154);
      this.lstFilePattern.TabIndex = 9;
      this.lstFilePattern.Visible = false;
      this.lstFilePattern.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lstFilePattern_ItemCheck);
      this.lstFilePattern.Leave += new System.EventHandler(this.lstFilePattern_Leave);
      // 
      // btnChoosePatterns
      // 
      this.btnChoosePatterns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnChoosePatterns.Location = new System.Drawing.Point(413, 61);
      this.btnChoosePatterns.Name = "btnChoosePatterns";
      this.btnChoosePatterns.Size = new System.Drawing.Size(95, 23);
      this.btnChoosePatterns.TabIndex = 5;
      this.btnChoosePatterns.Text = "Choose Patterns";
      this.btnChoosePatterns.UseVisualStyleBackColor = true;
      this.btnChoosePatterns.Click += new System.EventHandler(this.btnChoosePatterns_Click);
      // 
      // txSelectedPattern
      // 
      this.txSelectedPattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txSelectedPattern.Location = new System.Drawing.Point(107, 63);
      this.txSelectedPattern.Name = "txSelectedPattern";
      this.txSelectedPattern.Size = new System.Drawing.Size(300, 20);
      this.txSelectedPattern.TabIndex = 4;
      this.txSelectedPattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txSelectedPattern_KeyPress);
      // 
      // pbSearchProgress
      // 
      this.pbSearchProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.pbSearchProgress.Location = new System.Drawing.Point(113, 118);
      this.pbSearchProgress.Name = "pbSearchProgress";
      this.pbSearchProgress.Size = new System.Drawing.Size(496, 23);
      this.pbSearchProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.pbSearchProgress.TabIndex = 10;
      this.pbSearchProgress.Visible = false;
      // 
      // btnRemovePattern
      // 
      this.btnRemovePattern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRemovePattern.Location = new System.Drawing.Point(500, 89);
      this.btnRemovePattern.Name = "btnRemovePattern";
      this.btnRemovePattern.Size = new System.Drawing.Size(109, 23);
      this.btnRemovePattern.TabIndex = 7;
      this.btnRemovePattern.Text = "Remove Patterns";
      this.btnRemovePattern.UseVisualStyleBackColor = true;
      this.btnRemovePattern.Click += new System.EventHandler(this.btnRemovePattern_Click);
      // 
      // lstResults
      // 
      this.lstResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.lstResults.CheckOnClick = true;
      this.lstResults.FormattingEnabled = true;
      this.lstResults.IntegralHeight = false;
      this.lstResults.Location = new System.Drawing.Point(12, 147);
      this.lstResults.Name = "lstResults";
      this.lstResults.Size = new System.Drawing.Size(597, 162);
      this.lstResults.TabIndex = 9;
      this.lstResults.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstResults_MouseUp);
      // 
      // chkCheckAllResults
      // 
      this.chkCheckAllResults.AutoSize = true;
      this.chkCheckAllResults.Location = new System.Drawing.Point(12, 315);
      this.chkCheckAllResults.Name = "chkCheckAllResults";
      this.chkCheckAllResults.Size = new System.Drawing.Size(109, 17);
      this.chkCheckAllResults.TabIndex = 10;
      this.chkCheckAllResults.Text = "Check All Results";
      this.chkCheckAllResults.UseVisualStyleBackColor = true;
      this.chkCheckAllResults.CheckedChanged += new System.EventHandler(this.chkCheckAllResults_CheckedChanged);
      // 
      // cbFolder
      // 
      this.cbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.cbFolder.FormattingEnabled = true;
      this.cbFolder.Location = new System.Drawing.Point(107, 14);
      this.cbFolder.Name = "cbFolder";
      this.cbFolder.Size = new System.Drawing.Size(465, 21);
      this.cbFolder.TabIndex = 0;
      this.cbFolder.SelectionChangeCommitted += new System.EventHandler(this.cbFolder_SelectionChangeCommitted);
      // 
      // btnRemoveFolder
      // 
      this.btnRemoveFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRemoveFolder.Location = new System.Drawing.Point(514, 36);
      this.btnRemoveFolder.Name = "btnRemoveFolder";
      this.btnRemoveFolder.Size = new System.Drawing.Size(95, 23);
      this.btnRemoveFolder.TabIndex = 3;
      this.btnRemoveFolder.Text = "Remove Folder";
      this.btnRemoveFolder.UseVisualStyleBackColor = true;
      this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
      // 
      // frmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(621, 357);
      this.Controls.Add(this.btnRemoveFolder);
      this.Controls.Add(this.cbFolder);
      this.Controls.Add(this.chkCheckAllResults);
      this.Controls.Add(this.lstResults);
      this.Controls.Add(this.btnRemovePattern);
      this.Controls.Add(this.pbSearchProgress);
      this.Controls.Add(this.txSelectedPattern);
      this.Controls.Add(this.btnChoosePatterns);
      this.Controls.Add(this.lbFilesFound);
      this.Controls.Add(this.btnAddPattern);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.lnkPatternsHelp);
      this.Controls.Add(this.btnFind);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.btnFindFolder);
      this.Controls.Add(this.chkSearchSubfolders);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lstFilePattern);
      this.MinimumSize = new System.Drawing.Size(637, 395);
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "File Search";
      this.cmnuResults.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.CheckBox chkSearchSubfolders;
    private System.Windows.Forms.Button btnFindFolder;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.LinkLabel lnkPatternsHelp;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button btnAddPattern;
    private System.Windows.Forms.Label lbFilesFound;
    private System.Windows.Forms.CheckedListBox lstFilePattern;
    private System.Windows.Forms.Button btnChoosePatterns;
    private System.Windows.Forms.TextBox txSelectedPattern;
    private System.Windows.Forms.ContextMenuStrip cmnuResults;
    private System.Windows.Forms.ToolStripMenuItem cmnuCopy;
    private System.Windows.Forms.ToolStripMenuItem cmnuCopyFullResultToClipBoard;
    private System.Windows.Forms.ToolStripMenuItem cmnuOpenContainingFolder;
    private System.Windows.Forms.ProgressBar pbSearchProgress;
    private System.Windows.Forms.Button btnRemovePattern;
    private System.Windows.Forms.CheckedListBox lstResults;
    private System.Windows.Forms.ToolStripMenuItem cmnuCopyChecked;
    private System.Windows.Forms.CheckBox chkCheckAllResults;
    private System.Windows.Forms.ToolStripMenuItem cmnuMoveChecked;
    private System.Windows.Forms.ComboBox cbFolder;
    private System.Windows.Forms.Button btnRemoveFolder;
  }
}

