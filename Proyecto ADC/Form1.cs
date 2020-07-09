using proyecto_ADC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_ADC
{
    public partial class Form1 : Form
    {
        Maquina maq = new Maquina();

        // Funcion que determina la posicion de los textos de los objetos y si se deben mostrar
        public void moverTextos()
        {
            if (maq.jugs[0].activo == true) textBox3.Text = "J";
            else textBox3.Text = "";
            if (maq.jugs[1].activo == true) textBox4.Text = "i1";
            else textBox4.Text = "";
            if (maq.jugs[2].activo == true) textBox5.Text = "i2";
            else textBox5.Text = "";
            if (maq.jugs[3].activo == true) textBox6.Text = "i3";
            else textBox6.Text = "";
            if (maq.jugs[4].activo == true) textBox7.Text = "i4";
            else textBox7.Text = "";
            if (maq.jugs[5].activo == true) textBox8.Text = "i5";
            else textBox8.Text = "";
            if (maq.jugs[6].activo == true) textBox9.Text = "i6";
            else textBox9.Text = "";
            if (maq.jugs[7].activo == true) textBox10.Text = "O";
            else textBox10.Text = "";
            textBox3.Location = new Point(maq.jugs[0].x + 19, maq.jugs[0].y + 15);
            textBox4.Location = new Point(maq.jugs[1].x + 17, maq.jugs[1].y + 14);
            textBox5.Location = new Point(maq.jugs[2].x + 17, maq.jugs[2].y + 14);
            textBox6.Location = new Point(maq.jugs[3].x + 17, maq.jugs[3].y + 14);
            textBox7.Location = new Point(maq.jugs[4].x + 17, maq.jugs[4].y + 14);
            textBox8.Location = new Point(maq.jugs[5].x + 17, maq.jugs[5].y + 14);
            textBox9.Location = new Point(maq.jugs[6].x + 17, maq.jugs[6].y + 14);
            textBox10.Location = new Point(maq.jugs[7].x + 15, maq.jugs[7].y + 13);
        }

        public Form1()
        {
            InitializeComponent();
            moverTextos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Al hacer click en iniciar, se activa el reloj
        private void Boton_Inicio(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            textBox1.Text = "Estado = 0 (No matar)";
        }

        // Al hacer click en reiniciar, se coloca todo en estado inicial
        private void Boton_Reinicio(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            maq = new Maquina();
            this.Invalidate();
            textBox1.Text = "Estado = ";
            textBox2.Text = "";
            button1.Enabled = true;
            textBox10.Visible = true;
            moverTextos();
     
        }

        // Funcion que dibuja los cuadrados en pantalla
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (maq.jugs[i].activo == true)
                {
                    if (i == 0) e.Graphics.DrawRectangle(Pens.Blue, maq.jugs[i].x, maq.jugs[i].y, 50, 50);
                    else if (i == 7) e.Graphics.DrawRectangle(Pens.Red, maq.jugs[i].x, maq.jugs[i].y, 50, 50);
                    else e.Graphics.DrawRectangle(Pens.DarkGreen, maq.jugs[i].x, maq.jugs[i].y, 50, 50);
                }
            }
        }

        // Cada pulso de reloj se mueven los objetos y se cambian sus estados, tambien se determina si hay victoria o perdida.
        private void pulso_reloj(object sender, EventArgs e)
        {
            this.Invalidate();
            maq.moverObjetos();
            moverTextos();
            if (maq.jugs[0].estado == 0) textBox1.Text = "Estado = 0 (No matar)";
            else if (maq.jugs[0].estado == 1) textBox1.Text = "Estado = 1 (Matar inocente)";
            else if (maq.jugs[0].estado == 2) textBox1.Text = "Estado = 2 (Matar objetivo)";
            else if (maq.jugs[0].estado == 3)
            {
                textBox10.Visible = false;
                textBox1.Text = "Estado = 3 (Victoria)";
                textBox2.Text = "¡Ha ganado el jugador!";
                timer1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                textBox1.Text = "Estado = 4 (Derrota)";
                textBox2.Text = "¡Ha perdido el jugador!";
                timer1.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
    }
}
