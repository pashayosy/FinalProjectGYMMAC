using System;
namespace FinalProjectGYM.Models.ClientModel
{
	public static class ClientValidation
	{
		public static bool IsCorrectHeight(string height)
		{
			if (double.TryParse(height, out double h))
				return true;

            Console.WriteLine("you enter wrong height , please try again!");
            return false;
        }

		public static bool IsCorrectWeight(string weight)
		{
            if (double.TryParse(weight, out double h))
                return true;

            Console.WriteLine("you enter wrong weight , please try again!");
            return false;
        }

	}
}

