using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewsMediaMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reports.Models;

namespace NewsMediaMvc.Controllers;

public class HomeController : Controller
{
    private readonly ReportsContext _context;
    //private readonly ReportsApiClient _ReportsApiContext;

        public HomeController(ReportsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
            var reports = from s in _context.Reports
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                reports = reports.Where(s => s.ReportName.Contains(searchString)
                                    || s.Category.Contains(searchString));
            }            
            switch (sortOrder)
            {
                case "name_desc":
                    reports = reports.OrderByDescending(s => s.ReportName);
                    break;
                case "Date":
                    reports = reports.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    reports = reports.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    reports = reports.OrderBy(s => s.ReportName);
                    break;
            }
            return View(await reports.AsNoTracking().ToListAsync());
        }

        

        private bool ReportsExists(int id)
        {
            return _context.Reports.Any(e => e.Id == id);
        }

        



}
