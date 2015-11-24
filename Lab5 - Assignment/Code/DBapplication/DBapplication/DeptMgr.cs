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
    public partial class DeptMgr : Form
    {
        Controller controllerObj;
        public DeptMgr()
        {
            InitializeComponent();
            controllerObj = new Controller();
            DataTable dt = controllerObj.SelectEMgr();
            dataGridView1.DataSource = dt;
        }
    }
}
