using System;

namespace staj_1_SırketUygulaması
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Can", "012323445567", 4000, " Starts at 8 am - Ends at 6 pm ");
            Employer employer = new Employer("irem", "01233455678", 7000, " Starts at 8 an - Ends at 6 pm ");
            Worker worker = new Worker();
            employee.printInfo();
            employee.printWorkingPeriod();

            employer.printInfo();
            employer.printWorkingPeriod();
            worker = employer.createWorker();

            worker.printInfo();

        }
    }
}
