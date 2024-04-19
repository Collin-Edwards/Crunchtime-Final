using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Crunchtime.Entities;
using CrunchtimeRazor.Data;

namespace CrunchtimeRazor.Pages.UserCRUD
{
    public class IndexModel : PageModel
    {
        private readonly CrunchtimeRazor.Data.ApplicationDbContext _context;

        public IndexModel(CrunchtimeRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
