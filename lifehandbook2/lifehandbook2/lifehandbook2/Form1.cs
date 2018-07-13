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
    public partial class Form1 : Form
    {
        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=login.mdb";
        public static string UserName;
        string PassWord;

        private bool pdyj()
        {
            //用if来判断框的内容
            if (txtName.Text == "")
                return false;
            if (txtPassword.Text == "")
                return false;
            return true;
        }



        private void form_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void butLogin_Click(object sender, EventArgs e)
        {
            if (!pdyj())
            {
                MessageBox.Show("请输入正确信息");
                return;
            }

            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();
            string Access = "select UserNames from LOGIN where UserNames=@用户名";//select是查询数据库语句
            OleDbCommand myCmd = new OleDbCommand(Access, conn);

            myCmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            myCmd.Parameters.Add(new OleDbParameter("@密码", OleDbType.Char));
            myCmd.Parameters["@用户名"].Value = txtName.Text;
            myCmd.Parameters["@密码"].Value = txtPassword.Text;
            OleDbDataReader hyw = myCmd.ExecuteReader();

            if (!hyw.Read())
            {              
                MessageBox.Show("用户名不存在，请先注册！");
                conn.Close();                
            }
            else
            {
                Access = "select UserNames,PassWords from LOGIN where UserNames=@用户名 and PassWords=@密码";//select是查询数据库语句
                myCmd = new OleDbCommand(Access, conn);
                myCmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
                myCmd.Parameters.Add(new OleDbParameter("@密码", OleDbType.Char));
                myCmd.Parameters["@用户名"].Value = txtName.Text;
                myCmd.Parameters["@密码"].Value = txtPassword.Text;

                hyw = myCmd.ExecuteReader();

                if (hyw.Read())
                {                    
                    UserName= txtName.Text;
                    PassWord= txtPassword.Text;                    
                    MessageBox.Show("登录成功！");

                    conn.Close();
                    this.Close();
                    FormMain formMain = new FormMain();
                    formMain.Show();
                }
                else
                {                    
                    conn.Close();
                    MessageBox.Show("用户名或密码错误！");
                }
                
            }



            /*if (!pdyj())
            {
                MessageBox.Show("请输入正确信息");
                return;
            }

            OleDbConnection conn = new OleDbConnection(connStr);   
            conn.Open();
            string Access = "select UserName,PassWord from LOGIN where UserName=@用户名 and PassWord=@密码";//select是查询数据库语句
            OleDbCommand myCmd = new OleDbCommand(Access, conn);

            myCmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
            myCmd.Parameters.Add(new OleDbParameter("@密码", OleDbType.Char));
            myCmd.Parameters["@用户名"].Value = txtName.Text;
            myCmd.Parameters["@密码"].Value = txtPassword.Text;

            OleDbDataReader hyw = myCmd.ExecuteReader();                                    

            if (hyw.Read())
            {
                //在构造中我们的量就作为判断
                //UserName= txtName.Text;
                //PassWord= txtPassword.Text;
                //一旦连接成功了就弹出窗口
                MessageBox.Show("登录成功！");

                this.Close();
                FormMain formMain = new FormMain();
                formMain.Show();
            }
            else
            {
                //信息错误，判断条件不成立
                MessageBox.Show("用户名或密码错误！");
            }*/

            /*if (txtName.Text == "付志英" && txtPassword.Text == "41612138")
            {
                this.Close();
                FormMain formMain = new FormMain();
                formMain.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重新输入");
            }*/


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*DialogResult result = MessageBox.Show("确定关闭登录?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                //确定编码
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                e.Cancel = false;
            }

            //Application.Exit();
         
            if (MessageBox.Show("是否确认关闭", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                
                e.Cancel = true;
                //Application.Exit();
            }
            else
            {
                //e.Cancel = false;
                //Application.Exit();
            }*/

            //Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("用户名或密码不能为空！");
            }
            else 
            {
                string insertCmd;
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();

                string Access = "select UserNames from LOGIN where UserNames=@用户名";//select是查询数据库语句
                OleDbCommand myCmd = new OleDbCommand(Access, conn);
                myCmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));                
                myCmd.Parameters["@用户名"].Value = txtName.Text;                
                OleDbDataReader hyw = myCmd.ExecuteReader();
                if (hyw.Read())
                {
                    MessageBox.Show("用户名已存在，请重输！");
                    conn.Close();                    
                }
                else
                {
                    insertCmd = "insert into LOGIN(UserNames,PassWords)values(@用户名,@密码)";
                    myCmd = new OleDbCommand(insertCmd, conn);

                    myCmd.Parameters.Add(new OleDbParameter("@用户名", OleDbType.Char));
                    myCmd.Parameters.Add(new OleDbParameter("@密码", OleDbType.Char));
                    myCmd.Parameters["@用户名"].Value = txtName.Text;
                    myCmd.Parameters["@密码"].Value = txtPassword.Text;

                    myCmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("注册成功，请登陆进入！");
                }
                    
                txtName.Text = "";
                txtPassword.Text = "";
                
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
