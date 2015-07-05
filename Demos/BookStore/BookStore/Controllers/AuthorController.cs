using BookStore.Domain;
using BookStore.Filters;
using BookStore.Repositories;
using BookStore.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("autores")]
    //[LogActionFilter()]
    public class AuthorController : Controller
    {
        private IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }

        [Route("listar")]
        //[LogActionFilter()]
        public ActionResult Index()
        {
            var autores = _repository.Get();
            return View(autores);
        }

        [Route("criar")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(Autor author)
        {
            if (_repository.Create(author))
                return RedirectToAction("Index");

            return View(author);
        }

        [Route("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            var author = _repository.Get(id);
            return View(author);
        }

        [Route("editar/{id:int}")]
        [HttpPost]
        public ActionResult Edit(Autor author)
        {
            if (_repository.Update(author))
                return RedirectToAction("Index");

            return View(author);
        }

        [Route("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            var author = _repository.Get(id);
            return View(author);
        }

        [Route("excluir/{id:int}")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}