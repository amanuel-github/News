using NewsManagementForm.Models;
using NewsManagementForm.Repositories;
using NewsManagementForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsManagementForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNewsPage : ContentPage
    {
        private readonly NewsRepository _repository;
        public EditNewsPage(News news)
        {
            InitializeComponent();
            var editNewsViewModel = new EditNewsViewModel(new NewsRepository());
            editNewsViewModel.news = news;
            BindingContext = editNewsViewModel;
            editNewsViewModel.Navigation = Navigation;

        }
    }
}