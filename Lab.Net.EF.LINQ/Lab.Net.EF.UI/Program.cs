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
    public class Program
    {
        static void Main(string[] args)
        {
            CustomersLogic customersLogic = new CustomersLogic();
            ProductsLogic productsLogic = new ProductsLogic();
            CustomersOrdersLogic customersOrdersLogic = new CustomersOrdersLogic();

            Console.WriteLine("------------------ Bienvenidos a la Practica LINQ ------------------\n");
            bool salir = false;
            do
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1 - Devolver objeto Customer");
                Console.WriteLine("2 - Devolver todos los productos sin STOCK");
                Console.WriteLine("3 - Devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                Console.WriteLine("4 - Devolver todos los customers de la Región WA");
                Console.WriteLine("5 - Devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                Console.WriteLine("6 - Devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula");
                Console.WriteLine("7 - Devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
                Console.WriteLine(" ---------- PUNTOS OPCIONALES ---------- ");
                Console.WriteLine("8 - Devolver los primeros 3 Customers de la  Región WA ");
                Console.WriteLine("9 - Devolver lista de productos ordenados por nombre");
                Console.WriteLine("10 - Devolver lista de productos ordenados por unit in stock de mayor a menor");
                Console.WriteLine("11 - Devolver las distintas categorías asociadas a los productos ");
                Console.WriteLine("12 - Devolver el primer elemento de una lista de productos ");
                Console.WriteLine(" - ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------\n");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var customerId = "ALFKI";
                        var customer = customersLogic.GetCustomerById(customerId);
                        Console.WriteLine($"Customer Name: {customer.ContactName}");
                        break;
                    case "2":
                        var productosSinStock = productsLogic.GetProductsNoStock();
                        Console.WriteLine("Productos sin stock");
                        foreach (var product in productosSinStock)
                        {
                            Console.WriteLine($"ID: {product.ProductID}, Nombre: {product.ProductName}\n");
                        }
                        break;
                    case "3":
                        var proOnStockPrice3= productsLogic.GetProductsStockAndPrice3();
                        
                        Console.WriteLine("Productos en Stock y con valor mas de 3 por Unidad");
                        foreach (var product in proOnStockPrice3)
                        {
                            Console.WriteLine($"ID: {product.ProductID}, Nombre: {product.ProductName}\n");
                        }
                        break;
                    case "4":
                        var customersWA = customersLogic.GetCustomersByRegion("WA");
                        foreach (var customerbr in customersWA)
                        {
                            Console.WriteLine($"Customer ID: {customerbr.CustomerID}, Company Name: {customerbr.CompanyName}, Region: {customerbr.Region}");
                        }
                        break;
                    case "5":
                        int productId = 789;
                        Products product1 = productsLogic.GetProductById(productId);
                        if ( product1 != null )
                        {
                            Console.WriteLine($"Product found with ID {productId}: {product1.ProductName}");
                        }
                        else
                        {
                            Console.WriteLine($"Product with ID {productId} not found.");
                        }
                        break;
                    case "6":
                        string[] cNames = customersLogic.GetCustomerNamesUpLow();

                        Console.WriteLine("Customer Names in Uppercase:\n----------------------------------");
                        foreach (string name in cNames)
                        {
                            Console.WriteLine(name.ToUpper());
                        }
                        Console.WriteLine("\nCustomer Names in Lowercase:\n---------------------------------");
                        foreach (string name in cNames)
                        {
                            Console.WriteLine(name.ToLower());
                        }
                        break;
                    case "7":
                        customersOrdersLogic.CustomersOrdersJoin();
                        break;
                    case "8":
                        var customersWa = customersLogic.ThreeCustomers();
                        foreach (var cust in customersWa)
                        {
                            Console.WriteLine($"ID: {cust.CustomerID} - Nombre: {cust.CompanyName}");
                        }
                        break;
                    case "9":
                        var prodOrByName = productsLogic.GetProdOrderedByName();
                        Console.WriteLine("Lista de productos ordenados por nombre:");
                        foreach (var product in prodOrByName)
                        {
                            Console.WriteLine($"{product.ProductName}\n");
                        }
                        break;
                    case "10":
                        var products = productsLogic.GetProdOrderByUnitStock();
                        foreach (var product in products)
                        {
                            Console.WriteLine($"Name: {product.ProductName} ------------ Units in Stock: {product.UnitsInStock}\n");
                        }
                        break;
                    case "11":
                        var distinctCat = productsLogic.GetDistinctCategories();
                        Console.WriteLine("Categorías de productos: \n");
                        foreach (var category in distinctCat)
                        {
                            Console.WriteLine($"Categoria: {category}\n");
                        }
                        break;
                    case "12":
                        Products firstProduct = productsLogic.GetFirstProduct();
                        Console.WriteLine($"El Primer producto es : {firstProduct.ProductName}");
                        break;                 
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            } while (!salir);
        }
    }
}
