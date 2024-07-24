using System.Security.Authentication;
using AutoServiceConnect.Api.CustomAttributes;
using AutoServiceConnect.Api.Database.Models;
using AutoServiceConnect.Api.Services;
using AutoServiceConnect.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AutoServiceConnect.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController: ControllerBase
{
    private readonly UserService _userService;
    private readonly GoogleAuthenticationService _googleAuthenticationService;

    public UserController(UserService userService, GoogleAuthenticationService googleAuthenticationService)
    {
        _userService = userService;
        _googleAuthenticationService = googleAuthenticationService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterStudent([FromBody] RegisterLoginUserRequest request)
    {
        var userId = await _userService.RegisterUser(request.Email, request.Password);
        return Created($"{Request.Host}/student/{userId.ToString()}", request);
    }
    
    [HttpGet("auth-me")]
    public async Task<ActionResult<LoginUserResponse>> GetUserInfo()
    {
        User? result = null;
        var userId = User.FindFirst("UserId")?.Value;
        if (int.TryParse(userId, out var intUserId))
            result = await _userService.GetUserById(intUserId);
        else
            throw new AuthenticationException("Token not valid");
        if (result == null)
            throw new AuthenticationException("Token not valid");

        return Ok(result);
    }

    [HttpPost("google-auth")]
    public async Task<ActionResult<LoginUserResponse>> GoogleAuth([FromBody] GoogleAuthRequest request)
    {
        var response = await _googleAuthenticationService.Authenticate(request.AuthCode);
        
        return Ok(new LoginUserResponse{Email = response.Email, Token = response.Token});
    }
        
    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> LoginUser([FromBody] RegisterLoginUserRequest request)
    {
        var result = await _userService.Login(request.Email, request.Password);
        return Ok(result);
    }
    
    
    // [AuthorizeRoles([Role.Admin,Role.AutoServiceManager])]
    // [HttpPost("test")]
    // public async Task<ActionResult<LoginUserResponse>> Test()
    // {
    //     return Ok();
    // } 
}