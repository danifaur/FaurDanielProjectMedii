using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace FaurDanielProiectMedii.Models
{
    public class Intensitate
    {
        public Intensitate()
        {
        }

        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$",
        ErrorMessage = "Doar literele vor fi permise, de la 3 la 40 de caractere"), Required]
        public string Nume { get; set; }
    }
}
