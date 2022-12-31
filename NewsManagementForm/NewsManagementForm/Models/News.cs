using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NewsManagementForm.Models
{
    public class News 
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Body should not be empty")]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string ReportName { get; set; }
        public string Status { get; set; }
        [Range(1000, 1500, ErrorMessage = "EmployeeID should be between 1000 and 1500")]
        public int NewsCategoryId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Body should not be empty")]
        public string Body { get; set; }

    }
}
