using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class UpdateSalary : Form
    {
        Controller controllerObj;
        public UpdateSalary()
        {
            InitializeComponent();
            controllerObj = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controllerObj.UpdateESalary(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            MessageBox.Show("Updated Successfully");
            this.Close();
        }
    }
}
