using BookStore.Domain;
using System;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class TesteController : Controller
    {
        public ViewResult Dados(int Id)
        {
            var autor = new Autor
            {
                Id = 1,
                Nome = "André Baltieri"
            };

            ViewBag.Categoria = "Produtos de Limpeza";
            ViewData["Categoria"] = "Produtos de Informática";
            TempData["Categoria"] = "Produtos de Escritório";
            Session["Categoria"] = "Móveis";

            return View(autor);
        }

        public string Index(int Id)
        {
            return "Index do " + Id.ToString();
        }

        public JsonResult UmaAction(int? id, string nome)
        {            
            var autor = new Autor
            {
                Id = 0,
                Nome = nome
            };

            return Json(autor, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Autor")]
        public JsonResult ActionDois(Autor autor)
        {
            return Json(autor);
        }
    }
}