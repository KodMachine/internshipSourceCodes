using System;

namespace AreaAndPerimeterCalculator
{
    class BelowZero : Exception
    {
        public BelowZero(string message) : base(message)
        { }
    }
    
    class TriangleThirdEdge : Exception
    {
        public TriangleThirdEdge(string message) : base(message)
        { }
    }

    class Program
    {
        public double edge1  { get; set; }
        public double edge2  { get; set; }
        public double edge3  { get; set; }
        public double radius { get; set; }
        public double height { get; set; }

        //default constructor
        public Program()
        {
            edge1  = 0;
            edge2  = 0;
            edge3  = 0;
            radius = 0;
            height = 0;
        }

        //calculates and retuns the triangles area
        public double triangleArea() => Math.Sqrt(((edge1 + edge2 + edge3) / 2) * (((edge1 + edge2 + edge3) / 2) - edge1) * (((edge1 + edge2 + edge3) / 2) - edge2) * (((edge1 + edge2 + edge3) / 2) - edge3));

        //calculates and returns the squares area
        public double squareArea() => edge1 * edge1;

        //calculates and returns the rectangles area
        public double rectangleArea() => edge1 * edge2;

        //calcuates and returns the circles area
        public double circleArea() => Math.PI * radius * radius;

        //calculates and returns the triangles perimeter
        public double trianglePerimeter() => edge1 + edge2 + edge3;

        //calculates and returns the squares perimeter
        public double squarePerimeter() => edge1 * 4;

        //calculates and returns the rectangles perimeter
        public double rectanglePerimeter() => (edge1 + edge2) * 2;

        //calculates and returns the circles perimeter
        public double circlePerimeter() => Math.PI * radius * 2;

        //checks input is a double or not
        public static double take_double()
        {
            double num;

            while (!double.TryParse(Console.ReadLine(), out num))
            {
                System.Console.Write("Wrong input!! Enter a double number : ");
            }
            return num;
        }

        public double edgesSize() 
        {
            double edge;
            bool success = false;
            while (true) 
            {
                edge = take_double();

                try 
                {
                    if (edge <= 0)
                        throw new BelowZero("Can not enter less than or equal to zero!");
                    success = true;
                }
                catch (BelowZero belowZero) 
                {
                    Console.WriteLine(belowZero.Message);
                }
                
                if (success)
                    return edge;
                else 
                {
                    Console.Write("Enter a proper input : ");
                }
            }
        }

        public bool triangleEdges() 
        {
            double edge;
            bool success = false;
            while (true) 
            {
                edge = edgesSize();

                if (this.edge1 != 0 && this.edge2 != 0)
                {
                    try
                    {
                        if (Math.Abs(edge1 - edge2) >= edge || edge >= edge1 + edge2)
                            throw new TriangleThirdEdge("Third edge must bigger than first and second edges differences (" + Math.Abs(edge1 - edge2) +
                                                        " and lower than their summation (" + (edge1 + edge2) + ") !!");
                        success = true;
                    }catch (TriangleThirdEdge triangleThirdEdge)
                    {
                        Console.WriteLine(triangleThirdEdge.Message);
                    }
                }

                if (success) 
                {
                    edge3 = edge;
                    return true;
                }
                
                else
                {
                    Console.Write("Enter a proper edge : ");
                }
            }
        }
        
        public bool isoscelesTriangleEdges(double edge)
        {
            bool success = false;
            while (true)
            {
                try
                {
                    if (Math.Abs(edge1 - edge2) >= edge || edge >= edge1 + edge2)
                        throw new TriangleThirdEdge("This triangle is not exists : ");
                    success = true;
                }
                catch (TriangleThirdEdge triangleThirdEdge)
                {
                    Console.WriteLine(triangleThirdEdge.Message);
                }

                if (success)
                    return true;
                else
                {
                    return false;
                }
            }
        }

