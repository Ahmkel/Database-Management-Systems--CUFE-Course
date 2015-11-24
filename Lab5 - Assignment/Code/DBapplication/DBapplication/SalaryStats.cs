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
    public partial class SalaryStats : Form
    {
        Controller controllerObj;
        public SalaryStats()
        {
            InitializeComponent();
            controllerObj = new Controller();
            label2.Text = "MAX: " + controllerObj.GetMaxSalary();
            label3.Text = "MIN: " + controllerObj.GetMinSalary();
            label4.Text = "AVG: " + controllerObj.GetAvgSalary();
        }

        private void SalaryStats_Load(object sender, EventArgs e)
        {

        }
    }
}
