using Microsoft.AspNetCore.Mvc;
using SnackisAPI.Services;
using SnackisAPI.DTOs;
using SnackisAPI.Models;

namespace SnackisAPI.Controllers;

[Route("api/[controller]")]
[ApiController]

public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;   

    public MemberController(IMemberService memberService)
    {
        _memberService = memberService;
        
    }

   [HttpGet]
    public async Task<ActionResult<List<MemberDto>>> Get()
    {
        return Ok(await _memberService.GetAllMembersAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Post>>> Get(int id)
    {
        return Ok(await _memberService.GetAllPostsByMemberId(id));
    }

    [HttpGet("{date:datetime}")]
    public async Task<ActionResult<List<Post>>> Get(DateTime date)
    {
        return Ok(await _memberService.GetAllPostsByDate(date));
    }
}
