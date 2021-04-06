using BowlingLeague.Models;
using BowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext Context { get; set; }


        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            Context = ctx;
        }

        public IActionResult Index(long? teamId, string teamName, int pageNum = 0)
        {
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = Context.Bowlers
                    .Where(x => x.TeamId == teamId || teamId == null)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()
                ,

                PageNumberingInfo = new PageNumberingInfo
                {
                    PageItems = 5,
                    CurrentPage = pageNum,
                    // Get correct number of items based on if a team is selected
                    TotalItems = (teamId == null ? Context.Bowlers.Count() :
                    Context.Bowlers.Where(x => x.TeamId == teamId).Count())
                },

                Team = teamName
            });
        }
                

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
