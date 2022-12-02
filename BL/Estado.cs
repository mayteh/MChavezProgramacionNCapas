using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public static ML.Result EstadoGetByIdPais (int IdPais)
        {
            ML.Result result = new ML.Result ();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities ())
                {
                    var query = context.EstadoGetByIdPais(IdPais).ToList();
                    result.Objects = new List<object>();

                    if(query != null)
                    {
                        foreach(var objeto in query)
                        {
                            ML.Estado estado = new ML.Estado ();
                            estado.IdEstado = objeto.IdEstado;
                            estado.NombreEstado = objeto.NombreEstado;

                            estado.Pais = new ML.Pais ();  
                            estado.Pais.IdPais = IdPais;

                            result.Objects.Add(estado);
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
