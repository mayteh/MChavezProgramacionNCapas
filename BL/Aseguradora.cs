using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result AddEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var usuarios = context.AseguradoraAdd(aseguradora.NombreAseguradora, aseguradora.IdUsuario);

                    if (usuarios > 0)
                    {
                        result.Message = "La empresa se agrego correctamente";
                    }

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result UpdateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraUpdate(aseguradora.IdAseguradora ,aseguradora.NombreAseguradora, aseguradora.IdUsuario);

                    if (query > 0)
                    {
                        result.Message = "La empresa se modifico correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result DelateEF(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraDelete(aseguradora.IdAseguradora);
                    if (query >= 1)
                    {
                        result.Message = "EL dato se elimino correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                //Se obtiene la conexion a la base de datos
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();
                    result.Objects = new List<object>(); //Instanciar la lista para dar a entender que se trata de una lista lo que va a traer

                    if (query != null)
                    {
                        foreach (var objeto in query)//Sacar los row de la tabla EmpresaTable
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();
                            aseguradora.IdAseguradora = objeto.IdAseguradora;
                            aseguradora.NombreAseguradora = objeto.NombreAseguradora;
                            aseguradora.FechaCreacion = objeto.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = objeto.FechaModificacion.ToString();
                            aseguradora.IdUsuario = objeto.IdUsuario;
                            aseguradora.Usuario.NombreUsuario = objeto.NombreUsuario;
                            aseguradora.Usuario.ApellidoPaternoU = objeto.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaternoU = objeto.ApellidoPaterno;


                            result.Objects.Add(aseguradora);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result GetByIdEF(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetById(idAseguradora).SingleOrDefault();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();
                        aseguradora.IdAseguradora = query.IdAseguradora;
                        aseguradora.NombreAseguradora = query.NombreAseguradora;
                        aseguradora.FechaCreacion = query.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = query.FechaModificacion.ToString();
                        aseguradora.IdUsuario = query.IdUsuario;
                        aseguradora.Usuario.NombreUsuario = query.NombreUsuario;
                        aseguradora.Usuario.ApellidoPaternoU = query.ApellidoPaterno;
                        aseguradora.Usuario.ApellidoMaternoU = query.ApellidoPaterno;

                        ///boxing
                        result.Object = aseguradora;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
                return result;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }


        }
    }
}
