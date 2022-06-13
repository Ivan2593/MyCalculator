using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.ViewModel
{
    /// <summary>
    /// Класс управления главной страницей
    /// </summary>
    public sealed class MainPageViewModel: ObservableObject
    {
        /// <summary>
        /// Состояние кнопки (operations = операции, numbers = цифры, equal = равно,clear = обнуление)
        /// </summary>
        private string _status = "numbers";

        /// <summary>
        /// Текущая операция
        /// </summary>
        private string _operation = "";

        /// <summary>
        /// Строка для вывода
        /// </summary>
        private string _mainString = "0";

        /// <summary>
        /// Строка предыдущего состояния
        /// </summary>
        private string _backString = "";

        /// <summary>
        /// Первое число
        /// </summary>
        private double? _firstNumber = null;

        /// <summary>
        /// Второе число
        /// </summary>
        private double? _secondNumber = null;

        /// <summary>
        /// Строка для вывода
        /// </summary>
        public string MainString
        {
            get => _mainString;
            private set
            {
                if(_mainString != value)
                {
                    _mainString = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Строка для вывода
        /// </summary>
        public string BackString
        {
            get => _backString;
            private set
            {
                if (_backString != value)
                {
                    _backString = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Добавление цифр
        /// </summary>
        public RelayCommand AddZeroCommand { get; }
        public RelayCommand AddOneCommand { get; }
        public RelayCommand AddTwoCommand { get; }
        public RelayCommand AddThreeCommand { get; }
        public RelayCommand AddFourCommand { get; }
        public RelayCommand AddFiveCommand { get; }
        public RelayCommand AddSixCommand { get; }
        public RelayCommand AddSevenCommand { get; }
        public RelayCommand AddEightCommand { get; }
        public RelayCommand AddNineCommand { get; }


        private void ZeroingString()
        {
            if (_status == "operations")
            {
                MainString = "0";
            }
            if (_status == "clear")
            {
                ClearAll();
            }
        }

        /// <summary>
        /// Изменение строки
        /// </summary>
        private void AddZero() { ZeroingString(); MainString = WriteNumber("0"); _status = "numbers"; }
        private void AddOne() { ZeroingString(); MainString = WriteNumber("1"); _status = "numbers"; }
        private void AddTwo() { ZeroingString(); MainString = WriteNumber("2"); _status = "numbers"; }
        private void AddThree() { ZeroingString(); MainString = WriteNumber("3"); _status = "numbers"; }
        private void AddFour() { ZeroingString(); MainString = WriteNumber("4"); _status = "numbers"; }
        private void AddFive() { ZeroingString(); MainString = WriteNumber("5"); _status = "numbers"; }
        private void AddSix() { ZeroingString(); MainString = WriteNumber("6"); _status = "numbers"; }
        private void AddSeven() { ZeroingString(); MainString = WriteNumber("7"); _status = "numbers"; }
        private void AddEight() { ZeroingString(); MainString = WriteNumber("8"); _status = "numbers"; }
        private void AddNine() { ZeroingString(); MainString = WriteNumber("9"); _status = "numbers"; }

        /// <summary>
        /// Правило записи цифр
        /// </summary>
        public string WriteNumber(string number)
        {
            if (MainString != "0")
            {
                return MainString + number;
            }
            else
            {
                return number;
            }
        }

        /// <summary>
        /// Команда очистки всего
        /// </summary>
        public RelayCommand ClearAllCommand { get; }

        /// <summary>
        /// Команда очистки строки
        /// </summary>
        public RelayCommand ClearStringCommand { get; }

        /// <summary>
        /// Команда сложения
        /// </summary>
        public RelayCommand SumCommand { get; }

        /// <summary>
        /// Команда сложения
        /// </summary>
        public RelayCommand SubCommand { get; }

        /// <summary>
        /// Команда сложения
        /// </summary>
        public RelayCommand MultCommand { get; }

        /// <summary>
        /// Команда сложения
        /// </summary>
        public RelayCommand DivCommand { get; }

        /// <summary>
        /// Команда равно
        /// </summary>
        public RelayCommand EqualSignCommand { get; }

        /// <summary>
        /// Команда удаления последнего
        /// </summary>
        public RelayCommand DeleteLastCommand { get; }

        /// <summary>
        /// Инициализирует класс <see cref="MainPageViewModel"/>
        /// </summary>
        public MainPageViewModel()
        {
            AddZeroCommand = new RelayCommand(AddZero);
            AddOneCommand = new RelayCommand(AddOne);
            AddTwoCommand = new RelayCommand(AddTwo);
            AddThreeCommand = new RelayCommand(AddThree);
            AddFourCommand = new RelayCommand(AddFour);
            AddFiveCommand = new RelayCommand(AddFive);
            AddSixCommand = new RelayCommand(AddSix);
            AddSevenCommand = new RelayCommand(AddSeven);
            AddEightCommand = new RelayCommand(AddEight);
            AddNineCommand = new RelayCommand(AddNine);
            ClearAllCommand = new RelayCommand(ClearAll);
            ClearStringCommand = new RelayCommand(ClearString);
            SumCommand = new RelayCommand(Sum);
            SubCommand = new RelayCommand(Sub);
            MultCommand = new RelayCommand(Mult);
            DivCommand = new RelayCommand(Div);
            EqualSignCommand = new RelayCommand(EqualSing);
            DeleteLastCommand = new RelayCommand(DeleteLast);
        }

        /// <summary>
        /// Сложение
        /// </summary>
        private void Sum()
        {
            if (_status == "numbers")
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToInt32(MainString);
                }
                else
                {
                    _secondNumber = Convert.ToInt32(MainString);
                    string res = Calculation();
                    if (res != "/0")
                    {
                        MainString = res;
                    }
                    else
                    {
                        BackString = BackString + " " + MainString + " +";
                        MainString = "Деление на ноль невозможно";
                        _status = "clear";
                    }
                }
            }
            if (_status != "clear")
            {
                _secondNumber = null;
                _operation = "+";
                BackString = MainString + " " + _operation;
                _status = "operations";
            }
        }

        /// <summary>
        /// Вычитание
        /// </summary>
        private void Sub()
        {
            if (_status == "numbers")
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToInt32(MainString);
                }
                else
                {
                    _secondNumber = Convert.ToInt32(MainString);
                    string res = Calculation();
                    if (res != "/0")
                    {
                        MainString = res;
                    }
                    else
                    {
                        BackString = BackString + " " + MainString + " -";
                        MainString = "Деление на ноль невозможно";
                        _status = "clear";
                    }
                }
            }
            if (_status != "clear")
            {
                _secondNumber = null;
                _operation = "-";
                BackString = MainString + " " + _operation;
                _status = "operations";
            }
        }

        /// <summary>
        /// Умножение
        /// </summary>
        private void Mult()
        {
            if (_status == "numbers")
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToInt32(MainString);

                }
                else
                {
                    _secondNumber = Convert.ToInt32(MainString);
                    string res = Calculation();
                    if (res != "/0")
                    {
                        MainString = res;
                    }
                    else
                    {
                        BackString = BackString + " " + MainString + " *";
                        MainString = "Деление на ноль невозможно";
                        _status = "clear";
                    }
                }
            }
            if (_status != "clear")
            {
                _secondNumber = null;
                _operation = "*";
                BackString = MainString + " " + _operation;
                _status = "operations";
            }
        }

        /// <summary>
        /// Деление
        /// </summary>
        private void Div()
        {

            if (_status == "numbers")
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToInt32(MainString);

                }
                else
                {
                    _secondNumber = Convert.ToInt32(MainString);
                    string res = Calculation();
                    if (res != "/0")
                    {
                        MainString = res;
                    }
                    else
                    {
                        BackString = BackString + " " + MainString + " /";
                        MainString = "Деление на ноль невозможно";
                        _status = "clear";
                    }
                }
            }
            if (_status != "clear")
            {
                _secondNumber = null;
                _operation = "/";
                BackString = MainString + " " + _operation;
                _status = "operations";
            }
        }

        /// <summary>
        /// Вычисление
        /// </summary>
        private string Calculation()
        {
            string res = "";
            if (_operation == "+")
            {
                _firstNumber = _firstNumber + _secondNumber;
                res = _firstNumber.ToString();
            }
            if (_operation == "-")
            {
                _firstNumber = _firstNumber - _secondNumber;
                res = _firstNumber.ToString();
            }
            if (_operation == "*")
            {
                _firstNumber = _firstNumber * _secondNumber;
                res = _firstNumber.ToString();
            }
            if (_operation == "/")
            {
                if (_secondNumber != 0)
                {
                    _firstNumber = _firstNumber / _secondNumber;
                    res = _firstNumber.ToString();
                }
                else
                {
                    res = "/0";
                }
            }
            return res;
        }

        /// <summary>
        /// Знак равенства
        /// </summary>
        private void EqualSing()
        {
            if (_status != "clear")
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToInt32(MainString);
                    BackString = _firstNumber.ToString() + " =";
                }
                else
                {
                    if (_secondNumber == null)
                    {
                        _secondNumber = Convert.ToInt32(MainString);
                    }
                    BackString = _firstNumber.ToString();
                    string res = Calculation();
                    if (res != "/0")
                    {
                        MainString = res;
                    }
                    else
                    {
                        MainString = "Деление на ноль невозможно";
                        _status = "clear";
                        return;
                    }
                    BackString = BackString + " " + _operation + " " + _secondNumber.ToString() + " =";
                }
                _status = "equal";
            }
            else
            {
                ClearAll();
            }
        }

        /// <summary>
        /// Удаление последнего символа
        /// </summary>
        private void DeleteLast()
        {
            if (_status == "equal")
            {
                BackString = "";
                return;
            }
            if (_status == "numbers")
            {
                MainString = MainString.Substring(0, MainString.Length - 1);
                if (MainString == "")
                {
                    MainString = "0";
                }
            }
        }

        /// <summary>
        /// Очистка всего
        /// </summary>
        private void ClearAll()
        {
            MainString = "0";
            BackString = "";
            _firstNumber = null;
            _secondNumber = null;
            _operation = "";
            _status = "numbers";
        }

        /// <summary>
        /// Очистка всего
        /// </summary>
        private void ClearString()
        {
            MainString = "0";
            if (_status == "clear")
            {
                ClearAll();
            }
        }
    }
}
