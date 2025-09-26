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
        var members = await _memberService.GetAllMembersAsync();

        if (members == null)
        {
            return StatusCode(500);
        }

        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Post>>> Get(int id)
    {
        var posts = await _memberService.GetAllPostsByMemberId(id);

        if (posts == null)
        {
            return StatusCode(500);
        }

        return Ok();
    }

    [HttpGet("{date:datetime}")]
    public async Task<ActionResult<List<Post>>> Get(DateTime date)
    {
        var posts = await _memberService.GetAllPostsByDate(date);

        if(posts == null)
        {
            return StatusCode(500);
        }

        return Ok();
    }
}
