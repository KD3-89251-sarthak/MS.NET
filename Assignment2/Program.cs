namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Student student = new Student();
            
            student.AcceptDetails();

            student.Print();
        }
    }

    public struct Student
    {
        private static string _Name;
        private static bool _IsMale;
        private static int _Age;
        private static int _Std;
        private static char _Div;
        private static double _Marks;

        public double Marks
        {
            get { return _Marks; }
            set { _Marks = value; }
        }


        public char Div
        {
            get { return _Div; }
            set { _Div = value; }
        }


        public int Std
        {
            get { return _Std; }
            set { _Std = value; }
        }


        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }


        public bool IsMale
        {
            get { return _IsMale; }
            set { _IsMale = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public void Print()
        {
            Console.WriteLine(Name + " " + IsMale + " " + Age + " " + Std + " " + Div + " " + Marks);
        }

        public void AcceptDetails()
        {
            

            Console.WriteLine("Enter Name: ");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Gender: ");
            char g = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();
            IsMale = (g == 'M');

            Console.WriteLine("Enter Age: ");
            Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Std: ");
            Std = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Div: ");
            Div = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter Marks");
            Marks = double.Parse(Console.ReadLine());
        }
    }
}
