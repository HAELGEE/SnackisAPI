using System.ComponentModel.DataAnnotations;

namespace SnackisAPI.Models;
public class Post
{
    public int Id { get; set; }

   
    public string Description { get; set; } // What the Post is about (short description)

    public string Text { get; set; }   // Text (information about the context)

    public int Reply { get; set; } = 0;
    public bool? Reported { get; set; } = false;
    public int? ReporterId { get; set; }
    public int TotalReports { get; set; } = 0;

    public DateTime Created { get; set; } = DateTime.UtcNow;


    // DB connections
    public int? SubCategoryId { get; set; }  
    public int? MemberId { get; set; }
    public Member? Member { get; set; }
    public ICollection<SubPost>? SubPosts { get; set; }
   

}
