using SnackisAPI.DTOs;
using SnackisAPI.Models;
using SnackisAPI.Repositories;

namespace SnackisAPI.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;   

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;        
    }

    public async Task<List<MemberDto>> GetAllMembersAsync()
    {
        var membersDTO = from m in await _memberRepository.GetAllMembersAsync()
                         select new MemberDto()
                         {
                             Id = m.Id,
                             FirstName = m.FirstName,
                             LastName = m.LastName,
                             Birthday = m.Birthday,
                             UserName = m.UserName,
                             TotalPosts = m.TotalPosts,
                             TotalReply = m.TotalReply,
                             RegisteryDate = m.RegisteryDate,
                         };


        return membersDTO.ToList();
    }

    public async Task<List<Post>> GetAllPostsByMemberId(int id)
    {
        return await _memberRepository.GetAllPostsByMemberId(id);
    }
    public async Task<List<Post>> GetAllPostsByDate(DateTime dateTime)
    {
        return await _memberRepository.GetAllPostsByDate(dateTime);
    }

}
