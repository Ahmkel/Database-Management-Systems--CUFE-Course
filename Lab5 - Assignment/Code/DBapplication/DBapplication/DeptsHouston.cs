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
    public partial class DeptsHouston : Form
    {
        Controller controllerObj;
        public DeptsHouston()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetDeptsHouston();
            dataGridView1.DataSource = dt;
        }
    }
}
