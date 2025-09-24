using System.ComponentModel.DataAnnotations;

namespace SnackisAPI.Models;
public class SubPost
{
    public int Id { get; set; }

    
    public string? Text { get; set; }
    public bool? Reported { get; set; } = false;

    public DateTime? Created { get; set; } = DateTime.Now;


    // DB connections
    public int? PostId { get; set; }
    public int? MemberId { get; set; }
    public Member? Member { get; set; }

}
