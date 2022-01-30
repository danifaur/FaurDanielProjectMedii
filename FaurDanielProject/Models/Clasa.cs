using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace FaurDanielProiectMedii.Models
{
    public class Clasa
    {
        public Clasa()
        {
        }

        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,40}$",
        ErrorMessage = "Doar literele vor fi permise, de la 3 la 40 de caractere"), Required]
        public string Nume { get; set; }
        public int NivelID { get; set; }
        public Nivel Nivel { get; set; }
        public int IntensitateID { get; set; }
        public Intensitate Intensitate { get; set; }
        public int AntrenorID { get; set; }
        public Antrenor Antrenor { get; set; }
 
        [Display(Name = "Data Antrenamentului")]
        public DateTime DateTime { get; set; }
    }
}
