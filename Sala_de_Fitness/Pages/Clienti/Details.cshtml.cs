using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sala_de_Fitness.Data;
using Sala_de_Fitness.Models;

namespace Sala_de_Fitness.Pages.Clienti
{
    public class DetailsModel : PageModel
    {
        private readonly Sala_de_Fitness.Data.Sala_de_FitnessContext _context;

        public DetailsModel(Sala_de_Fitness.Data.Sala_de_FitnessContext context)
        {
            _context = context;
        }

        public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Client
                .Include(c => c.Sala)
                .Include(c => c.Instructor).FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
