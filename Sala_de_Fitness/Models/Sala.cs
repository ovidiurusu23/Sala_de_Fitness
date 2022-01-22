using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sala_de_Fitness.Models
{
    public class Sala
    {
        public int ID { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9''-'\s]{3,50}$",
         ErrorMessage = "Introduceti doar Litere si Cifre, max = 50, min = 3"), Required]
        public string Nume { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,50}$",
         ErrorMessage = "Introduceti doar Litere, max = 50, min = 3"), Required]
        public string Oras { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{3,50}$",
         ErrorMessage = "Introduceti doar Litere, max = 50, min = 3"), Required]

        public string Judet { get; set; }
    }
}
