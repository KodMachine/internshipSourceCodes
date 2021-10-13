using System;

namespace hesapMachine
{
    class Program
    {
        public double num_1 { get; set; }
        public double num_2 { get; set; }
        
        //Default Constructor
        public Program(double num_1, double num_2)
        {
            this.num_1 = num_1;
            this.num_2 = num_2;
        }

        //sumation method
        public string sum() => Convert.ToString(num_1 + num_2);
        
        //extraction method
        public string extract() => Convert.ToString(num_1 - num_2);

        //multiply method
        public string mult() => Convert.ToString(num_1 * num_2);

        //dived method
        public string div() => Convert.ToString(num_1 / num_2);

        //mod method
        public string mod() => Convert.ToString(num_1 % num_2);

        //printing menu method
        public static void printMenu()
        {
            System.Console.WriteLine("Enter 1 for +\nEnter 2 for -\nEnter 3 for *\nEnter 4 for /\nEnter 5 for %\nEnter 0 for exit");
        }

        //control method -> checks the value is double
        public static double take_double()
        {
            double num;

            //checks inpot is a deacimal or not
            while(!double.TryParse(Console.ReadLine(), out num))
            {
                System.Console.Write("Wrong input!! Enter a double number : ");
            }
            return num;
        }

        static void Main(string[] args)
        {
            Program p;
            double num_1, num_2;
            int num1, num2;
            string my_operator ;

            //endles loop
            while(true)
            {
                printMenu();

                //takes menu option input
                my_operator = Console.ReadLine();

                switch(my_operator)
                {
                    case "1":
                        System.Console.Write("Enter first double number : ");
                        num_1 = take_double();
                
                        System.Console.Write("Enter second double number : ");
                        num_2 = take_double();

                        p = new Program(num_1, num_2);
                        System.Console.WriteLine(num_1 + " + " + num_2 + " = " + p.sum());
                    break;
                    
                    case "2":
                        System.Console.Write("Enter first double number : ");
                        num_1 = take_double();
                
                        System.Console.Write("Enter second double number : ");
                        num_2 = take_double();

                        p = new Program(num_1, num_2);
                        System.Console.WriteLine(num_1 + " - " + num_2 + " = " + p.extract());
                    break;

                    case "3":
                        System.Console.Write("Enter first double number : ");
                        num_1 = take_double();
                
                        System.Console.Write("Enter second double number : ");
                        num_2 = take_double();

                        p = new Program(num_1, num_2);
                        System.Console.WriteLine(num_1 + " * " + num_2 + " = " + p.mult());
                    break;

                    case "4":
                        System.Console.Write("Enter first double number : ");
                        num_1 = take_double();
                
                        System.Console.Write("Enter second double number : ");
                        
                        //endless loop for checks the second number not equal to zero
                        while(true)
                        {
                            num_2 = take_double();
                            if(num_2 == 0)
                                System.Console.WriteLine("Second number can not equal to 0");
                            else    { break; }
                        }

                        p = new Program(num_1, num_2);
                        System.Console.WriteLine(num_1 + " / " + num_2 + " = " + p.div());
                    break;

                    case "5":
                        while(true)
                        {
                            System.Console.Write("Enter first integer number : ");
                            
                            //checks the input is an integer
                            while(!int.TryParse(Console.ReadLine(), out num1))
                            {
                                System.Console.Write("Wrong input!! Enter an integer : ");
                            }

                            //checks the input less than zero
                            if(num1 < 0)
                                System.Console.WriteLine("Numbers can not less than 0!");
                            else    { break; }
                        }
                        while(true)
                        {
                            System.Console.Write("Enter second integer number : ");

                            //checks the input is an integer
                            while(!int.TryParse(Console.ReadLine(), out num2))
                            {
                                System.Console.Write("Wrong input!! Enter an integer : ");
                            }

                            //checks the input less than or equal to zero
                            if(num2 <= 0)
                                System.Console.WriteLine("Numbers can not less than or equal to 0!");
                            else    { break; }
                        };

                        p = new Program(num1, num2);
                        System.Console.WriteLine(num1 + " % " + num2 + " = " + p.mod());
                    break;

                    case "0":
                        //if input equal to zero than exit
                        Environment.Exit(0);
                    break;

                    default:
                        //checks input value different from wanted value
                        System.Console.WriteLine("Invalid menu option!");
                    break;
                }
            }
        }
    }
}