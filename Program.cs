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
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        private int Age { get; set; }
        private int EmployeeID { get; set; }
        protected decimal CalculatedPay { get; set; }
        protected Employee(string Firstname, string Lastname, int Age, int EmployeeID)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Age = Age;
            this.EmployeeID = EmployeeID;

        }
        public string NameOutput()
        {
            return Lastname + ", " + Firstname;
        }
        public int AgeOutput()
        {
            return Age;
        }
        public int IDOutput()
        {
            return EmployeeID;
        }
        public string CalculatePay()
        {
            return "$" + CalculatedPay;
        }
    }
    public class SalariedEmployee : Employee
    {
        private decimal Monthlypay { get; set; }

        public SalariedEmployee(string Firstname, string Lastname, int Age, int EmployeeID, decimal Monthlypay)
            : base(Firstname, Lastname, Age, EmployeeID)
        {
            this.Monthlypay = Monthlypay;
            CalculatedPay = Monthlypay;
        }
    }
    public class HourlyEmployee : Employee
    {
        private decimal Hourlypay { get; set; }
        private decimal Hoursworked { get; set; }

        public HourlyEmployee(string Firstname, string Lastname, int Age, int EmployeeID, decimal Hourlypay, decimal Hoursworked)
            : base(Firstname, Lastname, Age, EmployeeID)
        {
            this.Hourlypay = Hourlypay;
            this.Hoursworked = Hoursworked;
            CalculatedPay = Hoursworked * Hourlypay;
        }
    }
}
