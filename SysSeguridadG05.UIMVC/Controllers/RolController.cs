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

        public async Task<IActionResult> Details(int pId)
        {
            var rol = await rolBL.ObtenerPorIdAsync(new Rol { Id = pId });
            return View(rol);
        }

        public IActionResult Create(int pId) 
        {
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rol pRol)
        {
            try
            {
                int result = await rolBL.CrearAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }

        public async Task<IActionResult> Edit(Rol pRol)
        {
            var rol = await rolBL.ObtenerPorIdAsync(pRol);
            ViewBag.Error = "";
            return View(rol);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int pId, Rol pRol)
        {
            try
            {
                int result = await rolBL.ModificarAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }

        public async Task<IActionResult> Delete(Rol pRol)
        {
            ViewBag.Error = "";
            var rol = await rolBL.ObtenerPorIdAsync(pRol);
            return View(rol);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Rol pRol)
        {
            try
            {
                int result = await rolBL.DeleteAsync(pRol);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pRol);
            }
        }

    }
}
