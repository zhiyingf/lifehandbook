using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ClassLibrary1
{
    public partial class CWecker : Form
    {
        public CWecker()
        {
            InitializeComponent();
        }

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=wecker.mdb";

        private void CWecker_Load(object sender, EventArgs e)
        {
            string selectCmd = "Select id_no as 计次,timei as 姓名 From wecker Order By id_no ASC";
            OleDbConnection mycon = new OleDbConnection(connStr);
            OleDbCommand comment = new OleDbCommand(selectCmd, mycon);
            OleDbDataAdapter myAdapter = new OleDbDataAdapter(selectCmd, mycon);
            DataSet myDataSet = new DataSet();
            mycon.Open();
            myAdapter.Fill(myDataSet, "wecker");
            dataGridView1.DataSource = myDataSet.Tables["wecker"].DefaultView;
            mycon.Close();
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].Width = 230;//设置每一列的宽度
            }
        }
    }
}
