using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sala_de_Fitness.Data;
using Sala_de_Fitness.Models;

namespace Sala_de_Fitness.Pages.Sali
{
    public class CreateModel : PageModel
    {
        private readonly Sala_de_Fitness.Data.Sala_de_FitnessContext _context;

        public CreateModel(Sala_de_Fitness.Data.Sala_de_FitnessContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Sala Sala { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sala.Add(Sala);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
