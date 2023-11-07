using Microsoft.AspNetCore.Mvc;
using NOVOROV.Context;
using NOVOROV.Models;
using NOVOROV.Services.Interfaces;
using System.Diagnostics;

namespace NOVOROV.Controllers
{
    public class HomeController : BaseController
    {
        private readonly RovDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService _apiService;

        public HomeController(ILogger<HomeController> logger, RovDbContext context, IApiService apiService)
        {
            _context = context;
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            var totalOcorrencias = _context.Ocorrencia.Count();
            TempData["totalOcorrencias"] = totalOcorrencias;

            var ocorrenciasSemBo = _context.Ocorrencia.Where(o => o.RegistroPolicialId == 2 || o.RegistroPolicialId == 3).Count().ToString();
            TempData["OcorrenciasSemBo"] = ocorrenciasSemBo;

            var totalOcorrenciasEncerradas = _context.Ocorrencia.Where(o => o.StatusId == 3).Count();
            TempData["TotalOcorrenciasEncerradas"] = totalOcorrenciasEncerradas;

            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            var auth = await _apiService.GetApiAuthToken();
            var apiData = await _apiService.GetApiData(auth.Token);
            return View(apiData);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult BuscaAvisos()
        {
            var avisos = _context.Aviso.ToList();
            return Json(avisos);
        }

        public async Task<IActionResult> Teste(int id)
        {
            int ocoId = 145;
            var ocorrencia = await _context.Ocorrencia.FindAsync(ocoId);
            return View(ocorrencia);
        }
    }
}