using NewsManagementForm.Models;
using NewsManagementForm.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsManagementForm.ViewModels
{
    public class EditNewsViewModel : ViewModel
    {
        public News news { get; set; }
        private readonly NewsRepository _repository;
        public EditNewsViewModel() { }
        public EditNewsViewModel(NewsRepository repository)
        {
            _repository = repository;
        }
        public ICommand PutNewsCommand
        {
            get
            {
                return new Command(async () =>
                {

                    await _repository.UpdateItem(news);
                });
            }
        }

        public ICommand DeleteNewsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await _repository.DeleteItem(news.Id);
                });
            }
        }
    }
}
    