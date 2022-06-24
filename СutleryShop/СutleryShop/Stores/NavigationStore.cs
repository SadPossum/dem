using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using СutleryShop.ViewModels;

namespace СutleryShop.Stores
{
    public class NavigationStore
    {
        private BaseViewModel curentViewModel;

        public BaseViewModel CurentViewModel
        {
            get => curentViewModel;
            set
            {
                curentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
