using System;
namespace FinalProjectGYM.Models.PersonModel
{
	public static class PersonValidation
	{
		public static bool IsCorrectId(string id)//check if the id correct
		{
			if (id.Length != 9)
			{
				Console.WriteLine("Don't forget to put 9 digits and use only numbers!");
                return false;
            }

			foreach (char letter in id)
			{
				if (!char.IsDigit(letter))
				{
					Console.WriteLine("You entered a wrong ID number, please try again!");
                    return false;
                }
			}

			return true;
		}

		public static bool IsCorrectName(string name)//check if the name or the last name is correct
		{
			if (name.Length == 0)
			{
				Console.WriteLine("Don't forget to put more than 0 characters!");
                return false;
            }

			foreach (char letter in name)
			{
				if (!char.IsLetter(letter))
				{
					Console.WriteLine("You entered an invalid first name, please try again!");
					return false;
				}
			}

			return true;
		}

        public static bool IsCorrectLastName(string lastName)//check if the name or the last name is correct
        {
            if (lastName.Length == 0)
            {
                Console.WriteLine("Don't forget to put more than 0 characters!");
                return false;
            }

            foreach (char letter in lastName)
            {
                if (!char.IsLetter(letter))
                {
                    Console.WriteLine("You entered an invalid last name, please try again!");
                    return false;
                }
            }

            return true;
        }

        public static bool IsCorrectGender(string gender)//check if the gender is correct
		{
			if (gender.Length == 1 && (char.ToLower(gender[0]) == 'm' || char.ToLower(gender[0]) == 'f' || char.ToLower(gender[0]) == 'o'))
				return true;

            Console.WriteLine("\"You entered an unknown character for gender, please try again!”\n“Remember you can use only this options: F , M, O.\"");
            return false;
        }

		public static bool IsCorrectDateOfBirth(string date)//check if the date is correct
		{
			if (date.Length != 10)
			{
				Console.WriteLine("You entered an invalid date of birth. Please input your date of birth in the following manner: XX(day)/XX(month)/XXXX(year) with the input being ONLY numbers..");
				return false;
			}

			int counterForwardSlash = 0;
			for (int i = 0; i < date.Length; i++)
			{
				if (date[i] == '/')
                    counterForwardSlash++;

            }

			if (counterForwardSlash != 2)
            {
                Console.WriteLine("You entered an invalid date of birth. Please input your date of birth in the following manner: XX(day)/XX(month)/XXXX(year) with the input being ONLY numbers.. ");
                return false;
            }

            int day;
			int month;
			int year;

			bool isCorrect = ParseDate(date, out day, out month, out year);//for later user to add date number validation

			if (isCorrect)
			{
				return true;
			}
			
            Console.WriteLine("You entered an invalid date of birth. Please input your date of birth in the following manner: XX(day)/XX(month)/XXXX(year) with the input being ONLY numbers..");
            return false;

        }

        private static bool ParseDate(string date, out int day,out int month, out int year)//parse the date to 3 ints because the size is define and will not be changed
        {
			bool isCorrect;

			date = date.Replace("/", "");
			isCorrect = int.TryParse(date.Substring(0, 2), out day);
			isCorrect &= int.TryParse(date.Substring(2, 2), out month);
			isCorrect &= int.TryParse(date.Substring(4, 4), out year);

			return isCorrect;
        }

		public static bool IsCorrectCity(string city)//check if the city is correct
		{
			foreach(char letter in city)
			{
				if (!char.IsLetter(letter))
				{
					Console.WriteLine("You enter unknown characters for 'city', please try again!");
					return false;
				}
			}

			return true;
		}

		public static bool IsCorrectAddress(string address)//check if the address is correct
		{
			if (address.Length > 0)
				return true;

            Console.WriteLine("Don't forget to put more than 0 characters!");
            return false;
        }

		public static bool IsCorrectPhone(string phone)//check if the phone correct
		{
			if (phone.Length == 0)
			{
				Console.WriteLine("You enter empty phone number");
				return false;
			}

			if (phone[0] != '0')
			{
				Console.WriteLine("don't forget to use only numbers and start with 0.");
                return false;
			}

			foreach(char number in phone)
			{
				if(!char.IsDigit(number))
				{
					Console.WriteLine("You enter wrong phone, please try again!");
					return false;
				}
			}

			return true;

		}

		public static bool IsCorrectEmail(string email)//chekc if the email correct
		{
			if (email.Contains('@'))
			{
				return true;
			}
			
            Console.WriteLine("You enter wrong email, please try again!\ndon't forget to use @ .");
            return false;
        }
	}
}

