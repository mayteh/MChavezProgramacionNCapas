using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
            public static ML.Result GetAll()
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                    {
                        var query = context.PaisGetAll().ToList();
                        result.Objects = new List<object>(); //Se inicializa la lista
                        if (query != null)
                        {
                            foreach (var objeto in query)
                            {
                            ML.Pais pais = new ML.Pais();
                            pais.IdPais = objeto.IdPais;
                            pais.NombrePais = objeto.NombrePais;

                            result.Objects.Add(pais); //Tiene que devolver el objeto 
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
                }


                return result;

            }

    }
    
}
