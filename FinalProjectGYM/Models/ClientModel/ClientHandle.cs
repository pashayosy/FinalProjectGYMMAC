using FinalProjectGYM.Models.PersonModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProjectGYM.Models.ClientModel
{
    internal static class ClientHandle
    {
        enum CLIENTPROPS { ID = 1, NAME, LASTNAME, GENDER, DATE, CITY, ADDRESS, PHONE, EMAIL, HEIGHT, WEIGHT }
        public static void ClientCreate()
        {
            string id;
            while (FileHandle.IsClientExist(id = CorrectInput("\n1.ID NUMBER:\nPlease enter ID number (9 digits).", PersonValidation.IsCorrectId))) ;
            string name = CorrectInput("\n2.FIRST NAME:\nPlease enter First name.", PersonValidation.IsCorrectName);
            string lastName = CorrectInput("\n3.LAST NAME:\nPlease enter Last name.", PersonValidation.IsCorrectLastName);
            char gender = CorrectInput("\n4.GENDER:\nPlease enter gender(F / M / O).", PersonValidation.IsCorrectGender)[0];
            string date = CorrectInput("\n5.DATE OF BIRTH:\nPlease enter date of birth(day / month / full year)", PersonValidation.IsCorrectDateOfBirth);
            string city = CorrectInput("\n6.City\nPlease enter City:", PersonValidation.IsCorrectCity);
            string address = CorrectInput("\n7.ADDRESS:\nPlease enter Address.", PersonValidation.IsCorrectAddress);
            string phone = CorrectInput("\n8.PHONE:\nPlease enter mobile phone number", PersonValidation.IsCorrectPhone);
            string email = CorrectInput("\n9.EMAIL:\nPlease enter email address.", PersonValidation.IsCorrectEmail);
            double height = double.Parse(CorrectInput("\n10. HEIGHT:\nPlease enter height.", ClientValidation.IsCorrectHeight));
            double weight = double.Parse(CorrectInput("\n11. WEIGHT:\nPlease enter weight.", ClientValidation.IsCorrectWeight));

            Client client = new Client(id , name, lastName, gender, date, city, address, phone, email, height, weight);
            FileHandle.ClientAdd(client);
        }

        public static string CorrectInput(string message, Func<string,bool> validation)//need message and validation function to return correcr data
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

        public static void ListPrint(Client[]clients)
        {
            if (clients.Length == 0) 
            {
                Console.WriteLine("\nThe list is empty");
                return;
            }
            foreach (Client client in clients) 
            {
                Console.WriteLine("\n" + client);
            }
        }

        public static void ClientEdit(int position, string id)
        {
            Client client = FileHandle.GetClientById(id);
            string data;
            switch(position)
            {
                case (int)CLIENTPROPS.ID:
                    data = CorrectInput("Input id for change:", PersonValidation.IsCorrectId);
                    while (FileHandle.IsClientExist(data)) 
                    {
                        data = CorrectInput("Input id for change:", PersonValidation.IsCorrectId);
                    }
                    string temp;
                    temp = client.Id;
                    client.Id = data;
                    data = temp;
                    FileHandle.ClientUpdateIdChanged(client, data);
                    break;
                case (int)CLIENTPROPS.NAME:
                    data = CorrectInput("Input Name for change:", PersonValidation.IsCorrectName);
                    client.Name = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.LASTNAME:
                    data = CorrectInput("Input Last Name for change:", PersonValidation.IsCorrectLastName);
                    client.LastName = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.GENDER:
                    data = CorrectInput("Input Gender for change:", PersonValidation.IsCorrectGender);
                    client.Gender = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.DATE:
                    data = CorrectInput("Input Date for change:", PersonValidation.IsCorrectDateOfBirth);
                    client.Date = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.CITY:
                    data = CorrectInput("Input City for change:", PersonValidation.IsCorrectCity);
                    client.City = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.ADDRESS:
                    data = CorrectInput("Input Address for change:", PersonValidation.IsCorrectAddress);
                    client.Address = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.PHONE:
                    data = CorrectInput("Input Phone for change:", PersonValidation.IsCorrectPhone);
                    client.Phone = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.EMAIL:
                    data = CorrectInput("Input Email for change:", PersonValidation.IsCorrectEmail);
                    client.Email = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.HEIGHT:
                    data = CorrectInput("Input Height for change:", ClientValidation.IsCorrectHeight);
                    client.Height = data;
                    FileHandle.ClientAdd(client);
                    break;
                case (int)CLIENTPROPS.WEIGHT:
                    data = CorrectInput("Input Weight for change:", ClientValidation.IsCorrectWeight);
                    client.Weight = data;
                    FileHandle.ClientAdd(client);
                    break;
            }
        }
    }
}
