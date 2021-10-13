using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_1_SırketUygulaması
{
    public abstract class Company
    {
        public string compName { get; set; }

        public Company()
        {
            compName = " OdakGIS";
        }

        public Company(string compName)
        {
            this.compName = compName;
        }

        public enum Department
        {
            Engineering,
            Manegement,
            Servant,
        }

        public Department department { get; set; }

        public virtual void printWorkingPeriod() 
        {
            Console.WriteLine("Starting shift at 8 am - Ending shift 6 pm");
        }

        public void printInfo() 
        {
            Console.WriteLine("Company name : " + compName);
        }
    }
}
