using System;

namespace MemoryCardGame
{
    class OutOFBounds : Exception
    {
        public OutOFBounds(string Message) : base(Message) 
        { }
    }
    class AlreadyOpen : Exception
    {
        public AlreadyOpen(string Message) : base(Message)
        { }
    }
    class AlreadyChoosen : Exception
    {
        public AlreadyChoosen(string Message) : base(Message)
        { }
    }

    class Program
    {
        public char[] arrCards = new char[16];
        public bool[] arrIs_Open = new bool[16];
        public char[] arrChar  = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        public int firstCard;
        public static Random rand;

        public Program()
        {
            firstCard = 0;
            rand = new Random();
            randomFill();
        }

        //randomly fills cards array
        public void randomFill() 
        {
            arrCards[0] = arrChar[rand.Next(8)];

            for (int i = 1; i < 16; i++)
            {
                again:
                int tmp = rand.Next(8);
                int count = 0;
                for (int j = 0; j < i; j++)
                {
                    if (arrCards[j].Equals(arrChar[tmp]))
                        count++;
                    if (count == 2)
                        goto again;
                }

                arrCards[i] = arrChar[tmp]; 
            }
        }

        //prints current cards
        public void findCards(int firstCard, int secondCard) 
        {
            for (int i = 0; i < 9; i++)
            {
                if(i % 4 == 0 && i != 0)
                    Console.WriteLine("| ");
                if (arrIs_Open[i])
                    Console.Write("| " + arrCards[i] + " ");
                else if (firstCard == i + 1 || secondCard == i + 1)
                    Console.Write("| " + arrCards[i] + " ");

                else
                {
                    Console.Write("| " + (i + 1) + " ");
                }
                
            }

            for (int i = 9; i < 16; i++)
            {
                if (i % 4 == 0)
                    Console.WriteLine("|");
                if (arrIs_Open[i])
                    Console.Write("| " + arrCards[i] + " ");
                else if (firstCard == i + 1 || secondCard == i + 1)
                    Console.Write("| " + arrCards[i] + " ");
                else
                {
                    Console.Write("| " + (i + 1));
                }
            }
            Console.WriteLine("|");

            if (arrCards[firstCard - 1].Equals(arrCards[secondCard - 1])) 
            {
                arrIs_Open[firstCard - 1] = true;
                arrIs_Open[secondCard - 1] = true;
            }
        }

        //prints cards situation
        public void printCards() 
        {
            for(int i = 0; i < 9; i++) 
            {
                if(i % 4 == 0 && i != 0)
                    Console.WriteLine("| ");
                if(arrIs_Open[i])
                    Console.Write("| " + arrCards[i] + " ");
                else
                {
                    Console.Write("| " + (i + 1) + " ");
                }
            }

            for (int i = 9; i < 16; i++)
            {
                if (i % 4 == 0 )
                    Console.WriteLine("|");
                if (arrIs_Open[i])
                    Console.Write("| " + arrCards[i] + " ");
                else
                {
                    Console.Write("|" + (i + 1) + " ");
                }
            }
            Console.WriteLine("|");
        }

        //checks input is a integer or not
        public static int take_int()
        {
            int num;

            while (!int.TryParse(Console.ReadLine(), out num))
            {
                System.Console.Write("Wrong input!! Enter an integer number : ");
            }
            return num;
        }

        public int checkInput() 
        {
            int tmp;
            bool success1 = false;
            bool success2 = false;
            bool success3 = false;

            while (true)
            {
                jump:
                tmp = take_int();

                try
                {
                    if (tmp <= 0 || tmp > 16)
                        throw new OutOFBounds("Input must between 1 to 16 !");
                    success1 = true;
                }
                catch (OutOFBounds outOfBounds)
                {
                    Console.WriteLine(outOfBounds.Message);
                    Console.Write("Enter a proper integer : ");
                    goto jump;
                }

                try 
                {
                    if (arrIs_Open[tmp - 1])
                        throw new AlreadyOpen("This card is already open!");
                    success2 = true;
                }
                catch (AlreadyOpen alreadyOpen)
                {
                    Console.WriteLine(alreadyOpen.Message);
                }

                try 
                {
                    if (firstCard != 0 && tmp == firstCard)
                        throw new AlreadyChoosen("This card has choosen at first!");
                    success3 = true;
                }
                catch (AlreadyChoosen alreadyChoosen) 
                {
                    Console.WriteLine(alreadyChoosen.Message);
                }

                if (success1 && success2 && success3)
                    return tmp;
                else 
                {
                    success1 = false;
                    success2 = false;
                    success3 = false;
                    Console.Write("Enter a proper input : ");
                }
            }
        }

        public bool is_allCardsOpen(int index) 
        {
            if(index == 15)
                return arrIs_Open[15];
           
            return arrIs_Open[index] && is_allCardsOpen(index + 1);
             
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            int firstCard;
            int secondCard;
            int count = 0;
            DateTime start = DateTime.Now;

            while (!p.is_allCardsOpen(0)) 
            {
                p.printCards();
                
                Console.Write("Enter first card : ");
                firstCard = p.checkInput();
                p.firstCard = firstCard;
                
                Console.Write("Enter second cars : ");
                secondCard = p.checkInput();
                Console.WriteLine();

                p.findCards(firstCard, secondCard);
                p.firstCard = 0;
                Console.WriteLine();
                count++;

            }
            Console.WriteLine("Making move : " + count);
            Console.WriteLine("Time : " + (DateTime.Now - start));

        }
    }
}
