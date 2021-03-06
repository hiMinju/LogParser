﻿using System.Windows.Forms;

namespace LogParser
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.btnParseTable = new System.Windows.Forms.Button();
            this.btnParseTree = new System.Windows.Forms.Button();
            this.richTxtBox = new System.Windows.Forms.RichTextBox();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BindingNavi = new System.Windows.Forms.BindingNavigator(this.components);
            this.NaviCount = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.NaviPos = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabTree = new System.Windows.Forms.TabPage();
            this.trvLog = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trvDir = new System.Windows.Forms.TreeView();
            this.lView = new System.Windows.Forms.ListView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnFolderDlg = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpRowNum = new System.Windows.Forms.GroupBox();
            this.rdoBtn40 = new System.Windows.Forms.RadioButton();
            this.rdoBtn10 = new System.Windows.Forms.RadioButton();
            this.rdoBtn30 = new System.Windows.Forms.RadioButton();
            this.rdoBtn20 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavi)).BeginInit();
            this.BindingNavi.SuspendLayout();
            this.tabTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpRowNum.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabText);
            this.tabControl2.Controls.Add(this.tabTable);
            this.tabControl2.Controls.Add(this.tabTree);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(894, 544);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl2_Selected);
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.btnParseTable);
            this.tabText.Controls.Add(this.btnParseTree);
            this.tabText.Controls.Add(this.richTxtBox);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(886, 518);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // btnParseTable
            // 
            this.btnParseTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParseTable.Location = new System.Drawing.Point(630, 469);
            this.btnParseTable.Name = "btnParseTable";
            this.btnParseTable.Size = new System.Drawing.Size(114, 23);
            this.btnParseTable.TabIndex = 4;
            this.btnParseTable.Text = "Table Parsing";
            this.btnParseTable.UseVisualStyleBackColor = true;
            this.btnParseTable.Click += new System.EventHandler(this.btnParseTable_Click);
            // 
            // btnParseTree
            // 
            this.btnParseTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParseTree.Location = new System.Drawing.Point(750, 469);
            this.btnParseTree.Name = "btnParseTree";
            this.btnParseTree.Size = new System.Drawing.Size(114, 23);
            this.btnParseTree.TabIndex = 3;
            this.btnParseTree.Text = "Tree ViewParsing";
            this.btnParseTree.UseVisualStyleBackColor = true;
            this.btnParseTree.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // richTxtBox
            // 
            this.richTxtBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtBox.Location = new System.Drawing.Point(69, 3);
            this.richTxtBox.Name = "richTxtBox";
            this.richTxtBox.ReadOnly = true;
            this.richTxtBox.Size = new System.Drawing.Size(814, 512);
            this.richTxtBox.TabIndex = 2;
            this.richTxtBox.Text = "";
            this.richTxtBox.WordWrap = false;
            // 
            // tabTable
            // 
            this.tabTable.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tabTable.Controls.Add(this.panel2);
            this.tabTable.Controls.Add(this.panel1);
            this.tabTable.Location = new System.Drawing.Point(4, 22);
            this.tabTable.Name = "tabTable";
            this.tabTable.Size = new System.Drawing.Size(886, 518);
            this.tabTable.TabIndex = 2;
            this.tabTable.Text = "Table";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(886, 489);
            this.panel2.TabIndex = 2;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridView.BackgroundColor = System.Drawing.SystemColors.InactiveBorder;
            this.gridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.Location = new System.Drawing.Point(0, 0);
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowHeadersWidth = 30;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(886, 489);
            this.gridView.TabIndex = 1;
            this.gridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridView_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BindingNavi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 29);
            this.panel1.TabIndex = 1;
            // 
            // BindingNavi
            // 
            this.BindingNavi.AddNewItem = null;
            this.BindingNavi.CountItem = this.NaviCount;
            this.BindingNavi.DeleteItem = null;
            this.BindingNavi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BindingNavi.GripMargin = new System.Windows.Forms.Padding(650, 2, 2, 2);
            this.BindingNavi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.NaviPos,
            this.NaviCount,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.BindingNavi.Location = new System.Drawing.Point(0, 0);
            this.BindingNavi.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BindingNavi.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BindingNavi.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BindingNavi.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BindingNavi.Name = "BindingNavi";
            this.BindingNavi.PositionItem = this.NaviPos;
            this.BindingNavi.Size = new System.Drawing.Size(886, 29);
            this.BindingNavi.TabIndex = 0;
            this.BindingNavi.Text = "bindingNavigator1";
            // 
            // NaviCount
            // 
            this.NaviCount.Name = "NaviCount";
            this.NaviCount.Size = new System.Drawing.Size(27, 26);
            this.NaviCount.Text = "/{0}";
            this.NaviCount.ToolTipText = "전체 항목 수";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMoveFirstItem.Text = "처음으로 이동";
            this.bindingNavigatorMoveFirstItem.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMovePreviousItem.Text = "이전으로 이동";
            this.bindingNavigatorMovePreviousItem.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 29);
            // 
            // NaviPos
            // 
            this.NaviPos.AccessibleName = "위치";
            this.NaviPos.AutoSize = false;
            this.NaviPos.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.NaviPos.Name = "NaviPos";
            this.NaviPos.Size = new System.Drawing.Size(50, 23);
            this.NaviPos.Text = "0";
            this.NaviPos.ToolTipText = "현재 위치";
            this.NaviPos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NaviPos_KeyDown);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMoveNextItem.Text = "다음으로 이동";
            this.bindingNavigatorMoveNextItem.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMoveLastItem.Text = "마지막으로 이동";
            this.bindingNavigatorMoveLastItem.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.trvLog);
            this.tabTree.Location = new System.Drawing.Point(4, 22);
            this.tabTree.Name = "tabTree";
            this.tabTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabTree.Size = new System.Drawing.Size(886, 518);
            this.tabTree.TabIndex = 1;
            this.tabTree.Text = "TreeView";
            this.tabTree.UseVisualStyleBackColor = true;
            // 
            // trvLog
            // 
            this.trvLog.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.trvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvLog.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.trvLog.Location = new System.Drawing.Point(3, 3);
            this.trvLog.Name = "trvLog";
            this.trvLog.Size = new System.Drawing.Size(880, 512);
            this.trvLog.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.trvDir);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lView);
            this.splitContainer2.Size = new System.Drawing.Size(385, 544);
            this.splitContainer2.SplitterDistance = 195;
            this.splitContainer2.TabIndex = 0;
            // 
            // trvDir
            // 
            this.trvDir.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.trvDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDir.Location = new System.Drawing.Point(0, 0);
            this.trvDir.Name = "trvDir";
            this.trvDir.Size = new System.Drawing.Size(195, 544);
            this.trvDir.TabIndex = 1;
            this.trvDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeExpand);
            this.trvDir.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeSelect);
            // 
            // lView
            // 
            this.lView.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lView.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lView.HideSelection = false;
            this.lView.Location = new System.Drawing.Point(0, 0);
            this.lView.Name = "lView";
            this.lView.OwnerDraw = true;
            this.lView.Size = new System.Drawing.Size(186, 544);
            this.lView.TabIndex = 0;
            this.lView.UseCompatibleStateImageBehavior = false;
            this.lView.View = System.Windows.Forms.View.Tile;
            this.lView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lView_DrawItem);
            this.lView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lView_MouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 78);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1283, 544);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 2;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(28, 15);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(30, 12);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(89, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(826, 21);
            this.txtPath.TabIndex = 1;
            // 
            // btnFolderDlg
            // 
            this.btnFolderDlg.Location = new System.Drawing.Point(921, 10);
            this.btnFolderDlg.Name = "btnFolderDlg";
            this.btnFolderDlg.Size = new System.Drawing.Size(28, 23);
            this.btnFolderDlg.TabIndex = 2;
            this.btnFolderDlg.Text = "...";
            this.btnFolderDlg.UseVisualStyleBackColor = true;
            this.btnFolderDlg.Click += new System.EventHandler(this.btnFolderDlg_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(984, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(137, 21);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Visible = false;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1127, 33);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(1220, 20);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(51, 18);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Visible = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Font = new System.Drawing.Font("굴림", 8F);
            this.btnDown.Location = new System.Drawing.Point(1220, 44);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(51, 18);
            this.btnDown.TabIndex = 6;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Visible = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(1127, 4);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 7;
            this.btnInit.Text = "초기화";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Visible = false;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grpRowNum);
            this.panel3.Controls.Add(this.btnInit);
            this.panel3.Controls.Add(this.btnDown);
            this.panel3.Controls.Add(this.btnUp);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.btnFolderDlg);
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.lblPath);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1283, 78);
            this.panel3.TabIndex = 1;
            // 
            // grpRowNum
            // 
            this.grpRowNum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpRowNum.Controls.Add(this.rdoBtn40);
            this.grpRowNum.Controls.Add(this.rdoBtn10);
            this.grpRowNum.Controls.Add(this.rdoBtn30);
            this.grpRowNum.Controls.Add(this.rdoBtn20);
            this.grpRowNum.Enabled = false;
            this.grpRowNum.Location = new System.Drawing.Point(715, 39);
            this.grpRowNum.Name = "grpRowNum";
            this.grpRowNum.Size = new System.Drawing.Size(200, 35);
            this.grpRowNum.TabIndex = 5;
            this.grpRowNum.TabStop = false;
            this.grpRowNum.Text = "행 개수";
            this.grpRowNum.Visible = false;
            // 
            // rdoBtn40
            // 
            this.rdoBtn40.AutoSize = true;
            this.rdoBtn40.Location = new System.Drawing.Point(144, 13);
            this.rdoBtn40.Name = "rdoBtn40";
            this.rdoBtn40.Size = new System.Drawing.Size(35, 16);
            this.rdoBtn40.TabIndex = 11;
            this.rdoBtn40.TabStop = true;
            this.rdoBtn40.Text = "40";
            this.rdoBtn40.UseVisualStyleBackColor = true;
            this.rdoBtn40.CheckedChanged += new System.EventHandler(this.rdoBtn10_CheckedChanged);
            // 
            // rdoBtn10
            // 
            this.rdoBtn10.AutoSize = true;
            this.rdoBtn10.Location = new System.Drawing.Point(21, 13);
            this.rdoBtn10.Name = "rdoBtn10";
            this.rdoBtn10.Size = new System.Drawing.Size(35, 16);
            this.rdoBtn10.TabIndex = 8;
            this.rdoBtn10.TabStop = true;
            this.rdoBtn10.Text = "10";
            this.rdoBtn10.UseVisualStyleBackColor = true;
            this.rdoBtn10.CheckedChanged += new System.EventHandler(this.rdoBtn10_CheckedChanged);
            // 
            // rdoBtn30
            // 
            this.rdoBtn30.AutoSize = true;
            this.rdoBtn30.Location = new System.Drawing.Point(103, 13);
            this.rdoBtn30.Name = "rdoBtn30";
            this.rdoBtn30.Size = new System.Drawing.Size(35, 16);
            this.rdoBtn30.TabIndex = 10;
            this.rdoBtn30.TabStop = true;
            this.rdoBtn30.Text = "30";
            this.rdoBtn30.UseVisualStyleBackColor = true;
            this.rdoBtn30.CheckedChanged += new System.EventHandler(this.rdoBtn10_CheckedChanged);
            // 
            // rdoBtn20
            // 
            this.rdoBtn20.AutoSize = true;
            this.rdoBtn20.Checked = true;
            this.rdoBtn20.Location = new System.Drawing.Point(62, 13);
            this.rdoBtn20.Name = "rdoBtn20";
            this.rdoBtn20.Size = new System.Drawing.Size(35, 16);
            this.rdoBtn20.TabIndex = 9;
            this.rdoBtn20.TabStop = true;
            this.rdoBtn20.Text = "20";
            this.rdoBtn20.UseVisualStyleBackColor = true;
            this.rdoBtn20.CheckedChanged += new System.EventHandler(this.rdoBtn10_CheckedChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1283, 622);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "LogParser";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BindingNavi)).EndInit();
            this.BindingNavi.ResumeLayout(false);
            this.BindingNavi.PerformLayout();
            this.tabTree.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grpRowNum.ResumeLayout(false);
            this.grpRowNum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BindingSource bindingSource1;
        private OpenFileDialog FileDialog;
        private TabControl tabControl2;
        private TabPage tabText;
        private Button btnParseTable;
        private Button btnParseTree;
        private RichTextBox richTxtBox;
        private TabPage tabTable;
        private Panel panel2;
        private DataGridView gridView;
        private Panel panel1;
        private BindingNavigator BindingNavi;
        private ToolStripLabel NaviCount;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox NaviPos;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private TabPage tabTree;
        private TreeView trvLog;
        private SplitContainer splitContainer2;
        private TreeView trvDir;
        private ListView lView;
        private SplitContainer splitContainer1;
        private Label lblPath;
        private TextBox txtPath;
        private Button btnFolderDlg;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnUp;
        private Button btnDown;
        private Button btnInit;
        private Panel panel3;
        private RadioButton rdoBtn40;
        private RadioButton rdoBtn30;
        private RadioButton rdoBtn20;
        private RadioButton rdoBtn10;
        private GroupBox grpRowNum;
    }
}

