using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button btn;
            int x = 10;
            int y = 10;
            for (int i = 1; i < 13; i++)
            {
                btn = new Button();

                btn.Text = i.ToString();
                if (i == 10) btn.Text = '*'.ToString();
                if (i == 11) btn.Text = 0.ToString();
                if (i == 12) btn.Text = '#'.ToString();

                btn.Size = new Size(75, 25);
                btn.Location = new Point(x, y);
                x += 100;
                if (i % 3 == 0) {
                    y += 40;
                    x = 10;
                }
                this.Controls.Add(btn);
            }
        }
    }
}

/*
 *  this.button1.Location = new System.Drawing.Point(12, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
 */