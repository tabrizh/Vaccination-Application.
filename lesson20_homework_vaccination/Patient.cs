using System;
namespace Vaccination
{
    public class Patient
    {
        private int _id = 0;
        private string _identification = "N/A";
        private string _name;
        private string _surname = "N/A";
        private byte _age = 0;
        private string _phoneNumber = "N/A";
        private string _email = "N/A";
        private string _address = "N/A";
        private string _company = "N/A";
        private bool _firstDose = false;
        private string _firstDoseDate = "N/A";
        private string _firstDoseName = "N/A";
        private bool _secondDose = false;
        private string _secondDoseDate = "N/A";
        private string _secondDoseName = "N/A";

        public int ID { get { return this._id; } set { this._id = value; } }
        public string Identification { get { return this._identification; } set { this._identification = value; } }
        public string Name { get { return this._name; } set { this._name = value; } }
        public string Surname { get { return this._surname; } set { this._surname = value; } }
        public byte Age { get { return this._age; } set { this._age = value; } }
        public string PhoneNumber { get { return this._phoneNumber; } set { this._phoneNumber = value; } }
        public string Email { get { return this._email; } set { this._email = value; } }
        public string Address { get { return this._address; } set { this._address = value; } }
        public string Company { get { return this._company; } set { this._company = value; } }
        public bool FirstDose { get { return _firstDose; } set { this._firstDose = value; } }
        public string FirstDoseDate { get { return this._firstDoseDate; } set { this._firstDoseDate = value; } }
        public string FirstDoseName { get { return this._firstDoseName; } set { this._firstDoseName = value; } }
        public bool SecondDose { get { return this._secondDose; } set { this._secondDose = value; } }
        public string SecondDoseDate { get { return this._secondDoseDate; } set { this._secondDoseDate = value; } }
        public string SecondDoseName { get { return this._secondDoseName; } set { this._secondDoseName = value; } }

        public Patient(string identification, string name, string surname, byte age, string phoneNumber, string email, string address, string company, bool firstDose, string firstDoseDate, string firstDoseName)
        {
            _identification = identification;
            _name = name;
            _surname = surname;
            _age = age;
            _phoneNumber = phoneNumber;
            _email = email;
            _address = address;
            _company = company;
            _firstDose = firstDose;
            _firstDoseDate = firstDoseDate;
            _firstDoseName = firstDoseName;
        }

        public static string ShowInfo(Patient ptnt)
        {
            return $"Name: {ptnt.Name}, Surname: {ptnt.Surname}, ID: {ptnt.ID}, First vaccination dose: {ptnt.FirstDoseDate}, {ptnt.FirstDoseName}";
        }
    }
}

