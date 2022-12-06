using DL_EF;
using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        //STORED PROCEDURE
        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "EmpresaAdd"; //se especifica donde se establecera la conexion
                        cmd.CommandType = CommandType.StoredProcedure;// Se especifica que se usaran stored procedure
                        cmd.Connection = contex;//Se establece la conexion

                        //Agregan los parametros
                        //Aqui se hara el llenado de informacion del objeto que envio PL

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[0].Value = empresa.NombreEmpresa;

                        collection[1] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                        collection[1].Value = empresa.Telefono;

                        collection[2] = new SqlParameter("@Email", SqlDbType.VarChar);
                        collection[2].Value = empresa.Email;

                        collection[3] = new SqlParameter("@DireccionWeb",SqlDbType.VarChar);
                        collection[3].Value = empresa.DireccionWeb;


                        //pasarle a mi command los parametros agregados
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }


                    }
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
        public static ML.Result Update(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "EmpresaUpdate"; //se especifica donde se establecera la conexion
                        cmd.CommandType = CommandType.StoredProcedure;// Se especifica que se usaran stored procedure
                        cmd.Connection = contex;//Se establece la conexion

                        //Agregan los parametros
                        //Aqui se hara el llenado de informacion del objeto que envio PL

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("@IdEmpresa", SqlDbType.VarChar);
                        collection[0].Value = empresa.IdEmpresa;

                        collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        collection[1].Value = empresa.NombreEmpresa;

                        collection[2] = new SqlParameter("@Telefono", SqlDbType.VarChar);
                        collection[2].Value = empresa.Telefono;

                        collection[3] = new SqlParameter("@Email", SqlDbType.VarChar);
                        collection[3].Value = empresa.Email;

                        collection[4] = new SqlParameter("@DireccionWeb", SqlDbType.VarChar);
                        collection[4].Value = empresa.DireccionWeb;


                        //pasarle a mi command los parametros agregados
                        cmd.Parameters.AddRange(collection);

                        //Abrir la conexión
                        cmd.Connection.Open();

                        //ejecutando nuestra sentencia
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }


                    }
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
        public static ML.Result Delate(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "EmpresaDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query; //se especifica donde se establecera la conexion
                        cmd.CommandType = CommandType.StoredProcedure;// Se especifica que se usaran stored procedure
                        cmd.Connection = contex;//Se establece la conexion
                        contex.Open();

                        //Agregan los parametros
                        //Aqui se hara el llenado de informacion del objeto que envio PL

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdEmpresa", System.Data.SqlDbType.Int);
                        collection[0].Value = empresa.IdEmpresa;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL dato se elimino correctamente";
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                //Se obtiene la conexion a la base de datos
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection())) 
                {
                    string query = "EmpresaGetAll"; //Se especifica el stored procedure que se ocupara
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //Se establece la conexion
                        cmd.CommandText = query; //Se establece la variable query para consultas en sql
                        cmd.CommandType = CommandType.StoredProcedure;//Se establece que se trata de stored procedure
                        contex.Open(); //Se abre la conexion

                        DataTable empresaTable = new DataTable();//Instancia de EmpresaTable
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //Funcion de retorno
                        //cmd envia todos los datos a SqlDataAdapter

                        sqlDataAdapter.Fill(empresaTable); //Llena la tabla EmpresaTable

                        if(empresaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach(DataRow row in empresaTable.Rows)//Sacar los row de la tabla EmpresaTable
                            {
                                ML.Empresa empresa = new ML.Empresa();
                                empresa.IdEmpresa = int.Parse(row[0].ToString());
                                empresa.NombreEmpresa = row[1].ToString();
                                empresa.Telefono = row[2].ToString();
                                empresa.Email = row[3].ToString();
                                empresa.DireccionWeb = row[4].ToString();

                                result.Objects.Add(empresa);
                            }
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
        public static ML.Result GetById(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "EmpresaGetById";
                        cmd.Connection = contex;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.VarChar);
                        collection[0].Value = idEmpresa;

                        cmd.Parameters.AddRange(collection);

                        //Almacenar la informacion
                        DataTable empresaTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        adapter.Fill(empresaTable);//Transferir los datos a la tabla empresaTable

                        if(empresaTable.Rows.Count > 0)
                        {
                            DataRow row = empresaTable.Rows[0];
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = int.Parse(row[0].ToString());
                            empresa.NombreEmpresa = row[1].ToString();  
                            empresa.Telefono = row[2].ToString();
                            empresa.Email = row[3].ToString();
                            empresa.DireccionWeb = row[4].ToString();

                            ///boxing
                            result.Object = empresa;
                            result.Correct = true;    
                        }
                        else
                        {
                            result.Correct = false;
                        }
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


        //ENTITY FRAMEWORK
        public static ML.Result AddEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var usuarios = context.EmpresaAdd(empresa.NombreEmpresa, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.Logo);

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

        public static ML.Result UpdateEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.EmpresaUpdate(empresa.IdEmpresa, empresa.NombreEmpresa, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.Logo);

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

        public static ML.Result DelateEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    int query = context.EmpresaDelete(empresa.IdEmpresa);
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
                    string valorNombre = null;
                    var query = context.EmpresaGetAll(valorNombre).ToList();
                    result.Objects = new List<object>(); //Instanciar la lista para dar a entender que se trata de una lista lo que va a traer

                    if (query != null)
                        {
                            foreach(var objeto in query)//Sacar los row de la tabla EmpresaTable
                            {
                                ML.Empresa empresa = new ML.Empresa();
                                empresa.IdEmpresa = objeto.IdEmpresa;
                                empresa.NombreEmpresa = objeto.Nombre;
                                empresa.Telefono = objeto.Telefono;
                                empresa.Email = objeto.Email;
                                empresa.DireccionWeb = objeto.DireccionWeb;

                                result.Objects.Add(empresa);
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

        public static ML.Result GetByIdEF(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetById(idEmpresa).SingleOrDefault();
                    result.Objects = new List<object>();

                        if (query != null)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = query.IdEmpresa;
                            empresa.NombreEmpresa = query.Nombre;
                            empresa.Telefono = query.Telefono;
                            empresa.Email = query.Email;
                            empresa.DireccionWeb = query.DireccionWeb;

                            ///boxing
                            result.Object = empresa;
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

        //LINQ
        public static ML.Result AddLQ(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaBD = new DL_EF.Empresa();

                    empresaBD.Nombre= empresa.NombreEmpresa;
                    empresaBD.Telefono= empresa.Telefono;
                    empresaBD.Email= empresa.Email;
                    empresaBD.DireccionWeb = empresa.DireccionWeb;

                    //usuario.Rol = new ML.Rol();
                    //usuario.Rol.IdRol = byte.Parse(usuarioDL.IdRol.ToString());


                    context.Empresas.Add(empresaBD);
                    context.SaveChanges();
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

        public static ML.Result UpdateLQ(ML.Empresa empresa)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaBD = new DL_EF.Empresa();

                    empresaBD.IdEmpresa = empresa.IdEmpresa;
                    empresaBD.Nombre = empresa.NombreEmpresa;
                    empresaBD.Telefono = empresa.Telefono;
                    empresaBD.Email = empresa.Email;
                    empresaBD.DireccionWeb = empresa.DireccionWeb;

                    //usuario.Rol = new ML.Rol();
                    //usuario.Rol.IdRol = byte.Parse(usuarioDL.IdRol.ToString());


                    context.Empresas.Add(empresaBD);
                    context.SaveChanges();
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

        public static Result DeleteLQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = (from a in context.Empresas
                                 where a.IdEmpresa == empresa.IdEmpresa
                                 select a).First();

                    context.Empresas.Remove(query);
                    context.SaveChanges();
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


        public static Result GetAllLQ()
        {
            Result result = new Result();

            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = (from empresaLQ in context.Empresas
                                     //join rol in context.Rols on usuarioLQ.IdRol equals rol.IdRol
                                 select new
                                 {
                                     idEmpresa = empresaLQ.IdEmpresa,
                                     Nombre = empresaLQ.Nombre,
                                     Telefono = empresaLQ.Telefono,
                                     Email = empresaLQ.Email,
                                     DireccionWeb = empresaLQ.DireccionWeb
                                 }); 

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = row.idEmpresa;
                            empresa.NombreEmpresa = row.Nombre;
                            empresa.Telefono = row.Telefono;
                            empresa.Email = row.Email;
                            empresa.DireccionWeb = row.DireccionWeb;

                            //usuario.NombreUsuario = obje.Nombre;
                            result.Objects.Add(empresa);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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
        public static ML.Result GetByIdLQ(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = (from empresaLQ in context.Empresas
                                 where empresaLQ.IdEmpresa == idEmpresa
                                 select new
                                 {
                                     IdEmpresa = empresaLQ.IdEmpresa,

                                     Nombre = empresaLQ.Nombre,
                                     Telefono = empresaLQ.Telefono,
                                     Email = empresaLQ.Email,
                                     DireccionWeb = empresaLQ.DireccionWeb
                                 }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();

                        empresa.IdEmpresa = query.IdEmpresa;
                        empresa.NombreEmpresa = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;

                        ///boxing
                        result.Object = empresa;
                        result.Correct = true;
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

    }//cierre de la clase 
}//cierre de namespace
