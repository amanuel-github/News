using NewsManagementForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NewsManagementForm.Repositories
{
    public class NewsRepository : INewsRepository
    {
        public event EventHandler<News> OnItemAdded;
        public event EventHandler<News> OnItemUpdated;
        public async Task<List<News>> GetItems()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            var json = await client.GetStringAsync("http://10.0.2.2:13199/api/News");
            var news = JsonConvert.DeserializeObject<List<News>>(json);
            return news;
        }
        public async Task<List<NewsCategory>> GetNewsCategoryItems()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            var json = await client.GetStringAsync(" http://10.0.2.2:13199/api/News/NewsCategory");
            var news = JsonConvert.DeserializeObject<List<NewsCategory>>(json);
            return news;
        }
        //
        public async Task AddItem(News news)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            var json = JsonConvert.SerializeObject(news);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            await client.PostAsync("http://10.0.2.2:13199/api/News", content);
            OnItemAdded?.Invoke(this, news);
        }
      

        //***Deleting a Employee
        public async Task DeleteItem(int id)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            var response = await client.DeleteAsync("http://10.0.2.2:13199/api/News?id="+ id );
            Debug.WriteLine(response);
        }
        public async Task UpdateItem(News item)
        {
           
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer");
            var json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
          
            var response = await client.PutAsync("http://10.0.2.2:13199/api/News", content);
            Debug.WriteLine(response);
            OnItemUpdated?.Invoke(this, item);
        }

        public async Task AddOrUpdate(News item)
        {
            if (item.Id == 0)
            {
                await AddItem(item);
            }
            else
            {
                await UpdateItem(item);
            }
        }
       
        }
    }
