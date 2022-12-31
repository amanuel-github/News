using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManagementForm.API.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReportName { get; set; }
        public string Status { get; set; }
        public Nullable<int> NewsCategoryId { get; set; }
        public string Body { get; set; }

    }
}
