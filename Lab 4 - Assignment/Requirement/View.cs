using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Requirement
{
    public partial class View : Form
    {
        Controller controllerObj;
        public View()
        {
            InitializeComponent();
        }

        private void InsertEmployeebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (controllerObj.InsertEmployee(FnametxtBox.Text, MinittxtBox.Text, LnametxtBox.Text, int.Parse(SSNtxtBox.Text), BdatetxtBox.Text,
                                             AddresstxtBox.Text, SextxtBox.Text, int.Parse(SalarytxtBox.Text), int.Parse(Super_SSNtxtBox.Text),
                                             int.Parse(DnotxtBox.Text)) == 0)
                {
                    MessageBox.Show("Insertion Failed");
                }
                else
                {
                    MessageBox.Show("Insertion Successful");
                }
            }
            catch
            {
                MessageBox.Show("Please revise the format:\nSSN,Salary,Super_SSN and Dno are integers\nBdate is date in format MM-DD-YEAR");
            }
        }

        private void View_Load(object sender, EventArgs e)
        {
            controllerObj = new Controller();
        }

        private void GetNumEmployeesProjectbtn_Click(object sender, EventArgs e)
        {

            if (ProjecttxtBox.Text.Length == 0)
                MessageBox.Show("Please enter project name");
            else
                NumEmployeesProjectLabel.Text = "Number of Employees: " + controllerObj.GetNumEmployeesProject(ProjecttxtBox.Text).ToString();
        }

        private void UpdateEmployeebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (controllerObj.UpdateEmployee(FnametxtBox.Text, MinittxtBox.Text, LnametxtBox.Text, int.Parse(SSNtxtBox.Text), BdatetxtBox.Text,
                                             AddresstxtBox.Text, SextxtBox.Text, int.Parse(SalarytxtBox.Text), int.Parse(Super_SSNtxtBox.Text),
                                             int.Parse(DnotxtBox.Text)) == 0)
                {
                    MessageBox.Show("Update Failed");
                }
                else
                {
                    MessageBox.Show("Update Successful");
                }
            }
            catch
            {
                MessageBox.Show("Please revise the format:\nSSN,Salary,Super_SSN and Dno are integers\nBdate is date in format MM-DD-YEAR");
            }
        }

        private void SelectEmployeesDepartmentbtn_Click(object sender, EventArgs e)
        {
            if (DepartmenttxtBox.Text.Length == 0)
                MessageBox.Show("Please enter department name");
            else
            {
                dataGridView1.DataSource = controllerObj.SelectEmployeesDepartment(DepartmenttxtBox.Text);
                dataGridView1.Refresh();
            }
        }

        private void DeleteProjectbtn_Click(object sender, EventArgs e)
        {
            if (ProjecttxtBox.Text.Length == 0)
                MessageBox.Show("Please enter project name");
            else
            {
                controllerObj.DeleteProject(ProjecttxtBox.Text);
            }
        }
    }
}
