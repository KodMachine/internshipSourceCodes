using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_1_SırketUygulaması
{
    class Employee : Company
    {
        private string name { get; set; }
        private string phoneNumber { get; set; }
        private int salary { get; set; }
        private string workingPeriod { get; set; }
        private string employeeDepartment { get; set; }

        //default constructor
        public Employee()
        {
            name = "";
            phoneNumber = "";
            salary = 0;
            workingPeriod = "";
            employeeDepartment = Convert.ToString(Department.Engineering);
        }

        //overloaded constructor
        public Employee(string name, string phoneNumber, int salary, string workingPeriod)
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.salary = salary;
            this.workingPeriod = workingPeriod;
            employeeDepartment = Convert.ToString(Department.Engineering);
        }

        //overideded print working period
        public override void printWorkingPeriod()
        {
            Console.WriteLine("Engineer Shifts : " + workingPeriod );
        }

        public void printInfo() 
        {
            Console.WriteLine("\nCompany Name : " + compName + 
                                "\nEmployee department : " + employeeDepartment + 
                                "\nName : " + name + 
                                "\nPhone Number : " + phoneNumber + 
                                "\nSalary : " + salary);
        }
    }
}
