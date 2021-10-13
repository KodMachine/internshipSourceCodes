using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_1_SırketUygulaması
{
    class Worker : Employer
    {

        private string name { get; set; }
        private string phoneNumber { get; set; }
        private int salary { get; set; }
        private string workingPeriod { get; set; }
        private string workerDepartment { get; set; }
        private string hiredBy { get; set; }

        //default constructor
        public Worker()
        {
            name = "";
            phoneNumber = "";
            salary = 0;
            workingPeriod = "";
            workerDepartment = Convert.ToString(Department.Servant);
            hiredBy = "";
        }

        //overloaded constructor
        public Worker(string name, string phoneNumber, int salary, string workingPeriod, string hiredBy) 
        {
            this.name = name;
            this.phoneNumber = phoneNumber;
            this.salary = salary;
            this.workingPeriod = workingPeriod;
            workerDepartment = Convert.ToString(Department.Servant);
            this.hiredBy = hiredBy;
        }

        public void printInfo()
        {
            Console.WriteLine("\nCompany Name : " + compName +
                                "\nEmployee department : " + workerDepartment +
                                "\nName : " + name +
                                "\nPhone Number : " + phoneNumber +
                                "\nSalary : " + salary +
                                "\nWorking Shifts : " + workingPeriod);
            if(hiredBy != "") 
            {
                Console.WriteLine("Hired By : " + hiredBy);
            }
        }
    }
}
