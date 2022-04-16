using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KyrylinDateLab02
{
    internal class DatePickerVM : INotifyPropertyChanged
    {
        #region Fields
        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthdate = DateTime.Today;
        private string _namesurnameemail = "";
        private string _age = "";
        private string _westernZodiac = "";
        private string _chineseZodiac = "";
        private RelayCommand<object> _submit;
        #endregion

        #region Properties
        public RelayCommand<object> Submitting
        {
            get
            {
                return _submit ?? (_submit = new RelayCommand<object>(
                           Submit_Click, o => IsAbleToSubmit()));
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                _birthdate = value;
                OnPropertyChanged();
            }
        }
        public string NameSurnameEmail
        {
            get
            {
                return _namesurnameemail;

            }
            private set
            {
                _namesurnameemail = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiac
        {
            get
            {
                return _westernZodiac;
            }
            set
            {
                _westernZodiac = value;
                OnPropertyChanged();
            }
        }
        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac;
            }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }
        public string Age
        {
            get
            {
                return _age;

            }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }
        #endregion

        internal DatePickerVM()
        {
            Birthdate = DateTime.Today;
        }

        private async void Submit_Click(object obj)
        {
            NameSurnameEmail = "";
            Age = "";
            WesternZodiac = "";
            ChineseZodiac = "";
            await Task.Run(() =>
            {
                Thread.Sleep(1000);
                try
                {
                    Person = new Person(Name, Surname, Email, Birthdate);
                    if ((_person.AgeFull < 0) || (_person.AgeFull > 135))
                    {
                        MessageBox.Show("Error! Wrong B-Day!");
                    }
                    else
                    {
                        if (_person.IsBirthday)
                        {
                            Age = "Happy birthday! You're turning " + _person.AgeFull + " today!";
                        }
                        else
                        {
                            Age = "Your age is " + _person.AgeFull + " full years.";
                        }
                        if (_person.IsAdult)
                        {
                            NameSurnameEmail = _person.Name + " " + _person.Surname + " , " + (_person.Birthdate).Day + "." + (_person.Birthdate).Month  + "." + (_person.Birthdate).Year + " ; " + _person.Email + " ; Adult.";
                        }
                        else
                        {
                            NameSurnameEmail = _person.Name + " " + _person.Surname + " , " + (_person.Birthdate).Day + "." + (_person.Birthdate).Month + "." + (_person.Birthdate).Year + " ; " + _person.Email + " ; Underaged.";
                        }
                        WesternZodiac = "Your zodiac sign is " + Person.WesternZodiac;
                        ChineseZodiac = "Your Chinese zodiac sign is " + Person.ChineseZodiac;
                    }
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
            });
        }
        private bool IsAbleToSubmit()
        {
            if (string.IsNullOrWhiteSpace(_name) || string.IsNullOrWhiteSpace(_surname) || string.IsNullOrWhiteSpace(_email))
            {
                return false;
            }
            else { return true; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

