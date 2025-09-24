using SnackisAPI.Models;

namespace SnackisAPI.Repositories;
public interface IMemberRepository
{
    Task<List<Member>> GetAllMembersAsync();
    Task<List<Post>> GetAllPostsByMemberId(int id);
    Task<List<Post>> GetAllPostsByDate(DateTime dateTime);

}