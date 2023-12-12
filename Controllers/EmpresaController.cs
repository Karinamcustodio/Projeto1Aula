using Microsoft.AspNetCore.Mvc;
using RepresentanteMVC.Dados;
using RepresentanteMVC.Models;

namespace RepresentanteMVC.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View(new DadosEmpresa().ConsultarTodos());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empresa empresa)
        {
            new DadosEmpresa().Adicionar(empresa);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Empresa empresa = new DadosEmpresa().ConsultarPorId((int)id);
            return View(empresa);
        }

        [HttpPost]
        public IActionResult Edit(Empresa empresa)
        {
            Empresa empresas = new DadosEmpresa().ConsultarPorId(empresa.Id);
            empresas.RazaoSocial = empresa.RazaoSocial;

            if (new DadosEmpresa().Editar(empresa))
            {
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Empresa empresa = new DadosEmpresa().ConsultarPorId((int)id);
            return View(empresa);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            new DadosEmpresa().Deletar((int)id);
            return RedirectToAction("Index");
        }
    }
}
