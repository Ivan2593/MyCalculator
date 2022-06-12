using Microsoft.Extensions.DependencyInjection;
using MyCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Helpers
{
    public sealed class ServicesContainer
    {

        public MainPageViewModel mainPageViewModel => GetService<MainPageViewModel>();

        /// <summary>
        /// Возвращает запрашиваемый сервис из контейнера.
        /// </summary>
        /// <typeparam name="T"> Имя сервиса </typeparam>
        /// <returns>Сервис</returns>
        public static T GetService<T>() => App.ServicesContainer.GetRequiredService<T>();
    }
}
