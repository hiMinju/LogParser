using System;
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

            // 탐색기 관련
            LoadDirectory();
        }

        private void btnFolderDlg_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            FileDialog.Filter = "log files (*.log)|*.log|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FileDialog.FilterIndex = 1;

            // 다른 사용자의 컴퓨터 환경에 따르도록 처리
            if (Properties.Settings.Default.PrevPath == "")
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
                LineNumTxtBox.Text = "";
                txtPath.Text = FileDialog.FileName;

                // Change the PrevPath value
                Properties.Settings.Default.PrevPath = FileDialog.FileName;
                Properties.Settings.Default.Save();

                //Read the contents of the file into a stream
                var fileStream = FileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                {
                    richTxtBox.Text = reader.ReadToEnd();
                    reader.Close();
                }

                AddLineNumbers();

                if (btnSearch.Text == "마침")
                {
                    btnSearch.Text = "검색";
                    txtSearch.Text = "";
                }
                ControlSearch();

                tabControl2.SelectedTab = tabText;
            }
        }

        public void AddLineNumbers()
        {
            int len = richTxtBox.Lines.Length;
            string text = "";

            for (int i=0; i<len; i++)
            {
                text += (i + 1).ToString();
                text += "\r\n";
            }
            LineNumTxtBox.Text = text;
        }

        // treeview 탐색기
        private void LoadDirectory()
        {
            try
            {
                // 로컬 정보를 가져와서 노드에 추가한다.
                string driver = "C:\\Neozensoft";

                TreeNode root = new TreeNode(driver);
                trvDir.Nodes.Add(root);

                DirectoryInfo dir = new DirectoryInfo(driver);

                if (dir.Exists)
                {
                    AddDirectoryNodes(root, dir, false);
                }
            }
            catch
            {
                // 로컬 정보를 가져와서 노드에 추가한다.
                string[] drivers = Directory.GetLogicalDrives();
                foreach (string drive in drivers)
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
        }

        private void AddDirectoryNodes(TreeNode root, DirectoryInfo dir, bool isLoop)
        {
            try
            {
                DirectoryInfo[] drivers = dir.GetDirectories();
                foreach (DirectoryInfo drive in drivers)
                {
                    // 디렉토리 명을 파라미터로 전달받은 상위 드라이버를 넣는다.
                    TreeNode childRoot = new TreeNode(drive.Name);

                    root.Nodes.Add(childRoot);

                    // 처음 드라이버 검색을 제외한 디렉토리 검색일 때
                    // 하위 디렉토리 여부 검색
                    if (isLoop)
                    {
                        AddDirectoryNodes(childRoot, drive, false);
                    }
                }
            }
            catch // 액세스 거부
            {
                if (firstLoad == false) // !firstLoad true일 때 참 
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

        string treePath = null;
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
                    if(file.Extension == ".log" || file.Extension == ".txt" || file.Extension == ".xml")
                    {
                        ListViewItem item = new ListViewItem(file.Name);
                        lView.Items.Add(item);
                        treePath = fullPath;
                        txtPath.Text = fullPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void lView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lView.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = lView.SelectedItems;
                ListViewItem item = items[0];

                string fullPath = treePath + '\\' + item.Text;

                ReadFile(fullPath);

                ControlSearch();
                tabControl2.SelectedTab = tabText;
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
            else if (tabControl2.SelectedTab == tabTable)
            {
                btnDown.Visible = false;
                btnUp.Visible = false;
            }
        }

        private void LoadXmlTree()
        {
            trvLog.Nodes.Clear();
            // TreeView에 Node가 추가될 때 TreeView Component가 update되지 않도록 함
            trvLog.BeginUpdate();

            // Node 추가
            XmlParser parser = new XmlParser();
            parser.xmlParsing(richTxtBox.Text); // 미리 text로 불러온 파일 파싱

            int index = 0;
            for (int i = 1; i < parser.listString.Count; i++)
            {
                if (parser.listString[i].Length == 5)
                {
                    string[] s = parser.listString[i];
                    TreeNode node = new TreeNode(s[0]);

                    for (int k = 1; k < parser.attr.Length - 1; k++)
                    {
                        node.Nodes.Add(parser.attr[k] + ": " + s[k]);
                    }
                    node.Nodes.Add(parser.attr[parser.attr.Length - 1]);

                    int j;
                    for (j = index; j < index + parser.tableNum[i - 1]; j++)
                    {
                        List<string> name = parser.innerName[j];
                        List<string> xml = parser.innerXml[j];
                        TreeNode childNode = new TreeNode();

                        for (int k = 0; k < name.Count; k++)
                        {
                            childNode = new TreeNode(name[k] + ": " + xml[k]);
                            node.Nodes[3].Nodes.Add(childNode);
                            //node.Nodes[s.Length - 1].Nodes.Add(childNode);
                        }
                    }
                    index = j;

                    trvLog.Nodes.Add(node);
                }
            }
            // TreeView에 Node 추가가 완료되었으면 TreeView Component가 update될 수 있도록 함
            trvLog.EndUpdate();
        }

        private void ControlSearch()
        {
            if (richTxtBox.Text != "")
            {
                if(tabControl2.SelectedTab == tabText)
                {
                    txtSearch.Visible = true;
                    btnSearch.Visible = true;
                    btnDown.Visible = true;
                    btnUp.Visible = true;
                }
                else if(tabControl2.SelectedTab == tabTable)
                {
                    txtSearch.Visible = true;
                    btnSearch.Visible = true;
                }
            }
            else if (txtSearch.Text != "")
            {
                EndSearch();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "검색" && txtSearch.Text != "")
            {
                if (tabControl2.SelectedTab == tabText)
                {
                    SearchKeyword();
                }
                else if (tabControl2.SelectedTab == tabTable)
                {
                    // table 안에서 키워드 검색
                    SearchRow();
                }
            }
            else // text가 마침일 때
            {
                if (tabControl2.SelectedTab == tabText)
                {
                    EndSearch();
                }
                else if (tabControl2.SelectedTab == tabTable)
                {
                    // table 안에서 키워드 검색 마침
                    EndSearchRow();
                }
            }
        }

        private void EndSearchRow()
        {
            btnSearch.Text = "검색";
            txtSearch.Text = "";
            gridView.DataSource = table;
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

        private void SearchRow()
        {
            List<int> rowIndex = new List<int>();
            Regex regex = new Regex(txtSearch.Text); //Regex 사용하여 특정문자 찾기
            MatchCollection matches = regex.Matches(richTxtBox.Text);
            DataTable newTable = new DataTable();

            foreach (string s in header)
            {
                newTable.Columns.Add(s, typeof(string));
            }

            foreach (DataTable t in tables)
            {
                foreach(DataRow r in t.Rows)
                {
                    if(r[4] != null && r[4].ToString().Contains(txtSearch.Text))
                    {
                        newTable.Rows.Add(r[0], r[1], r[2], r[3], r[4]);
                    }
                }
            }

            if(newTable.Rows.Count == 0)
            {
                txtSearch.Text = "";
                MessageBox.Show("찾으시려는 문자가 존재하지 않습니다!");
                return;
            }
            else
            {
                gridView.DataSource = newTable;
                btnInit.Visible = true;
                BindingNavi.Enabled = false;
            }
        }

        private void SearchKeyword()
        {
            // 키워드 검색 이벤트 처리
            string text = richTxtBox.Text;

            if (!text.Contains(txtSearch.Text))
            {
                btnSearch.Text = "검색";
                txtSearch.Text = "";
                MessageBox.Show("찾으시려는 문자가 존재하지 않습니다!");
                return;
            }
            btnSearch.Text = "마침";

            Regex regex = new Regex(txtSearch.Text); //Regex 사용하여 특정문자 찾기
            MatchCollection matches = regex.Matches(richTxtBox.Text);

            int iCursorPosition = richTxtBox.SelectionStart;
            Location point = new Location();

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
            MessageBox.Show(locations.Count.ToString()+ "개를 찾았습니다!");
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
                if (tabControl2.SelectedTab == tabText)
                {
                    SearchKeyword();
                }
                else if (tabControl2.SelectedTab == tabTable)
                {
                    // table 안에서 키워드 검색
                    SearchRow();
                }
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
            tabControl2.SelectedTab = tabText;
        }

        public void ReadFile(string fullPath)
        {
            StreamReader sr = new StreamReader(
                new FileStream(fullPath, FileMode.Open), Encoding.Default);
            LineNumTxtBox.Text = "";
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
                tabControl2.SelectedTab = tabTree;

                MessageBox.Show("파싱을 완료하였습니다!");
            }
        }

        private DataTable table = null;
        private string[] header;
        private List<DataTable> tables = null;
        BindingSource customersBindingSource = new BindingSource();
        // text -> table
        private void btnParseTable_Click(object sender, EventArgs e)
        {
            if (richTxtBox.Text == "")
                return;
            
            XmlParser parser = new XmlParser();
            parser.StringParsing(richTxtBox.Text); // 미리 text로 불러온 파일 속성 파싱
            table = new DataTable();
            tables = new List<DataTable>();

            header = parser.attr;
            foreach(string s in header)
            {
                table.Columns.Add(s, typeof(string));
            }

            this.BindingNavi.BindingSource = this.customersBindingSource;

            for (int i = 0; i <= parser.listString.Count / 21; i++)
            {
                for (int j=1; j<22; j++)
                {
                    if(parser.listString.Count > i*21+j)
                        table.Rows.Add(parser.listString[i * 21 + j]);
                }
                tables.Add(table);
                table = new DataTable();
                header = parser.attr;
                foreach (string s in header)
                {
                    table.Columns.Add(s, typeof(string));
                }
            }
            this.customersBindingSource.DataSource = tables;
            NaviCount.Text = tables.Count.ToString();
            NaviPos.Text = "1";
            gridView.DataSource = tables[0];

            tabControl2.SelectedTab = tabTable;
            MessageBox.Show("테이블로 파싱을 완료하였습니다!");
        }

        // dataGridView에서 셀을 마우스로 더블 클릭할 때 event 발생
        private void gridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = gridView.Rows[e.RowIndex];
            Form2 form2 = new Form2(row)
            {
                Owner = this
            };
            form2.Show();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            gridView.DataSource = tables[0];
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            gridView.DataSource = tables[Int32.Parse(NaviPos.Text)-1];
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {  
            gridView.DataSource = tables[Int32.Parse(NaviPos.Text)-1];
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            gridView.DataSource = tables[tables.Count-1];
        }
        // 검색 항목 초기화
        private void btnInit_Click(object sender, EventArgs e)
        {
            // 저장해둔 tables 실행

            btnInit.Visible = false;
            BindingNavi.Enabled = true;

            gridView.DataSource = tables[Int32.Parse(NaviPos.Text) - 1];
            txtSearch.Text = "";
        }

        private void NaviPos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Int32.Parse(NaviPos.Text) > 0 && Int32.Parse(NaviPos.Text) < tables.Count)
            {
                gridView.DataSource = tables[Int32.Parse(NaviPos.Text) - 1];
            }
        }
        // line number 드래그 금지
        private void LineNumTxtBox_Enter(object sender, EventArgs e)
        {
            tabControl2.Focus();
        }
    }
}
