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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnFolderDlg = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.trvDir = new System.Windows.Forms.TreeView();
            this.lView = new System.Windows.Forms.ListView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.btnUp = new System.Windows.Forms.Button();
            this.richTxtBox = new System.Windows.Forms.RichTextBox();
            this.LineNumTxtBox = new System.Windows.Forms.RichTextBox();
            this.tabTree = new System.Windows.Forms.TabPage();
            this.trvLog = new System.Windows.Forms.TreeView();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnDown = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDown);
            this.panel3.Controls.Add(this.btnUp);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.txtSearch);
            this.panel3.Controls.Add(this.btnFolderDlg);
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Controls.Add(this.txtPath);
            this.panel3.Controls.Add(this.lblPath);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1283, 62);
            this.panel3.TabIndex = 1;
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
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(984, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(137, 21);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.Visible = false;
            // 
            // btnFolderDlg
            // 
            this.btnFolderDlg.Location = new System.Drawing.Point(921, 20);
            this.btnFolderDlg.Name = "btnFolderDlg";
            this.btnFolderDlg.Size = new System.Drawing.Size(28, 23);
            this.btnFolderDlg.TabIndex = 2;
            this.btnFolderDlg.Text = "...";
            this.btnFolderDlg.UseVisualStyleBackColor = true;
            this.btnFolderDlg.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(316, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(662, 530);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(654, 504);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(654, 504);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(89, 22);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(826, 21);
            this.txtPath.TabIndex = 1;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(28, 25);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(30, 12);
            this.lblPath.TabIndex = 0;
            this.lblPath.Text = "Path";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 62);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1283, 530);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 2;
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
            this.splitContainer2.Size = new System.Drawing.Size(385, 530);
            this.splitContainer2.SplitterDistance = 195;
            this.splitContainer2.TabIndex = 0;
            // 
            // trvDir
            // 
            this.trvDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDir.Location = new System.Drawing.Point(0, 0);
            this.trvDir.Name = "trvDir";
            this.trvDir.Size = new System.Drawing.Size(195, 530);
            this.trvDir.TabIndex = 1;
            this.trvDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeExpand);
            this.trvDir.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeSelect);
            // 
            // lView
            // 
            this.lView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lView.HideSelection = false;
            this.lView.Location = new System.Drawing.Point(0, 0);
            this.lView.Name = "lView";
            this.lView.OwnerDraw = true;
            this.lView.Size = new System.Drawing.Size(186, 530);
            this.lView.TabIndex = 0;
            this.lView.UseCompatibleStateImageBehavior = false;
            this.lView.View = System.Windows.Forms.View.Tile;
            this.lView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lView_DrawItem);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabText);
            this.tabControl2.Controls.Add(this.tabTree);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(894, 530);
            this.tabControl2.TabIndex = 0;
            this.tabControl2.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl2_Selected);
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.richTxtBox);
            this.tabText.Controls.Add(this.LineNumTxtBox);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(886, 504);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text";
            this.tabText.UseVisualStyleBackColor = true;
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
            // 
            // richTxtBox
            // 
            this.richTxtBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.richTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTxtBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTxtBox.Location = new System.Drawing.Point(69, 3);
            this.richTxtBox.Name = "richTxtBox";
            this.richTxtBox.ReadOnly = true;
            this.richTxtBox.Size = new System.Drawing.Size(814, 498);
            this.richTxtBox.TabIndex = 2;
            this.richTxtBox.Text = "";
            this.richTxtBox.VScroll += new System.EventHandler(this.richTxtBox_VScroll);
            this.richTxtBox.TextChanged += new System.EventHandler(this.richTxtBox_TextChanged);
            // 
            // LineNumTxtBox
            // 
            this.LineNumTxtBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.LineNumTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumTxtBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.LineNumTxtBox.ForeColor = System.Drawing.Color.Blue;
            this.LineNumTxtBox.Location = new System.Drawing.Point(3, 3);
            this.LineNumTxtBox.Name = "LineNumTxtBox";
            this.LineNumTxtBox.ReadOnly = true;
            this.LineNumTxtBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumTxtBox.Size = new System.Drawing.Size(66, 498);
            this.LineNumTxtBox.TabIndex = 1;
            this.LineNumTxtBox.Text = "";
            // 
            // tabTree
            // 
            this.tabTree.Controls.Add(this.trvLog);
            this.tabTree.Location = new System.Drawing.Point(4, 22);
            this.tabTree.Name = "tabTree";
            this.tabTree.Padding = new System.Windows.Forms.Padding(3);
            this.tabTree.Size = new System.Drawing.Size(886, 504);
            this.tabTree.TabIndex = 1;
            this.tabTree.Text = "TreeView";
            this.tabTree.UseVisualStyleBackColor = true;
            // 
            // trvLog
            // 
            this.trvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvLog.Location = new System.Drawing.Point(3, 3);
            this.trvLog.Name = "trvLog";
            this.trvLog.Size = new System.Drawing.Size(880, 498);
            this.trvLog.TabIndex = 0;
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "openFileDialog1";
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1283, 592);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabTree.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TabPage tabTree;
        private System.Windows.Forms.Button btnFolderDlg;
        private System.Windows.Forms.TreeView trvLog;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.RichTextBox LineNumTxtBox;
        private System.Windows.Forms.RichTextBox richTxtBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView trvDir;
        private System.Windows.Forms.ListView lView;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnUp;
        private Button btnDown;
    }
}
