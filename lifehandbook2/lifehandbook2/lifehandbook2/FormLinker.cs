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
    public partial class FormLinker : Form
    {
        string Na = Form1.UserName;

        public FormLinker()
        {
            InitializeComponent();
        }

        private void FormLinker_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)//返回
        {
            FormMain formMain = new FormMain();
            //formMain.Closed += new EventHandler(this.form_Closed);
            //f2.Closed += (obj, args) => { Application.Exit(); };  
            formMain.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)//退出
        {
            Application.Exit();
        }

        private void FormLinker_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            showPerson();
        }
        /***************************************************************************************/
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PERSONDB.mdb";

        public void showPerson()
        {
            string selectCmd = "Select linkers as 姓名,relations as 关系,birthdays as 生日,times as 认识时间,things as 共同记忆 From PERSON";
            OleDbConnection mycon = new OleDbConnection(connStr);
            OleDbCommand comment = new OleDbCommand(selectCmd, mycon);
            OleDbDataAdapter myAdapter = new OleDbDataAdapter(selectCmd, mycon);
            DataSet myDataSet = new DataSet();
            mycon.Open();
            myAdapter.Fill(myDataSet, "PERSON");
            dataGridView1.DataSource = myDataSet.Tables["PERSON"].DefaultView;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].Width = 110;//设置每一列的宽度
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
 
            if (txtName.Text == "" || txtRelation.Text == "" || txtTime.Text == "" || txtBirthday.Text == "")
            {
                MessageBox.Show("所有项都必须填写！ ");
                return;
            }

            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            string Access = "select linkers from PERSON where userNames='" + Na + "' and linkers=@姓名";//select是查询数据库语句
            OleDbCommand myCmd = new OleDbCommand(Access, conn);

            myCmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));            
            myCmd.Parameters["@姓名"].Value = txtName.Text;            
            OleDbDataReader hyw = myCmd.ExecuteReader();
            if(hyw.Read())
            {
                MessageBox.Show("该联系人已存在！");
                return;
            }

            string insertCmd;
            conn = new OleDbConnection(connStr);
            conn.Open();
            insertCmd = "Insert Into PERSON(linkers, relations, birthdays, times,things,userNames) Values(@姓名, @关系, @生日, @认识时间,@共同记忆,@用户名)";
            

            OleDbCommand cmd = new OleDbCommand(insertCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@关系", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@生日", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@认识时间", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@共同记忆", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            cmd.Parameters["@姓名"].Value = txtName.Text;
            cmd.Parameters["@关系"].Value = txtRelation.Text;
            cmd.Parameters["@生日"].Value = txtTime.Text;
            cmd.Parameters["@认识时间"].Value = txtBirthday.Text;
            cmd.Parameters["@共同记忆"].Value = textBox1.Text;
            cmd.Parameters["@用户名"].Value = Na;

            cmd.ExecuteNonQuery();
            conn.Close();
            showPerson();


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateCmd;
            OleDbConnection mycon = new OleDbConnection(connStr);
            updateCmd = "update PERSON set relations=@关系, birthdays=@生日, times=@认识时间, things=@共同记忆 Where linkers='" + txtName.Text + "' and userNames='" + Na + "'";
            mycon.Open(); //"update LOGIN set Sex=@性别, Tel=@电话, Sign=@签名 Where UserNames='" + uN + "'"
            OleDbCommand cmd = new OleDbCommand(updateCmd, mycon);
            //cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@关系", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@生日", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@认识时间", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@共同记忆", OleDbType.Char));
            //cmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            //cmd.Parameters["@姓名"].Value = txtName.Text;
            cmd.Parameters["@关系"].Value = txtRelation.Text;
            cmd.Parameters["@生日"].Value = txtTime.Text;
            cmd.Parameters["@认识时间"].Value = txtBirthday.Text;
            cmd.Parameters["@共同记忆"].Value = textBox1.Text;
            //cmd.Parameters["@用户名"].Value = Na;

            cmd.ExecuteNonQuery();
            mycon.Close();
            showPerson();
            txtName.Text = "";
            txtRelation.Text = "";
            txtTime.Text = "";
            txtBirthday.Text = "";
            textBox1.Text = "";      
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            OleDbConnection mycon = new OleDbConnection(connStr);
            mycon.Open();
            string delCmd = "Delete From PERSON Where userNames='" + Na + "'and linkers=@姓名";
            OleDbCommand cmd = new OleDbCommand(delCmd, mycon);
            cmd.Parameters.Add(new OleDbParameter("@姓名", OleDbType.Char));
            cmd.Parameters["@姓名"].Value = txtName.Text;

            cmd.ExecuteNonQuery();
            mycon.Close();
            showPerson();
            MessageBox.Show("删除成功！");
            txtName.Text = "";
            txtRelation.Text = "";
            txtTime.Text = "";
            txtBirthday.Text = "";
            textBox1.Text = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

        }
    }
}
