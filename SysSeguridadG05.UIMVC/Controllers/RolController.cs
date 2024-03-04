using Microsoft.AspNetCore.Mvc;
//referencias
using SysSeguridadG05.EN;
using SysSeguridadG05.BL;

namespace SysSeguridadG05.UIMVC.Controllers
{
    public class RolController : Controller
    {
        RolBL rolBL = new RolBL(); 
        public async Task<IActionResult> Index(Rol pRol = null)
        {
            if (pRol == null)
                 pRol = new Rol();

            if (pRol.Top_Aux == 0)
                 pRol.Top_Aux = 10;
            else
                if(pRol.Top_Aux == -1)
                    pRol.Top_Aux = 0;

            var roles = await new RolBL().BuscarAsync(pRol);
            ViewBag.Top = pRol.Top_Aux;
            return View(roles);
        }
    }
}
