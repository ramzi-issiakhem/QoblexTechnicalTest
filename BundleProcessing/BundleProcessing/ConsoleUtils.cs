using System;



namespace App
{
    class ConsoleUtils
    {
        public static string GetNonEmptyStringInput(string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();

            while (string.IsNullOrEmpty(value))
            {
                Console.WriteLine("Input Invalid: Empty Value or no value Sent");
                value = Console.ReadLine();
            };
            return value;
        }
        

        public static bool GetBooleanValue(string message)
        {
            Console.WriteLine(message);
            char value = Console.ReadKey().KeyChar; 

            while (value != 'Y' && value != 'N')
            {
                Console.WriteLine("\nInput Invalid: Enter either Y for Yes, or N for No");
                value = Console.ReadKey().KeyChar; 
            }

            return value == 'Y';
        }
        

        public static int GetPositiveNumberInput(string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            int numberValue;

            while (!int.TryParse(value, out numberValue) || (numberValue <= 0))
            {
                Console.WriteLine("Invalid Number: Non Number value input or NonPositive Number");
                value = Console.ReadLine();
            };
            return numberValue;
        }

        public static int GetNonNegativeNumberInput(string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine();
            int numberValue;

            while (!int.TryParse(value, out numberValue) || (numberValue < 0))
            {
                Console.WriteLine("Invalid Number: Non Number value input or Negative Number");
                value = Console.ReadLine();
            };
            return numberValue;
        }

        internal static void displaySeparator()
        {
            Console.WriteLine("----------------------------------------------------");
        }
    }

}