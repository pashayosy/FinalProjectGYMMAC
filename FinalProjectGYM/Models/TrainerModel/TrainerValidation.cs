using System;
namespace FinalProjectGYM.Models.TrainerModel
{
	public static class TrainerValidation
	{
		public static bool IsCorrectBankName(string bankName)//check is the bank name correct
		{
			foreach (char letter in bankName)
			{
				if (!char.IsLetter(letter))
				{
					Console.WriteLine("wrong name of bank, please try again.");
					return false;
				}
			}

			return true;
		}

        public static bool IsCorrectBankBranch(string bankBranch)//check if the branch correct
        {
            foreach (char number in bankBranch)
            {
                if (!char.IsDigit(number))
                {
                    Console.WriteLine("wrong branch, please try again.");
                    return false;
                }
            }

            return true;
        }

        public static bool IsCorrectBankAccountNumber(string backAccountNumber)//check if the bank account number correct
        {
            foreach (char number in backAccountNumber)
            {
                if (!char.IsDigit(number))
                {
                    Console.WriteLine("wrong account number, please try again.");
                    return false;
                }
            }

            return true;
        }

        public static bool IsCorrectProfession(string profession)//check if the profession correct
        {
            if (profession.Length < 4)
            {
                Console.WriteLine("Invalid profession.  Minimum  4 characters in the profession. Please try again..");
                return false;
            }

            return true;
        }
    }
}

