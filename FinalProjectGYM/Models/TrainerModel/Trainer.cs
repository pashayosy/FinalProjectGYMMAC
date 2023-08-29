using System;
using FinalProjectGYM.Models.PersonModel;
using Newtonsoft.Json;

namespace FinalProjectGYM.Models.TrainerModel
{
	public class Trainer : Person
	{
        public BankDetails BankAccount 
        {
            set
            {
                if (TrainerValidation.IsCorrectBankName(value.BankName) && TrainerValidation.IsCorrectBankBranch(value.BankBranch) && TrainerValidation.IsCorrectBankAccountNumber(value.BankAccountNumber))
                    _bankAccount = new BankDetails(value);
            }
            get { return _bankAccount; }
        }
        private BankDetails _bankAccount;
        public string Profession
        {
            set
            {
                if(TrainerValidation.IsCorrectProfession(value))
                    _profession = value;
            }
            get { return _profession; }
        }
        private string _profession;

        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        [JsonConstructor]
        public Trainer(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email, BankDetails bankAccount, string profession) : base(id, name, lastName, gender, date, city, address, phone, email)
        {
            _bankAccount = new BankDetails(bankAccount);
            _profession = profession;
            _isActive = true;
        }

        public override string ToString()
        {
            return base.ToString() +
                    $"Bank account : {_bankAccount.BankName} + {_bankAccount.BankBranch} + {_bankAccount.BankAccountNumber}\n" +
                    $"Profession : {Profession}\n";
        }
    }
}

