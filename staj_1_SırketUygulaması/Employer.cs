using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_1_SırketUygulaması
{
    class Employer : Company, ItoEmploy
    {
        private string name { get; set; }
        private string phoneNumber { get; set; }
        private int salary { get; set; }
        private string workingPeriod { get; set; }
        private string employerDepartment { get; set; }

        //default constructor
        public Employer() 
        {
            name = "";
            phoneNumber = "";
            salary = 0;
            workingPeriod = "";
            employerDepartment = Convert.ToString(Department.Manegement);
        }
        
        //overloaded constructor
        public Employer(string name, string phoneNumber, int salary, string workingPeriod) 
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.salary = salary;
            this.workingPeriod = workingPeriod;
            employerDepartment = Convert.ToString(Department.Manegement);
        }

        //overideded print working period
        public override void printWorkingPeriod() 
        {
            Console.WriteLine("Manager Shifts : " + workingPeriod);
        }

        //an ability to create worker
        public Worker createWorker()
        {
            Worker newWorker = new Worker("Yazgi", "01234567890", 2200,"10AM - 4PM", this.name);
            return newWorker;
        }

        public void printInfo()
        {
            Console.WriteLine("\nCompany Name : " + compName +
                                "\nEmployer department : " + employerDepartment +
                                "\nName : " + name +
                                "\nPhone Number : " + phoneNumber +
                                "\nSalary : " + salary);
        }
    }
}
