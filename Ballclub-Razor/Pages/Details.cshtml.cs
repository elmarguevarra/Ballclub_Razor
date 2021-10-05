using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BallClub.Repositories.Data;
using BallClub.Repositories.Messages;

namespace Ballclub_Razor.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly BallClub.Repositories.Data.ApplicationDbContext _context;

        //public DetailsModel(BallClub.Repositories.Data.ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public TeamDTO TeamDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamDTO = await _context.Teams.FirstOrDefaultAsync(m => m.TeamId == id);

            if (TeamDTO == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
