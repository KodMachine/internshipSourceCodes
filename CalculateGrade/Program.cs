using System;

namespace CalculateGrade
{
    class GradeAndPrecent : Exception
    {
        public GradeAndPrecent(string message) : base(message)
        { }
    }

    class PercentageFull : Exception 
    {
        public PercentageFull(string message) : base(message) 
        { }
    }

    class Program
    {
        public int    enteredGrade      { get; set; }
        public int    enteredPercents   { get; set; }
        public int    sumOfPercents     { get; set; }
        public double sumOfAverages     { get; set; }
        public string nameOfLesson      { get; set; }
        public int    numberOfGrades    { get; set; }
        public int    NumberOfPercents  { get; set; }
        public bool   flag              { get; set; }

        //default constructor
        public Program() 
        {
            enteredGrade    =  0;
            enteredPercents =  0;
            sumOfPercents   =  0;
            sumOfAverages   =  0;
            nameOfLesson    = "";
            numberOfGrades  =  0;
            flag            = false;
        }

        //checks input is a int or not
        public static int take_int()
        {
            int grade;

            while (!int.TryParse(Console.ReadLine(), out grade))
            {
                System.Console.Write("Wrong input!! Enter an integer number : ");
            }
            return grade;
        }

        public int numberOfLessons() 
        {
            int lessons;
            bool succes = false;
            while (true) 
            {
                lessons = take_int();
                try
                {
                    if (lessons <= 0)
                        throw new GradeAndPrecent("Number of lessons must more than 0!");
                    succes = true;
                }
                catch (GradeAndPrecent gradeAndPercent)
                {
                    Console.WriteLine(gradeAndPercent.Message);
                }
                if (succes)
                    break;
                else 
                {
                    Console.Write("Enter a proper number for lessons : ");
                }
            }
            return lessons;
        }

        //checks grade less tahn 0 or more tahn 100
        public int betweenBounds() 
        {
            int  grade   =     0;
            bool succes1 = false;
            bool succes2 = false;
            while (true)
            {
                grade = take_int();
                try
                {
                    if (grade > 100)
                        throw new GradeAndPrecent("Grade must less than or equal to 100!");
                    succes1 = true;

                }catch(GradeAndPrecent gradeAndPercent)
                {
                    Console.WriteLine(gradeAndPercent.Message);
                }

                try
                {
                    if(grade < 0)
                        throw new GradeAndPrecent("Grade must more than or equal to 0!");
                    succes2 = true;
                }
                catch(GradeAndPrecent gradeAndPercent)
                {
                    Console.WriteLine(gradeAndPercent.Message);
                }

                //found any exception
                if (succes1 && succes2)
                    break;
                else 
                {
                    succes1 = false;
                    succes2 = false;
                    Console.Write("Enter a proper grade : ");
                }

            }
            return grade;
        }

        //checks the percent more than 100 or less than 0 or more than remaining percent
        public int checkPercent() 
        {
            int percent = 0;
            bool succes1 = false;
            bool succes2 = false;
            bool succes3 = false;
            while (true)
            {
                percent = take_int();

                try
                {
                    if(percent > 100)
                        throw new GradeAndPrecent("percent must less than or equal to 100!");
                    succes1 = true;
                }catch(GradeAndPrecent gradeAndPrecent)
                {
                    Console.WriteLine(gradeAndPrecent.Message);
                }

                try
                {
                    if(percent <= 0)
                        throw new GradeAndPrecent("percent must more than 0!");
                    succes2 = true;
                }catch(GradeAndPrecent gradeAndPercent)
                {
                    Console.WriteLine(gradeAndPercent.Message);
                }

                try
                {
                    int tmpSumOfPercent = sumOfPercents + percent;
                    if((100 - tmpSumOfPercent) < 0)
                        throw new GradeAndPrecent("Summation of percents must equal to 100! Remaining percent is " + remainingPercent() + "!");
                    succes3 = true;
                }catch(GradeAndPrecent gradeAndPercent)
                {
                    Console.WriteLine(gradeAndPercent.Message);
                }

                if (succes1 && succes2 && succes3)
                {
                    try
                    {
                        if (NumberOfPercents > (100 - (sumOfPercents + percent)))
                            throw new GradeAndPrecent("Percent is already full!");
                    }
                    catch (GradeAndPrecent gradeAndPercent)
                    {
                        Console.WriteLine(gradeAndPercent.Message);
                        flag = true;
                        return percent;
                    }
                    break;
                }

                else
                {
                    succes1 = false;
                    succes2 = false;
                    succes3 = false;
                    Console.Write("Enter a proper percent : ");
                }
            }
            return percent;
        }


