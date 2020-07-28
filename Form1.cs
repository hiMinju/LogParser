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

namespace LogParser
{
    public partial class Form1 : Form
    {
        private bool firstLoad = false;

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
            //richTxtBox.Select();
            //AddLineNumbers();

            //// 탐색기 관련
            LoadDirectory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            FileDialog.Filter = "log files (*.log)|*.log|txt files (*.txt)|*.txt|All files (*.*)|*.*";
            FileDialog.FilterIndex = 1;
            FileDialog.InitialDirectory = "C:\\Neozensoft\\Framework\\COM_LOG";

            if(FileDialog.ShowDialog() == DialogResult.OK)
            {
                richTxtBox.Clear();
                txtPath.Text = FileDialog.FileName;

                //Read the contents of the file into a stream
                var fileStream = FileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
                {
                    richTxtBox.Text = reader.ReadToEnd();
                }

                //richTxtBox.Text = fileContent;
                AddLineNumbers();
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
                DirectoryInfo[] folders = dir.GetDirectories();

                FileAttributes attr = File.GetAttributes(fullPath); 
                foreach (DirectoryInfo folder in folders)
                {
                    if((folder.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        ListViewItem item = new ListViewItem(folder.Name);
                        item.SubItems.Add(""); // 크기, 폴더이므로 없음
                        item.SubItems.Add(folder.Attributes.ToString());
                        item.SubItems.Add(folder.LastWriteTime.ToString());

                        lView.Items.Add(item);

                        StreamReader sr = new StreamReader(
                            new FileStream(fullPath, FileMode.Open), Encoding.Default);
                        richTxtBox.Text = sr.ReadToEnd();
                        AddLineNumbers();
                    }
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
        }

        private void richTxtBox_TextChanged(object sender, EventArgs e)
        {
            ControlSearch();
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
            else
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;
                btnDown.Visible = false;
                btnUp.Visible = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(btnSearch.Text == "검색")
            {
                btnSearch.Text = "마침";
            }
            else
            {
                btnSearch.Text = "검색";
            }

            // 키워드 검색 이벤트 처리

        }
    }
}
