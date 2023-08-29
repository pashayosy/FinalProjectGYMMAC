namespace FinalProjectGYM.Models.PersonModel
{
	public abstract class Person
	{
        public string Id
        {
            set
            {
                if (PersonValidation.IsCorrectId(value))
                    _id = value;
            }
            get { return _id; }
        }
        private string _id;
		public string Name
        {
            set
            {
                if (PersonValidation.IsCorrectName(value))
                    _name = value;
            }
            get { return _name; }
        }
        private string _name;
		public string LastName
        {
            set 
            {
                if(PersonValidation.IsCorrectLastName(value))
                    _lastName = value;
            }
            get { return _lastName; }
        }
        private string _lastName;
		public string Gender
        { 
            set
            {
                if (PersonValidation.IsCorrectGender(value))
                    _gender = value[0];
            }
            get { return _gender.ToString(); }
        }
        private char _gender;
		public string Date
        {
            set 
            {
                if (PersonValidation.IsCorrectDateOfBirth(value))
                    _date = value;
            }
            get { return _date; }
        }
        private string _date;
		public string City
        {
            set
            {
                if (PersonValidation.IsCorrectCity(value))
                    _city = value;
            }
            get { return _city; }
        }
        private string _city;
		public string Address
        {
            set
            {
                if (PersonValidation.IsCorrectAddress(value))
                    _address = value;
            }
            get { return _address; }
        }
        private string _address;

        public string Phone
        {
            set
            {
                if (PersonValidation.IsCorrectPhone(value))
                    _phone = value;
            }
            get { return _phone; }
        }
        private string _phone;
        
        public string Email
        {
            set
            {
                if (PersonValidation.IsCorrectEmail(value))
                    _email = value;
            }
            get { return _email; }
        }
        private string _email;

        protected Person(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email)
        {
            _id = id;
            _name = name;
            _lastName = lastName;
            _gender = gender;
            _date = date;
            _city = city;
            _address = address;
            _phone = phone;
            _email = email;
        }

        public override string ToString()
        {
            return $"Id : {_id}\n" +
                   $"Name : {_name}\n" +
                   $"Last Name : {_lastName}\n" +
                   $"Gender : {_gender}\n" +
                   $"Date of birth : {_date}\n" +
                   $"City : {_city}\n" +
                   $"Address : {_address}\n" +
                   $"Phone : {_phone}\n" +
                   $"Email : {_email}\n";
        }
    }
}

