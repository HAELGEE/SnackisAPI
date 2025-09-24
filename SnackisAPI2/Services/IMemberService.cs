using SnackisAPI.DTOs;
using SnackisAPI.Models;

namespace SnackisAPI.Services;
public interface IMemberService
{
    Task<List<MemberDto>> GetAllMembersAsync();
    Task<List<Post>> GetAllPostsByMemberId(int id);
    Task<List<Post>> GetAllPostsByDate(DateTime dateTime);

}