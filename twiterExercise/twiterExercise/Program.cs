using System;

namespace twiterExercise
{
    class Program
    {
        static void RectangularTower()
        {
            Console.WriteLine("Tap Height and Width (height must be at least 2)");
            float heigth = float.Parse(Console.ReadLine());
            float width = float.Parse(Console.ReadLine());
            while (heigth < 2.0)
            {
                Console.WriteLine("Typo, height must be at least 2");
                heigth = float.Parse(Console.ReadLine());
            }
              
            while (width <= 0.0)
            {
                Console.WriteLine("Typo, can't have a negative width or equal to zero");
                width = float.Parse(Console.ReadLine());
            }
            //Is it a square or a rectangle with the difference between the lengths of its sides
            //Greater than 5, then its area will be printed. Otherwise its scope will be printed.
            float resulte = Math.Abs(heigth - width) > 5 ? heigth * width : 2 * (heigth + width);
            Console.WriteLine("the resulte: {0}", resulte);
        }
        static void TriangleTower()
        {
            Console.WriteLine("Tap Height and Width");
            int heigth = Convert.ToInt32(Console.ReadLine());
            int width = Convert.ToInt32(Console.ReadLine());
            while (heigth < 2.0)
            {
                Console.WriteLine("Typo, can't have a negative heigth or equal to zero");
                heigth = Convert.ToInt32(Console.ReadLine());
            }

            while (width <= 0.0)
            {
                Console.WriteLine("Typo, can't have a negative width or equal to zero");
                width = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Tap the option you want\n1.Calculate the perimeter of the triangle\n2.The triangle print");
            int option =Convert.ToInt16(Console.ReadLine());
            switch (option)
            {
                case 1:
                    //Print calculate the perimeter of the triangle
                    //The Pythagorean theorem for half the width calculates one side of the legs, multiplying times 2 for 2 legs, and of course dividing and multiplying by 2 reduces
                    Console.WriteLine(width + Math.Sqrt(Math.Abs(width) + Math.Abs(heigth)));
                    break;
                case 2:
                    PrintTriangleTower(heigth,width);
                    break;                
                default:
                    Console.WriteLine("Typing error");
                    break;
            }
        }
        static void PrintTriangleTower(int heigth,int width)
        {
            if (width % 2 == 0 || width >= 2 * heigth)
                Console.WriteLine("The triangle cannot be printed");
            else
            {
                PrintRow(1,width);
                if (heigth > 2)
                {
                    int TypesRows = (1 + width) / 2-2;
                    int i;
                    for (i = heigth / 2; i > 0 &&(heigth-2)/i<TypesRows; i--) ;
                    int modulue = heigth - 2 - TypesRows * i;
                    for (int j = 0; j < modulue; j++)
                    {
                        
                        PrintRow(3, width);
                    }                    
                    int amount = 3;
                    for (int j = 0; j < TypesRows; j++)
                    {
                        for (int l = 0; l < i; l++)
                        {
                            PrintRow(amount, width);
                           
                        }
                        
                        amount += 2;
                    }
                }
                
                PrintRow(width, width);
            }
            
        }
        static void PrintRow(int amount, int width)
        {
            for (int i = 0; i < (width-amount)/2; i++)
            {
                Console.Write(" ");
            }
            for (int i = 0; i < amount; i++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }
        static void Main(string[] args)
        {
            short option = 0;
            do
            {
                Console.WriteLine("Tap the option you want\n1.Rectangular tower\n2.Triangle tower\n3.Stop the program");                
                option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RectangularTower();
                        break;
                    case 2:
                        TriangleTower();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Typing error");
                        break;
                }
            } while(option!=3);
        }
    }
}
