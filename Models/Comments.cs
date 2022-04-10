using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Comments.Models
{
public class Comment
{
	public int Id { get; set; }
        
        [Required]
        [MaxLength(2000)]
        public string? CommentDescription { get; set; }
        
        [Required]
        [DisplayName("Created By")]
        public Guid CreatedBy { get; set; }

        [DisplayName("Date Created")]
        public DateTime CreatedDate { get; set; }
        
        public int ReportId {get; set;}
}
}