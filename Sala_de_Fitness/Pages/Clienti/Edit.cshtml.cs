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

namespace Sala_de_Fitness.Pages.Clienti
{
    public class EditModel : PageModel
    {
        private readonly Sala_de_Fitness.Data.Sala_de_FitnessContext _context;

        public EditModel(Sala_de_Fitness.Data.Sala_de_FitnessContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["SalaID"] = new SelectList(_context.Sala, "ID", "Nume");
           ViewData["InstructorID"] = new SelectList(_context.Instructor, "ID", "Nume");
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

            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.ID))
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

        private bool ClientExists(int id)
        {
            return _context.Client.Any(e => e.ID == id);
        }
    }
}
