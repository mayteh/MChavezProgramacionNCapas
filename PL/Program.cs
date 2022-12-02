using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL //Presentation layer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc, opc1, opc2;

            Console.WriteLine("Seleccione sobe quien quiere trabajar");
            Console.WriteLine("1. Usuario");
            Console.WriteLine("2. Empresa");
            opc1 = int.Parse(Console.ReadLine());

            switch (opc1)
                {
                case 1:
                    Console.WriteLine("-----------USUARIO----------");
                    Console.WriteLine("Ingrese la opcion a realizar");
                    Console.WriteLine("1. Ingresar");
                    Console.WriteLine("2. Modificar");
                    Console.WriteLine("3. Eliminar");
                    Console.WriteLine("4. Consultar");
                    Console.WriteLine("5. Consultar por ID");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            Usuario.Add();
                            Console.ReadKey();
                            break;

                        case 2:
                            Usuario.Update();
                            Console.ReadKey();
                            break;

                        case 3:
                            Usuario.Delate();
                            Console.ReadKey();
                            break;

                        case 4:
                            Usuario.GetAll();

                            Console.ReadKey();
                            break;

                        case 5:
                            Usuario.GetById();
                            Console.ReadKey();
                            break;

                        default:
                            break;

                    }
                    break;  
                case 2:
                    Console.WriteLine("----------EMPRESA---------------");
                    Console.WriteLine("Ingrese la opcion a realizar");
                    Console.WriteLine("1. Ingresar");
                    Console.WriteLine("2. Modificar");
                    Console.WriteLine("3. Eliminar");
                    Console.WriteLine("4. Consultar");
                    Console.WriteLine("5. Consultar por ID");
                    opc2 = int.Parse(Console.ReadLine());

                    switch (opc2)
                    {
                        case 1:
                            Empresa.Add();
                            Console.ReadKey();
                            break;

                        case 2:
                            Empresa.Update();
                            Console.ReadKey();
                            break;

                        case 3:
                            Empresa.Delete();
                            Console.ReadKey();
                            break;

                        case 4:
                            Empresa.GetAll();
                            Console.ReadKey();
                            break;

                        case 5:
                            Empresa.GetById();
                            Console.ReadKey();
                            break;

                        default:
                            break;

                    }
                    break;

                    default :
                    break;
            }               
         
        }
    }
}
