using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using СutleryShop.Stores;
using СutleryShop.ViewModels;

namespace СutleryShop.Comands
{
    public class NavigateCommand<TViewModel> : ICommand where TViewModel : BaseViewModel
    {
        private readonly Func<TViewModel> _createViewModel;

        private readonly NavigationStore _navigationStore;

        public NavigateCommand(NavigationStore navigationStore, Func<TViewModel> createViwModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViwModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => _navigationStore.CurentViewModel = _createViewModel();
    }
}
