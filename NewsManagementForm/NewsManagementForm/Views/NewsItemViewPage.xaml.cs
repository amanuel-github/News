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
    public partial class NewsItemView : ContentPage
    {



        private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = sender as Picker;
        
            bool focused = picker.IsFocused;
            if (!focused)
            {
                int x = 3;
            }
        }

        DatePicker datePicker = new DatePicker
        {
            MinimumDate = new DateTime(2018, 1, 1),
            MaximumDate = new DateTime(2018, 12, 31),
            Date = new DateTime(2018, 6, 21)
        };

        public NewsItemView(NewsViewModel viewmodel)
        {
            InitializeComponent();
            var createNewsViewModel = new NewsViewModel(new NewsRepository());
            createNewsViewModel.categorys = viewmodel.categorys;
            BindingContext = createNewsViewModel;
            items.ItemsSource = createNewsViewModel.categorys;
            viewmodel.Navigation = Navigation;
        }

        void DatePickerDateSelected(object sender, DateChangedEventArgs e)
        {
        }
        void PickerSelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}