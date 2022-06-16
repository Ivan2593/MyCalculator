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
        /// Состояние кнопки (operations = операции, numbers = цифры, equal = равно, clear = обнуление, functions = функции)
        /// </summary>
        enum _status
        {
            operations,
            numbers,
            equal,
            clear,
            functions
        }

        /// <summary>
        /// Текущее состояние калькулятора
        /// </summary>
        private _status _nowStatus = _status.numbers;

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
        /// Левая часть выражения
        /// </summary>
        private string _leftString = "";

        /// <summary>
        /// Правая часть выражения
        /// </summary>
        private string _rightString = "";

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
            if (_nowStatus != _status.numbers)
            {
                if (_nowStatus == _status.clear)
                {
                    ClearAll();
                }
                else
                {
                    ClearString();
                }
            }
        }

        /// <summary>
        /// Изменение строки
        /// </summary>
        private void AddZero() {
            if (MainString == "0") return;
            ZeroingString(); 
            MainString = WriteNumber("0");
        }
        private void AddOne() { ZeroingString(); MainString = WriteNumber("1"); }
        private void AddTwo() { ZeroingString(); MainString = WriteNumber("2"); }
        private void AddThree() { ZeroingString(); MainString = WriteNumber("3"); }
        private void AddFour() { ZeroingString(); MainString = WriteNumber("4"); }
        private void AddFive() { ZeroingString(); MainString = WriteNumber("5"); }
        private void AddSix() { ZeroingString(); MainString = WriteNumber("6"); }
        private void AddSeven() { ZeroingString(); MainString = WriteNumber("7"); }
        private void AddEight() { ZeroingString(); MainString = WriteNumber("8"); }
        private void AddNine() { ZeroingString(); MainString = WriteNumber("9"); }

        /// <summary>
        /// Правило записи цифр
        /// </summary>
        public string WriteNumber(string number)
        {
            _secondNumber = null;
            _rightString = "";
            _nowStatus = _status.numbers;
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
        /// Добавление точки
        /// </summary>
        private void AddDot()
        {
            if (_nowStatus == _status.equal)
            {
                ClearAll();
            }
            if (_nowStatus == _status.functions || _nowStatus == _status.operations)
            {
                ClearString();
            }
            if (MainString.IndexOf(',') == -1)
            {
                MainString = MainString + ",";
            }
        }

        /// <summary>
        /// Команда добавления точки
        /// </summary>
        public RelayCommand AddDotCommand { get; }

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
        /// Команда удаления последнего
        /// </summary>
        public RelayCommand PercentCommand { get; }

        /// <summary>
        /// Команда удаления последнего
        /// </summary>
        public RelayCommand HyperboleCommand { get; }

        /// <summary>
        /// Команда удаления последнего
        /// </summary>
        public RelayCommand SquareCommand { get; }

        /// <summary>
        /// Команда удаления последнего
        /// </summary>
        public RelayCommand RootCommand { get; }

        // <summary>
        /// Команда смены знака
        /// </summary>
        public RelayCommand SignChangeCommand { get; }

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
            PercentCommand = new RelayCommand(Percent);
            HyperboleCommand = new RelayCommand(Hyperbole);
            SquareCommand = new RelayCommand(Square);
            RootCommand = new RelayCommand(Root);
            AddDotCommand = new RelayCommand(AddDot);
            SignChangeCommand = new RelayCommand(SignChange);
        }

        /// <summary>
        /// Сложение
        /// </summary>
        private void Sum()
        {
            if (_nowStatus == _status.numbers || _nowStatus == _status.functions)
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToDouble(MainString);
                    if (_secondNumber != null)
                    {
                        _leftString = _rightString;
                    }
                    else
                    {
                        _leftString = _firstNumber.ToString();
                        if (MainString[MainString.Length-1] == ',')
                        {
                            DeleteLast();
                        }
                    }
                }
                else
                {
                    _secondNumber = Convert.ToDouble(MainString);
                    string res = BasicCalculation();
                    if (res != "/0")
                    {
                        MainString = res;
                        _leftString = MainString;
                    }
                    else
                    {
                        BackString = BackString + " " + _rightString + " +";
                        MainString = "Деление на ноль невозможно";
                        _nowStatus = _status.clear;
                    }
                }
            }
            if (_nowStatus != _status.clear)
            {
                _secondNumber = null;
                _operation = "+";
                if (_nowStatus == _status.equal)
                {
                    _leftString = MainString;
                    _firstNumber = Convert.ToDouble(MainString);
                }
                BackString = _leftString + " " + _operation + " ";
                _nowStatus = _status.operations;
            }
            _rightString = "";
        }

        /// <summary>
        /// Вычитание
        /// </summary>
        private void Sub()
        {
            if (_nowStatus == _status.numbers || _nowStatus == _status.functions)
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToDouble(MainString);
                    if (_secondNumber != null)
                    {
                        _leftString = _rightString;
                    }
                    else
                    {
                        _leftString = _firstNumber.ToString();
                        if (MainString[MainString.Length - 1] == ',')
                        {
                            DeleteLast();
                        }
                    }
                }
                else
                {
                    _secondNumber = Convert.ToDouble(MainString);
                    string res = BasicCalculation();
                    if (res != "/0")
                    {
                        MainString = res;
                        _leftString = MainString;
                    }
                    else
                    {
                        BackString = BackString + " " + _rightString + " -";
                        MainString = "Деление на ноль невозможно";
                        _nowStatus = _status.clear;
                    }
                }
            }
            if (_nowStatus != _status.clear)
            {
                _secondNumber = null;
                _operation = "-";
                if (_nowStatus == _status.equal)
                {
                    _leftString = MainString;
                    _firstNumber = Convert.ToDouble(MainString);
                }
                BackString = _leftString + " " + _operation + " ";
                _nowStatus = _status.operations;
            }
            _rightString = "";
        }

        /// <summary>
        /// Умножение
        /// </summary>
        private void Mult()
        {
            if (_nowStatus == _status.numbers || _nowStatus == _status.functions)
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToDouble(MainString);
                    if (_secondNumber != null)
                    {
                        _leftString = _rightString;
                    }
                    else
                    {
                        _leftString = _firstNumber.ToString();
                        if (MainString[MainString.Length - 1] == ',')
                        {
                            DeleteLast();
                        }
                    }
                }
                else
                {
                    _secondNumber = Convert.ToDouble(MainString);
                    string res = BasicCalculation();
                    if (res != "/0")
                    {
                        MainString = res;
                        _leftString = MainString;
                    }
                    else
                    {
                        BackString = BackString + " " + _rightString + " *";
                        MainString = "Деление на ноль невозможно";
                        _nowStatus = _status.clear;
                    }
                }
            }
            if (_nowStatus != _status.clear)
            {
                _secondNumber = null;
                _operation = "*";
                if (_nowStatus == _status.equal)
                {
                    _leftString = MainString;
                    _firstNumber = Convert.ToDouble(MainString);
                }
                BackString = _leftString + " " + _operation + " ";
                _nowStatus = _status.operations;
            }
            _rightString = "";
        }

        /// <summary>
        /// Деление
        /// </summary>
        private void Div()
        {
            if (_nowStatus == _status.numbers || _nowStatus == _status.functions)
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToDouble(MainString);
                    if (_secondNumber != null)
                    {
                        _leftString = _rightString;
                    }
                    else
                    {
                        _leftString = _firstNumber.ToString();
                        if (MainString[MainString.Length - 1] == ',')
                        {
                            DeleteLast();
                        }
                    }
                }
                else
                {
                    _secondNumber = Convert.ToDouble(MainString);
                    string res = BasicCalculation();
                    if (res != "/0")
                    {
                        MainString = res;
                        _leftString = MainString;
                    }
                    else
                    {
                        BackString = BackString + " " + _rightString + " /";
                        MainString = "Деление на ноль невозможно";
                        _nowStatus = _status.clear;
                    }
                }
            }
            if (_nowStatus != _status.clear)
            {
                _secondNumber = null;
                _operation = "/";
                if (_nowStatus == _status.equal)
                {
                    _leftString = MainString;
                    _firstNumber = Convert.ToDouble(MainString);
                }
                BackString = _leftString + " " + _operation + " ";
                _nowStatus = _status.operations;
            }
            _rightString = "";
        }

        /// <summary>
        /// Вычисление
        /// </summary>
        private string BasicCalculation()
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
            if (_nowStatus != _status.clear)
            {
                if (_firstNumber == null)
                {
                    _firstNumber = Convert.ToDouble(MainString);
                    if (_secondNumber != null)
                    {
                        _leftString = _rightString;
                        _secondNumber = null;
                        _rightString = "";
                    }
                    else
                    {
                        _leftString = _firstNumber.ToString();
                        _firstNumber = null;
                    }
                    BackString = _leftString + " =";
                }
                else
                {
                    if (_secondNumber == null)
                    {
                        if (_nowStatus == _status.equal)
                        {
                            return;
                        }
                        _secondNumber = Convert.ToDouble(MainString);
                        if (MainString[MainString.Length - 1] == ',')
                        {
                            DeleteLast();
                        }
                        _rightString = MainString;
                    }
                    else
                    {
                        if (_nowStatus == _status.functions)
                        {
                            _secondNumber = Convert.ToDouble(MainString);
                        }
                        else
                        {
                            _leftString = _firstNumber.ToString();
                            _rightString = _secondNumber.ToString();
                        }
                    }
                    string res = BasicCalculation();
                    if (res != "/0")
                    {
                        MainString = res;
                    }
                    else
                    {
                        MainString = "Деление на ноль невозможно";
                        _nowStatus = _status.clear;
                        return;
                    }
                    BackString = _leftString + " " + _operation + " " + _rightString + " =";
                }
                _nowStatus = _status.equal;
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
            if (_nowStatus == _status.clear)
            {
                ClearAll();
                return;
            }
            if (_nowStatus == _status.equal)
            {
                BackString = "";
                return;
            }
            if (_nowStatus == _status.numbers)
            {
                MainString = MainString.Substring(0, MainString.Length - 1);
                if (MainString == "")
                {
                    MainString = "0";
                }
            }
        }

        /// <summary>
        /// Вычисление процента
        /// </summary>
        private void Percent()
        {
            if (_nowStatus != _status.clear)
            {
                if (_firstNumber == null)
                {
                    BackString = "0";
                    MainString = "0";
                    _secondNumber = null;
                    _rightString = "";
                    _nowStatus = _status.numbers;
                    return;
                }
                
                _secondNumber = Convert.ToDouble(MainString);
                MainString = (_firstNumber * Convert.ToDouble(MainString) / 100).ToString();
                if (_nowStatus == _status.equal)
                {
                    _rightString = "";
                    _leftString = "";
                    _operation = "";
                    BackString = MainString;
                    _nowStatus = _status.equal;
                    return;
                }
                _rightString = MainString;
                BackString = _leftString + " " + _operation + " " + _rightString;
                _nowStatus = _status.functions;
            }

        }

        /// <summary>
        /// Вычисление гиперболы
        /// </summary>
        private void Hyperbole()
        {
            if (_nowStatus != _status.clear)
            {
                if (_nowStatus == _status.equal)
                {
                    _firstNumber = null;
                    _rightString = "";
                    _leftString = "";
                    _operation = "";
                }
                _secondNumber = Convert.ToDouble(MainString);
                if (_rightString == "")
                {
                    _rightString = "1/(" + _secondNumber.ToString() + ")";
                }
                else
                {
                    _rightString = "1/(" + _rightString + ")";
                }

                MainString = (1 / Convert.ToDouble(MainString)).ToString();
                if (_secondNumber == 0)
                {
                    BackString = BackString + " " + _rightString;
                    MainString = "Деление на ноль невозможно";
                    _nowStatus = _status.clear;
                }
                else
                {
                    BackString = _leftString + " " + _operation + " " + _rightString;
                    _nowStatus = _status.functions;
                }
            }
        }

        /// <summary>
        /// Вычисление квадрата
        /// </summary>
        private void Square()
        {
            if (_nowStatus != _status.clear)
            {
                if (_nowStatus == _status.equal)
                {
                    _firstNumber = null;
                    _rightString = "";
                    _leftString = "";
                    _operation = "";
                }
                _secondNumber = Convert.ToDouble(MainString);
                if (_rightString == "")
                {
                    _rightString = "sqr(" + _secondNumber.ToString() + ")";
                }
                else
                {
                    _rightString = "sqr(" + _rightString + ")";
                }
                
                MainString = (Convert.ToDouble(MainString) * Convert.ToDouble(MainString)).ToString();
                BackString = _leftString + " " + _operation + " " + _rightString;
                _nowStatus = _status.functions;
            }
        }

        /// <summary>
        /// Вычисление корня
        /// </summary>
        private void Root()
        {
            if (_nowStatus != _status.clear)
            {
                if (_nowStatus == _status.equal)
                {
                    _firstNumber = null;
                    _rightString = "";
                    _leftString = "";
                    _operation = "";
                }
                _secondNumber = Convert.ToDouble(MainString);
                if (_rightString == "")
                {
                    _rightString = "√(" + _secondNumber.ToString() + ")";
                }
                else
                {
                    _rightString = "√(" + _rightString + ")";
                }

                MainString = (Math.Sqrt(Convert.ToDouble(MainString))).ToString();
                BackString = _leftString + " " + _operation + " " + _rightString;
                _nowStatus = _status.functions;
            }
        }


        /// <summary>
        /// Смена знака
        /// </summary>
        private void SignChange()
        {
            if (MainString != "0")
            {
                if (MainString[0] == '-')
                {
                    MainString = MainString.Remove(0, 1);
                }
                else
                {
                    MainString = MainString.Insert(0, "-");
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
            _leftString = "";
            _rightString = "";
            _operation = "";
            _nowStatus = _status.numbers;
        }

        /// <summary>
        /// Очистка всего
        /// </summary>
        private void ClearString()
        {
            MainString = "0";
            if (_nowStatus == _status.clear)
            {
                ClearAll();
            }
            if (_nowStatus == _status.equal && _secondNumber != null)
            {
                ClearAll();
            }
            if (_nowStatus == _status.functions)
            {
                if (_firstNumber == null)
                {
                    BackString = _leftString + " " + _operation + " " + _rightString;
                    _operation = "";
                }
                else
                {
                    BackString = _leftString + " " + _operation + " ";
                }
                _secondNumber = null;
                _rightString = "";
                _nowStatus = _status.numbers;
            }
            if (_nowStatus == _status.operations)
            {
                _nowStatus = _status.numbers;
            }
        }
    }
}