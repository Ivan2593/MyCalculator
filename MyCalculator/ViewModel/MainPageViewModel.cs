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
        /// Строка для вывода
        /// </summary>
        private string _mainString = "0";

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
        /// Команда говна
        /// </summary>
        public RelayCommand SomeAddCommand { get; }

        /// <summary>
        /// Инициализирует класс <see cref="MainPageViewModel"/>
        /// </summary>
        public MainPageViewModel()
        {
            SomeAddCommand = new RelayCommand(SomeAdd);
        }

        /// <summary>
        /// Изменение строки
        /// </summary>
        private void SomeAdd()
        {
            MainString = MainString + "a";
        }
    }
}
