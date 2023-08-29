using FinalProjectGYM.Models.ClientModel;
using FinalProjectGYM.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectGYM.Models.TrainerModel
{
    internal class TrainerHandle
    {
        enum TRAINERPROPS { ID = 1, NAME, LASTNAME, GENDER, DATE, CITY, ADDRESS, PHONE, EMAIL, BANKNAME, BANKBRANCH, BANKACCOUNTNUMBER, PROFESSION}

        public static void TrainerCreate()
        {
            string id;
            while (FileHandle.IsTrainerExist(id = CorrectInput("\n1.ID NUMBER:\nPlease enter ID number (9 digits).", PersonValidation.IsCorrectId))) ;
            string name = CorrectInput("\n2.FIRST NAME:\nPlease enter First name.", PersonValidation.IsCorrectName);
            string lastName = CorrectInput("\n3.LAST NAME:\nPlease enter Last name.", PersonValidation.IsCorrectLastName);
            char gender = CorrectInput("\n4.GENDER:\nPlease enter gender(F / M / O).", PersonValidation.IsCorrectGender)[0];
            string date = CorrectInput("\n5.DATE OF BIRTH:\nPlease enter date of birth(day / month / full year)", PersonValidation.IsCorrectDateOfBirth);
            string city = CorrectInput("\n6.City\nPlease enter City:", PersonValidation.IsCorrectCity);
            string address = CorrectInput("\n7.ADDRESS:\nPlease enter Address.", PersonValidation.IsCorrectAddress);
            string phone = CorrectInput("\n8.PHONE:\nPlease enter mobile phone number", PersonValidation.IsCorrectPhone);
            string email = CorrectInput("\n9.EMAIL:\nPlease enter email address.", PersonValidation.IsCorrectEmail);
            string bankName = CorrectInput("\n10.1 Bank account Name:\nPlease enter a bank account name", TrainerValidation.IsCorrectBankName);
            string bankBranch = CorrectInput("\n10.2 Bank account branch:\nPlease enter a bank account branch", TrainerValidation.IsCorrectBankBranch);
            string bankAcoounNumber = CorrectInput("\n10.3 Bank account number:\nPlease enter a bank account number", TrainerValidation.IsCorrectBankAccountNumber);
            string profession = CorrectInput("\n11.Profession:\nPlease enter a profession", TrainerValidation.IsCorrectProfession);

            BankDetails bankAccount = new BankDetails(bankName, bankBranch, bankAcoounNumber);

            Trainer trainer = new Trainer(id, name, lastName, gender, date, city, address, phone, email, bankAccount, profession);
            FileHandle.TrainerAdd(trainer);
        }

        public static string CorrectInput(string message, Func<string, bool> validation)//need message and validation function to return correcr data
        {
            string correctInput;
            Console.WriteLine(message);
            correctInput = Console.ReadLine();
            while (!validation(correctInput))
            {
                correctInput = Console.ReadLine();
            }

            return correctInput;
        }

        public static void ListPrint(Trainer[] trainers)
        {
            if (trainers.Length == 0)
            {
                Console.WriteLine("\nThe list is empty");
                return;
            }
            foreach (Trainer trainer in trainers)
            {
                Console.WriteLine("\n" + trainer);
            }
        }

        public static void TrainerEdit(int position, string id)
        {
            Trainer trainer = FileHandle.GetTrainerById(id);
            string data;
            switch (position)
            {
                case (int)TRAINERPROPS.ID:
                    data = CorrectInput("Input id for change:", PersonValidation.IsCorrectId);
                    while (FileHandle.IsTrainerExist(data))
                    {
                        data = CorrectInput("Input id for change:", PersonValidation.IsCorrectId);
                    }
                    string temp;
                    temp = trainer.Id;
                    trainer.Id = data;
                    data = temp;
                    FileHandle.TrainerUpdateIdChanged(trainer, data);
                    break;
                case (int)TRAINERPROPS.NAME:
                    data = CorrectInput("Input Name for change:", PersonValidation.IsCorrectName);
                    trainer.Name = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.LASTNAME:
                    data = CorrectInput("Input Last Name for change:", PersonValidation.IsCorrectLastName);
                    trainer.LastName = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.GENDER:
                    data = CorrectInput("Input Gender for change:", PersonValidation.IsCorrectGender);
                    trainer.Gender = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.DATE:
                    data = CorrectInput("Input Date for change:", PersonValidation.IsCorrectDateOfBirth);
                    trainer.Date = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.CITY:
                    data = CorrectInput("Input City for change:", PersonValidation.IsCorrectCity);
                    trainer.City = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.ADDRESS:
                    data = CorrectInput("Input Address for change:", PersonValidation.IsCorrectAddress);
                    trainer.Address = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.PHONE:
                    data = CorrectInput("Input Phone for change:", PersonValidation.IsCorrectPhone);
                    trainer.Phone = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.EMAIL:
                    data = CorrectInput("Input Email for change:", PersonValidation.IsCorrectEmail);
                    trainer.Email = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.BANKNAME:
                    data = CorrectInput("Input Bank name for change:", TrainerValidation.IsCorrectBankName);
                    trainer.BankAccount.BankName = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.BANKBRANCH:
                    data = CorrectInput("Input bank branch for change:", TrainerValidation.IsCorrectBankBranch);
                    trainer.BankAccount.BankBranch = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.BANKACCOUNTNUMBER:
                    data = CorrectInput("Input banc account number for change:", TrainerValidation.IsCorrectBankAccountNumber);
                    trainer.BankAccount.BankAccountNumber = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
                case (int)TRAINERPROPS.PROFESSION:
                    data = CorrectInput("Input progession for change:", TrainerValidation.IsCorrectProfession);
                    trainer.Profession = data;
                    FileHandle.TrainerAdd(trainer);
                    break;
            }
        }
    }
}
