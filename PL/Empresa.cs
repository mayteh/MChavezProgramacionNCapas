using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Empresa
    {
        public static void Add()
        {
            ML.Empresa empresa = new ML.Empresa(); //Se instancia la clase Empresa

            //Se le piden los datos al usuario
            Console.WriteLine("Ingrese los datos de la empresa\n");
            Console.WriteLine("Ingrese el nombre de la empresa");
            empresa.NombreEmpresa = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de telefono");
            empresa.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el email");
            empresa.Email = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion web");
            empresa.DireccionWeb = Console.ReadLine();
            //Se llena el objeto con la informacion ingresada


            //Se envia el objeto con la informacion
            //ML.Result result = BL.Empresa.Add(empresa); //ADD con STORED PROCEDURE
            //ML.Result result = BL.Empresa.AddEF(empresa); //EntityFramework
            ML.Result result = BL.Empresa.AddLQ(empresa); // LINQ
            if (result.Correct)
            {
                Console.WriteLine("Se agrego correctamente");
                Console.ReadKey();
            }

        }
        public static void Update()
        {
            ML.Empresa empresa = new ML.Empresa(); //Se instancia la clase Empresa

            //Se le piden los datos al usuario
            Console.WriteLine("Ingrese los datos de la empresa a modificar\n");

            Console.WriteLine("Ingrese el Id de la empresa");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el nombre de la empresa");
            empresa.NombreEmpresa = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de telefono");
            empresa.Telefono = Console.ReadLine();
            Console.WriteLine("Ingrese el email");
            empresa.Email = Console.ReadLine();
            Console.WriteLine("Ingrese la direccion web");
            empresa.DireccionWeb = Console.ReadLine();
            //Se llena el objeto con la informacion ingresada

            //Se envia el objeto con la informacion
            //ML.Result result = BL.Empresa.Update(empresa)///Con Stored procedure
            //ML.Result result = BL.Empresa.UpdateEF(empresa);//Con Entity Framework
            ML.Result result = BL.Empresa.UpdateLQ(empresa); //LINQ
            if (result.Correct)
            {
                Console.WriteLine("Se modifico correctamente");
                Console.ReadKey();
            }
        }
        public static void Delete()
        {
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingrese el ID de la empresa que desea Eliminar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());


            //Instanciar la clase result asignando el metodo delate que se encuentra dentro de la clase BL

            //ML.Result result = BL.Empresa.Delate(empresa); // con Stored Procedure
            //ML.Result result = BL.Empresa.DelateEF(empresa); // Con Entity Framework
            ML.Result result = BL.Empresa.DeleteLQ(empresa); //LINQ


            if (result.Correct)
            {
                Console.WriteLine("La empresa se elimino correctamente");
            }
        }
        public static void GetAll()
        {
            //ML.Result result = BL.Empresa.GetAll();//Por medio de stored procedure
            //ML.Result result = BL.Empresa.GetAllEF();//Por medio de EF
            ML.Result result = BL.Empresa.GetAllLQ();//LQ

            if (result.Correct)
            {
                foreach(ML.Empresa empresa in result.Objects)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Id Empresa:" + empresa.IdEmpresa);
                    Console.WriteLine("Nombre:" + empresa.NombreEmpresa);
                    Console.WriteLine("Telefono:" + empresa.Telefono);
                    Console.WriteLine("Email:" + empresa.Email);
                    Console.WriteLine("Direccion Web:" + empresa.DireccionWeb);
                    Console.WriteLine("------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Ocurrio un error al cargar la informacion" + result.Ex);
            }

        }
        public static void GetById()
        {
            ML.Empresa empresa = new ML.Empresa();  

            Console.WriteLine("Ingrese el ID de la empresa que desea consultar");
             empresa.IdEmpresa = int.Parse(Console.ReadLine());


            ML.Result result = BL.Empresa.GetByIdLQ(empresa.IdEmpresa); //LQ
            //ML.Result result = BL.Empresa.GetById(empresa.IdEmpresa);  //SP
            //ML.Result result = BL.Empresa.GetByIdEF(empresa.IdEmpresa);  //EF
            // Asignamos el metodo GetByID que se encuentra en la clase BL Donde tendremos como parametro el IdEMpresa

            if (result.Correct)
            {
                //unboxing BL.Empresa hace referencia al tipo de dato que tienen nuestras variables
                //result.Object hace referencia al objeto donde se guardo el boxing
                empresa = (ML.Empresa)result.Object;

                Console.WriteLine("--------------------------------");
                Console.WriteLine("Id de la empresa:" + empresa.IdEmpresa);
                Console.WriteLine("Nombre:" +empresa.NombreEmpresa);
                Console.WriteLine("Telefono:" +empresa.Telefono);
                Console.WriteLine("Email:" +empresa.Email);
                Console.WriteLine("Pagina Web:" +empresa.DireccionWeb);
                Console.WriteLine("----------------------------------");
            }
            else
            {
                Console.WriteLine("Ocurrio un error al cargar la informacion" +result.Ex);
            }

        }

    }
}
