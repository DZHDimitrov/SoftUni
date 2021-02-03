using System;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool letterAndDigit = CheckIfLettersAndDigits(password);
            bool areTwoletters = CheckIfThereAreTwoDigits(password);
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!letterAndDigit)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!areTwoletters)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if ((password.Length >= 6 && password.Length <= 10) && letterAndDigit && areTwoletters)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool CheckIfLettersAndDigits(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsLetterOrDigit(text[i]))
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckIfThereAreTwoDigits(string text)
        {
            int counter = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    counter++;
                }
            }
            if (counter < 2)
            {
                return false;
            }
            return true;
        }
    }
}
