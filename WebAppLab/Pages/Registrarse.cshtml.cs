using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
namespace WebAppLab.Pages
{
    public class RegistrarseModel : PageModel
    {

        public UsuariosEntity Entity { get; set; } = new UsuariosEntity();
        public void OnGet()
        {
        }
    }
}
