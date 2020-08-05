using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogParser
{
    public partial class Form2 : Form
    {
        private DataGridViewRow row;
        public Form2(DataGridViewRow row)
        {
            InitializeComponent();
            this.row = row;

            DataTable table = new DataTable();

            table.Columns.Add("Value");

            table.Rows.Add(row.Cells[0].Value);
            table.Rows.Add(row.Cells[1].Value);
            table.Rows.Add(row.Cells[2].Value);
            table.Rows.Add(row.Cells[3].Value);

            GridView.DataSource = table;

            // 나중에 추가 ==> 정상적으로 작동 안 함 이유??
            GridView.Rows[0].HeaderCell.Value = "Calling Date/Time";
            GridView.Rows[1].HeaderCell.Value = "Client IP";
            GridView.Rows[2].HeaderCell.Value = "Calling WebMethod";
            GridView.Rows[3].HeaderCell.Value = "Type";

            XmlParser xmlParser = new XmlParser();

            xmlParser.parsing(row.Cells[4].Value.ToString());

            // 안의 내용 개수만큼 가져와서 row 추가
            for(int i=0; i<xmlParser.tableNum[0]; i++)
            {
                List<string> name = xmlParser.innerName[i];
                List<string> xml = xmlParser.innerXml[i];

                for (int j = 0; j < name.Count; j++) {
                    table.Rows.Add(xml[j]);
                    GridView.Rows[4 + i * name.Count + j].HeaderCell.Value = name[j];
                }
            }
        }
    }
}
