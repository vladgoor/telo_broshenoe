using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brosok_pod_yglom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float _x = 50;
        float _y = 200;
        float _x0 = 50;
        float _y0 = 200;
        float _v = 0;
        float _vx;
        float _vy;
        float _ang;
        float _t = 0;
        float _t0 = 0;
        float _g = 9.81f;
        float _zemlya = 201;
        double _pi = Math.PI / 180;
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _vy = (float)(_v * Math.Cos(_ang * _pi));
            _vx = (float)(_v * Math.Sin(_ang * _pi));
            _t++;
            float _dt = _t / 100;
            _y -= _vx * _dt - _g * _dt * _dt;
            _x += _vy * _dt;
            if (_y >= _zemlya)
            {
                timer1.Stop();
            }
            pictureBox1.Refresh();
        }
   private void button1_Click(object sender, EventArgs e)
        {
            float.TryParse(textBox1.Text, out _v);
            float.TryParse(textBox2.Text, out _ang);
            timer1.Start();
            timer1.Interval = 10;
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Black, _x, _y, 20, 20);
            e.Graphics.DrawLine(Pens.Black, 60, 250, 60, 10);
            e.Graphics.DrawLine(Pens.Black, 40, 210, 900, 210);
            e.Graphics.DrawLine(Pens.Black, 60, 10, 55, 30);
            e.Graphics.DrawLine(Pens.Black, 60, 10, 65, 30);
            e.Graphics.DrawLine(Pens.Black, 900, 210, 880, 205);
            e.Graphics.DrawLine(Pens.Black, 900, 210, 880, 215);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            _x = _x0;
            _y = _y0;
            _t = _t0;
            pictureBox1.Refresh();
        }
    }
}
