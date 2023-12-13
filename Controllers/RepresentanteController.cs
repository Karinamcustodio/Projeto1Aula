using Microsoft.AspNetCore.Mvc;
using RepresentanteMVC.Dados;
using RepresentanteMVC.Models;

namespace RepresentanteMVC.Controllers
{
    public class RepresentanteController : Controller
    {
        public IActionResult Index()
        {
            return View(new DadosRepresentante().ConsultarTodos());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Representante representante)
        {
            new DadosRepresentante().Adicionar(representante);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Representante representante = new DadosRepresentante().ConsultarPorId((int)id);
            return View(representante);
        }

        [HttpPost]
        public IActionResult Edit(Representante representante)
        {
            if (new DadosRepresentante().Editar(representante))
            {
                return RedirectToAction("Index");
            }
            return View(representante);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Representante representante = new DadosRepresentante().ConsultarPorId((int)id);
            return View(representante);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            new DadosRepresentante().Deletar((int)id);
            return RedirectToAction("Index");
        }
    }
}
