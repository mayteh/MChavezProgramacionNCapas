using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class AseguradoraController : Controller
    {
        // GET: Empresa
        public ActionResult GetAll()
        {
            ML.Result result = BL.Aseguradora.GetAllEF();
            ML.Aseguradora aseguradora = new ML.Aseguradora();
            if (result.Correct)
            {
                aseguradora.Aseguradoras = result.Objects;
            }
            else
            {
                ViewBag.Message = "Error al cargar la informacion";
            }


            return View(aseguradora);
        }

        [HttpGet]
        public ActionResult Form(int? idAseguradora) //se usa el int? para que acepte valores null
        {
            if (idAseguradora == null)
            {

                return View();
            }

            else
            {
                ML.Result result = BL.Aseguradora.GetByIdEF(idAseguradora.Value);

                ML.Aseguradora aseguradora = new ML.Aseguradora();

                if (result.Correct)
                {
                    //Se tiene que hacer un unboxing del objeto que nos trajo el metodo de GEYBYID
                    aseguradora = (ML.Aseguradora)result.Object; //Se usa el object porque solo es 1 objeto 
                }
                else
                {
                    ViewBag.Message = "Error al cargar la informacion";
                }
                return View(aseguradora);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Aseguradora aseguradora) //se usa el int? para que acepte valores null
        {
            //ML.Usuario usuario = new ML.Usuario();

            if (aseguradora.IdAseguradora == 0)
            {
                ML.Result result = BL.Aseguradora.AddEF(aseguradora);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error:" + result.Message;
                }

            }

            else
            {
                ML.Result result = BL.Aseguradora.UpdateEF(aseguradora);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }

            return PartialView("Modal");
        }

        public ActionResult Delete(ML.Aseguradora aseguradora)
        {
            ML.Result result = BL.Aseguradora.DelateEF(aseguradora);
            if (result.Correct)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Error:" + result.Message;
            }
            return PartialView("Modal");
        }
    }
}
