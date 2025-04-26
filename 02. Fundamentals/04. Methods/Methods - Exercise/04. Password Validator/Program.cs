namespace _04._Password_Validator
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string password = Console.ReadLine();
			char[] passwordArray = new char[password.Length];

			for (int i = 0; i < password.Length; i++)
			{
				char singleLetter = password[i];
				passwordArray[i] = singleLetter;
			}

			bool hasLengthBetweenSixAndTen = HasLengthBetweenSixAndTen(passwordArray);
			bool containsOnlyLettersAndDigits = ContainsOnlyLettersAndDigits(passwordArray);
			bool hasAtLeastTwoDigits = HasAtLeastTwoDigits(passwordArray);

			PasswordValidator(hasLengthBetweenSixAndTen, containsOnlyLettersAndDigits, hasAtLeastTwoDigits);
		}

		static bool HasLengthBetweenSixAndTen(char[] passwordArray)
		{
			int length = passwordArray.Length;
			if (length >= 6 && length <= 10)
			{
				return true;
			}

			return false;
		}
		static bool ContainsOnlyLettersAndDigits(char[] passwordArray)
		{
			bool isPassValid = true;
			for (int i = 0; i < passwordArray.Length; i++)
			{
				char singleLetter = passwordArray[i];
				if (!char.IsDigit(singleLetter) &&
					!char.IsLetter(singleLetter))
				{
					isPassValid = false;
					break;
				}
			}

			return isPassValid;
		}
		static bool HasAtLeastTwoDigits(char[] passwordArray)
		{
			int counter = 0;

			for (int i = 0; i < passwordArray.Length; i++)
			{
				char currentLetter = passwordArray[i];

				if (char.IsDigit(currentLetter))
				{
					counter++;
				}
			}

			return counter >= 2;
		}
		static void PasswordValidator(bool hasLengthBetweenSixAndTen, bool containsOnlyLettersAndDigits, bool hasAtLeastTwoDigits)
		{
			if (hasLengthBetweenSixAndTen && containsOnlyLettersAndDigits && hasAtLeastTwoDigits)
			{
				Console.WriteLine("Password is valid");
			}
			if (hasLengthBetweenSixAndTen == false)
			{
				Console.WriteLine("Password must be between 6 and 10 characters");
			}
			if (containsOnlyLettersAndDigits == false)
			{
				Console.WriteLine("Password must consist only of letters and digits");
			}
			if (hasAtLeastTwoDigits == false)
			{
				Console.WriteLine("Password must have at least 2 digits");
			}
		}
	}
}