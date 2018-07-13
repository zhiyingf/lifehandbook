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

namespace lifehandbook2
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        string Na = Form1.UserName;

        private void FormMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnMemorandum_Click(object sender, EventArgs e)
        {
            FormMemo formMemo = new FormMemo();
            formMemo.Show();
            this.Hide();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            FormCalen formCalen = new FormCalen();
            formCalen.Show();
            this.Hide();
        }

        private void btnWecker_Click(object sender, EventArgs e)
        {
            FormWecker formWecker = new FormWecker();
            formWecker.Show();
            this.Hide();
        }

        private void btnLinkman_Click(object sender, EventArgs e)
        {
            FormLinker formLinker = new FormLinker();
            formLinker.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "帮助.chm";
            p.Start();
        }

        //编辑
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LOGIN.mdb";

        private void edit_Click(object sender, EventArgs e)
        {
            Form frmEnter = new ClassLibrary1.CEdit(Na);
            frmEnter.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(1) + label1.Text.Substring(0, 1);
            label2.Text = label2.Text.Substring(1) + label2.Text.Substring(0, 1);
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
            label4.Text = label4.Text.Substring(1) + label4.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            string Access = "select Sign from LOGIN where UserNames='" + Na + "'";//select是查询数据库语句
            OleDbCommand myCmd = new OleDbCommand(Access, conn);

            //myCmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            //myCmd.Parameters["@用户名"].Value = Na;
            OleDbDataReader hyw = myCmd.ExecuteReader();
            

            if (!hyw.Read())
            {
                MessageBox.Show("尚未编辑签名！");
                conn.Close();
            }
            else
            {
                Label la = new Label();//动态声明控件
                this.Controls.Add(la);                
                la.Top = 350;
                la.Left = 180;
                la.Width = 500;
                la.Height = 40;
                la.BackColor = Color.Transparent;
                la.Font = new Font("楷体", 20);
                la.ForeColor = Color.BlueViolet;                                                           
                OleDbDataAdapter myAdapter = new OleDbDataAdapter(Access, conn);
                DataSet myDataSet = new DataSet();

                myAdapter.Fill(myDataSet, "LOGIN");
  
                la.DataBindings.Add("Text", myDataSet, "LOGIN.Sign");
                conn.Close();
                button1.Text = "个性签名：";
            }
        }
    }
}
