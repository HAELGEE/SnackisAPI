using Microsoft.EntityFrameworkCore;
using SnackisAPI.Data;
using SnackisAPI.Models;

namespace SnackisAPI.Repositories;
public class MemberRepository : IMemberRepository
{
    private readonly MyDbContext _dbContext;

    public MemberRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Member>> GetAllMembersAsync() => await _dbContext.Member.ToListAsync();
    
    public async Task<List<Post>> GetAllPostsByMemberId(int id) => await _dbContext.Post
        .Where(p => p.MemberId == id)
        .Include(p => p.SubPosts)
        .ToListAsync();

    public async Task<List<Post>> GetAllPostsByDate(DateTime dateTime) => await _dbContext.Post
        .Where(p => p.Created.Date == dateTime.Date)
        .Include(p => p.SubPosts)
        .ToListAsync();
}
