using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace NewsMediaMvc.Controllers
{
    public class ReportsController : Controller
    {
       public IActionResult Index()
        {
            return View();
        }

        
    
        private readonly NewsMediaDbContext _context;

        public ReportsController(NewsMediaDbContext context)
        {
            _context = context;
        }

    }
}
