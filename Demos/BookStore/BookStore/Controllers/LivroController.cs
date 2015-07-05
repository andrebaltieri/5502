using BookStore.Context;
using BookStore.Domain;
using BookStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [RoutePrefix("livros")]
    public class LivroController : Controller
    {
        BookStoreDataContext _db = new BookStoreDataContext();

        [Route("listar")]
        public ActionResult Index()
        {
            return View(_db.Livros.ToList());
        }

        [Route("criar")]
        public ActionResult Create()
        {
            var categorias = _db.Categorias.ToList();
            var model = new EditorBookViewModel
            {
                Nome = "",
                ISBN = "",
                CategoriaId = 0,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };

            return View(model);
        }

        [Route("criar")]
        [HttpPost]
        public ActionResult Create(EditorBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var categorias = _db.Categorias.ToList();
                model.CategoriaOptions = new SelectList(categorias, "Id", "Nome");
                return View(model);
            }

            var livro = new Livro();
            livro.Nome = model.Nome;
            livro.ISBN = model.ISBN;
            livro.DataLancamento = model.DataLancamento;
            livro.CategoriaId = model.CategoriaId;
            _db.Livros.Add(livro);

            try
            {
                throw new Exception("Falha no banco");
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Mensagem", ex.Message);
                var categorias = _db.Categorias.ToList();
                model.CategoriaOptions = new SelectList(categorias, "Id", "Nome");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [Route("editar")]
        public ActionResult Edit(int id)
        {
            var categorias = _db.Categorias.ToList();
            var livro = _db.Livros.Find(id);

            var model = new EditorBookViewModel
            {
                Nome = livro.Nome,
                ISBN = livro.ISBN,
                CategoriaId = livro.CategoriaId,
                CategoriaOptions = new SelectList(categorias, "Id", "Nome")
            };

            return View(model);
        }

        [Route("editar")]
        [HttpPost]
        public ActionResult Edit(EditorBookViewModel model)
        {
            var livro = _db.Livros.Find(model.Id);
            _db.Entry<Livro>(livro).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}