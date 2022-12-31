using NewsManagementForm.Models;
using NewsManagementForm.Repositories;
using NewsManagementForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsManagementForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public ObservableCollection<News> searches = new ObservableCollection<News>();
        MainViewModel main = new MainViewModel(new NewsRepository());
        public MainView(MainViewModel viewModel)
            {
                InitializeComponent();
                viewModel.Navigation = Navigation;
                BindingContext = viewModel;
            ListView.ItemsSource= viewModel.items;
            searches = viewModel.items;
           




        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListView.ItemsSource = SearchNews(e.NewTextValue);
        }
        public ObservableCollection<News> SearchNews(string searchText = null)
        {


            if (string.IsNullOrEmpty(searchText))
                return main.items;
            return searches;
        }
        private async void GoToEditNewsPage_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var news = e.Item as News;
            await Navigation.PushAsync(new EditNewsPage(news));
        }
    }
}