using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Requirement
{
    class Controller
    {
        DBManager dbManager;

        public Controller()
        {
            dbManager = new DBManager();
        }
        public int InsertEmployee(string Fname,string Minit,string Lname,int SSN,string Bdate,string Address,string Sex,int Salary,int Super_SSN,int Dno)
        {
            string sqlQuery = string.Format("INSERT INTO Employee VALUES('{0}','{1}','{2}',{3},'{4}','{5}','{6}',{7},{8},{9})",
                                            Fname, Minit, Lname, SSN, Bdate, Address, Sex, Salary, Super_SSN, Dno);
            return dbManager.ExecuteNonQuery(sqlQuery);
        }
        public int UpdateEmployee(string Fname, string Minit, string Lname, int SSN, string Bdate, string Address, string Sex, int Salary, int Super_SSN, int Dno)
        {
            string sqlQuery = string.Format("UPDATE Employee SET Fname='{0}',Minit='{1}',Lname='{2}',Bdate='{3}',Address='{4}',Sex='{5}',Salary={6},Super_SSN={7},Dno={8} ",
                                            Fname, Minit, Lname, Bdate, Address, Sex, Salary, Super_SSN, Dno);
            sqlQuery += string.Format("WHERE SSN={0}", SSN);
            return dbManager.ExecuteNonQuery(sqlQuery);
        }
        public DataTable SelectEmployeesDepartment(string DName)
        {
            string sqlQuery = "SELECT Fname, Minit, Lname, Bdate, Address, Sex, Salary, Super_SSN, Dno FROM Employee,Department ";
            sqlQuery += string.Format("WHERE Employee.Dno=Department.DNumber AND Department.DName='{0}'", DName);
            return dbManager.ExecuteReader(sqlQuery);
        }
        public int GetNumEmployeesProject(string PName)
        {
            string sqlQuery = string.Format("SELECT COUNT(Essn) FROM Works_On,Project WHERE Works_On.Pno=Project.Pnumber AND Project.Pname='{0}'", PName);
            return dbManager.ExecuteScalar(sqlQuery);
        }
        public int DeleteProject(string Pname)
        {
            string sqlQuery = string.Format("DELETE FROM Project WHERE Pname='{0}'",Pname);
            return dbManager.ExecuteNonQuery(sqlQuery);
        }
        public void TerminateConnection()
        {
            dbManager.CloseConnection();
        }
    }
}