        //calculates sumOfAverages
        public double calculateSumOfAverages(int grade, int percent) 
        {
            sumOfAverages += (grade * percent / 100.0);
            return sumOfAverages;
        }

        // calculates the remaning percent
        public int remainingPercent() 
        {
            return (100 - sumOfPercents);
        }

        //takes grades and percents in a for loop
        public void takeGradeAndPercent() 
        {
            NumberOfPercents = numberOfGrades;
            for(int i = 0; i < numberOfGrades; i++)
            {
                NumberOfPercents--;
                Console.Write("Enter your grade number " + (i + 1) + " : ");
                enteredGrade = betweenBounds();
                if (numberOfGrades - 1 != i)
                {
                    Console.Write("Enter your percent number " + (i + 1) + " : ");
                    enteredPercents = checkPercent();
                }
                else
                {
                    enteredPercents = remainingPercent();
                }

                if (flag)
                    break;

                calculateSumOfAverages(enteredGrade, enteredPercents);
                sumOfPercents += enteredPercents;
            }
        }

        //prints letter grades
        public void printGrades()
        {
            if(sumOfAverages >= 90)
                Console.WriteLine("Letter grade AA passed");
            else if(sumOfAverages < 90 && sumOfAverages >= 85)
                Console.WriteLine("Letter grade BA passed");
            else if(sumOfAverages < 85 && sumOfAverages >= 80)
                Console.WriteLine("Letter grade BB passed");
            else if(sumOfAverages < 80 && sumOfAverages >= 75)
                Console.WriteLine("Letter grade CB passed");
            else if(sumOfAverages < 75 && sumOfAverages >= 65)
                Console.WriteLine("Letter grade CC passed");
            else if(sumOfAverages < 65 && sumOfAverages >= 58)
                Console.WriteLine("Letter grade DC failed");
            else if(sumOfAverages < 58 && sumOfAverages >= 50)
                Console.WriteLine("Letter grade DD failed");
            else if(sumOfAverages < 50 && sumOfAverages >= 40)
                Console.WriteLine("Letter grade FD failed");
            else 
            {
                Console.WriteLine("Letter grade FF failed");
            }
        }


        static void Main(string[] args)
        {
            string option = "";

            //endless loop
            while (true) 
            {
                Console.WriteLine("Enter H for calculate grade\nEnter E for exit");
                option = Console.ReadLine();
                option = option.ToUpper();

                switch (option) 
                {
                    case "H":
                        //endless loop for check persents equal to 100
                        while (true)
                        {
                            Program p = new Program();
                            Console.Write("Enter your lessons name : ");
                            p.nameOfLesson = Console.ReadLine();
                            Console.Write("How many grade you will enter : ");
                            p.numberOfGrades = p.numberOfLessons();
                            p.takeGradeAndPercent();

                            if (p.sumOfPercents != 100 || p.flag)
                            {
                                Console.WriteLine("Calculations are not true\n!Recalculate starded! ");
                            }
                            else
                            {
                                p.printGrades();
                                break;
                            }
                        }
                    break;

                    case "E":
                        //exit
                        Environment.Exit(0);
                    break;

                    default:
                        Console.WriteLine("Wrong input!");
                    break;
                }
            }
        }
    }
}
