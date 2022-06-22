#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Silownia
{
    public class IndexModel : PageModel
    {   
        public string post { get; set; }
        private readonly Silownia.SilowniaContext _context;
        public IndexModel(Silownia.SilowniaContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        /*public async Task OnGetAsync()
        {
            Post = await _context.Post.ToListAsync();
        }*/

        public async Task OnGetAsync(string pst)
        {
            Post = await _context.Post.ToListAsync();
            post = pst;

        }
        public List<Post> getLista()
        {
            if (post == "blog")
            {
                return _context.Post.Where(x=>x.CzyBlog == true).ToList();
            }
            else
            {
                return _context.Post.Where(x=>x.CzyBlog == false).ToList();
            }
        }
    }
}
