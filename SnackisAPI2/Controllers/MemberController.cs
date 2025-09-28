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
            return Ok(members);

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Servern ligger nere: {ex}");
        }

    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<Post>>> Get(int id)
    {
        var allUsers = await _memberService.GetAllMembersAsync();
        bool userFound = false;
        if (allUsers != null)
        {
            foreach (var user in allUsers)
            {
                if (user.Id == id)
                {
                    userFound = true; break;
                }
            }
        }

        if (!userFound)
        {
            return StatusCode(400, $"Inget id hittad med id: {id}");
        }

        try
        {
            var posts = await _memberService.GetAllPostsByMemberId(id);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Servern ligger nere: {ex}");
        }

            

    }

    [HttpGet("{date:datetime}")]
    public async Task<ActionResult<List<Post>>> Get(DateTime date)
    {

        try
        {
            var posts = await _memberService.GetAllPostsByDate(date);

            var dateFound = false;

            if (posts != null)
            {

                foreach (var post in posts)
                {
                    foreach (var subPost in post.SubPosts)
                    {
                        if (post.Created.Date == date.Date || subPost.Created.Date == date.Date)
                        {
                            dateFound = true; break;
                        }
                    }
                }
            }

            if (!dateFound)
            {
                return StatusCode(400, $"Inget skapat under detta datumet: {date}");
            }

            return Ok(posts);

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Servern ligger nere: {ex}");
        }

    }
}
