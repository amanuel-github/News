using NewsManagementForm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace NewsManagementForm.ViewModels
{
   
        public class ToDoNewsViewModel : ViewModel
        {
            public ToDoNewsViewModel(News item) => Item = item;
            public event EventHandler ItemStatusChanged;
            public News Item { get; private set; }
         
         

        }
    }
