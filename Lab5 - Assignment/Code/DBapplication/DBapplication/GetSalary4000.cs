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
    public partial class GetSalary4000 : Form
    {
        Controller controllerObj;
        public GetSalary4000()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetEwithSless4000();
            dataGridView1.DataSource = dt;
        }

        private void GetSalary4000_Load(object sender, EventArgs e)
        {

        }
    }
}
