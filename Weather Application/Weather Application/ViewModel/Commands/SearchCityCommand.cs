using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Weather_Application.ViewModel.Commands
{
    public class SearchCityCommand : ICommand
    {
        public WeatherVM WeatherVM { get; set; }
        public event EventHandler? CanExecuteChanged;
        public SearchCityCommand(WeatherVM weatherVM)
        {
            WeatherVM = weatherVM;
        }

        public bool CanExecute(object? parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter as string))
                return false;
            else
                return true;
        }

        public void Execute(object? parameter)
        {
            WeatherVM.MakeQuery();
        }
    }
}
