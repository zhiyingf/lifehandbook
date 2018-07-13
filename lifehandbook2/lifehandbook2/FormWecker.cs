using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Data.OleDb;

namespace lifehandbook2
{
    public partial class FormWecker : Form
    {
        string Na = Form1.UserName;
        //bool timeWecker = false;
        int hour;
        int minute;

        int sumTime3;
        int sumTime4=0;

        int mm, ss, ms;

        int id=0;

        bool tag3;




        private void form_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public FormWecker()
        {
            InitializeComponent();
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

        private void FormWecker_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
            OleDbConnection mycon = new OleDbConnection(connStr);
            mycon.Open();
            string delCmd = "Delete From wecker";
            OleDbCommand cmd = new OleDbCommand(delCmd, mycon);

            cmd.ExecuteNonQuery();
            mycon.Close();
        }

        private bool flag = true;
        public class name
        {
            public static int x = 150;
            public static int y = 150;
        }

        private void FormWecker_Load(object sender, EventArgs e)
        {
            tag3 = false;
            nowTime.Text = DateTime.Now.ToString();
            lblMsg.Location = new Point(name.x, name.y);
            lblMsg.BackColor = Color.Aqua;
            lblMsg.Font = new System.Drawing.Font("楷体_GB2312", 15, FontStyle.Bold);

            timer1.Enabled = true;
            timer2.Enabled = true;


            /**************************************************************************************************/


        }

        /*******************************************************************************************************/

        private void timer1_Tick(object sender, EventArgs e)
        {
            nowTime.Text = DateTime.Now.ToString();            
            if (flag)// 左移
            {
                name.x -= 1;
                lblMsg.Location = new Point(name.x, name.y);                
                if (lblMsg.Left <= 0)
                    flag = false;
            }
            else
            {
                name.x += 1;
                lblMsg.Location = new Point(name.x, name.y);               
                if (lblMsg.Left + lblMsg.Width >= this.Width)
                    flag = true;
            }   //左移                
        }

        SoundPlayer sp = new SoundPlayer();

