#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Silownia;

namespace Silownia.Pages.Komentarze
{
    public class EditModel : PageModel
    {
        private readonly Silownia.SilowniaContext _context;

        public EditModel(Silownia.SilowniaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Komentarz Komentarz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Komentarz = await _context.Komentarz.FirstOrDefaultAsync(m => m.Id == id);

            if (Komentarz == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Komentarz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KomentarzExists(Komentarz.Id))
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

        private bool KomentarzExists(int id)
        {
            return _context.Komentarz.Any(e => e.Id == id);
        }
    }
}
