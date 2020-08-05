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

            table.Columns.Add("attribute");
            table.Columns.Add("value");

            table.Rows.Add("Calling Date/Time", row.Cells[0].Value);
            table.Rows.Add("Client IP", row.Cells[1].Value);
            table.Rows.Add("Calling WebMethod", row.Cells[2].Value);
            table.Rows.Add("Type",row.Cells[3].Value);

            GridView.DataSource = table;

            XmlParser xmlParser = new XmlParser();

            xmlParser.parsing(row.Cells[4].Value.ToString());

            // 안의 내용 개수만큼 가져와서 row 추가
            for(int i=0; i<xmlParser.tableNum[0]; i++)
            {
                List<string> name = xmlParser.innerName[i];
                List<string> xml = xmlParser.innerXml[i];

                for (int j = 0; j < name.Count; j++) {
                    table.Rows.Add(name[j], xml[j]);
                }
            }
        }
    }
}
