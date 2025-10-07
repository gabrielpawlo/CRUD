using CrudProjeto.Data;
using Microsoft.AspNetCore.Mvc;

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
}
