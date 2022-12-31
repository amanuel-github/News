using NewsManagementForm.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace NewsManagementForm.Services
{
    public interface INavService
    {
        bool CanGoBack { get; }
        Task GoBack();
        Task NavigateTo<TVM>()
        where TVM : ViewModel;
        Task NavigateTo<TVM, TParameter>(TParameter parameter)
        where TVM : ViewModel;
        void RemoveLastView();
        void ClearBackStack();
        void NavigateToUri(Uri uri);
        event PropertyChangedEventHandler CanGoBackChanged;
    }
}
