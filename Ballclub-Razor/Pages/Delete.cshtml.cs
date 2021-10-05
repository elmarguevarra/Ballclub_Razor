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
    public class DeleteModel : PageModel
    {
        private readonly BallClub.Repositories.Data.ApplicationDbContext _context;

        public DeleteModel(BallClub.Repositories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TeamDTO = await _context.Teams.FindAsync(id);

            if (TeamDTO != null)
            {
                _context.Teams.Remove(TeamDTO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
