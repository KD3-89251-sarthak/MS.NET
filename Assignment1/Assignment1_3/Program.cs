namespace Assignment1_3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string value;

            do {
                Console.WriteLine("1. Add, 2.Subtract, 3.Multiply, 4.Divide");
                Console.WriteLine("Enter choice: ");
                string choice = Console.ReadLine();
                int z = Convert.ToInt32(choice);

                Console.WriteLine("Enter first number: ");
                string n1 = Console.ReadLine();

                Console.WriteLine("Enter second number: ");
                string n2 = Console.ReadLine();

                int x = Convert.ToInt32(n1);
                int y = Convert.ToInt32(n2);

                

                switch (z)
                {
                    case 1:
                        Console.WriteLine(x + y);
                        break;
                    case 2:
                        Console.WriteLine(x - y);
                        break;
                    case 3:
                        Console.WriteLine(x * y);
                        break;
                    case 4:
                        if (y == 0)
                        {
                            Console.WriteLine("Cannot divide by zero");
                        }
                        else
                        {
                        Console.WriteLine(x / y);
                        }
                        break;
                    default:
                        Console.WriteLine("invalid option");
                        break;
                }
                //Console.ReadLine();
                Console.WriteLine("Do you want to continue(y/n): ");
                value = Console.ReadLine();

            } while (value == "y" || value == "Y");
        }
    }
}

