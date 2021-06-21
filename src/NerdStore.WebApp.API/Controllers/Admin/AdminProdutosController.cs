using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerdStore.WebApp.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public AdminProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet("admin-produtos")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _produtoAppService.ObterPorTodos());
        }
    }
}
