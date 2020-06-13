using System;
using System.Collections.Generic;

namespace payroll
{
    public class Program
    {
        public static int Main(string[] args)
        {
            int input = 0;
            List<Employee> Employees = new List<Employee>();
            while (input != 3)
            {
                Console.WriteLine("Choose from the following options:\n");
                Console.WriteLine("1.Add a salaried employee");
                Console.WriteLine("2.Add an hourly employee");
                Console.WriteLine("3.Generate report");
                input = UserInput.IntInput(Console.ReadLine());
                //old error checker before i used the UserInput class left below
                //if(!int.TryParse(Console.ReadLine(), out input))
                //{ Console.WriteLine("Please enter a valid option."); continue; }
                switch (input)
                {
                    //switch case menu options
                    case 1:
                        string tempfirst;
                        string templast;
                        int tempage;
                        int tempid;
                        decimal tempsalary;
                        Console.WriteLine("Enter the following details:");
                        Console.WriteLine("First name");
                        //tempfirst = Console.ReadLine();
                        tempfirst = UserInput.StringInput(Console.ReadLine());
                        if (tempfirst is null) continue;
                        Console.WriteLine("Last name");
                        templast = UserInput.StringInput(Console.ReadLine());
                        if (templast is null) continue;
                        Console.WriteLine("Age");
                        tempage = UserInput.IntInput(Console.ReadLine());
                        if (tempage == 0) continue;
                        //when the IntInput checker returns a 0 it means the input was not an int, so this skips it
                        Console.WriteLine("Employee ID");
                        tempid = UserInput.IntInput(Console.ReadLine());
                        if (tempid == 0) continue;
                        Console.WriteLine("Monthly salary");
                        tempsalary = UserInput.DecInput(Console.ReadLine());
                        if (tempsalary == 0) continue;         
                        Employees.Add(new SalariedEmployee(tempfirst, templast, tempage, tempid, tempsalary));
                        break;
                    case 2:
                        decimal temphourly;
                        decimal temphours;
                        Console.WriteLine("Enter the following details:");
                        Console.WriteLine("First name");
                        tempfirst = UserInput.StringInput(Console.ReadLine());
                        if (tempfirst is null) continue;
                        Console.WriteLine("Last name");
                        templast = UserInput.StringInput(Console.ReadLine());
                        if (templast is null) continue;
                        Console.WriteLine("Age");
                        tempage = UserInput.IntInput(Console.ReadLine());
                        if (tempage == 0) continue;
                        Console.WriteLine("Employee ID");
                        tempid = UserInput.IntInput(Console.ReadLine());
                        if (tempid == 0) continue;
                        Console.WriteLine("Hourly pay");
                        temphourly = UserInput.DecInput(Console.ReadLine());
                        if (temphourly == 0) continue;     
                        Console.WriteLine("Hours worked");
                        temphours = UserInput.DecInput(Console.ReadLine());
                        if (temphours == 0) continue;
                        Employees.Add(new HourlyEmployee(tempfirst, templast, tempage, tempid, temphourly, temphours));
                        break;
                    case 3:
                        decimal total = 0M;
                        decimal salariedtotal = 0M;
                        decimal hourlytotal = 0M;
                        foreach (Employee s in Employees)
                        {
                            //employee output loop for report
                            Console.WriteLine(s.NameOutput() + " | " + s.IDOutput() + " | " + s.AgeOutput() + " | " + s.CalculatePay() + "\n");
                            total += s.CalculatedPay;
                            if(s is SalariedEmployee)
                            {
                                salariedtotal += s.CalculatedPay;
                            } else
                            {
                                hourlytotal += s.CalculatedPay;
                            }
                        }
                        //rounding, addition, and tax outputs here
                        Console.Write("Total gross payout $" + total);
                        Console.Write(" | Net paid: $" + decimal.Round(total - (total * .265M) - (total * .0765M), 2));
                        Console.Write(" | FICA paid: $" + decimal.Round((total * .0765M), 2));
                        Console.WriteLine(" | Fed Inc Tax paid: $" + decimal.Round((total * .265M), 2) + "\n");

                        Console.Write("Total hourly payout: $" + hourlytotal);
                        Console.Write(" | Net paid: $" + decimal.Round(hourlytotal - (hourlytotal * .265M) - (hourlytotal * .0765M), 2));
                        Console.Write(" | FICA paid: $" + decimal.Round((hourlytotal * .0765M), 2));
                        Console.WriteLine(" | Fed Inc Tax paid: $" + decimal.Round((hourlytotal * .265M), 2) + "\n");

                        Console.Write("Total salaried payout: $" + salariedtotal);
                        Console.Write(" | Net paid: $" + decimal.Round(salariedtotal - (salariedtotal * .265M) - (salariedtotal * .0765M), 2));
                        Console.Write(" | FICA paid: $" + decimal.Round((salariedtotal * .0765M), 2));
                        Console.WriteLine(" | Fed Inc Tax paid: $" + decimal.Round((salariedtotal * .265M), 2));

                        break;
                }
            }
            return 0;
        }
    }
    public static class UserInput
    {
        //used to have small checks after inputs in main, but couldn't unit test them there
        //moving them here allowed me to call them in main and in my unit test
        static int input;
        static decimal decimalinput;
        public static int IntInput(string i)
        {
            if (!int.TryParse(i, out input))
            {
                Console.WriteLine("Please enter a valid option."); return 0;
                //returns a 0 if it cannot parse
            }
            else
                return input;
        }
        public static decimal DecInput(string i)
        {
            if (!decimal.TryParse(i, out decimalinput))
            {
                Console.WriteLine("Please enter a valid option."); return 0;
            }
            else
                return decimalinput;
        }
        public static string StringInput(string i)
        {
            if (decimal.TryParse(i, out decimal temp))
            {
                //if string entered is convertable to a decimal, then it likely isn't a name so this rejects it
                Console.WriteLine("Please enter a valid option."); return null;
            }
            else
            {
                return i;
            }
        }
    }
    public abstract class Employee
    {
        private string Firstname { get; set; }
        private string Lastname { get; set; }
        private int Age { get; set; }
        private int EmployeeID { get; set; }
        public decimal CalculatedPay { get; set; }
        //pay is declared within employee at first, defined in the subclasses later
        protected Employee(string Firstname, string Lastname, int Age, int EmployeeID)
        {
            //constructor
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Age = Age;
            this.EmployeeID = EmployeeID;
        }
        public string NameOutput()
        {
            //outputs to help when final report is used
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
            //additional monthly pay constructor arg
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
            //additional hours and hourly pay constructor args
            this.Hourlypay = Hourlypay;
            this.Hoursworked = Hoursworked;
            CalculatedPay = Hoursworked * Hourlypay;
        }
    }

    
}
