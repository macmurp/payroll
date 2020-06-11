using System;

namespace payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    abstract class Employee
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Age { get; set; }
        int EmployeeID { get; set; }
        Employee(string Firstname, string Lastname, int Age, int EmployeeID)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Age = Age;
            this.EmployeeID = EmployeeID;
        }
        string Nameoutput()
        {
            string Nameoutput = Lastname + ", " + Firstname;
            return Nameoutput;
        }
        string Ageoutput()
        {
            string Ageoutput = Age + " years old";
            return Ageoutput;

        }
        string IDoutput()
        {
            string IDoutput = "ID " + EmployeeID;
            return IDoutput;
        }
    }
    class HourlyEmployee : Employee
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Age { get; set; }
        int EmployeeID { get; set; }
        int MonthlyPay { get; set; }
    }
}
