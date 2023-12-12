using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Tls;
using RepresentanteMVC.Dados;
using RepresentanteMVC.Models;

namespace RepresentanteMVC.Controllers
{
    public class PedidosController : Controller
    {
        public int id;
        public IActionResult Index() => View();
        public IActionResult verificarAcesso(Pedidos pedidos)
        {
            Representante representante = new();
            id = pedidos.RepresentanteId;
            bool conf = new Dados.DadosPedidos().VerificarRepresentante(pedidos);

            if (conf == true)
            {
                return RedirectToAction("Pedidos");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
        public IActionResult Pedidos()
        {

            return View(new DadosPedidos().ConsultarTodos());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.representante = new DadosRepresentante().ConsultarNomeId()
              .Select(representantes => new SelectListItem()
              {
                  Text = representantes.RazaoSocial,
                  Value = representantes.Id.ToString()
              })
              .ToList();

            ViewBag.empresa = new DadosEmpresa().ConsultarNomeId()
              .Select(empresas => new SelectListItem()
              {
                  Text = empresas.RazaoSocial,
                  Value = empresas.Id.ToString()
              })
            .ToList();

            ViewBag.loja = new DadosLoja().ConsultarNomeId()
                .Select(lojas => new SelectListItem()
                {
                    Text = lojas.RazaoSocial,
                    Value = lojas.Id.ToString()
                })
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Pedidos pedidos)
        {
            new DadosPedidos().Adicionar(pedidos);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Pedidos pedidos = new DadosPedidos().ConsultarPorId((int)id);
            return View(pedidos);
        }

        [HttpPost]
        public IActionResult Edit(Pedidos pedidos)
        {
            Pedidos pedido = new DadosPedidos().ConsultarPorId(pedidos.Id);

            if (new DadosPedidos().Editar(pedido))
            {
                return RedirectToAction("Index");
            }
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            Pedidos pedidos = new DadosPedidos().ConsultarPorId((int)id);
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            new DadosPedidos().Deletar((int)id);
            return RedirectToAction("Index");
        }
    }
}
