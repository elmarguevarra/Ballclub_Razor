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
    public class TeamsModel : PageModel
    {
        private readonly BallClub.Repositories.Data.ApplicationDbContext _context;

        public TeamsModel(BallClub.Repositories.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TeamDTO> TeamDTO { get;set; }

        public async Task OnGetAsync()
        {
            TeamDTO = await _context.Teams.ToListAsync();
        }
    }
}
