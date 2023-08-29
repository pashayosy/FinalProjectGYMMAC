using FinalProjectGYM.Models.ClientModel;
using FinalProjectGYM.Models.PersonModel;
using FinalProjectGYM.Models.TrainerModel;
using System.Text;

namespace FinalProjectGYM.Models
{
	public static class Menu
	{
        enum PERSONFUNCTION { ADD = 1, EDIT, DELETE, LIST, RETURN }
        public static int createMenu(string[]optionNames)//create menu of my choose
		{
            Console.Clear();
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Gym Application!");
            Console.ResetColor();
            Console.Write("\nUse \u2191 and \u2193 to navigate and press ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Enter");
            Console.ResetColor();
            Console.Write(" to select:\n");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            ConsoleKeyInfo key;
            bool isSelected = false;

            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);

                for (int i = 0; i < optionNames.Length; i++)
                {
                    if (option == i + 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{optionNames[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"{optionNames[i]}");
                    }
                    
                }

                key = Console.ReadKey(false);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? optionNames.Length : option - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        option = option == optionNames.Length ? 1 : option + 1;
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }
            }

            return option;
        }

        public static void MenuInteraction()//interact with the menu i create
        {
            int position;
            position = Menu.createMenu(new string[] { "Client", "Coach", "Exit" });

            switch(position)
            {
                case 1:
                    position = Menu.createMenu(new string[] { "Add Client", "Edit Client", "Delete Client", "List all Client", "Return" });
                    ClientFunctionDo(position);
                    break;
                case 2:
                    position = Menu.createMenu(new string[] { "Add Coach", "Edit Coach", "Delete Coach", "List all Coach", "Return" });
                    TrainerFunctionDo(position);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void ClientFunctionDo(int position)//start methods that the user choose
        {
            string id;
            switch (position)
            {
                case (int)PERSONFUNCTION.ADD:
                    ClientHandle.ClientCreate();
                    break;

                case (int)PERSONFUNCTION.EDIT:
                    Console.WriteLine("Please enter a exist id");
                    while (!PersonValidation.IsCorrectId(id = Console.ReadLine()) || !FileHandle.IsClientExist(id)) 
                    {
                        Console.WriteLine("The id not correct or this id isn't exist");
                    }

                    if (FileHandle.GetClientById(id).IsActive)
                    {
                        int choose = Menu.createMenu(new string[] { "Id", "Name", "Last Name", "Gender", "Date of birth", "City", "Address", "Phone", "Email", "Height", "Weight" });
                        ClientHandle.ClientEdit(choose, id);
                    }
                    else
                    {
                        Console.WriteLine("The client is In-active");
                    }
                    break;

                case (int)PERSONFUNCTION.DELETE:
                    
                    Console.WriteLine("Please enter a exist id");
                    while (!PersonValidation.IsCorrectId(id = Console.ReadLine()) || !FileHandle.IsClientExist(id)) 
                    {
                        Console.WriteLine("The id not correct or this id isn't exist");
                    }
                    FileHandle.ClientRemove(id);
                    break;

                case (int)PERSONFUNCTION.LIST:
                    Client[] clients = FileHandle.ClientListCreate();
                    if (clients != null)
                    {
                        ClientHandle.ListPrint(clients);
                    }
                    else
                    {
                        Console.WriteLine("\nThe CLient List is empty\n");
                    }
                    break;

                case (int)PERSONFUNCTION.RETURN:
                    break;
            }

            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();
            MenuInteraction();
        }

        public static void TrainerFunctionDo(int position)//start methods that the user choose
        {
            string id;
            switch (position)
            {
                case (int)PERSONFUNCTION.ADD:
                    TrainerHandle.TrainerCreate();
                    break;
                case (int)PERSONFUNCTION.EDIT:
                    Console.WriteLine("Please enter a exist id");
                    while (!PersonValidation.IsCorrectId(id = Console.ReadLine()) || !FileHandle.IsTrainerExist(id))
                    {
                        Console.WriteLine("The id not correct or this id isn't exist");
                    }
                    if (FileHandle.GetTrainerById(id).IsActive)
                    {
                        int choose = Menu.createMenu(new string[] { "Id", "Name", "Last Name", "Gender", "Date of birth", "City", "Address", "Phone", "Email", "Bank Name", "Bank branch", "Bank account number", "Profession" });
                        TrainerHandle.TrainerEdit(choose, id);
                    }
                    else
                    {
                        Console.WriteLine("The Trainer is In-active");
                    }
                    break;
                case (int)PERSONFUNCTION.DELETE:
                    Console.WriteLine("Please enter a exist id");
                    while (!PersonValidation.IsCorrectId(id = Console.ReadLine()) || !FileHandle.IsTrainerExist(id))
                    {
                        Console.WriteLine("The id not correct or this id isn't exist");
                    }
                    FileHandle.TrainerRemove(id);
                    break;
                case (int)PERSONFUNCTION.LIST:
                    Trainer[] trainers = FileHandle.TrainerListCreate();
                    if (trainers != null)
                    {
                        TrainerHandle.ListPrint(trainers);
                    }
                    else
                    {
                        Console.WriteLine("The Trainer list is empty");
                    }
                    
                    break;
                case (int)PERSONFUNCTION.RETURN:;
                    break;
            }

            Console.WriteLine("Press enter to go back to menu");
            Console.ReadLine();
            MenuInteraction();
        }
    }
}

