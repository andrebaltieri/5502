using BookStore.Validators;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BookStore.ViewModels
{
    public class EditorBookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome inválido")]
        [Display(Name = "Nome do livro")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "ISBN inválido")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Data inválida")]
        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria")]
        public int CategoriaId { get; set; }
        public SelectList CategoriaOptions { get; set; }

        [CheckAgeValidator]
        public DateTime Age { get; set; }
    }
}