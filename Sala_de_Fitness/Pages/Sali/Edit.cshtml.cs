using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sala_de_Fitness.Data;
using Sala_de_Fitness.Models;

namespace Sala_de_Fitness.Pages.Sali
{
    public class EditModel : PageModel
    {
        private readonly Sala_de_Fitness.Data.Sala_de_FitnessContext _context;

        public EditModel(Sala_de_Fitness.Data.Sala_de_FitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sala Sala { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sala = await _context.Sala.FirstOrDefaultAsync(m => m.ID == id);

            if (Sala == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(Sala.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SalaExists(int id)
        {
            return _context.Sala.Any(e => e.ID == id);
        }
    }
}
