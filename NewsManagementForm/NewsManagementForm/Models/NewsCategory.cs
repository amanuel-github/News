using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsManagementForm.Models
{
   public class NewsCategory
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
