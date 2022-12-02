using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public static void  Add() 
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia
            

            Console.WriteLine("Ingrese los datos del usuario\n");
            Console.WriteLine("Ingrese su nombre");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido paterno");
            usuario.ApellidoPaternoU = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido materno");
            usuario.ApellidoMaternoU = Console.ReadLine();
            Console.WriteLine("Ingrese su fecha de nacimiento dd-MM-yyy");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese su genero M/F");
            usuario.Genero = Console.ReadLine();
            Console.WriteLine("Ingrese su password");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese numero de telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese numero de celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese su curp");
            usuario.Curp = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre de usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese su email");
            usuario.Email = Console.ReadLine();


            Console.WriteLine("Ingrese el semestre");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());


            //Llenado del objeto con informacion

            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario); //Con SP Se envia el objeto con la información
            //ML.Result result = BL.Usuario.AddEF(usuario); //Con EF
            ML.Result result = BL.Usuario.AddLQ(usuario);
            if (result.Correct)
            {
                Console.WriteLine("Se agrego correctamente");
                Console.ReadKey();
            }
        }//YA
        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario(); //Instancia


            Console.WriteLine("Ingrese los datos del usuario\n");
            Console.WriteLine("Ingrese el ID del usuario");
            usuario.IdUsuario = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese su nombre");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido paterno");
            usuario.ApellidoPaternoU = Console.ReadLine();
            Console.WriteLine("Ingrese su apellido materno");
            usuario.ApellidoMaternoU = Console.ReadLine();
            Console.WriteLine("Ingrese su fecha de nacimiento dd-MM-yyy");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.WriteLine("Ingrese su genero M/F");
            usuario.Genero = Console.ReadLine();
            Console.WriteLine("Ingrese su password");
            usuario.Password = Console.ReadLine();
            Console.WriteLine("Ingrese numero de telefono");
            usuario.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese numero de celular");
            usuario.Celular = Console.ReadLine();
            Console.WriteLine("Ingrese su curp");
            usuario.Curp = Console.ReadLine();
            Console.WriteLine("Ingrese su nombre de usuario");
            usuario.UserName = Console.ReadLine();
            Console.WriteLine("Ingrese su email");
            usuario.Email = Console.ReadLine();


            Console.WriteLine("Ingrese el rol");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());


            //Llenado del objeto con informacion

            //ML.Result result = BL.Usuario.AddSP(usuario); //Se envia el objeto con la información
            //ML.Result result = BL.Usuario.AddSP(usuario); //SP
            //ML.Result result = BL.Usuario.UpdateEF(usuario); //EF
            ML.Result result = BL.Usuario.UpdateEF(usuario); //LQ

            if (result.Correct)
            {
                Console.WriteLine("Se agrego correctamente");
                Console.ReadKey();
            }
        }//YA
        public static void Delate()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el ID del usuario a eliminar\n");
            usuario.IdUsuario = int.Parse(Console.ReadLine());


            //Se envia el objeto con la informacion
            //ML.Result result = BL.Usuario.DelateSP(usuario);Store procedure
            //ML.Result result = BL.Usuario.DelateEF(usuario);//EntityFramework
            ML.Result result = BL.Usuario.DeleteLQ(usuario); //LINQ

            if (result.Correct)
            {
                Console.WriteLine("Se elimino correctamente");
                Console.ReadKey();
            }
        } //Ya
        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll(); // SP
            //ML.Result result = BL.Usuario.GetAllEF(); //EF
            ML.Result result = BL.Usuario.GetAllLQ();//LQ

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Id Usuario:" + usuario.IdUsuario);
                    Console.WriteLine("Nombre de usuario:" + usuario.NombreUsuario);
                    Console.WriteLine("Apellido paterno:" + usuario.ApellidoPaternoU);
                    Console.WriteLine("Apellido materno:" + usuario.ApellidoMaternoU);
                    Console.WriteLine("Fecha de nacimiento:" + usuario.FechaNacimiento);
                    Console.WriteLine("Genero:" + usuario.Genero);
                    Console.WriteLine("Password:" + usuario.Password);
                    Console.WriteLine("Telefono:" + usuario.Telefono);
                    Console.WriteLine("Celular:" + usuario.Celular);
                    Console.WriteLine("Curp:" + usuario.Curp);
                    Console.WriteLine("User Name:" + usuario.UserName);
                    Console.WriteLine("Email:" + usuario.Email);
                    Console.WriteLine("Rol:" + usuario.Rol.IdRol);

                    Console.WriteLine("-----------------------------------");
                }

            }
            else
            {
                //Console.WriteLine("Ocurrio un error " + result.);
            }
        }//YA
        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el id del alumno que desea consultar");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIdLQ(usuario.IdUsuario); //LINQ
            //ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario); //Con Entity framework
            //ML.Result result = BL.Usuario.GetByIdSP(usuario.IdUsuario); //Con Stored procedure

            if (result.Correct)
            {
                //unboxing
                usuario = (ML.Usuario)result.Object;

                Console.WriteLine("-----------------------------------");
                Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El nombre del usuario es: " + usuario.NombreUsuario);
                Console.WriteLine("El apellido paterno del usuario es: " + usuario.ApellidoPaternoU);
                Console.WriteLine("El apellido materno del usuario es: " + usuario.ApellidoMaternoU);
                Console.WriteLine("La fecha de nacimiento del usuario es: " + usuario.FechaNacimiento);
                Console.WriteLine("El Genero es: " + usuario.Genero);
                Console.WriteLine("El password es: " + usuario.Password);
                Console.WriteLine("El telefono es: " + usuario.Telefono);
                Console.WriteLine("El celular es: " + usuario.Celular);
                Console.WriteLine("El curp" + usuario.Curp);
                Console.WriteLine("El nombre de usuario " + usuario.UserName);
                Console.WriteLine("El email es: " + usuario.Email);
                Console.WriteLine("El rol es: " + usuario.Rol.IdRol);
                Console.WriteLine("-----------------------------------");
            }
            else
            {
                Console.WriteLine("Ocurrio un error " + result.Ex);
            }
        }//YA

        

    }
}