        static void Main(string[] args)
        {
            string option;

            while (true) 
            {
                Console.WriteLine("For calculate press 1\nFor exit press 0");
                option = Console.ReadLine();
                switch (option) 
                {
                    case "1":
                        one:
                        option = "";
                        Console.WriteLine("For calculate area press 1\nFor calculate primeter press 2");
                        option = Console.ReadLine();

                        Program p = new Program();

                        switch (option) 
                        {
                            case "1":
                                two:
                                option = "";
                                Console.WriteLine("For triangle press 1\nFor square press 2\nFor rectangle press 3\nFor circle press 4");
                                option = Console.ReadLine();

                                switch (option)
                                {
                                    case "1":
                                        three:
                                        option = "";
                                        Console.WriteLine("For equilateral triangle press 1\nFor isosceles triangle press 2\nFor scalene press 3");
                                        option = Console.ReadLine();

                                        switch (option)
                                        {
                                            case "1":
                                                Console.Write("Enter an edge : ");
                                                p.edge1 = p.edgesSize();
                                                p.edge2 = p.edge1;
                                                p.edge3 = p.edge1;
                                                Console.WriteLine("Triangles area : " + p.triangleArea());
                                                break;

                                            case "2":
                                                bool tmp = false;
                                                while (!tmp)
                                                {
                                                    Console.Write("Enter edge 1 : ");
                                                    p.edge1 = p.edgesSize();
                                                    Console.Write("Enter edge 2 : ");
                                                    p.edge2 = p.edgesSize();

                                                    four:
                                                    option = "";
                                                    Console.WriteLine("Which edge is dublicate 1 or 2 : ");
                                                    option = Console.ReadLine();

                                                    switch (option)
                                                    {
                                                        case "1":
                                                            if (p.isoscelesTriangleEdges(p.edge1))
                                                            {
                                                                p.edge3 = p.edge1;
                                                                Console.WriteLine("Triangles area : " + p.triangleArea());
                                                                tmp = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("!Restarting!");
                                                            }
                                                            break;

                                                        case "2":
                                                            if (p.isoscelesTriangleEdges(p.edge2))
                                                            {
                                                                p.edge3 = p.edge2;
                                                                Console.WriteLine("Triangles area : " + p.triangleArea());
                                                                tmp = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Restarting!");
                                                            }
                                                            break;

                                                        default:
                                                            //invalid menu option
                                                            Console.WriteLine("Invalid menu option!");
                                                            goto four;
                                                    }
                                                }
                                                break;

                                            case "3":
                                                Console.Write("Enter edge 1 : ");
                                                p.edge1 = p.edgesSize();
                                                Console.Write("Enter edge 2 : ");
                                                p.edge2 = p.edgesSize();
                                                Console.Write("Enter edge 3 : ");
                                                p.triangleEdges();
                                                Console.WriteLine(p.triangleArea());
                                                break;

                                            default:
                                                //invalid menu option
                                                Console.WriteLine("Invalid menu option!");
                                                goto three;
                                        }
                                        break;

                                        case "2":
                                            Console.Write("Enter the edge : ");
                                            p.edge1 = p.edgesSize();
                                            Console.WriteLine("Squares area : " + p.squareArea());
                                            break;

                                        case "3":
                                            Console.Write("Enter edge 1 : ");
                                            p.edge1 = p.edgesSize();
                                            Console.Write("Enter edge 2 : ");
                                            p.edge2 = p.edgesSize();
                                            Console.WriteLine("Rectangles area : " + p.rectangleArea());
                                            break;

                                        case "4":
                                            Console.Write("Enter radius : ");
                                            p.radius = p.edgesSize();
                                            Console.WriteLine("Circles area : " + p.circleArea());
                                            break;

                                        default:
                                            //invalid menu option
                                            Console.WriteLine("Invalid menu option");
                                            goto two;
                                }
                                break;

                            case "2":
                                five:
                                option = "";
                                Console.WriteLine("For triangle press 1\nFor square press 2\nFor rectangle press 3\nFor circle press 4");
                                option = Console.ReadLine();

                                switch (option)
                                {
                                    case "1":
                                        six:
                                        option = "";
                                        Console.WriteLine("For equilateral triangle press 1\nFor isosceles triangle press 2\nFor scalene press 3");
                                        option = Console.ReadLine();

                                        switch (option)
                                        {
                                            case "1":
                                                Console.Write("Enter an edge : ");
                                                p.edge1 = p.edgesSize();
                                                p.edge2 = p.edge1;
                                                p.edge3 = p.edge1;
                                                Console.WriteLine("Triangles perimeter : " + p.trianglePerimeter());
                                                break;

                                            case "2":
                                                bool tmp = false;
                                                while (!tmp)
                                                {
                                                    Console.Write("Enter edge 1 : ");
                                                    p.edge1 = p.edgesSize();
                                                    Console.Write("Enter edge 2 : ");
                                                    p.edge2 = p.edgesSize();

                                                    seven:
                                                    option = "";
                                                    Console.WriteLine("Which edge is dublicate 1 or 2 : ");
                                                    option = Console.ReadLine();
                                                    switch (option)
                                                    {
                                                        case "1":
                                                            if (p.isoscelesTriangleEdges(p.edge1))
                                                            {
                                                                p.edge3 = p.edge1;
                                                                Console.WriteLine("Triangles perimeter : " + p.trianglePerimeter());
                                                                tmp = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("!Restarting!");
                                                            }
                                                            break;

                                                        case "2":
                                                            if (p.isoscelesTriangleEdges(p.edge2))
                                                            {
                                                                p.edge3 = p.edge2;
                                                                Console.WriteLine("Triangles perimeter : " + p.trianglePerimeter());
                                                                tmp = true;
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine("Invalid triangle! Restarting!");
                                                            }
                                                            break;

                                                        default:
                                                            //invalid menu option
                                                            Console.WriteLine("Invalid menu option!");
                                                            goto seven;
                                                    }
                                                }
                                                break;

                                            case "3":
                                                Console.Write("Enter edge 1 : ");
                                                p.edge1 = p.edgesSize();
                                                Console.Write("Enter edge 2 : ");
                                                p.edge2 = p.edgesSize();
                                                Console.Write("Enter edge 3 : ");
                                                p.triangleEdges();
                                                Console.WriteLine(p.trianglePerimeter());
                                                break;

                                            default:
                                                //invalid menu option
                                                Console.WriteLine("Invalid menu option!");
                                                goto six;
                                        }
                                        break;

                                    case "2":
                                        Console.Write("Enter the edge : ");
                                        p.edge1 = p.edgesSize();
                                        Console.WriteLine("Squares perimeter : " + p.squarePerimeter());
                                        break;

                                    case "3":
                                        Console.Write("Enter edge 1 : ");
                                        p.edge1 = p.edgesSize();
                                        Console.Write("Enter edge 2 : ");
                                        p.edge2 = p.edgesSize();
                                        Console.WriteLine("Rectangles perimeter : " + p.rectanglePerimeter());
                                        break;

                                    case "4":
                                        Console.Write("Enter radius : ");
                                        p.radius = p.edgesSize();
                                        Console.WriteLine("Circles perimeter : " + p.circlePerimeter());
                                        break;

                                    default:
                                        //invalid menu option
                                        Console.WriteLine("Invalid menu option!");
                                        goto five;
                                }
                                break;

                            default:
                                //invalid menu option
                                Console.WriteLine("Invalid menu option!");
                                goto one;
                        }
                    break;

                    case "0":
                        //exit
                        Environment.Exit(0);
                    break;

                    default:
                        //invalid menu option
                        Console.WriteLine("Invalid menu option!");
                    break;
                }
            }
        }
    }
}
