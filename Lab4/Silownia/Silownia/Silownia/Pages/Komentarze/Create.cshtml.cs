#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Silownia;

namespace Silownia.Pages.Komentarze
{
    public class CreateModel : PageModel
    {
        private readonly Silownia.SilowniaContext _context;

        public CreateModel(Silownia.SilowniaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Komentarz Komentarz { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Komentarz.Add(Komentarz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
