using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Direccion
    {
        public static ML.Result DireccionGetByIdColonia(int IdColonia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.MunicipioGetByIdColonia(IdColonia); //Aqui me equivoque y nombre a mi SP Municipio en lugar de direccion
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objeto in query)
                        {
                            ML.Direccion direccion = new ML.Direccion();
                            direccion.IdDireccion = objeto.IdDireccion;
                            direccion.Calle = objeto.Calle;
                            direccion.NumeroInterior = objeto.NumeroInterior;
                            direccion.NumeroExterior = objeto.NumeroExterior;

                            direccion.Colonia = new ML.Colonia();
                            direccion.Colonia.IdColonia = IdColonia;

                            //direccion.Usuario = new ML.Usuario();   
                            //direccion.Usuario.IdUsuario = IdUs

                            result.Objects.Add(direccion);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido realizar la consulta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
