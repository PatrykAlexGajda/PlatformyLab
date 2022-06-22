#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Silownia;

namespace Silownia.Pages.Komentarze
{
    public class DetailsModel : PageModel
    {
        private readonly Silownia.SilowniaContext _context;

        public DetailsModel(Silownia.SilowniaContext context)
        {
            _context = context;
        }

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
    }
}
