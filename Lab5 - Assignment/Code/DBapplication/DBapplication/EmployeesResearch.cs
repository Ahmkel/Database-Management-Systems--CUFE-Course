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
    public partial class EmployeesResearch : Form
    {
        Controller controllerObj;
        public EmployeesResearch()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetEmployeesResearch();
            dataGridView1.DataSource = dt;
        }
    }
}
