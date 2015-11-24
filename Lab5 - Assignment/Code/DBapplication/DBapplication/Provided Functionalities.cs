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
    public partial class Provided_Functionalities : Form
    {
       
        public Provided_Functionalities(int a)
        {
            InitializeComponent();
            if (a == 0) //1 for admin, 0 for other
            {
                this.button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RetrieveProjects RP = new RetrieveProjects();
            RP.Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewEmployees v = new ViewEmployees();
            v.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProject p = new AddProject();
            p.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetSalary4000 f = new GetSalary4000();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FemaleEAdmins f = new FemaleEAdmins();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeptsHouston f = new DeptsHouston();
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EStHo f = new EStHo();
            f.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddDept f = new AddDept();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateSalary f = new UpdateSalary();
            f.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DeptMgr f = new DeptMgr();
            f.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EmployeesResearch f = new EmployeesResearch();
            f.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SalaryStats f = new SalaryStats();
            f.Show();
        }
    }
}
