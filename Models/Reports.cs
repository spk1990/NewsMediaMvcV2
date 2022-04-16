using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reports.Models
{
public class Report
{
	public int Id { get; set; }

        [DisplayName("Title")]
        public string? ReportName { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string? Description { get; set; }
        
        [Required]
        [MaxLength(5000)]
         public string? Body {get; set; }
        
        [Required]
        [DisplayName("Created By")]
        public Guid CreatedBy { get; set; }

        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Last Modified")]
        public DateTime LastUpdatedDate { get; set; }
        public string? Category { get; set; }
        
}
}