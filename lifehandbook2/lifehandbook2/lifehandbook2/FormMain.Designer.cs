namespace lifehandbook2
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLinkman = new System.Windows.Forms.Button();
            this.btnWecker = new System.Windows.Forms.Button();
            this.btnMemorandum = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLinkman
            // 
            this.btnLinkman.BackColor = System.Drawing.Color.Transparent;
            this.btnLinkman.Font = new System.Drawing.Font("STCaiyun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLinkman.ForeColor = System.Drawing.Color.Black;
            this.btnLinkman.Location = new System.Drawing.Point(233, 221);
            this.btnLinkman.Name = "btnLinkman";
            this.btnLinkman.Size = new System.Drawing.Size(113, 36);
            this.btnLinkman.TabIndex = 3;
            this.btnLinkman.Text = "生 日 管 家";
            this.btnLinkman.UseVisualStyleBackColor = false;
            this.btnLinkman.Click += new System.EventHandler(this.btnLinkman_Click);
            // 
            // btnWecker
            // 
            this.btnWecker.BackColor = System.Drawing.Color.Transparent;
            this.btnWecker.Font = new System.Drawing.Font("STCaiyun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnWecker.ForeColor = System.Drawing.Color.Black;
            this.btnWecker.Location = new System.Drawing.Point(233, 56);
            this.btnWecker.Name = "btnWecker";
            this.btnWecker.Size = new System.Drawing.Size(113, 36);
            this.btnWecker.TabIndex = 2;
            this.btnWecker.Text = "时 钟";
            this.btnWecker.UseVisualStyleBackColor = false;
            this.btnWecker.Click += new System.EventHandler(this.btnWecker_Click);
            // 
            // btnMemorandum
            // 
            this.btnMemorandum.BackColor = System.Drawing.Color.White;
            this.btnMemorandum.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMemorandum.Font = new System.Drawing.Font("STCaiyun", 15.75F);
            this.btnMemorandum.Location = new System.Drawing.Point(233, 168);
            this.btnMemorandum.Name = "btnMemorandum";
            this.btnMemorandum.Size = new System.Drawing.Size(113, 36);
            this.btnMemorandum.TabIndex = 0;
            this.btnMemorandum.Text = "画 板";
            this.btnMemorandum.UseVisualStyleBackColor = false;
            this.btnMemorandum.Click += new System.EventHandler(this.btnMemorandum_Click);
            // 
            // btnCalendar
            // 
            this.btnCalendar.BackColor = System.Drawing.Color.Transparent;
            this.btnCalendar.Font = new System.Drawing.Font("STCaiyun", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalendar.ForeColor = System.Drawing.Color.Black;
            this.btnCalendar.Location = new System.Drawing.Point(233, 110);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(113, 36);
            this.btnCalendar.TabIndex = 1;
            this.btnCalendar.Text = "日 历";
            this.btnCalendar.UseVisualStyleBackColor = false;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("KaiTi", 12F);
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(559, 366);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 36);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // help
            // 
            this.help.Font = new System.Drawing.Font("KaiTi", 12F);
            this.help.ForeColor = System.Drawing.Color.Black;
            this.help.Location = new System.Drawing.Point(559, 4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(80, 36);
            this.help.TabIndex = 5;
            this.help.Text = "帮助";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // edit
            // 
            this.edit.Font = new System.Drawing.Font("KaiTi", 12F);
            this.edit.ForeColor = System.Drawing.Color.Black;
            this.edit.Location = new System.Drawing.Point(559, 46);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(80, 36);
            this.edit.TabIndex = 6;
            this.edit.Text = "编辑资料";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(178, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "★☆★☆★☆★☆★☆★☆★☆★☆★";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(168, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 280);
            this.label2.TabIndex = 8;
            this.label2.Text = "☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(381, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 302);
            this.label4.TabIndex = 10;
            this.label4.Text = "☆★☆★★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(183, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★☆★";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("KaiTi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(180, 309);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "显示签名";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::lifehandbook2.Properties.Resources.edit2;
            this.ClientSize = new System.Drawing.Size(648, 414);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLinkman);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMemorandum);
            this.Controls.Add(this.btnWecker);
            this.Controls.Add(this.btnCalendar);
            this.Controls.Add(this.help);
            this.Controls.Add(this.edit);
            this.Font = new System.Drawing.Font("KaiTi", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生活APP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLinkman;
        private System.Windows.Forms.Button btnWecker;
        private System.Windows.Forms.Button btnCalendar;
        private System.Windows.Forms.Button btnMemorandum;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button1;
    }
}