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
    public partial class CEdit : Form
    {
        string uN;
        string sexx="女";
        public CEdit(string userN)
        {
            InitializeComponent();
            uN = userN;
        }

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LOGIN.mdb";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox2.TextLength == 11)
                {
                    string updateCmd;
                    OleDbConnection mycon = new OleDbConnection(connStr);
                    updateCmd = "update LOGIN set Sex=@性别, Tel=@电话, Sign=@签名 Where UserNames='" + uN + "'";
                    mycon.Open();
                    OleDbCommand cmd = new OleDbCommand(updateCmd, mycon);
                    //cmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
                    cmd.Parameters.Add(new OleDbParameter("@性别", OleDbType.Char));
                    cmd.Parameters.Add(new OleDbParameter("@电话", OleDbType.Char));
                    cmd.Parameters.Add(new OleDbParameter("@签名", OleDbType.Char));
                    //cmd.Parameters["@用户名"].Value = uN;
                    cmd.Parameters["@性别"].Value = sexx;
                    cmd.Parameters["@电话"].Value = textBox2.Text;
                    cmd.Parameters["@签名"].Value = textBox3.Text;


                    cmd.ExecuteNonQuery();
                    mycon.Close();
                    MessageBox.Show("编辑成功！");
                    button1.Enabled = false;

                    textBox2.Text = "";
                    textBox3.Text = "";
                    
                }
                else
                    MessageBox.Show("手机号码填写错误！");
                
            }
            else
            {
                MessageBox.Show("请填写完整信息！");
            }
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioButton1.Checked) sexx = radioButton1.Text;
            //else radioButton2.Checked = true;
            button1.Enabled = true;*/
            sexx = radioButton1.Text;
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            /*if (radioButton2.Checked) sexx = radioButton2.Text;
            //else radioButton1.Checked = true;
            button1.Enabled = true;*/
            sexx = radioButton2.Text;
            button1.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CEdit_Load(object sender, EventArgs e)
        {
            label1.Text = uN + "欢迎您，祝天天开心！";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.Text!="")
            button1.Enabled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
                if (textBox2.Text.Length == 0)
                {
                    if ((ch < '1' || ch > '9') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
                else 
                {
                    if ((ch < '0' || ch > '9') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
            
        }

        private void CEdit_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
