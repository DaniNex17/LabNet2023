using Lab.Net.EF.Entities;
using Lab.Net.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------ Bienvenidos al CRUD Practica 4 EF ------------------\n");
            bool salir = false;
            do
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Operaciones de Regiones - VISTO EN LA DEMO");
                Console.WriteLine("2 - Operaciones de Empleados");
                Console.WriteLine("3 - Operaciones de Ordenes");            
                Console.WriteLine("0 - Salir");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        OpRegiones();
                        break;
                    case "2":
                        OpEmpleados();
                        break;
                    case "3":
                        OpOrdenes();
                        break;        
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }while (!salir);       
        }
        // ------------------------------------------------------ PRIMER OPERACION --- REGIONES ------------------------------------------------------
        private static void OpRegiones()
        {
            RegionLogic regionLogic = new RegionLogic();

            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Listar Regiones");
                Console.WriteLine("2 - Agregar Regiones");
                Console.WriteLine("3 - Eliminar Regiones");
                Console.WriteLine("4 - Actualizar Regiones");
                Console.WriteLine("0 - Menu Principal");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarRegiones(regionLogic);
                        break;
                    case "2":
                        AgregarRegiones(regionLogic);
                        break;
                    case "3":
                        EliminarRegiones(regionLogic);
                        break;
                    case "4":
                        ActualizarRegiones(regionLogic);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
        private static void ListarRegiones(RegionLogic regionLogic)
        {
            Console.WriteLine("\n-- Lista de Regiones: --");
            foreach (var item in regionLogic.GetAll())
            {
                Console.WriteLine($"{item.RegionID} - {item.RegionDescription}\n");
            }
        }
        private static void AgregarRegiones(RegionLogic regionLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Agregar nueva región --\n");
                    Console.Write("Ingrese el ID de la region: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el DESCRIPCION de la region: ");
                    string desc = Console.ReadLine();
                    regionLogic.Add(new Region
                    {
                        RegionID = id,
                        RegionDescription = desc
                    });
                    Console.WriteLine($"\nLa region {desc} ha sido agregada correctamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea agregar otra region? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }      
        }
        private static void EliminarRegiones(RegionLogic regionLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Eliminar region --");
                    Console.Write("Ingrese el ID de la region que desea eliminar: ");
                    int id = int.Parse(Console.ReadLine());
                    regionLogic.Delete(id);
                    Console.WriteLine($"\nLa region con ID {id} ha sido eliminada exitosamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea eliminar otra region? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }           
        }
        private static void ActualizarRegiones(RegionLogic regionLogic)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("\n-- Actualizar region --\n");
                    Console.Write("Ingrese el ID de la region que desea actualizar: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese la nueva descripcion de la region: ");
                    string newDescription = Console.ReadLine();
                    regionLogic.Update(new Region
                    {
                        RegionDescription = newDescription,
                        RegionID = id
                    });
                    Console.WriteLine($"\nLa region con ID {id} ha sido actualizada exitosamente");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea agregar otra region? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }           
        }

        // ------------------------------------------------------ SEGUNDA OPERACION --- EMPLEADOS ------------------------------------------------------

        private static void OpEmpleados()
        {
            EmployeesLogic employeesLogic = new EmployeesLogic();

            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Listar Empleados");
                Console.WriteLine("2 - Agregar Empleados");
                Console.WriteLine("3 - Eliminar Empleados");
                Console.WriteLine("4 - Actualizar Empleados");
                Console.WriteLine("0 - Menu Principal");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarEmpleados(employeesLogic);
                        break;
                    case "2":
                        AgregarEmpleados(employeesLogic);
                        break;
                    case "3":
                        EliminarEmpleados(employeesLogic);
                        break;
                    case "4":
                        ActualizarEmpleados(employeesLogic);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
        private static void ListarEmpleados(EmployeesLogic employeesLogic)
        {
            Console.WriteLine("\n-- Lista de Empleados: --");
            foreach (var e in employeesLogic.GetAll())
            {
                Console.WriteLine($"{e.EmployeeID} - {e.FirstName} - {e.LastName}\n");
            }
        }
        private static void AgregarEmpleados(EmployeesLogic employeesLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Agregar nuevo empleado --\n");
                    Console.Write("Ingrese el primer nombre del empleado: ");
                    string fn = Console.ReadLine();
                    Console.Write("Ingrese el segundo nombre del empleado: ");
                    string ln = Console.ReadLine();
                    employeesLogic.Add(new Employees
                    {
                        FirstName = fn,
                        LastName = ln
                    });
                    Console.WriteLine($"\nEl empleado {fn} ha sido agregado correctamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.\n");
                }
                Console.Write("¿Desea agregar otro empleado? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }           
        }
        private static void EliminarEmpleados(EmployeesLogic employeesLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Eliminar empleado --");
                    Console.Write("Ingrese el ID del empleado que desea eliminar: ");
                    int id = int.Parse(Console.ReadLine());
                    employeesLogic.Delete(id);
                    Console.WriteLine($"\nEl empleado con ID {id} ha sido eliminado exitosamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea eliminar otro empleado? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }       
        }
        private static void ActualizarEmpleados(EmployeesLogic employeesLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Actualizar empleado --");
                    Console.Write("Ingrese el ID del empleado que desea actualizar: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nuevo nombre ");
                    string newFName = Console.ReadLine();
                    Console.Write("Ingrese el segundo nombre");
                    string newLName = Console.ReadLine();

                    employeesLogic.Update(new Employees
                    {
                        FirstName = newFName,
                        LastName = newLName,
                        EmployeeID = id
                    });
                    Console.WriteLine($"\nEl empleado ha sido actualizado exitosamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea modificar otro empleado? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }           
        }

        // ------------------------------------------------------ TERCERA OPERACION --- ORDENES ------------------------------------------------------
        private static void OpOrdenes()
        {
            OrdersLogic ordersLogic = new OrdersLogic();

            while (true)
            {
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Listar Ordenes");
                Console.WriteLine("2 - Agregar Ordenes");
                Console.WriteLine("3 - Eliminar Ordenes");
                Console.WriteLine("4 - Actualizar Ordenes");
                Console.WriteLine("0 - Menu Principal");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        ListarOrdenes(ordersLogic);
                        break;
                    case "2":
                        AgregarOrdenes(ordersLogic);
                        break;
                    case "3":
                        EliminarOrdenes(ordersLogic);
                        break;
                    case "4":
                        ActualizarOrdenes(ordersLogic);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
        private static void ListarOrdenes(OrdersLogic ordersLogic)
        {
            Console.WriteLine("\n-- Lista de Ordenes: --");
            foreach (var o in ordersLogic.GetAll())
            {
                Console.WriteLine($"{o.OrderID} - {o.ShipName} - {o.ShipCountry}\n");
            }
        }
        private static void AgregarOrdenes(OrdersLogic ordersLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Agregar nueva orden --\n");
                    Console.Write("Ingrese el ID de la orden: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre de la orden: ");
                    string on = Console.ReadLine();
                    Console.Write("Ingrese el pais de destino: ");
                    string oc = Console.ReadLine();
                    ordersLogic.Add(new Orders
                    {
                         OrderID = id,
                         ShipName = on,
                         ShipCountry = oc
                    });
                    Console.WriteLine($"\nLa orden con ID {id} ha sido agregado correctamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.\n");
                }
                Console.Write("¿Desea agregar otra orden? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }
        }
        private static void EliminarOrdenes(OrdersLogic ordersLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Eliminar orden --");
                    Console.Write("Ingrese el ID de la orden que desea eliminar: ");
                    int id = int.Parse(Console.ReadLine());
                    ordersLogic.Delete(id);
                    Console.WriteLine($"\nLa orden con ID {id} ha sido eliminado exitosamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea eliminar otra orden? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }
        }
        private static void ActualizarOrdenes(OrdersLogic ordersLogic)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n-- Actualizar orden --");
                    Console.Write("Ingrese el ID de la orden: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el nombre de la orden: ");
                    string on = Console.ReadLine();
                    Console.Write("Ingrese el pais de destino: ");
                    string oc = Console.ReadLine();
  
                    ordersLogic.Update(new Orders
                    {
                        OrderID = id,
                        ShipName = on,
                        ShipCountry = oc
                    });
                    Console.WriteLine($"\nLa orden con ID {id} ha sido actualizada exitosamente\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nError: No se permite el ingreso de letras o numeros decimales. Solo valores enteros\n");
                }
                finally
                {
                    Console.WriteLine("Operación finalizada.");
                }
                Console.Write("¿Desea modificar otra orden? (S/N): ");
                string respuesta = Console.ReadLine().ToUpper();
                if (respuesta != "S")
                {
                    break;
                }
            }
        }
    }
}