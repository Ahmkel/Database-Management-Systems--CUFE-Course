using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBapplication
{
    public class Controller
    {
        DBManager dbMan;
        DBConnection DBCon;
        public Controller()
        {
            dbMan = new DBManager();
            DBCon = DBConnection.Instance();
        }

      
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }
        public DataTable SelectAllEmp()
        {
            string query = "SELECT * FROM Employee;";
            return dbMan.ExecuteReader(query);
        }


        public int InsertProject(string Pname, int pnumber, string Plocation, int Dnum)
        {
            string query = "INSERT INTO Project (Pname, Pnumber, Plocation, Dnum)" +
                            "Values ('" + Pname + "'," + pnumber + ",'" + Plocation + "'," + Dnum + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectDepNum()
        {
            string query= "SELECT Dnumber FROM Department;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable SelectDepLoc()
        {
            string query = "SELECT DISTINCT Dlocation FROM Dept_Locations;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable SelectProject(string location)
        {
            string query = "SELECT Pname,Dname FROM Department D, Project P, Dept_Locations L"
             +" where P.Dnum=D.Dnumber and L.Dnumber=D.Dnumber and L.Dlocation='"+location+"';"; 
            
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetEwithSless4000()
        {
            string query = "SELECT SSN,Address FROM EMPLOYEE WHERE Salary<40000";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetFemaleEAdmins()
        {
            string query = "SELECT Employee.* FROM Employee,Department WHERE Sex = 'F' and Dno=Dnumber and Dname='Administration'";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetDeptsHouston()
        {
            string query = "SELECT Department.Dname FROM Department,Dept_Locations WHERE Department.Dnumber=Dept_Locations.Dnumber AND Dlocation='Houston'";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetEStHo()
        {
            string query = "SELECT DISTINCT Employee.Fname,Employee.Minit,Employee.Lname,Employee.Salary FROM Employee,Project,Works_On WHERE Works_On.Essn=Employee.SSN AND Works_On.Pno = Project.Pnumber AND (Project.Plocation='Houston' OR Project.Plocation='Stafford') AND Works_On.Hours<35";
            return dbMan.ExecuteReader(query);
        }

        public int InsertDept(string Dname, int Dnum, int Mgr_SSN,string Mgr_Start_Date)
        {
            string query = String.Format("INSERT INTO Department VALUES('{0}',{1},{2},'{3}')", Dname, Dnum, Mgr_SSN, Mgr_Start_Date);
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateESalary(int SSN,int Salary)
        {
            string query = String.Format("UPDATE Employee SET Salary={0} WHERE SSN={1}", Salary, SSN);
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable SelectEMgr()
        {
            string query = "SELECT Employee.Lname,Employee.Salary FROM Employee,Department WHERE Employee.SSN = Department.Mgr_SSN";
            return dbMan.ExecuteReader(query);
        }

        public DataTable GetEmployeesResearch()
        {
            string query = "(SELECT Employee.Fname,Employee.Minit,Employee.Lname,Employee.SSN From Employee,Department WHERE Employee.Dno=Department.Dnumber AND Department.Dname='Research')";
            query += "UNION";
            query += "(SELECT Employee.Fname,Employee.Minit,Employee.Lname,Employee.SSN From Employee,Department,Project,Works_On WHERE Employee.SSN=Works_On.Essn AND Project.Pnumber=Works_On.Pno AND Project.Dnum=Department.Dnumber AND Department.Dname='Research')";
            return dbMan.ExecuteReader(query);
        }

        public int GetMaxSalary()
        {
            return (int)dbMan.ExecuteScalar("SELECT MAX(Employee.Salary) FROM Employee");
        }
        public int GetMinSalary()
        {
            return (int)dbMan.ExecuteScalar("SELECT MIN(Employee.Salary) FROM Employee");
        }

        public int GetAvgSalary()
        {
            return (int)dbMan.ExecuteScalar("SELECT AVG(Employee.Salary) FROM Employee");
        }

        public DataTable Testt()
        {
            DataTable dt = new DataTable();
            if (DBCon.IsConnect())
            {
                string query = "Select * from User";
                MySqlCommand cmd = new MySqlCommand(query, DBCon.GetConnection());
                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            return dt;
        }
    }
}
