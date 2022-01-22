using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sala_de_Fitness.Models
{
    public class Client
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,50}$",
        ErrorMessage = "Introduceti doar Litere, max = 50, min = 3"), Required]
        public string Nume { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,50}$",
        ErrorMessage = "Introduceti doar Litere, max = 50, min = 3"), Required]
        public string Prenume { get; set; }
        [Display(Name = "Data Nasterii")]
        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }
        [Display(Name = "Instructor")]
        public int SalaID { get; set; }
        public Sala Sala { get; set; }
        [Display(Name = "Instructor")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }

    }
}
