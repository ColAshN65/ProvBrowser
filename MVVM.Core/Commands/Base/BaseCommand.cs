using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM.Core.Commands.Base
{
    public class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public event Action Triggered;

        private readonly Action<object?> _execute;
        private readonly Func<object?, bool>? _canExecute;

        public BaseCommand(Action<object?> execute)
        {
            _execute = execute;
        }
        protected BaseCommand(Action<object?> execute, Func<object?, bool>? canExecute) : this(execute)
        {
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) =>
            _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter)
        {
            if (_execute is null)
                return;
            _execute.Invoke(parameter);
            Triggered?.Invoke();
        }
    }
}
