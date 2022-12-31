using InvestmentPermit.Infrastructure.DBContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsManagementForm.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManagementForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly NewsDbContext context;
        public NewsController(NewsDbContext invesRepository
             )
        {
            context = invesRepository;
            
        }

        [HttpGet]
        public async Task<IEnumerable<News>> GetNews()
        {
            return await context.News.ToListAsync();
         
        }
        [HttpGet("NewsCategory")]
        public async Task<IEnumerable<NewsCategory>> GetNewsCategories()
        {
            return await context.NewsCategories.ToListAsync();

        }
        [HttpPost]
        public async Task AddNews([FromBody]News news)
       {
            await context.News.AddAsync(news);
            await context.SaveChangesAsync();
        }

        [HttpPut]
        public IActionResult UpdateNews( News news)
        {

            context.News.Attach(news);
            context.Entry(news).State = EntityState.Modified;
            context.SaveChanges();
            return NoContent();

        }

        [HttpDelete]
        public async Task Delete(int id)
        {
             var obj = context.News.Find(id);
        
           context.News.Remove(obj);
            await context.SaveChangesAsync();
        }
    }
}
