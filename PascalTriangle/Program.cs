using System;

namespace PascalTriangle
{
    class IterationNotPositive : Exception
    {
        public IterationNotPositive(string Message) : base(Message) 
        { }
    }

    class Program
    {
        public Program() 
        {}

        public void printPascal(int size)
        {
            for(int i = 0; i < size; i++) 
            {
                int tmp = 1;

                for(int k = size - i; k > 0; k--)
                {
                    Console.Write(" ");
                }

                for(int j = 0; j < i + 1; j++) 
                {
                    if(j == 0 || j == i)
                        Console.Write("1 ");
                    else 
                    {
                        tmp = tmp * (i - j + 1) / j;
                        Console.Write(tmp + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public static int take_int()
        {
            int num;

            //checks inpot is a integer or not
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                System.Console.Write("Wrong input!! Enter an integer number : ");
            }
            return num;
        }

        public int takePositiveİteration() 
        {
            int num  = 0;
            bool is_catch = true;
            while (is_catch)
            {
                num = take_int();
                try 
                {
                    if (num <= 0)
                        throw new IterationNotPositive("Iteration must be a positive number!");
                    is_catch = false;
                } catch (IterationNotPositive iterationNotPositive) 
                {
                    Console.WriteLine(iterationNotPositive.Message);
                    Console.Write("Enter an positive integer : ");
                }
            }
            return num;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            int input;
            Console.Write("Enter the iteration number : ");
            input = p.takePositiveİteration();
            p.printPascal(input);
        }
    }
}
