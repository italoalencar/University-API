﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University_API.DTOs;
using University_API.Services;

namespace University_API.Controllers;

[ApiController]
[Route("[controller]")]
public class AdministradorController : ControllerBase
{
    private readonly AdministradorService _service;

    public AdministradorController(AdministradorService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraAdm([FromBody] CreateAdmDTO admDTO)
    {
        var resultado = await _service.CreateAdm(admDTO);
        if (resultado.Succeeded) return Ok("Administrador cadastrado!");
        return BadRequest("Falha ao realizar cadastro!");
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAdm([FromBody] LoginAdmDTO admDTO)
    {
        var token = await _service.LoginAdm(admDTO);
        return Ok(token);
    }
}
