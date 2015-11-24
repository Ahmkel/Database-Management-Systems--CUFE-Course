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
    public partial class FemaleEAdmins : Form
    {
        Controller controllerObj;
        public FemaleEAdmins()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.GetFemaleEAdmins();
            dataGridView1.DataSource = dt;
        }
    }
}
