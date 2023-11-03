using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ConsoleTables;
using FerretiaLinqCristian.Classes;

namespace FerretiaLinqCristian.Extensions
{
    public class Core
    {
        List<Productos> _productos = new List<Productos>()
        {
            new Productos() { IdProducto = 1, NombreProducto="Cemento",PrecioUnit=25000,Cantidad=50,StockMin=40,StockMax=100},
            new Productos() { IdProducto = 2, NombreProducto="Palas",PrecioUnit=30000,Cantidad=20,StockMin=5,StockMax=40},
            new Productos() { IdProducto = 3, NombreProducto="Brocha",PrecioUnit=8000,Cantidad=30,StockMin=10,StockMax=50},
            new Productos() { IdProducto = 4, NombreProducto="Metro",PrecioUnit=20000,Cantidad=5,StockMin=10,StockMax=30},
            new Productos() { IdProducto = 5, NombreProducto="Pintura",PrecioUnit=50000,Cantidad=8,StockMin=10,StockMax=30}
        };
        List<Cliente> _clientes = new List<Cliente>()
        {
            new Cliente(){IdCliente=101,NombreCliente="Jose",Email="josecampus@gmail.com"},
            new Cliente(){IdCliente=102,NombreCliente="Orlando",Email="orlando@gmail.com"},
            new Cliente(){IdCliente=103,NombreCliente="Sergio",Email="sergio@gmail.com"}
        };
        List<Factura> _factura = new List<Factura>()
        {
            new Factura(){IdFactura="101",Fecha=new DateOnly(2023, 1, 2),IdCliente = 101,TotalFactura = 190000},
            new Factura(){IdFactura="102",Fecha=new DateOnly(2023, 1, 15),IdCliente = 103,TotalFactura = 320000},
            new Factura(){IdFactura="103",Fecha=new DateOnly(2023, 3, 6),IdCliente = 102,TotalFactura = 180000},
        };
        List<DetalleFactura> _detallefactura = new List<DetalleFactura>()
        {
            new DetalleFactura(){
                IdDetalleFactura = 1,IdFactura="101", ProductosDetalle = new List<ProductoDetalle>{
                    new ProductoDetalle(){Id = 1, Cantidad = 2, Valor = 25000,ValorTotalPro=50000},
                    new ProductoDetalle(){Id = 3, Cantidad = 5, Valor = 8000,ValorTotalPro=40000},
                    new ProductoDetalle(){Id = 5, Cantidad = 2, Valor = 50000,ValorTotalPro=100000}

                }
            },
            new DetalleFactura(){
                IdDetalleFactura = 2,IdFactura="102", ProductosDetalle = new List<ProductoDetalle>{
                    new ProductoDetalle(){Id = 1, Cantidad = 8, Valor = 25000,ValorTotalPro=200000},
                    new ProductoDetalle(){Id = 4, Cantidad = 1, Valor = 20000,ValorTotalPro=20000},
                    new ProductoDetalle(){Id = 5, Cantidad = 2, Valor = 50000,ValorTotalPro=100000}

                }
            },
            new DetalleFactura(){
                IdDetalleFactura = 3,IdFactura="103", ProductosDetalle = new List<ProductoDetalle>{
                    new ProductoDetalle(){Id = 1, Cantidad = 5, Valor = 25000,ValorTotalPro=100000},
                    new ProductoDetalle(){Id = 2, Cantidad = 2, Valor = 30000,ValorTotalPro=60000},
                    new ProductoDetalle(){Id = 4, Cantidad = 1, Valor = 20000,ValorTotalPro=20000}

                }
            }
        };


        public void MENU()
        {
            Console.WriteLine("----------------MENU PRINCIPAL---------------");
            Console.WriteLine("1.Lista de productos del inventario");
            Console.WriteLine("2.Lista de productos a punto de agotarse");
            Console.WriteLine("3.Productos a comprar y cantidad que se debe comprar");
            Console.WriteLine("4.Lista total de facturas de cada mes.");
            Console.WriteLine("5.Listado de productos vendidos en determinada factura");
            Console.WriteLine("6.Calcular valor total del inventario");
            Console.WriteLine("0.Salir");
            Console.WriteLine("Selecciones una opcion: ");
        }

