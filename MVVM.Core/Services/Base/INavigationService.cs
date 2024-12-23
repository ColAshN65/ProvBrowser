using MVVM.Core.Event.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Core.Services.Base
{
    /// <summary>
    /// Интерфейс сервиса навигации для навигации между контролами приложения
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Переводит к View, представленную типом ViewModel
        /// </summary>
        /// <typeparam name="T">Тип ViewModel для перехода к связанному View</typeparam>
        void Navigate<T>(NavigationEventArgs? args = null);
    }
}
