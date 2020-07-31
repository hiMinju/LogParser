﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace LogParser
{
    public struct Location
    {
        public Location(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public int start { get; set; }
        public int end { get; set; }
    };

    public partial class Form1 : Form
    {
        private bool firstLoad = false;
        // 모든 키워드 위치, 길이 저장
        private List<Location> locations = new List<Location>();
        private int index;

        //global brushes with ordinary/selected colors
        private SolidBrush reportsForegroundBrushSelected = new SolidBrush(Color.White);
        private SolidBrush reportsForegroundBrush = new SolidBrush(Color.Black);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 행번호 관련
            LineNumTxtBox.Font = richTxtBox.Font;

            //// 탐색기 관련
            LoadDirectory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            FileDialog.Filter = "log files (*.log)|*.log|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FileDialog.FilterIndex = 1;

            // 다른 사용자의 컴퓨터 환경에 따르도록 처리
            if(Properties.Settings.Default.PrevPath=="")
            {
                FileDialog.InitialDirectory = Application.StartupPath;
            }
            else
            {
                FileDialog.InitialDirectory = Properties.Settings.Default.PrevPath;
            }

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                richTxtBox.Clear();
                txtPath.Text = FileDialog.FileName;

                // Change the PrevPath value
                Properties.Settings.Default.PrevPath = txtPath.Text;
                Properties.Settings.Default.Save();

                //Read the contents of the file into a stream
                var fileStream = FileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                {
                    richTxtBox.Text = reader.ReadToEnd();

                    reader.Close();
                }

                //richTxtBox.Text = fileContent;
                AddLineNumbers();

                if (btnSearch.Text == "마침")
                {
                    btnSearch.Text = "검색";
                    txtSearch.Text = "";
                }
                ControlSearch();
            }
        }

        public int getWidth()
        {
            int w = 25;
            // get total lines of richTxtBox    
            int line = richTxtBox.Lines.Length;

            if (line <= 99)
            {
                w = 20 + (int)richTxtBox.Font.Size;
            }
            else if (line <= 999)
            {
                w = 30 + (int)richTxtBox.Font.Size;
            }
            else
            {
                w = 50 + (int)richTxtBox.Font.Size;
            }

            return w;
        }

        public void AddLineNumbers()
        {
            // create & set Point pt to (0,0)    
            Point pt = new Point(0, 0);
            // get First Index & First Line from richTxtBox    
            int First_Index = richTxtBox.GetCharIndexFromPosition(pt);
            int First_Line = richTxtBox.GetLineFromCharIndex(First_Index);
            // set X & Y coordinates of Point pt to ClientRectangle Width & Height respectively    
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
            // get Last Index & Last Line from richTxtBox    
            int Last_Index = richTxtBox.GetCharIndexFromPosition(pt);
            int Last_Line = richTxtBox.GetLineFromCharIndex(Last_Index);
            // set Center alignment to LineNumTxtBox    
            LineNumTxtBox.SelectionAlignment = HorizontalAlignment.Center;
            // set LineNumTxtBox text to null & width to getWidth() function value    
            LineNumTxtBox.Text = "";
            LineNumTxtBox.Width = getWidth();
            // now add each line number to LineNumTxtBox upto last line    
            for (int i = First_Line; i <= Last_Line; i++)
            {
                LineNumTxtBox.Text += i + 1 + "\n";
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void richTxtBox_VScroll(object sender, EventArgs e)
        {
            LineNumTxtBox.Text = "";
            AddLineNumbers();
            LineNumTxtBox.Invalidate();
        }

        // treeview 탐색기
        private void LoadDirectory()
        {
            try
            {
                // 로컬 정보를 가져와서 노드에 추가한다.
                string[] drivers = Directory.GetLogicalDrives();
                foreach(string drive in drivers)
                {
                    // 드라이버 명을 가져온다.
                    TreeNode root = new TreeNode(drive);
                    trvDir.Nodes.Add(root);

                    // 드라이버 명에 해당하는 디렉토리만 찾는다.
                    DirectoryInfo dir = new DirectoryInfo(drive);

                    if (dir.Exists)
                    {
                        AddDirectoryNodes(root, dir, false);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        private void AddDirectoryNodes(TreeNode root, DirectoryInfo dir, bool isLoop)
        {
            try
            {
                DirectoryInfo[] drivers = dir.GetDirectories();
                foreach(DirectoryInfo drive in drivers)
                {
                    // 디렉토리 명을 파라미터로 전달받은 상위 드라이버를 넣는다.
                    TreeNode childRoot = new TreeNode(drive.Name);                

                    root.Nodes.Add(childRoot);

                    // 처음 드라이버 검색을 제외한 디렉토리 검색일 때
                    // 하위 디렉토리 여부 검색
                    if(isLoop)
                    {
                        AddDirectoryNodes(childRoot, drive, false);
                    }
                }
            }
            catch // 액세스 거부
            {
                if(firstLoad==false) // !firstLoad true일 때 참 
                {
                   // MessageBox.Show(ex.Message);
                }
            }
        }

        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(e.Node.FullPath); // 디렉터리 정보
                e.Node.Nodes.Clear();
                AddDirectoryNodes(e.Node, dir, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 폴더를 선택하기 전 이벤트 발생
        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            string fullPath = e.Node.FullPath;

            try
            {
                lView.Items.Clear();
                // 폴더를 추가한다.
                DirectoryInfo dir = new DirectoryInfo(fullPath);
                FileInfo[] files = dir.GetFiles();

                FileAttributes attr = File.GetAttributes(fullPath); 
                foreach (FileInfo file in files)
                {
                    ListViewItem item = new ListViewItem(file.Name);
                    lView.Items.Add(item);
                    txtPath.Text = fullPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;

            SolidBrush foregroundBrush;
            if ((e.Item.Index % 2) == 0)
            {
                g.FillRectangle(new SolidBrush(Color.AliceBlue), e.Bounds);
                foregroundBrush = reportsForegroundBrush;
            }
            else
            {
                g.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Highlight)), e.Bounds);
                foregroundBrush = reportsForegroundBrushSelected;
            }
            g.DrawString(e.Item.Text, e.Item.Font, foregroundBrush, lView.GetItemRect(e.Item.Index).Location);

            e.DrawFocusRectangle();     
        }

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            ControlSearch();

            if (tabControl2.SelectedTab == tabTree)
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;
                btnDown.Visible = false;
                btnUp.Visible = false;


            }
        }

        private void LoadXmlTree()
        {
            // TreeView에 Node가 추가될 때 TreeView Component가 update되지 않도록 함
            trvLog.BeginUpdate();

            // Node 추가
            XmlParser parser = new XmlParser();
            List<List<string>> list = new List<List<string>>();
            list = parser.StringParsing(richTxtBox.Text); // 미리 text로 불러온 파일 파싱

            for(int i=1; i<parser.listString.Count; i++)
            {
                if (parser.listString[i].Length == 5)
                {
                    string[] s = parser.listString[i];
                    TreeNode node = new TreeNode(s[0]);

                    for (int j = 1; j < parser.attr.Length; j++)
                    {
                        node.Nodes.Add(parser.attr[j]);
                    }

                    for (int j=1; j<s.Length-1; j++)
                    {
                        node.Nodes[j - 1].Nodes.Add(s[j]);
                    }

                    // node.Nodes[s.Length].Add() --> xml 관련 추가
                    List<string> xml = parser.innerXml[i-1];

                    for (int j = 0; j < parser.childName.Count; j++)
                    {
                        TreeNode childNode = new TreeNode(parser.childName[j]);
                        //childNode.Nodes.Add(parser.attr[j]);

                        childNode.Nodes.Add(xml[j]);
                        node.Nodes[s.Length - 2].Nodes.Add(childNode);
                    }

                    trvLog.Nodes.Add(node);
                }
            }
            
            // TreeView에 Node 추가가 완료되었으면 TreeView Component가 update될 수 있도록 함
            trvLog.EndUpdate();

        }

        private void ControlSearch()
        {
            if(tabControl2.SelectedTab == tabText && richTxtBox.Text != "")
            {
                txtSearch.Visible = true;
                btnSearch.Visible = true;
                btnDown.Visible = true;
                btnUp.Visible = true;
            }
            else if (txtSearch.Text != "")
            {
                EndSearch();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(btnSearch.Text == "검색" && txtSearch.Text!="")
            {
                SearchKeyword();
            }
            else // text가 마침일 때
            {
                EndSearch();
            }
        }

        private void EndSearch()
        {
            btnSearch.Text = "검색";

            foreach (Location loc in locations)
            {
                richTxtBox.Select(loc.start, loc.end);
                richTxtBox.SelectionColor = Color.Black;
                richTxtBox.SelectionBackColor = Color.FromArgb(244,247,252);
            }
            locations.Clear();
            txtSearch.Text = "";
        }

        private void SearchKeyword()
        {
            btnSearch.Text = "마침";

            // 키워드 검색 이벤트 처리
            string text = richTxtBox.Text;

            if (!text.Contains(txtSearch.Text))
            {
                btnSearch.Text = "검색";
                txtSearch.Text = "";
                MessageBox.Show("찾으시려는 문자가 존재하지 않습니다!");
                return;
            }

            Regex regex = new Regex(txtSearch.Text); //Regex 사용하여 특정문자 찾기
            MatchCollection matches = regex.Matches(richTxtBox.Text);

            int iCursorPosition = richTxtBox.SelectionStart;
            Location point = new LogParser.Location();

            foreach (Match m in matches)
            {
                point.start = m.Index;
                point.end = m.Length;

                locations.Add(point);

                richTxtBox.Select(point.start, point.end);
                richTxtBox.SelectionColor = Color.Red;
                richTxtBox.SelectionBackColor = Color.Aqua;
                richTxtBox.SelectionStart = iCursorPosition;
                richTxtBox.SelectionColor = Color.Black;
            }
            MessageBox.Show(locations.Count.ToString());
        }

        // 찾은 키워드 이동하며 찾기
        private void btnUp_Click(object sender, EventArgs e)
        {
            if(index == 0)
            {
                index = locations.Count - 1;
            }
            else
            {
                --index;
            }
            moveFocus();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if(index == locations.Count - 1)
            {
                index = 0;
            }
            else
            {
                ++index;
            }
            moveFocus();
        }

        private void moveFocus()
        {
            richTxtBox.Select(locations[index].start, locations[index].end);
            richTxtBox.SelectionStart = locations[index].start;
            richTxtBox.Focus();
            richTxtBox.ScrollToCaret();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SearchKeyword();
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if(s.Length>1)
            {
                MessageBox.Show("파일 하나만 가능합니다!");
                return;
            }

            txtPath.Text = s[0];
            richTxtBox.Text = "";

            // 파일 경로 통하여 text 읽어오기
            ReadFile(txtPath.Text);
            ControlSearch();
        }

        private void lView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lView.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lView.SelectedItems;
                ListViewItem item = items[0];

                string fullPath = txtPath.Text + '\\' + item.Text;

                ReadFile(fullPath);

                ControlSearch();
            }
        }

        public void ReadFile(string fullPath)
        {
            StreamReader sr = new StreamReader(
                new FileStream(fullPath, FileMode.Open), Encoding.Default);
            richTxtBox.Text = sr.ReadToEnd();

            sr.Close();
            AddLineNumbers();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            if (richTxtBox.Text.StartsWith("#"))
            {
                MessageBox.Show("파싱할 수 있는 파일이 아닙니다!");
                return;
            }
            // treview 호출
            if (richTxtBox.Text != "") // 조건 더 추가 필요
            {
                LoadXmlTree();
                MessageBox.Show("파싱을 완료하였습니다!");
            }
        }
    }
}
