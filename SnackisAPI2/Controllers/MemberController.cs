using Microsoft.AspNetCore.Mvc;
using SnackisAPI.Services;
using SnackisAPI.DTOs;
using SnackisAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;

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
        try
        {
            var members = await _memberService.GetAllMembersAsync();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Servern ligger nere: {ex}");
        }

        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Post>>> Get(int id)
    {
        try
        {
            var posts = await _memberService.GetAllPostsByMemberId(id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Servern ligger nere: {ex}");
        }

        return Ok();
    }

    [HttpGet("{date:datetime}")]
    public async Task<ActionResult<List<Post>>> Get(DateTime date)
    {
        try
        {
            var posts = await _memberService.GetAllPostsByDate(date);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Servern ligger nere: {ex}");
        }

        return Ok();
    }
}
