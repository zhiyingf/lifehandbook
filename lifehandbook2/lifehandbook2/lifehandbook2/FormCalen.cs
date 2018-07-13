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
    public partial class FormCalen : Form
    {
        string userN = Form1.UserName;

        private void form_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public FormCalen()
        {
            InitializeComponent();
        }

        private void FormCalen_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Closed += new EventHandler(this.form_Closed);
            //f2.Closed += (obj, args) => { Application.Exit(); };  
            formMain.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormCalen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            //textBox1.Text=
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                monthCalendar1.ShowWeekNumbers = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                monthCalendar1.ShowWeekNumbers = false;
            }
        }

        /*******************************************************************************************/
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=calen.mdb";
        //新建
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string insertCmd;
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();
                insertCmd = "Insert Into calen(acti, beginn, endd,userN) Values(@日程, @起始日期, @结束日期,@用户名)";


                OleDbCommand cmd = new OleDbCommand(insertCmd, conn);
                cmd.Parameters.Add(new OleDbParameter("@日程", OleDbType.Char));
                cmd.Parameters.Add(new OleDbParameter("@起始日期", OleDbType.Char));
                cmd.Parameters.Add(new OleDbParameter("@结束日期", OleDbType.Char));
                cmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));

                cmd.Parameters["@日程"].Value = textBox1.Text;
                cmd.Parameters["@起始日期"].Value = dateTimePicker1.Text;
                cmd.Parameters["@结束日期"].Value = dateTimePicker2.Text;
                cmd.Parameters["@用户名"].Value = userN;


                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("新建成功！");
                button3.Enabled = false;
            }     
            else
            {
                MessageBox.Show("请填写标题！");
            }                
            
        }

        //取消
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        //查看
        private void button5_Click(object sender, EventArgs e)
        {
            Form ccalen = new ClassLibrary1.CCalen(userN);          
            ccalen.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
        }
    }
}
