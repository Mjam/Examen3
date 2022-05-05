using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
namespace WebAppLab.Pages
{
    public class IndexModel : PageModel
    {

      
        public IActionResult OnGet()
        {

            if (!this.SessionOnline()) return RedirectToPage("Login");



           


            return Page();

        }
    }
}
