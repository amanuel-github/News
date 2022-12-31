using NewsManagementForm.Models;
using NewsManagementForm.Repositories;
using NewsManagementForm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsManagementForm.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MainViewModel : ViewModel
    {
        private readonly NewsRepository _repository;
        public ObservableCollection<News> items = new ObservableCollection<News>();
       
        public string FilterText => ShowAll ? "All" : "Active";
        public ICommand ToggleFilter => new Command(async () =>
        {
            ShowAll = !ShowAll;
           
        });

        public MainViewModel(NewsRepository repository)
        {

            _repository = repository;
            Init();
           
        }

        public async void Init()
        {
            var prod = await _repository.GetItems();
            foreach (var item in prod)
            {
                items.Add(item);
            }
          
        }
    

        public bool ShowAll { get; set; }


        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<NewsItemView>();
            await Navigation.PushAsync(itemView);
        });
    }
}
