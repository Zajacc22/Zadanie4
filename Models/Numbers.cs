using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zad3.Models
{
    public class Numbers
    {
            public int Id { get; set; }

            [Display(Name = "Liczba:")]
            [Required(ErrorMessage = "Podaj liczbę!")]
            [Range(1, 1000, ErrorMessage = "Podaj liczbę z zakresu 1-1000!")]
            public int Number { get; set; }

            public DateTime Date { get; set; }

            public string Message { get; set; }
    }
}
