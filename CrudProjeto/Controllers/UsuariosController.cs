using CrudProjeto.Data;
using CrudProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudProjeto.Controllers;

[ApiController]//controler api
[Route("api/[controller]")]//end point entre [] pega o nome do arquivo

public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;//cirando variavel que pega o banco de dados

    public UsuariosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddUsuario(Usuarios usuario)//criando usuario
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return Ok(usuario);
    }

    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return Ok(usuarios);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUsuarios(Usuarios usuarios)
    {
        //fazer delete
        return Ok();
    }
}
