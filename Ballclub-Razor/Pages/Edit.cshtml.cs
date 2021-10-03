using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BallClub.Repositories.Data;
using BallClub.Repositories.Messages;

namespace Ballclub_Razor.Pages
{
    public class EditModel : PageModel
    {
        private readonly BallClub.Repositories.Data.ApplicationDbContext _context;

        public EditModel(BallClub.Repositories.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TeamDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamDTOExists(TeamDTO.TeamId))
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

        private bool TeamDTOExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }
    }
}
