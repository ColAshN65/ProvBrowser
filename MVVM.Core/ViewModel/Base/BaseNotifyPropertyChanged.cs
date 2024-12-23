using MVVM.Core.Event.Args;
using MVVM.Core.Event.Handlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Core.ViewModel.Base
{
    /// <summary>
    ///     Базовый класс модели представления.
    /// </summary>
    public class BaseNotifyPropertyChanged : INotifyPropertyChanged
    {
        
        #region PropertyChanged

        /// <summary>
        ///     Событие, на которое подписываются DependencyProperty.
        ///     Вызывается в случае изменения св-в.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///     Метод, упрощающий синтаксис подписывания св-в на PropertyChanged.
        /// </summary>
        /// <typeparam name="T">Тип св-ва.</typeparam>
        /// <param name="field">Ссылка на Backfield св-во.</param>
        /// <param name="value">Новое значение св-ва.</param>
        /// <param name="propertyName">Имя изменяемого св-ва.</param>
        /// <returns></returns>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        ///     Вызов события PropertyChanged.
        /// </summary>
        /// <param name="prop">Имя изменяемого св-ва.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        
    }


    

}
