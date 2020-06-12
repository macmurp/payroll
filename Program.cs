using System;
using System.Collections.Generic;

namespace payroll
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            List<Employee> Employees = new List<Employee>();
            while (input != 3)
            {
                Console.WriteLine("Choose from the following options:\n");
                Console.WriteLine("1.Add a salaried employee");
                Console.WriteLine("2.Add an hourly employee");
                Console.WriteLine("3.Generate report");
                //input = Convert.ToInt32(Console.ReadLine());
                if(!int.TryParse(Console.ReadLine(), out input))
                { Console.WriteLine("Please enter a valid option."); continue; }
                switch (input)
                {
                    case 1:
                        string tempfirst;
                        string templast;
                        int tempage;
                        int tempid;
                        decimal tempsalary;
                        Console.WriteLine("Enter the following details:");
                        Console.WriteLine("First name");
                        tempfirst = Console.ReadLine();
                        Console.WriteLine("Last name");
                        templast = Console.ReadLine();
                        Console.WriteLine("Age");
                        if(!int.TryParse(Console.ReadLine(), out tempage))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Console.WriteLine("Employee ID");
                        if (!int.TryParse(Console.ReadLine(), out tempid))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Console.WriteLine("Monthly salary");
                        if (!decimal.TryParse(Console.ReadLine(), out tempsalary))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Employees.Add(new SalariedEmployee(tempfirst, templast, tempage, tempid, tempsalary));
                        break;
                    case 2:
                        decimal temphourly;
                        decimal temphours;
                        Console.WriteLine("Enter the following details:");
                        Console.WriteLine("First name");
                        tempfirst = Console.ReadLine();
                        Console.WriteLine("Last name");
                        templast = Console.ReadLine();
                        Console.WriteLine("Age");
                        if (!int.TryParse(Console.ReadLine(), out tempage))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Console.WriteLine("Employee ID");
                        if (!int.TryParse(Console.ReadLine(), out tempid))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Console.WriteLine("Hourly pay");
                        if (!decimal.TryParse(Console.ReadLine(), out temphourly))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Console.WriteLine("Hours worked");
                        if (!decimal.TryParse(Console.ReadLine(), out temphours))
                        { Console.WriteLine("Please enter a valid option."); continue; }
                        Employees.Add(new HourlyEmployee(tempfirst, templast, tempage, tempid, temphourly, temphours));
                        break;
                    case 3:
                        foreach(Employee s in Employees)
                        {
                            Console.WriteLine(s.NameOutput() + " | " + s.IDOutput() + " | " + s.AgeOutput() + " | " + s.CalculatePay() + "\n");

                        }
                        Console.WriteLine("Total payout here");
                        break;
                }
            }
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
            return "Name: " + Lastname + ", " + Firstname;
        }
        public string AgeOutput()
        {
            return "Age: " + Age;
        }
        public string IDOutput()
        {
            return "Employee ID: " + EmployeeID;
        }
        public string CalculatePay()
        {
            return "Pay: $" + CalculatedPay;
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
