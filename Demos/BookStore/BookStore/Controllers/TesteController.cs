using BookStore.Domain;
using BookStore.Filters;
using System;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("teste")]
    [Route("{action=Dados}")]    
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

        [Route("minharota/{id:int}")]
        public string MinhaAction(int id)
        {
            return "OK! Cheguei na rota!";
        }

        [Route("~/rotaignorada/{id:int}")]
        public string MinhaAction2(int id)
        {
            return "OK! Cheguei na rota!";
        }

        [Route("rota/{categoria:alpha:minlength(3)}")]
        public string MinhaAction3(string categoria)
        {
            return "OK! Cheguei na rota! " + categoria;
        }

        //[Route("rota4/{estacao:(primavera|verao|outono|inverno)}")]
        //public string MinhaAction4(string estacao)
        //{
        //    return "Olá, estamos no " + estacao;
        //}
    }
}