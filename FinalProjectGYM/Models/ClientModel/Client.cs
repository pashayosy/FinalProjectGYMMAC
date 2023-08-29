using FinalProjectGYM.Models.PersonModel;
using System.Text.Json.Serialization;

namespace FinalProjectGYM.Models.ClientModel
{
	public class Client : Person
	{
        private double _height;
        public string Height
        {
            set
            {
                if (ClientValidation.IsCorrectHeight(value))
                {
                    _height = double.Parse(value);
                    Bmi = _weight / Math.Pow(_height, 2);
                }
            }
            get
            {
                return _height.ToString();
            }
        }

        private double _weight;
        public string Weight
        {
            set
            {
                if (ClientValidation.IsCorrectWeight(value))
                {
                    _weight = double.Parse(value);
                    Bmi = _weight / Math.Pow(_height, 2);
                }
            }
            get
            {
                return _weight.ToString();
            }
        }

        public double Bmi { private set; get; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }


        public Client(string id, string name, string lastName, char gender, string date, string city, string address, string phone, string email, double height, double weight) : base(id, name, lastName, gender, date, city, address, phone, email)
        {
            _height = height;
            _weight = weight;
            Bmi = _weight / Math.Pow(_height, 2);
            _isActive = true;
        }

        public override string ToString()
        {
            return base.ToString() + 
                    $"Height : {_height}\n" +
                    $"Weight : {_weight}\n" +
                    $"Bmi : {Bmi}\n";
        }
    }
}

