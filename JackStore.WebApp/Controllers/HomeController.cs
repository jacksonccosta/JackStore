using JackStore.Repository.Interface;
using JackStore.ViewModel;
using JackStore.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JackStore.WebApp
{
    public class HomeController : BaseController
    {
        private readonly IRepCategoriaProduto _repCategoriaProduto;
        private readonly IRepProduto _repProduto;

        public HomeController(IRepCategoriaProduto repCategoriaProduto, IRepProduto repProduto)
        {
            _repCategoriaProduto = repCategoriaProduto;
            _repProduto = repProduto;
        }

        private async Task InitIndex(string slug = "")
        {
            var categorias = (await _repCategoriaProduto.GetCategorias()).ToViewModel().OrderBy(x => x.Nome).ToList();
            ViewData["categorias"] = categorias;

            var produtos = (await _repProduto.GetProdutos(slug)).ToViewModel().OrderBy(x => x.Nome).ToList();
            ViewData["produtos"] = produtos;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await InitIndex();
            return View();
        }

        [HttpGet]
        [Route("categoria/{slug}")]
        public async Task<IActionResult> Categoria(string slug)
        {
            await InitIndex(slug);
            return View("Index");
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}