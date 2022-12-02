using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result ColoniaGetBYIdMunicipio(int IdMunicipio)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.ColoniaGetByIdMunicipio(IdMunicipio).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objeto in query)
                        {
                            ML.Colonia colonia = new ML.Colonia();
                            colonia.IdColonia = objeto.IdColonia;
                            colonia.NombreColonia = objeto.NombreColonia;

                            colonia.Municipio = new ML.Municipio();
                            colonia.Municipio.IdMunicipio= IdMunicipio;

                            result.Objects.Add(colonia);
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
