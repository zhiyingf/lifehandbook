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
    public partial class CCalen : Form
    {
        string userNN;
        public CCalen(string username)
        {
            userNN = username;
            InitializeComponent();
        }
        
        
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=calen.mdb";
        private void CCalen_Load(object sender, EventArgs e)
        {
           
            string selectCmd = "Select acti as 日程,beginn as 起始日期,endd as 结束日期 From calen where userN='"+userNN+"'";
            OleDbConnection mycon = new OleDbConnection(connStr);

            OleDbCommand comment = new OleDbCommand(selectCmd, mycon);
            
            //comment.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            //comment.Parameters["@用户名"].Value = userNN;


            OleDbDataAdapter myAdapter = new OleDbDataAdapter(selectCmd, mycon);
            DataSet myDataSet2 = new DataSet();
            mycon.Open();
            myAdapter.Fill(myDataSet2, "calen");
            dataGridView1.DataSource = myDataSet2.Tables["calen"].DefaultView;
            mycon.Close();
            //this.dataGridView1.Width = this.dataGridView1.Columns[0].HeaderCell.Size.Width * 3;//根据column[0]的headercell的width计算整个datagridview的宽度
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].Width = 188;//设置每一列的宽度
            }


        }
    }
}
