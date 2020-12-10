using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            int x = 20;
            int y = 70;
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
                    x = 20;
                }
                btn.MouseEnter += new System.EventHandler(this.btn_MouseEnter);
                btn.MouseLeave += new System.EventHandler(this.btn_MouseLeave);
                btn.Click += new System.EventHandler(this.btn_Click);
                this.Controls.Add(btn);
            }
        }

        private void btn_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.Aqua;

        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = DefaultBackColor;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            txtPantalla.Text += ((Button)sender).Text;
            ((Button)sender).BackColor = Color.Red;
            ((Button)sender).MouseEnter -= new System.EventHandler(this.btn_MouseEnter);
            ((Button)sender).MouseLeave -= new System.EventHandler(this.btn_MouseLeave);
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            Restaurar();
        }

        public void Restaurar() 
        {
            txtPantalla.Text = "";
            foreach (object control in this.Controls)
            {
                if (control.GetType() == typeof(Button) && control != btnRestaurar)
                {
                    ((Button)control).BackColor = DefaultBackColor;
                    ((Button)control).MouseEnter += new System.EventHandler(this.btn_MouseEnter);
                    ((Button)control).MouseLeave += new System.EventHandler(this.btn_MouseLeave);
                }
            }
        }

        private void grabarNumeroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtPantalla.Text))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Selección de directorio para almacenar datos";
                saveFileDialog.InitialDirectory = Environment.GetEnvironmentVariable("HomePath");
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.ValidateNames = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName,true))
                    {
                        sw.WriteLine(txtPantalla.Text);
                    }
                }             
            }
            else 
            {
                MessageBox.Show("No hay número a guardar");
            }
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restaurar();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Creador: Gleen Montiel", "Acerca de...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}