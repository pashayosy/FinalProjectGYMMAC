using Newtonsoft.Json;
using System;
namespace FinalProjectGYM.Models.TrainerModel
{
	public class BankDetails
	{
        public string BankName
        {
            set 
            {
                if(TrainerValidation.IsCorrectBankName(value))
                    _bankName = value;
            }
            get { return _bankName; }
        }
        private string _bankName;
		public string BankBranch
        {
            set
            {
                if (TrainerValidation.IsCorrectBankBranch(value))
                    _bankBranch = value;
            }
            get { return _bankBranch; }
        }
        private string _bankBranch;
        public string BankAccountNumber
        {
            set
            {
                if (TrainerValidation.IsCorrectBankAccountNumber(value))
                    _bankAccountNumber = value;
            }
            get { return _bankAccountNumber; }
        }
        private string _bankAccountNumber;

        [JsonConstructor]
        public BankDetails(string bankName, string bankBranch, string bankAccountNuber)
        {
            _bankName = bankName;
            _bankBranch = bankBranch;
            _bankAccountNumber = bankAccountNuber;
        }

        public BankDetails(BankDetails b)
        {
            _bankName = b.BankName;
            _bankBranch = b.BankBranch;
            _bankAccountNumber = b.BankAccountNumber;
        }
    }
}

