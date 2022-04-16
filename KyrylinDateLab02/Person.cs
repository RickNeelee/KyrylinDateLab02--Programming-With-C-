using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyrylinDateLab02
{
    internal class Person
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private int _age;
        private DateTime _birthdate;

        private readonly bool _isAdult;
        private readonly bool _isBirthday;
        private readonly string _westernZodiac;
        private readonly string _chineseZodiac;

        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            private set
            {
                _surname = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                _email = value;
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            private set
            {
                _birthdate = value;
            }
        }

        public int AgeFull
        {
            get
            {
                return _age;
            }
            private set
            {
                _age = value;
            }
        }
        public string WesternZodiac
        {
            get
            {
                return _westernZodiac;
            }
        }

        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac;
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
        }

        #endregion

        internal Person(string Name, string Surname, string Email, DateTime Birthdate)
        {
            _name = Name;
            _surname = Surname;
            _email = Email;
            _birthdate = Birthdate;
            _age = GetAgeInt(_birthdate, DateTime.Today);

            int age = GetAgeInt(_birthdate, DateTime.Today);
            _isAdult = (age >= 18);
            _isBirthday = IsBirthdayCheck(_birthdate, DateTime.Today);
            _westernZodiac = GettingZodiac(_birthdate);
            _chineseZodiac = GettingChZodiac(_birthdate);
        }

        public Person(string Name, string Surname, DateTime Birthdate) :
           this(Name, Surname, "rickneelee@coolhouse.com", Birthdate)
        {

        }
        public Person(string Name, string Surname, string Email) :
            this(Name, Surname, Email, DateTime.Today)
        {

        }
 
        private int GetAgeInt(DateTime startDate, DateTime endDate)
        {
            int AgeFull = (endDate.Year - startDate.Year - 1) +
                (((endDate.Month > startDate.Month) ||
                ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
            return AgeFull;
        }

        private bool IsBirthdayCheck(DateTime startDate, DateTime endDate)
        {
            if ((startDate.Day == DateTime.Today.Day) && (startDate.Month == DateTime.Today.Month))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GettingZodiac(DateTime birthDate)
        {
            return GetZodiac(birthDate);
        }

        private string GettingChZodiac(DateTime birthDate)
        {
            return GetChineseZodiac(birthDate);
        }
        public string GetZodiac(DateTime birthDate)
        {
            switch (birthDate.Month)
            {
                case 1:
                    {
                        if (birthDate.Day < 21) return "Capricorn";
                        else return "Aquarius";
                    }
                case 2:
                    {
                        if (birthDate.Day < 20) return "Aquarius";
                        else return "Pisces";
                    }
                case 3:
                    {
                        if (birthDate.Day < 21) return "Pisces";
                        else return "Aries";
                    }
                case 4:
                    {
                        if (birthDate.Day < 21) return "Aries";
                        else return "Taurus";
                    }
                case 5:
                    {
                        if (birthDate.Day < 22) return "Taurus";
                        else return "Gemini";
                    }
                case 6:
                    {
                        if (birthDate.Day < 22) return "Gemini";
                        else return "Cancer";
                    }
                case 7:
                    {
                        if (birthDate.Day < 23) return "Cancer";
                        else return "Leo";
                    }
                case 8:
                    {
                        if (birthDate.Day < 22) return "Leo";
                        else return "Virgo";
                    }
                case 9:
                    {
                        if (birthDate.Day < 24) return "Virgo";
                        else return "Libra";
                    }
                case 10:
                    {
                        if (birthDate.Day < 24) return "Libra";
                        else return "Scorpio";
                    }
                case 11:
                    {
                        if (birthDate.Day < 24) return "Scorpio";
                        else return "Saggitarius";
                    }
                case 12:
                    {
                        if (birthDate.Day < 23) return "Saggitarius";
                        else return "Capricorn";
                    }
                default: return "Ophiuchus";
            }
        }

        public string GetChineseZodiac(DateTime birthDate)
        {
            switch ((birthDate.Year - 4) % 12)
            {
                case 0:
                    {
                        return "Rat";
                    }
                case 1:
                    {
                        return "Ox";
                    }
                case 2:
                    {
                        return "Tiger";
                    }
                case 3:
                    {
                        return "Rabbit";
                    }
                case 4:
                    {
                        return "Dragon";
                    }
                case 5:
                    {
                        return "Snake";
                    }
                case 6:
                    {
                        return "Horse";
                    }
                case 7:
                    {
                        return "Goat";
                    }
                case 8:
                    {
                        return "Monkey";
                    }
                case 9:
                    {
                        return "Rooster";
                    }
                case 10:
                    {
                        return "Dog";
                    }
                case 11:
                    {
                        return "Pig";
                    }
                default: return "Unknown";
            }
        }
    }
}

    