        private void timer2_Tick(object sender, EventArgs e)
        {            
            if (DateTime.Now.Hour == hour &&DateTime.Now.Minute == minute/*&&timeWecker*/)
            {
                timer2.Enabled = false;
                nowTime.Text = DateTime.Now.ToString();
                //播放音乐
                SoundPlayer sp = new SoundPlayer();
                //sp.SoundLocation = @"爱情花园.wav";
                switch (label5.Text)
                {
                    case "爱情花园.wav":
                        {
                            sp.SoundLocation = @"liveGarden.wav";
                            break;
                        }
                    case "tommora.wav":
                        {
                            sp.SoundLocation = @"tommora.wav";
                            break;
                        }
                    case "陌上花早.wav":
                        {
                            sp.SoundLocation = @"flower.wav";
                            break;
                        }
                    case "喜欢你.wav":
                        {
                            sp.SoundLocation = @"liveYou.wav";
                            break;
                        }                   
                }
                sp.Play();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if(textBox1.Text=="1"||textBox1.Text=="2") textBox1.MaxLength = 2;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (textBox1.Text.Length <= 2)
            {
                if (textBox1.Text.Length == 0)
                {
                    if ((ch < '0' || ch > '3') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
                else if (textBox1.Text.Length == 1)
                {
                    if (textBox1.Text == "2" && (ch < '0' || ch > '5') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                    else
                        if ((ch < '0' || ch > '9') && ch != '\b')
                        e.Handled = true;
                }
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (textBox2.Text.Length <= 2)
            {
                if (textBox2.Text.Length == 0)
                {
                    if ((ch < '0' || ch > '6') && ch != '\b')
                    {
                        e.Handled = true;
                    }                    
                }
                else if(textBox2.Text.Length==1)
                {
                    if ((ch < '0' || ch > '9') && ch != '\b')
                        {
                            e.Handled = true;
                        } 
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""&&textBox2.Text=="")
            {
                MessageBox.Show("请填写全时间！");
                //timeWecker = false;
            }
            else
            {
                //timeWecker = true;
                hour = Convert.ToInt32(textBox1.Text);
                minute = Convert.ToInt32(textBox2.Text);
                button4.Enabled = true;
                button3.Enabled = false;
            }
        }        

        private void button4_Click(object sender, EventArgs e)
        {
            sp.Stop();
            //timer2.Enabled = true;
            //timeWecker = false;
            button3.Enabled = true;
            button4.Enabled = false;
        }

        /********************************计时器****************************************************/

        private void button5_Click(object sender, EventArgs e)
        {
            timer3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            textBox3.Text = "00";
            textBox4.Text = "00";
            textBox5.Text = "00";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("请填写完整时间！");
                timer3.Enabled = false;
            }
            else
            {
                int h = Convert.ToInt32(textBox3.Text);
                int m = Convert.ToInt32(textBox4.Text);
                int s = Convert.ToInt32(textBox5.Text);
                sumTime3 = h * 3600 + m * 60 + s;
                if (m == 0 && h > 0) textBox3.Text = Convert.ToString(h - 1);
                if (s == 0 && m > 0) textBox4.Text = Convert.ToString(m - 1);
                timer3.Enabled =!timer3.Enabled;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;                

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
                        
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {            
            if (timer3.Enabled && Convert.ToInt32(textBox3.Text) > 0 && Convert.ToInt32(textBox4.Text) == 0)
                textBox3.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) - 1);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (timer3.Enabled && Convert.ToInt32(textBox4.Text) > 0 && Convert.ToInt32(textBox5.Text) == 0)
                textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) - 1);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (textBox3.Text.Length <= 2)
            {
                if (textBox3.Text.Length == 0)
                {
                    if ((ch < '0' || ch > '9') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
                else if (textBox3.Text.Length == 1)
                {
                    if ((ch < '0' || ch > '9') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (textBox4.Text.Length <= 2)
            {
                if (textBox4.Text.Length == 0)
                {
                    if ((ch < '0' || ch > '6') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
                else if (textBox4.Text.Length == 1)
                {
                    if ((ch < '0' || ch > '9') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (textBox5.Text.Length <= 2)
            {
                if (textBox5.Text.Length == 0)
                {
                    if ((ch < '0' || ch > '6') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
                else if (textBox5.Text.Length == 1)
                {
                    if ((ch < '0' || ch > '9') && ch != '\b')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if(sumTime3>0)
            {
                sumTime3--;
                int s = sumTime3 % 60;
                textBox5.Text = Convert.ToString(s);
                //if(s==0)
            }
            else
            {
                timer3.Enabled = false;
                textBox3.Text = "00";
                textBox4.Text = "00";
                textBox5.Text = "00";
                SoundPlayer sp = new SoundPlayer();
                //sp.SoundLocation = @"爱情花园.wav";
                switch (label5.Text)
                {
                    case "爱情花园.wav":
                        {
                            sp.SoundLocation = @"liveGarden.wav";
                            break;
                        }
                    case "tommora.wav":
                        {
                            sp.SoundLocation = @"tommora.wav";
                            break;
                        }
                    case "陌上花早.wav":
                        {
                            sp.SoundLocation = @"flower.wav";
                            break;
                        }
                    case "喜欢你.wav":
                        {
                            sp.SoundLocation = @"liveYou.wav";
                            break;
                        }                    
                }
                sp.Play();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sp.Stop();
        }

        /******************************************秒表****************************************/
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        int count = 0;

        private void button8_Click(object sender, EventArgs e)
        {
            timer4.Enabled = false;
            button8.Enabled = false;            
            button10.Enabled = false;
            textBox6.Text = "00";
            textBox7.Text = "00";
            textBox8.Text = "00";
            //清空数据库
            OleDbConnection mycon = new OleDbConnection(connStr);
            mycon.Open();
            string delCmd = "Delete From wecker";
            OleDbCommand cmd = new OleDbCommand(delCmd, mycon);           

            cmd.ExecuteNonQuery();
            mycon.Close();

            count = 0;
            button11.Enabled = false;

        }

        string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=wecker.mdb";

        private void button10_Click(object sender, EventArgs e)
        {  //插入表mm,ss,ms一条记录
            //button10.BackColor = Color.LightPink;

            string insertCmd;
            OleDbConnection conn = new OleDbConnection(connStr);
            conn.Open();


            insertCmd = "Insert Into wecker(id_no, timei) Values(@计次, @时间)";

            count++;
            OleDbCommand cmd = new OleDbCommand(insertCmd, conn);
            cmd.Parameters.Add(new OleDbParameter("@计次", OleDbType.Char));
            cmd.Parameters.Add(new OleDbParameter("@时间", OleDbType.Char));
            
            cmd.Parameters["@计次"].Value = count;
            cmd.Parameters["@时间"].Value = textBox6.Text+":"+textBox7.Text+":"+textBox8.Text;            

            cmd.ExecuteNonQuery();
            conn.Close();
        }


        //查看计次
        private void button11_Click(object sender, EventArgs e)
        {
            Form frmEnter= new ClassLibrary1.CWecker();
            frmEnter.ShowDialog();            
        }
        /************************选择音乐*****************************/

        BindingManagerBase Bm;

        private void CheckBm()
        {
            if (Bm.Position == 0)
            {
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            else if (Bm.Position == Bm.Count - 1)
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
                btnNext.Enabled = false;
                btnLast.Enabled = false;
            }
            else
            {
                btnFirst.Enabled = true;
                btnPrev.Enabled = true;
                btnNext.Enabled = true;
                btnLast.Enabled = true;
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Bm.Position = 0;
            CheckBm();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (Bm.Position > 0)
            {
                Bm.Position -= 1;
            }
            CheckBm();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Bm.Position < Bm.Count - 1)
            {
                Bm.Position += 1;
            }
            CheckBm();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Bm.Position = Bm.Count - 1;
            CheckBm();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = this.tabControl1.SelectedIndex;
            switch (id)
            {
                case 0:
                    {
                        /*nowTime.Text = DateTime.Now.ToString();
                        lblMsg.Location = new Point(name.x, name.y);
                        lblMsg.BackColor = Color.Aqua;
                        lblMsg.Font = new System.Drawing.Font("楷体_GB2312", 15, FontStyle.Bold);

                        timer1.Enabled = true;
                        timer2.Enabled = true;        */                
                        break;

                    }
                case 1:
                    {                        
                        break;
                    }
                case 2:
                    {                        
                        break;
                    }
                case 3:
                    {
                        
                        if(!tag3)
                        {
                            tag3 = true;
                            string selectCmd = "select musicName as 音乐名 From music";
                            string connStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=music.mdb";
                            OleDbConnection conn;
                            OleDbDataAdapter myAdapter;
                            DataSet myDataSet = new DataSet();
                            conn = new OleDbConnection(connStr);
                            conn.Open();
                            myAdapter = new OleDbDataAdapter(selectCmd, conn);
                            myAdapter.Fill(myDataSet, "music");
                            Binding bindId = new Binding("Text", myDataSet, "music.音乐名");

                            label5.DataBindings.Add(bindId);

                            Bm = this.BindingContext[myDataSet, "music"];
                            CheckBm();
                        }
                        
                        break;
                    }
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            sumTime4++;
            int ms1 = sumTime4 % 100;
            int ss1=(sumTime4/100+ss)%60;
            textBox8.Text = Convert.ToString(ms1);
            textBox7.Text = Convert.ToString(ss1);
            if(ms1==0&&ss1==0)
            textBox6.Text = Convert.ToString(++mm);
        }

        private void button9_Click(object sender, EventArgs e)
        {            
                mm = Convert.ToInt32(textBox6.Text);
                ss = Convert.ToInt32(textBox7.Text);
                ms = Convert.ToInt32(textBox8.Text);
                sumTime4 = ms;
                
                timer4.Enabled = !timer4.Enabled;
                button8.Enabled = true;
                if (timer4.Enabled)
                {
                    button10.Enabled = true;
                    button11.Enabled = false;

                }  
                else
                {
                    button10.Enabled = false;
                    button11.Enabled = true;
                }          
        }
    }
}
