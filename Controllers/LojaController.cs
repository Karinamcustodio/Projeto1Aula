using Microsoft.AspNetCore.Mvc;
using RepresentanteMVC.Dados;
using RepresentanteMVC.Models;

namespace RepresentanteMVC.Controllers
{
    public class LojaController : Controller
    {
        public IActionResult Index()
        {
            return View(new DadosLoja().ConsultarTodos());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loja loja)
        {
            new DadosLoja().Adicionar(loja);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Loja loja = new DadosLoja().ConsultarPorId((int)id);
            return View(loja);
        }

        [HttpPost]
        public IActionResult Edit(Loja loja)
        {
            if (new DadosLoja().Editar(loja))
            {
                return RedirectToAction("Index");
            }
            return View(loja);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Loja loja = new DadosLoja().ConsultarPorId((int)id);
            return View(loja);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            new DadosLoja().Deletar((int)id);
            return RedirectToAction("Index");
        }
    }
}