using System;

namespace payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public abstract class Employee
    {
        public abstract string Firstname { get; set; }
        public abstract string Lastname { get; set; }
        public abstract int Age { get; set; }
        public abstract int EmployeeID { get; set; }
        public Employee(string Firstname, string Lastname, int Age, int EmployeeID)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Age = Age;
            this.EmployeeID = EmployeeID;
        }
        public string Nameoutput()
        {
            string Nameoutput = Lastname + ", " + Firstname;
            return Nameoutput;
        }
        public string Ageoutput()
        {
            string Ageoutput = Age + " years old";
            return Ageoutput;

        }
        public string IDoutput()
        {
            string IDoutput = "ID " + EmployeeID;
            return IDoutput;
        }
    }
    public class SalariedEmployee : Employee
    {
        public decimal Monthlypay { get; set; }
        public override string Firstname { get; set; }
        public override string Lastname { get; set; }
        public override int Age { get; set; }
        public override int EmployeeID { get; set; }

        public SalariedEmployee(string Firstname, string Lastname, int Age, int EmployeeID, decimal Monthlypay)
            : base(Firstname, Lastname, Age, EmployeeID)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Age = Age;
            this.EmployeeID = EmployeeID;
            this.Monthlypay = Monthlypay;
        }
    }
}
