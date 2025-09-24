using SnackisAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackisAPI.DTOs;
public class MemberDto
{
    public int Id { get; set; }    
    public string? FirstName { get; set; }    
    public string? LastName { get; set; }    
    public string? Birthday { get; set; }
    public string? UserName { get; set; }

    // Information for the View on Profile
    public int Age
    {
        get
        {
            if (Birthday!.Length == 8)
            {
                var birthStr = Birthday;
                var birthDate = DateTime.ParseExact(birthStr, "yyyyMMdd", CultureInfo.InvariantCulture);
                var age = DateTime.Now.Year - birthDate.Year;
                if (DateTime.Now < birthDate.AddYears(age)) age--;
                return age;
            }
            else
                return 0;
        }
    }
    public int TotalPosts { get; set; } = 0;
    public int TotalReply { get; set; } = 0;   
    public DateTime? RegisteryDate { get; set; } = DateTime.Now;
    public ICollection<Post>? Posts { get; set; }
    public ICollection<SubPost>? SubPosts { get; set; }

}
