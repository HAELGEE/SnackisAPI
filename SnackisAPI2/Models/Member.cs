using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace SnackisAPI.Models;

[Index(nameof(UserName), nameof(Email), IsUnique = true)]
public class Member
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }   
    public string? Birthday { get; set; }    
    public string? UserName { get; set; }
    public string? Email { get; set; }   
    public string? Password { get; set; }
    public string? PasswordValidation { get; set; }

    // Admin rights
    public bool IsOwner { get; set; } = false;
    public bool IsAdmin { get; set; } = false;
    public int? Reports { get; set; } = 0;

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
    public string ProfileImagePath { get; set; } = "/uploads/standardProfile.png";

}
