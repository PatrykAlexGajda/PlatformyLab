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
    public class IndexModel : PageModel
    {
        private readonly Silownia.SilowniaContext _context;

        public IndexModel(Silownia.SilowniaContext context)
        {
            _context = context;
        }

        public IList<Komentarz> Komentarz { get;set; }

        public async Task OnGetAsync()
        {
            Komentarz = await _context.Komentarz.ToListAsync();
        }
    }
}
