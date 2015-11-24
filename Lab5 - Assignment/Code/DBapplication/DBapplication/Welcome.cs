﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Welcome : Form
    {
        Controller controllerObj;
        public Welcome()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin a = new AdminLogin();
            a.Show();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Provided_Functionalities f = new Provided_Functionalities(0);//for admin
            f.Show();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {

            controllerObj = new Controller();
            DataTable dt = controllerObj.Testt();
            dataGridView1.DataSource = dt;
        }
    }
}
