using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empresa.GetAllEF();
            ML.Empresa empresa = new ML.Empresa();
            if(result.Correct)
            {
               empresa.Empresas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Error al cargar la informacion";
            }


            return View(empresa);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpresa) //se usa el int? para que acepte valores null
        {
            if (IdEmpresa == null)
            {

                return View();
            }

            else
            {
                ML.Result result = BL.Empresa.GetByIdEF(IdEmpresa.Value);

                ML.Empresa empresa = new ML.Empresa();

                if (result.Correct)
                {
                    //Se tiene que hacer un unboxing del objeto que nos trajo el metodo de GEYBYID
                    empresa = (ML.Empresa)result.Object; //Se usa el object porque solo es 1 objeto 
                }
                else
                {
                    ViewBag.Message = "Error al cargar la informacion";
                }
                return View(empresa);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa) //se usa el int? para que acepte valores null
        {
            //ML.Usuario usuario = new ML.Usuario();

            if (empresa.IdEmpresa == 0)
            {
                ML.Result result = BL.Empresa.AddEF(empresa);
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
                ML.Result result = BL.Empresa.UpdateEF(empresa);

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

        public ActionResult Delete(ML.Empresa empresa)
        {
            ML.Result result = BL.Empresa.DelateEF(empresa);
            if(result.Correct)
            {
                ViewBag.Message = result.Message;
            }
            else
            {
                ViewBag.Message = "Error:" +result.Message;
            }
            return PartialView("Modal");
        }
    }
}