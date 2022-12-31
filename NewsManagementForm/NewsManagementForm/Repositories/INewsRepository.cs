using NewsManagementForm.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsManagementForm.Repositories
{
  public  interface INewsRepository
    {
       
            event EventHandler<News> OnItemAdded;
            event EventHandler<News> OnItemUpdated;
            Task<List<News>> GetItems();
           
        Task AddItem(News item);
            Task UpdateItem(News item);
            Task AddOrUpdate(News item);
        
    }
}
