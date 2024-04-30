using Microsoft.AspNetCore.Mvc;

using RESTAPI_CORE.Datos;
using RESTAPI_CORE.Modelos;

namespace CRUDCORE.Controllers
{
    public class InscripcionController : Controller
    {

        InscriptosDatos _ContactoDatos = new InscriptosDatos();

        public IActionResult Listar()
        {
       
            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
    
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(InscriptosModel oContacto)
        {
           
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int Id)
        {
            
            var ocontacto = _ContactoDatos.Obtener(Id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(InscriptosModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int Id)
        {
            
            var ocontacto = _ContactoDatos.Obtener(Id);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(InscriptosModel oContacto)
        {
  
            var respuesta = _ContactoDatos.Eliminar(oContacto.Id);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
