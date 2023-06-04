namespace _04._Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            string[] passwordArray = new string[password.Length];

            for (int i = 0; i < password.Length; i++)
            {
                string singleLetter = password[i].ToString();
                passwordArray[i] = singleLetter;
            }

            bool is6To10Long = Is6To10LongPass(passwordArray);
            bool isLetterAndDigit = IsLetterAndDigitPass(passwordArray);
            bool isContaining2Num = IsContaining2NumPass(passwordArray);

            PasswordValidator(is6To10Long, isLetterAndDigit, isContaining2Num);
        }

        static bool Is6To10LongPass(string[] passwordArray)
        {
            int lenght = passwordArray.Length;

            if (lenght >= 6 && lenght <= 10)
            {
                return true;
            }

            return false;
        }
        static bool IsLetterAndDigitPass(string[] passwordArray)
        {
            string singleLetter = "";
            bool isValidPass = false;
            for (int i = 0; i < passwordArray.Length; i++)
            {
                singleLetter = passwordArray[i];
                char singleChar = char.Parse(singleLetter);
                if (singleChar >= 48 && singleChar <= 57 ||
                    singleChar >= 65 && singleChar <= 90 ||
                    singleChar >= 97 && singleChar <= 122)
                {
                    isValidPass = true;
                }
                else
                {
                    isValidPass = false;
                    break;
                }
            }

            return isValidPass;
        }
        static bool IsContaining2NumPass(string[] passwordArray)
        {
            int counter = 0;
            int output = 0;

            for (int i = 0; i < passwordArray.Length; i++)
            {
                string currentLetter = passwordArray[i];
                bool isNumber = int.TryParse(currentLetter, out output);

                if (isNumber)
                {
                    counter++;
                }
            }

            return counter >= 2;
        }
        static void PasswordValidator(bool is6To10Long, bool isLetterAndDigit, bool isContaining2Num)
        {
            if (is6To10Long && isLetterAndDigit && isContaining2Num)
            {
                Console.WriteLine("Password is valid");
            }
            if (is6To10Long == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (isLetterAndDigit == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (isContaining2Num == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
        }
    }
}