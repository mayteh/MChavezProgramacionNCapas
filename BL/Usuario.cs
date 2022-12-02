using DL_EF;
using ML;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL //Bussines Layer
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)

        {
            ML.Result result = new ML.Result(); //Se crea el objeto result para poder enviar el estado del programa despues.
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))//Se obtiene la conexion
                {
                    string query = "INSERT INTO [Usuario]([NombreUsuario],[ApellidoPaternoU],[ApellidoMaternoU],[Edad],[Estatura],[FechaNacimiento],[Genero])VALUES(@NombreUsuario,@ApellidoPaternoU,@ApellidoMaternoU,@Edad,@Estatura,@FechaNacimiento,@Genero)";
                    using (SqlCommand cmd = new SqlCommand())//archivos temporales
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta sentencia sql
                        contex.Open();//abrir la conexion

                        SqlParameter[] collection = new SqlParameter[7];//se crea el arreglo donde se almacenara la informacion
                        collection[0] = new SqlParameter("NombreUsuario", System.Data.SqlDbType.VarChar);
                        collection[0].Value = usuario.NombreUsuario;

                        collection[1] = new SqlParameter("ApellidoPaternoU", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaternoU;

                        collection[2] = new SqlParameter("ApellidoMaternoU", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaternoU;

                        collection[3] = new SqlParameter("Edad", System.Data.SqlDbType.Int);
                        collection[3].Value = usuario.Edad;

                        collection[4] = new SqlParameter("Estatura", System.Data.SqlDbType.Float);
                        collection[4].Value = usuario.Estatura;

                        collection[5] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[5].Value = usuario.FechaNacimiento;

                        collection[6] = new SqlParameter("Genero", System.Data.SqlDbType.Char);
                        collection[6].Value = usuario.Genero;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL dato se agrego correctamente";
                        }
                    }
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "UPDATE [Usuario]SET [NombreUsuario]=@NombreUsuario,[ApellidoPaternoU]=@ApellidoPaternoU,[ApellidoMaternoU]=@ApellidoMaternoU,[Edad]=@Edad,[Estatura]=@Estatura,[FechaNacimiento]=@FechaNacimiento,[Genero]=@Genero WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[8];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("NombreUsuario", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.NombreUsuario;

                        collection[2] = new SqlParameter("ApellidoPaternoU", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaternoU;

                        collection[3] = new SqlParameter("ApellidoMaternoU", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaternoU;

                        collection[4] = new SqlParameter("Edad", System.Data.SqlDbType.Int);
                        collection[4].Value = usuario.Edad;

                        collection[5] = new SqlParameter("Estatura", System.Data.SqlDbType.Float);
                        collection[5].Value = usuario.Estatura;

                        collection[6] = new SqlParameter("FechaNacimiento", System.Data.SqlDbType.Date);
                        collection[6].Value = usuario.FechaNacimiento;

                        collection[7] = new SqlParameter("Genero", System.Data.SqlDbType.Char);
                        collection[7].Value = usuario.Genero;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL dato se modifico correctamente";
                        }
                    }
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;


        }

        public static ML.Result Delate(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "USE [MChavezProgramacionNCapas] DELETE FROM [Usuario] WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL dato se elimino correctamente";
                        }
                    }
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;

        }

        public static ML.Result Select(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "SELECT IdUsuario, NombreUsuario, ApellidoPaternoU, ApellidoMaternoU, Edad, FechaNacimiento, Genero FROM Usuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        contex.Open();

                        //SqlDataReader reader = cmd.ExecuteReader();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(String.Format("{0:d}", reader.GetInt32(0))); //Imprime iD
                                Console.WriteLine(String.Format("{0,30}", reader.GetString(1)));
                                Console.WriteLine(String.Format("{0,30}", reader.GetString(2)));
                                Console.WriteLine(String.Format("{0,30}", reader.GetString(3)));
                                Console.WriteLine(String.Format("{0:d}", reader.GetInt32(4)));
                                //Console.WriteLine(String.Format("{0:0:00}", reader.GetFloat(5))); ¿COMO SE HACE CON UN FLOAT?
                                Console.WriteLine(String.Format("{0:d}", reader.GetDateTime(5)));
                                Console.WriteLine(String.Format("{0,30}", reader.GetString(6)));
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
        //-------------------PROCEDIMIENTOS ALMACENADOS --------------------------
        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioAdd";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;


                        //agregar parametros 
                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                        collection[0].Value = usuario.NombreUsuario;

                        collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaternoU;

                        collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaternoU;

                        collection[3] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[4].Value = usuario.Genero;

                        collection[5] = new SqlParameter("@Password", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Password;

                        collection[6] = new SqlParameter("@Telefono", System.Data.SqlDbType.Char);
                        collection[6].Value = usuario.Telefono;

                        collection[7] = new SqlParameter("@Celular", System.Data.SqlDbType.Char);
                        collection[7].Value = usuario.Celular;

                        collection[8] = new SqlParameter("@Curp", System.Data.SqlDbType.Char);
                        collection[8].Value = usuario.Curp;

                        collection[9] = new SqlParameter("@UserName", System.Data.SqlDbType.Char);
                        collection[9].Value = usuario.UserName;

                        collection[10] = new SqlParameter("@Email", System.Data.SqlDbType.Char);
                        collection[10].Value = usuario.Email;


                        collection[11] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        //pasarle a mi command los parametros
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
        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = contex;


                        //agregar parametros 
                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("@NombreUsuario", SqlDbType.VarChar);
                        collection[1].Value = usuario.NombreUsuario;

                        collection[2] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaternoU;

                        collection[3] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaternoU;

                        collection[4] = new SqlParameter("@FechaNacimiento", System.Data.SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                        collection[5].Value = usuario.Genero;

                        collection[6] = new SqlParameter("@Password", System.Data.SqlDbType.Char);
                        collection[6].Value = usuario.Password;

                        collection[7] = new SqlParameter("@Telefono", System.Data.SqlDbType.Char);
                        collection[7].Value = usuario.Telefono;

                        collection[8] = new SqlParameter("@Celular", System.Data.SqlDbType.Char);
                        collection[8].Value = usuario.Celular;

                        collection[9] = new SqlParameter("@Curp", System.Data.SqlDbType.Char);
                        collection[9].Value = usuario.Curp;

                        collection[10] = new SqlParameter("@UserName", System.Data.SqlDbType.Char);
                        collection[10].Value = usuario.UserName;

                        collection[11] = new SqlParameter("@Email", System.Data.SqlDbType.Char);
                        collection[11].Value = usuario.Email;

                        collection[12] = new SqlParameter("@IdRol", System.Data.SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        //pasarle a mi command los parametros
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
        public static ML.Result DelateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "UsuarioDelate";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = query; //consulta
                        cmd.CommandType = CommandType.StoredProcedure;

                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", System.Data.SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "EL dato se elimino correctamente";
                        }
                    }
                }
                result.Correct = true;
            }// cierre de try
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
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConection()))//Se obtiene la conexion
                {
                    string querySP = "UsuarioGetAll"; //Se usa en query y en vez de llamar la sentencia se manda a llamar el stored procedure
                    using (SqlCommand cmd = new SqlCommand())//archivos temporales
                    {
                        cmd.Connection = contex; //coneccion 
                        cmd.CommandText = querySP; //consulta sentencia sql
                        cmd.CommandType = CommandType.StoredProcedure;//Especificar que se trata de un stored procedure
                        contex.Open();//abrir la conexion

                        DataTable usuarioTable = new DataTable(); // Se hace la instancia de la clase tipo DataTable
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //Adapta la funcion de retorno de sql
                        //cmd envia todos los datos a sqlDataAdapter
                        sqlDataAdapter.Fill(usuarioTable);//Llena la tabla "usuarioTable de los datos que tiene la BD

                        if (usuarioTable.Rows.Count > 0)//Si las rows dentro de tabla usuarioTable  es mayor a 0
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in usuarioTable.Rows)// Sacar los row de nuestra tabla usuarioTable
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.NombreUsuario = row[1].ToString();
                                usuario.ApellidoPaternoU = row[2].ToString();
                                usuario.ApellidoMaternoU = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Genero = row[5].ToString();
                                usuario.Password = row[6].ToString();
                                usuario.Telefono = row[7].ToString();
                                usuario.Celular = row[8].ToString();
                                usuario.Curp = row[9].ToString();
                                usuario.UserName = row[10].ToString();
                                usuario.Email = row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                                //usuario.Imagen = byte.Parse()

                                result.Objects.Add(usuario);//Agrega todos los datos a usuario
                            }
                        }
                    }
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }           
        public static ML.Result GetByIdSP(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UsuarioGetById";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("@IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;

                        cmd.Parameters.AddRange(collection);

                        //aqui voy a almacenar la información
                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //adapter.SelectCommand = cmd;
                        adapter.Fill(tableUsuario);//Trsnaferir los datos al objeto tableUsuario

                       if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.NombreUsuario = row[1].ToString();
                            usuario.ApellidoPaternoU = row[2].ToString();
                            usuario.ApellidoMaternoU = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Genero = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.Telefono = row[7].ToString();
                            usuario.Celular = row[8].ToString();
                            usuario.Curp = row[9].ToString();
                            usuario.UserName = row[10].ToString();
                            usuario.Email = row[11].ToString();

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            //boxing
                            //Almacenar cualquier tipo de dato en un dato object
                            result.Object = usuario;
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
            }
            return result;
        }


        ////////////////////// ENTITY FRAMEWORK //////////////////////////////////////

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result(); //instancia de Result
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities contex = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    int query = contex.UsuarioAdd(usuario.NombreUsuario, usuario.ApellidoPaternoU, usuario.ApellidoMaternoU, usuario.FechaNacimiento, usuario.Genero, usuario.Password, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.UserName, usuario.Email, usuario.Rol.IdRol,usuario.Imagen,usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                        if (query > 0)
                        {
                        result.Message = "El usuario se agrego con exito";
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
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities contex = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = contex.UsuarioUpdate(usuario.IdUsuario, usuario.NombreUsuario, usuario.ApellidoPaternoU, usuario.ApellidoMaternoU, usuario.FechaNacimiento, usuario.Genero, usuario.Password, usuario.Telefono, usuario.Celular, usuario.Curp, usuario.UserName, usuario.Email, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
       

                        if(query > 0)
                        {
                            result.Message = "EL dato se modifico correctamente";
                        }
                    
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;


        }
        public static ML.Result DelateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities contex = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    int query = contex.UsuarioDelate(usuario.IdUsuario);

                    if (query >= 1)
                    {
                        result.Message = "EL dato se elimino correctamente";
                    }

                }
                result.Correct = true;
            }// cierre de try
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
                using (DL_EF.MChavezProgramacionNCapasEntities contex = new DL_EF.MChavezProgramacionNCapasEntities())//Se obtiene la conexion
                {
                    var usuarios = contex.UsuarioGetAll().ToList();

                    result.Objects = new List<object>();

                    if (usuarios != null)//Si las rows dentro de nuestra lista query es diferente de null
                     {
                            foreach (var objeto in usuarios)// Sacar los row de nuestra lista
                            {
                            
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = objeto.IdUsuario;
                            usuario.NombreUsuario = objeto.NombreUsuario;
                            usuario.ApellidoPaternoU = objeto.ApellidoPaterno;
                            usuario.ApellidoMaternoU = objeto.ApellidoMaterno;
                            usuario.FechaNacimiento = objeto.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Genero = objeto.Sexo;
                            usuario.Password = objeto.Password;
                            usuario.Telefono = objeto.Telefono;
                            usuario.Celular = objeto.Celular;
                            usuario.Curp = objeto.Curp;
                            usuario.UserName = objeto.UserName;
                            usuario.Email = objeto.Email;

                            
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(objeto.IdRol.ToString());
                            usuario.Rol.NombreRol = objeto.NombreRol;

                            usuario.Imagen = objeto.Imagen;

                            //usuario.Imagen = byte[].Parse(objeto.Imagen.ToString());
                            //DIRECCION//
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = objeto.IdDireccion;
                            usuario.Direccion.Calle = objeto.Calle;
                            usuario.Direccion.NumeroInterior = objeto.NumeroInterior;
                            usuario.Direccion.NumeroExterior = objeto.NumeroExterior;
                            //COLONIA//
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = objeto.IdColonia.Value;
                            usuario.Direccion.Colonia.NombreColonia = objeto.NombreColonia;
                            usuario.Direccion.Colonia.CodigoPostal = objeto.CodigoPostal;
                            //MUNICIPIO//
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = objeto.IdMunicipio.Value;
                            usuario.Direccion.Colonia.Municipio.NombreMunicipio = objeto.NombreMunicipio;
                            //ESTADO//
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objeto.IdEstado.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = objeto.NombreEstado;
                            //PAIS// 
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objeto.IdPais.Value;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = objeto.NombrePais;


                            result.Objects.Add(usuario);//Agrega todos los datos a usuario
                            }
                     }
                    
                }
                result.Correct = true;
            }// cierre de try
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al cargar la información" + result.Ex;
                throw;
            }//(Algún error en el programa)
            return result;
        }
        public static ML.Result GetByIdEF(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    //var tableUsuario = context.UsuarioGetById(idUsuario).SingleOrDefault();
                    var tableUsuario = context.UsuarioGetById(idUsuario).FirstOrDefault();
                    result.Objects = new List<object>();
                    if (tableUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = tableUsuario.IdUsuario;
                        usuario.NombreUsuario = tableUsuario.NombreUsuario;
                        usuario.ApellidoPaternoU = tableUsuario.ApellidoPaterno;
                        usuario.ApellidoMaternoU = tableUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = tableUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Genero = tableUsuario.Sexo;
                        usuario.Password = tableUsuario.Password;
                        usuario.Telefono = tableUsuario.Telefono;
                        usuario.Celular = tableUsuario.Telefono;
                        usuario.Curp = tableUsuario.Curp;
                        usuario.UserName = tableUsuario.UserName;
                        usuario.Email = tableUsuario.Email;
                        //Se tiene que instanciar el objeto para poderlo usarlo y asi almacenar
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = byte.Parse(tableUsuario.IdRol.ToString());

                        usuario.Imagen = tableUsuario.Imagen;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = tableUsuario.IdDireccion;
                        usuario.Direccion.Calle = tableUsuario.Calle;
                        usuario.Direccion.NumeroInterior = tableUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = tableUsuario.NumeroExterior;
                        //COLONIA//
                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = tableUsuario.IdColonia.Value;
                        usuario.Direccion.Colonia.NombreColonia = tableUsuario.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = tableUsuario.CodigoPostal;
                        //MUNICIPIO//
                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = tableUsuario.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.NombreMunicipio = tableUsuario.NombreMunicipio;
                        //ESTADO//
                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = tableUsuario.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.NombreEstado = tableUsuario.NombreEstado;
                        //PAIS// 
                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = tableUsuario.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.NombrePais = tableUsuario.NombrePais;

                        //boxing
                        //Almacenar cualquier tipo de dato en un dato object
                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                
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


        //////////////////////////// LINQ ///////////////////////////////
        ///

        public static ML.Result AddLQ(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.NombreUsuario = usuario.NombreUsuario;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaternoU; 
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaternoU;
                    //usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento.ToString("dd-MM-yyyy"));
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Genero;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.Curp = usuario.Curp;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    //usuario.Rol = new ML.Rol();
                    //usuario.Rol.IdRol = byte.Parse(usuarioDL.IdRol.ToString());


                    context.Usuarios.Add(usuarioDL);
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

        public static ML.Result UpdateLQ(ML.Usuario usuario)
        {
            Result result = new Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.IdUsuario = usuario.IdUsuario;    
                    usuarioDL.NombreUsuario = usuario.NombreUsuario;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaternoU;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaternoU;
                    //usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento.ToString("dd-MM-yyyy"));
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    usuarioDL.Sexo = usuario.Genero;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.Curp = usuario.Curp;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    //usuario.Rol = new ML.Rol();
                    //usuario.Rol.IdRol = byte.Parse(usuarioDL.IdRol.ToString());


                    context.Usuarios.Add(usuarioDL);
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

        public static Result DeleteLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {
                    var query = (from a in context.Usuarios
                                 where a.IdUsuario == usuario.IdUsuario
                                 select a).First();

                    context.Usuarios.Remove(query);
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
                    var query = (from usuarioLQ in context.Usuarios
                                     //join rol in context.Rols on usuarioLQ.IdRol equals rol.IdRol
                                 select new { idUsuario = usuarioLQ.IdUsuario,
                                              Nombre = usuarioLQ.NombreUsuario,
                                              ApellidoPaterno = usuarioLQ.ApellidoPaterno,
                                              ApellidoMaterno = usuarioLQ.ApellidoMaterno,
                                              FechaNacimiento = usuarioLQ.FechaNacimiento,
                                              Genero = usuarioLQ.Sexo,
                                              Password = usuarioLQ.Password,
                                              Telefono = usuarioLQ.Telefono,
                                              Celular = usuarioLQ.Celular,
                                              Curp = usuarioLQ.Curp,
                                              UserName = usuarioLQ.UserName,
                                              Email = usuarioLQ.Email,
                                              IdRol = usuarioLQ.IdRol
                                 }); 

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var row in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = row.idUsuario;
                            usuario.NombreUsuario = row.Nombre;
                            usuario.ApellidoPaternoU = row.ApellidoPaterno;
                            usuario.ApellidoMaternoU = row.ApellidoPaterno;
                            usuario.FechaNacimiento = row.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Genero = row.Genero;
                            usuario.Password = row.Password;
                            usuario.Telefono = row.Telefono;
                            usuario.Celular = row.Celular;
                            usuario.Curp = row.Curp;   
                            usuario.UserName = row.UserName;
                            usuario.Email = row.Email;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row.IdRol.ToString());
                            //usuario.Rol.IdRol = byte.Parse(row.IdRol.ToString());


                            //usuario.NombreUsuario = obje.Nombre;
                            result.Objects.Add(usuario);
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

        public static ML.Result GetByIdLQ(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.MChavezProgramacionNCapasEntities context = new DL_EF.MChavezProgramacionNCapasEntities())
                {

                    var query = (from usuarioLQ in context.Usuarios
                                 where usuarioLQ.IdUsuario == idUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioLQ.IdUsuario,

                                     Nombre = usuarioLQ.NombreUsuario,
                                     ApellidoPaterno = usuarioLQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLQ.ApellidoMaterno,
                                     FechaNacimiento = usuarioLQ.FechaNacimiento,
                                     Genero = usuarioLQ.Sexo,
                                     Password = usuarioLQ.Password,
                                     Telefono = usuarioLQ.Telefono,
                                     Celular = usuarioLQ.Celular,
                                     Curp = usuarioLQ.Curp,
                                     UserName = usuarioLQ.UserName,
                                     Email = usuarioLQ.Email,
                                     IdRol = usuarioLQ.IdRol
                                 }).SingleOrDefault(); //ES NECESARIO PONER EL SINGLE OR DEFAULT
                    //result.Objects = new List<object>();

                    if (query != null)
                    {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = query.IdUsuario;
                            usuario.NombreUsuario = query.Nombre;
                            usuario.ApellidoPaternoU = query.ApellidoPaterno;
                            usuario.ApellidoMaternoU = query.ApellidoMaterno;
                            usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuario.Genero = query.Genero;
                            usuario.Password = query.Password;
                            usuario.Telefono = query.Telefono;
                            usuario.Celular = query.Celular;
                            usuario.Curp = query.Curp;
                            usuario.UserName = query.UserName;
                            usuario.Email = query.Email;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = query.IdRol.Value;


                            result.Object = usuario;
                            result.Correct = true;
                             //result.Objects.Add(usuario);//boxing
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



    }// cierre name class usuario
}// cierre namespace 