        public void Productos()
        {
            Console.Clear();
            int contador = 1;
            var table = new ConsoleTable("#", "Productos");
            foreach (var item in _productos)
            {
                table.AddRow(contador, item.NombreProducto);
                contador++;
            }
            table.Write(Format.Alternative);
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        public void CasiAgotado()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Productos que están por agotarse");
            var table = new ConsoleTable("#", "Producto");
            var result = _productos.Where(x => x.Cantidad < x.StockMin).ToList<Productos>();
            result.ForEach(x => table.AddRow(contador, x.NombreProducto));
            table.Write(Format.Alternative);
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        public void Acomprar()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Productos que están por agotarse.");
            var table = new ConsoleTable("#", "Producto", "Cantidad a compra");
            var result = _productos.Where(x => x.Cantidad < x.StockMin).ToList<Productos>();
            result.ForEach(x => table.AddRow(contador, x.NombreProducto, x.StockMax - x.Cantidad));
            table.Write(Format.Alternative);
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();

            Console.Clear();
        }
        public void Facturas()
        {
            Console.Clear();
            int contador = 1;
            int mesbuscar = 0;
            Console.WriteLine("Ingresa el numero del mes a buscar");
            mesbuscar = Int16.Parse(Console.ReadLine());
            Console.Clear();
            if (mesbuscar > 12)
            {
                Console.WriteLine("Mes no valido");
            }
            var result = _factura.Where(x => x.Fecha.Month == mesbuscar).ToList<Factura>();
            if (mesbuscar < 12 && result.Count() != 0)
            {
                var table = new ConsoleTable("#",$"Factura");
                result.ForEach(x => table.AddRow(contador, x.Fecha.ToString("dd-MM-yyyy")));
                table.Write(Format.Alternative);
            }
            if (result.Count() == 0 && mesbuscar < 12)
            {
                Console.WriteLine("No se encontraron Facturas");
            }
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();
            Console.Clear();
        }
        public void ProductosVendidos()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Listado de Facturas");
            foreach (var item in _factura)
            {
                Console.WriteLine($"{contador}: Id de la factura es: {item.IdFactura}");
                contador++;
            }
            Console.WriteLine("Ingresa el Id de la factura que desees listar: ");
            string idlistar = Console.ReadLine();
            var result = _detallefactura.Where(x => x.IdFactura == idlistar);
            if (result.Count() == 0)
            {
                Console.WriteLine("Ingreso de Id incorrecto.");
            }
            foreach (var item in result)
            {
                Console.WriteLine($"Id Factura {idlistar}");
                var table = new ConsoleTable("Id", "Unit", "VUnit", "VParcial");
                foreach (var productoD in item.ProductosDetalle)
                    table.AddRow(productoD.Id, productoD.Cantidad, productoD.Valor, productoD.ValorTotalPro);
                table.Write(Format.Alternative);
            }
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();

            Console.Clear();
        }
        public void ValorInventario()
        {
            Console.Clear();
            int ValorTotal = 0;
            var table = new ConsoleTable("Id", "Producto", "PrecioUnit", "Valor");
            foreach (var item in _productos)
            {
                int valorparcial = 0;
                table.AddRow(item.IdProducto, item.Cantidad, item.PrecioUnit, item.Cantidad * item.PrecioUnit);
                valorparcial = item.PrecioUnit * item.Cantidad;
                ValorTotal = ValorTotal + valorparcial;
            }
            table.AddRow("","","TOTAL",ValorTotal);
            table.Write(Format.Alternative);
            Console.WriteLine($"El valor total del inventario es: {ValorTotal}");

            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}