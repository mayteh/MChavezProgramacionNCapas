using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        [HttpGet] //GetAll muestra toda la vista
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF();
            ML.Usuario usuario = new ML.Usuario();

            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Error al cargar la informacion";
            }


            return View(usuario);
        }

        [HttpGet] //Verifica si el usuario viene null o con informacion
        public ActionResult Form(int? IdUsuario) //se usa el int? para que acepte valores null
        {
            ML.Usuario usuario = new ML.Usuario(); //Se instancia la clase usuario para poder asignar el Rol
            usuario.Rol = new ML.Rol();   

            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultPais = BL.Pais.GetAll();
            ML.Result resultRol = BL.Rol.GetAll(); //Se manda a llamar al metodo de GetAll Rol para que tome en cuenta las opciones de la lista
             


            if (IdUsuario == null)
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                return View(usuario);
            }

            else
            {
                //GET BY ID
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);

                if (result.Correct)
                {
                    //Se tiene que hacer un unboxing del objeto que nos trajo el metodo de GEYBYID este a su vez los muestra en la vista
                    usuario = (ML.Usuario)result.Object;// Unboxing
                    usuario.Rol.Roles = resultRol.Objects; //ResultRol trae todos los Roles es necesario especificar la ruta: usuario.Rol.Roles


                    //Para mostrar direccion en el update
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;                    
                    ML.Result resultEstados = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                   
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstados.Objects;//unboxing

                    ML.Result resultMunicipios = BL.Municipio.MunicipioGetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipios.Objects;//unboxing

                    ML.Result resultColonias = BL.Colonia.ColoniaGetBYIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonias.Objects;//unboxing

                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Error al cargar la informacion";
                }
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario) //se usa el int? para que acepte valores null
        {
            //ML.Usuario usuario = new ML.Usuario();

            HttpPostedFileBase file = Request.Files["ImagenData"];
            //HttpPostedFileBase permite recuperar el elemento de tipo "file" con el nombre asignado "ImagenData"
            if (file.ContentLength > 0) //si en el file encuentra valores
            {
                usuario.Imagen = null; //ConvertToBytes(file); //los convierte a byte y asigna a usuario.Imagen
            }

            if (usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuario.AddEF(usuario);
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
                ML.Result result = BL.Usuario.UpdateEF(usuario);

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

        //[HttpDelete]
        public ActionResult Delete(ML.Usuario usuario)
        {
            if (usuario.IdUsuario >= 1)
            {   /*ML.Usuario usuario = new ML.Usuario();*/
                ML.Result result = BL.Usuario.DelateEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error:" + result.Message;
                }

            }

            return PartialView("Modal");
        }



        // ------------------- JSON ----------------------------
        public JsonResult GetEstado (int IdPais)
        {
            var result = BL.Estado.EstadoGetByIdPais(IdPais);   //Se inicializa el result con el metodo EstadoGetByIdPais
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.MunicipioGetByIdEstado(IdEstado);   //Se inicializa el result con el metodo EstadoGetByIdPais
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.ColoniaGetBYIdMunicipio(IdMunicipio);   //Se inicializa el result con el metodo EstadoGetByIdPais
            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream); //Lee el archivo
            data = reader.ReadBytes((int)Imagen.ContentLength); //Lo convierte en un arreglo de bytes

            return data;
        }  //COnvertir en un arreglo de bytes
    }
}