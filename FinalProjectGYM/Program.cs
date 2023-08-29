using FinalProjectGYM.Models;
using System.Globalization;

namespace FinalProjectGYM;

class Program
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");//fix the bug with double.TryParse that not working with numbers like {0.2,1.5}
        Menu.MenuInteraction();
        Console.ReadLine();
    }
}

