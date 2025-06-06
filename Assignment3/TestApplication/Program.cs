using System.Reflection;

namespace TestApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "F:\\Disk HDD (H)\\netPractice\\Assignment3\\MathLib\\bin\\Debug\\net8.0\\MathLib.dll";
            
            Assembly assembly = Assembly.LoadFrom(path);

            Type type = assembly.GetType("MathLib.Maths");

            object mathObj =  assembly.CreateInstance(type.FullName);

            while (true)
            {
                Console.WriteLine("-------------Menu-----------");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Add Method");
                Console.WriteLine("2. Sub Method");
                Console.WriteLine("3. Mul Method");
                Console.WriteLine("4. Div method");
                Console.WriteLine("------------------------");
                Console.WriteLine("Enter the choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                if(choice == 0)
                {
                    break;
                }
                if(choice != 1 && choice != 2 && choice != 3 && choice != 4)
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }

                try
                {
                    string methodName = ""; 
                    switch (choice)
                    {
                        case 1:
                            methodName += "Sum";
                            break;
                        case 2:
                            methodName += "Sub"; 
                            break;
                        case 3:
                            methodName += "Mul";
                            break;
                        case 4:
                            methodName += "Div";
                            break;
                        default:
                            break;
                    }

                    MethodInfo method = type.GetMethod(methodName);
                    Console.WriteLine("Calling {0} - ", method.Name);

                    ParameterInfo[] parameters = method.GetParameters();
                    object[] input = new object[parameters.Length];

                    for(int i = 0; i < parameters.Length; i++)
                    {
                        ParameterInfo parameter = parameters[i]; 
                        Console.WriteLine("Please provide of {0} type for {1}", parameter.Name, parameter.GetType());

                        input[i] = Convert.ChangeType(Console.ReadLine(), parameter.ParameterType);
                        Console.WriteLine();
                    }

                    object result = type.InvokeMember(
                        methodName,
                        BindingFlags.Public |
                        BindingFlags.Instance |
                        BindingFlags.InvokeMethod,
                        null,
                        mathObj,
                        input);

                    Console.WriteLine("Result of {0} is {1}",
                        methodName, result);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ;
            }
            Console.WriteLine("Thank you :)");
        }
    }
}
