using NewsManagementForm.Models;
using NewsManagementForm.Repositories;
using NewsManagementForm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsManagementForm.ViewModels
{
    public class NewsViewModel : ViewModel
    {

        private readonly NewsRepository _repository;

        public ObservableCollection<NewsCategory> categorys = new ObservableCollection<NewsCategory>();

        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReportName { get; set; }
        public int NewsCategoryId { get; set; }
        public string Status { get; set; }

        public string Body { get; set; }
        public NewsViewModel(NewsRepository repository)
        {
            _repository = repository;

            categories();
        }

        public ICommand Save
        {
            get
            {
                return new Command(async () =>
                {
                    var employee = new News
                    {
                        Title = Title,
                        DateCreated = DateCreated,
                        ReportName = ReportName,
                        NewsCategoryId = NewsCategoryId,
                        Status = Status,
                        Body = Body
                    };
                    await _repository.AddOrUpdate(employee);


                }
                );

            }
        }

        public async void categories()
        {
            var cat = await _repository.GetNewsCategoryItems();
            foreach (var item in cat)
            {
                categorys.Add(item);
            }

        }
    }
    }


