using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace lifehandbook2
{
    public partial class FormMemo : Form
    {
        string Na = Form1.UserName;

        int oldX, oldY;
        Bitmap bmp = new Bitmap(550, 440);
        int point = 6;
        Color pen_c;
        


        private void form_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public FormMemo()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain();
            formMain.Closed += new EventHandler(this.form_Closed);
            //f2.Closed += (obj, args) => { Application.Exit(); };  
            formMain.Show();
            this.Close();
        }

        private void FormMemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("请按退出键退出！");
            //e.Cancel = true;
        }

        private void FormMemo_Load(object sender, EventArgs e)
        {
            //picShow.Size = new Size(783, 472);
            //picShow.Location = new Point(4, 106);
            picColor.BackColor = Color.Black;
            hsbB.Scroll += new ScrollEventHandler(this.hsbA_Scroll);
            hsbR.Scroll += new ScrollEventHandler(this.hsbA_Scroll);
            hsbG.Scroll += new ScrollEventHandler(this.hsbA_Scroll);

            picColor.BackColor = Color.FromArgb(hsbA.Value, hsbR.Value, hsbG.Value, hsbB.Value);
            pen_c = Color.FromArgb(hsbA.Value, hsbR.Value, hsbG.Value, hsbB.Value);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);
            picShow.Image = bmp;
            picShow.Refresh();

        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void hsbA_Scroll(object sender, ScrollEventArgs e)
        {
            
            lblA.Text = "A=" + hsbA.Value.ToString();
            lblR.Text = "R=" + hsbR.Value.ToString();
            lblG.Text = "G=" + hsbG.Value.ToString();
            lblB.Text = "B=" + hsbB.Value.ToString();
            picColor.BackColor = Color.FromArgb(hsbA.Value, hsbR.Value, hsbG.Value, hsbB.Value);
            pen_c = Color.FromArgb(hsbA.Value, hsbR.Value, hsbG.Value, hsbB.Value);

        }

        private void picShow_MouseDown(object sender, MouseEventArgs e)
        {
            oldX = e.X;
            oldY = e.Y;
        }

        private void picShow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(bmp);
                Pen pen = new Pen(pen_c, point);
                g.DrawLine(pen, oldX, oldY, e.X, e.Y);
                picShow.Image = bmp;
                oldX = e.X;
                oldY = e.Y;
            }
            int x = Control.MousePosition.X-332;
            int y = Control.MousePosition.Y-170;            
            label5.Text = "X=" + x + " " + "Y=" + y;
        }
        //画空椭圆
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int beginX = Convert.ToInt32(textBox1.Text);
                int beginY = Convert.ToInt32(textBox2.Text);
                int width = Convert.ToInt32(textBox3.Text);
                int height = Convert.ToInt32(textBox4.Text);                               
                Graphics g;
                Pen pen = new Pen(pen_c, point);
                //Target.Refresh()
                
                g = picShow.CreateGraphics();
                g.DrawEllipse(pen, beginX, beginY, width, height);                
                g.Dispose();
                pen.Dispose();
               
                
            }
            else
                MessageBox.Show("请填写完整画图的起始坐标XY以及宽高！");
            
        }
        //画空矩形
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int beginX = Convert.ToInt32(textBox1.Text);
                int beginY = Convert.ToInt32(textBox2.Text);
                int width = Convert.ToInt32(textBox3.Text);
                int height = Convert.ToInt32(textBox4.Text);                           
                Graphics g;
                //Target.Refresh()
                g = picShow.CreateGraphics();
                Pen pen = new Pen(pen_c, point);
                g.DrawRectangle(pen, beginX, beginY, width, height);
                g.Dispose();
            }
            else
                MessageBox.Show("请填写完整画图的起始坐标XY以及宽高！");
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if ((ch < '0' || ch > '9') && ch != '\b')
               {
                 e.Handled = true;
               }
                
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch < '0' || ch > '9') && ch != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch < '0' || ch > '9') && ch != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if ((ch < '0' || ch > '9') && ch != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (point < 15) point++;
            //label1.Text = "penSize=" + pen_c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (point > 1) point--;
            //label1.Text = "penSize=" + pen_c;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);
            //picShow.Image = bmp;
            picShow.Refresh();
        }

        private void picShow_Paint(object sender, PaintEventArgs e)
        {
            /*Graphics g;
            g = picShow.CreateGraphics();
            picShow.Refresh();
            HatchBrush myhb = new HatchBrush(HatchStyle.DashedDownwardDiagonal, Color.Blue, Color.Yellow);
            Rectangle myRctangle1 = new Rectangle(20, 50, 80, 80);
            g.FillRectangle(myhb, myRctangle1);
            Rectangle myRctangle2 = new Rectangle(120, 50, 100, 80);
            LinearGradientBrush myLb1 = new LinearGradientBrush(myRctangle2, Color.Red, Color.Wheat, 60);
            g.FillEllipse(myLb1, myRctangle2);
            Rectangle myRctangle3 = new Rectangle(250, 50, 80, 100);
            LinearGradientBrush myLb2 = new LinearGradientBrush(myRctangle3, Color.Purple, Color.YellowGreen, 60);
            g.FillPie(myLb2, myRctangle3, -90, -270);

            SolidBrush mySb = new SolidBrush(Color.Aqua);
            Point[] points = new Point[5];
            points[0] = new Point(400, 50);
            points[0] = new Point(360, 120);
            points[0] = new Point(450, 70);
            points[0] = new Point(350, 70);
            points[0] = new Point(440, 120);

            g.FillPolygon(mySb, points);
            g.Dispose();
            //p.Dispose();*/
        }

        private void FormMemo_Paint(object sender, PaintEventArgs e)
        {
           /* Graphics g;
            g = this.CreateGraphics();
            HatchBrush myhb = new HatchBrush(HatchStyle.DashedDownwardDiagonal, Color.Blue, Color.Yellow);
            Rectangle myRctangle1 = new Rectangle(20, 100, 80, 80);
            g.FillRectangle(myhb, myRctangle1);
            Rectangle myRctangle2 = new Rectangle(120, 100, 100, 80);
            LinearGradientBrush myLb1 = new LinearGradientBrush(myRctangle2, Color.Red, Color.Wheat, 60);
            g.FillEllipse(myLb1, myRctangle2);
            Rectangle myRctangle3 = new Rectangle(250, 100, 80, 100);
            LinearGradientBrush myLb2 = new LinearGradientBrush(myRctangle3, Color.Purple, Color.YellowGreen, 60);
            g.FillPie(myLb2, myRctangle3, -90, -270);

            SolidBrush mySb = new SolidBrush(Color.Aqua);
            Point[] points = new Point[5];
            points[0] = new Point(400, 50);
            points[0] = new Point(360, 120);
            points[0] = new Point(450, 70);
            points[0] = new Point(350, 70);
            points[0] = new Point(440, 120);

            g.FillPolygon(mySb, points);*/
        }
        //画直线
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int beginX = Convert.ToInt32(textBox1.Text);
                int beginY = Convert.ToInt32(textBox2.Text);
                int width = Convert.ToInt32(textBox3.Text);
                int height = Convert.ToInt32(textBox4.Text);
                // Dim p As New Pen(Color.Red, 5)
                Graphics g;
                Pen pen = new Pen(pen_c, point);
                //Target.Refresh()
                g = picShow.CreateGraphics();
                g.DrawLine(pen, beginX, beginY, width, height);
                g.Dispose();
                pen.Dispose();
            }
            else
                MessageBox.Show("请填写完整画图的起始坐标XY以及宽高！");
           
        }

        private void picShow_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void picShow_MouseEnter(object sender, EventArgs e)
        {
            label5.Visible = true;
        }
        //画满椭圆
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int beginX = Convert.ToInt32(textBox1.Text);
                int beginY = Convert.ToInt32(textBox2.Text);
                int width = Convert.ToInt32(textBox3.Text);
                int height = Convert.ToInt32(textBox4.Text);               
                Graphics g;
                //Target.Refresh()
                g = picShow.CreateGraphics();
                SolidBrush brush = new SolidBrush(pen_c);
                g.FillEllipse(brush,beginX, beginY, width, height);
                g.Dispose();
                
                
            }
            else
                MessageBox.Show("请填写完整画图的起始坐标XY以及宽高！");
        }
        //画满矩形
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int beginX = Convert.ToInt32(textBox1.Text);
                int beginY = Convert.ToInt32(textBox2.Text);
                int width = Convert.ToInt32(textBox3.Text);
                int height = Convert.ToInt32(textBox4.Text);
                Rectangle rect = new Rectangle(beginX, beginY, width, height);
                LinearGradientBrush linGrBrush = new LinearGradientBrush(rect, Color.Red, Color.Blue, 90);
                Graphics g;
                //Target.Refresh()
                g = picShow.CreateGraphics();
                g.FillRectangle(linGrBrush, rect);
                /*Point p1 = new Point(80, 80);
                Point p2 = new Point(180, 160);
                LinearGradientBrush linGrBrush2 = new LinearGradientBrush(p1, p2, Color.White, Color.Black);
                g.FillRectangle(linGrBrush2, 80, 80, 100, 80);                                
                linGrBrush2.Dispose();*/
                g.Dispose();
                linGrBrush.Dispose();
            }
            else
                MessageBox.Show("请填写完整画图的起始坐标XY以及宽高！");

        }
        //图形画圆
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                int beginX = Convert.ToInt32(textBox1.Text);
                int beginY = Convert.ToInt32(textBox2.Text);
                int width = Convert.ToInt32(textBox3.Text);
                int height = Convert.ToInt32(textBox4.Text);
                /*Bitmap img = new Bitmap("tankD.bmp");
               // TextureBrush tb = new TextureBrush(img);
                //Pen pen = new Pen(pen_c, point);
                Graphics g;
                //Target.Refresh()
                g = picShow.CreateGraphics();
                g.DrawEllipse(pen, beginX, beginY, width, height);
                g.Dispose();
                pen.Dispose();
                b.Dispose();
                img.Dispose();*/

                Bitmap img = new Bitmap("tankD.bmp");
                Graphics g;
                g = picShow.CreateGraphics();
                TextureBrush tb = new TextureBrush(img);
                Pen pen = new Pen(tb, point);
                g.DrawEllipse(pen, beginX, beginY, width, height);
                //g.FillEllipse(tb, beginX, beginY, width, height);
            }
            else
                MessageBox.Show("请填写完整画图的起始坐标XY以及宽高！");
        }

        private void hsbR_Scroll(object sender, ScrollEventArgs e)
        {
            
        }
    }
}
