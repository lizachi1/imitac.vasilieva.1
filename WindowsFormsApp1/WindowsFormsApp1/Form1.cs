﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Высота_Click(object sender, EventArgs e)
        {

        }

        const double dt = 0.1;

        const double g = 9.81;
        const double C = 0.15;
        const double rho = 1.29;


        double height, angle, speed, S, m;
        double cosa, sina, beta, k;

        

        double t, x, y, vx, vy;

        private void button1_Click(object sender, EventArgs e)
        {
            height = (double)edHeight.Value;
            angle = (double)edAngle.Value;
            speed = (double)edSpeed.Value;
            S = (double)edSize.Value;
            m = (double)edWeight.Value;

            cosa = Math.Cos(angle * Math.PI / 180);
            sina = Math.Sin(angle * Math.PI / 180);

            beta = 0.5 * C * S * rho;
            k = beta / m;

            t = 0;
            x = 0;
            y = height;
            vx = speed * cosa;
            vy = speed * sina;

            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(x, y);

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            double vx_old = vx;
            double vy_old = vy;
            double root = Math.Sqrt(vx * vx + vy * vy);

            t = t + dt;

            vx = vx_old - k * vx_old * root * dt;
            vy = vy_old - (g + k * vy_old * root) * dt;

            x = x + vx * dt;
            y = y + vy * dt;

            chart1.Series[0].Points.AddXY(x, y);

            if (y <= 0) timer1.Stop();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
