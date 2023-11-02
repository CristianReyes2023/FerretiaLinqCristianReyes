using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            new Factura(){IdFactura="125",Fecha=new DateOnly(2023, 1, 2),IdCliente = 101,TotalFactura = 190000},
            new Factura(){IdFactura="135",Fecha=new DateOnly(2023, 1, 15),IdCliente = 103,TotalFactura = 370000},
            new Factura(){IdFactura="525",Fecha=new DateOnly(2023, 3, 6),IdCliente = 102,TotalFactura = 180000},
        };
        List<DetalleFactura> _detallefactura = new List<DetalleFactura>()
        {
            new DetalleFactura(){
                IdDetalleFactura = 1,IdFactura="125", ProductosDetalle = new List<ProductoDetalle>{
                    new ProductoDetalle(){Id = 1, Cantidad = 2, Valor = 25000,ValorTotalPro=50000},
                    new ProductoDetalle(){Id = 3, Cantidad = 5, Valor = 8000,ValorTotalPro=40000},
                    new ProductoDetalle(){Id = 5, Cantidad = 2, Valor = 50000,ValorTotalPro=100000}
                    
                }
            },
            new DetalleFactura(){
                IdDetalleFactura = 2,IdFactura="135", ProductosDetalle = new List<ProductoDetalle>{
                    new ProductoDetalle(){Id = 1, Cantidad = 10, Valor = 25000,ValorTotalPro=250000},
                    new ProductoDetalle(){Id = 4, Cantidad = 1, Valor = 20000,ValorTotalPro=20000},
                    new ProductoDetalle(){Id = 5, Cantidad = 2, Valor = 50000,ValorTotalPro=100000}
                    
                }
            },
            new DetalleFactura(){
                IdDetalleFactura = 3,IdFactura="525", ProductosDetalle = new List<ProductoDetalle>{
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
            Console.WriteLine("4.Lista total de facturas del mes de enero del 2023");
            Console.WriteLine("5.Listado de productos vendidos en determinada factura");
            Console.WriteLine("6.Calcular valor total del inventario");
            Console.WriteLine("0.Salir");
            Console.WriteLine("Selecciones una opcion: ");
        }

        public void Productos()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Productos");
            foreach (var item in _productos)
            {
                Console.WriteLine($"{contador}: {item.NombreProducto}");
                contador++;
            }
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();

            Console.Clear();
        }
        public void CasiAgotado()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Productos que están por agotarse");
            var result = _productos.Where(x => x.Cantidad < x.StockMin).ToList<Productos>();
            result.ForEach(x => Console.WriteLine($"{contador++}: {x.NombreProducto}"));
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();

            Console.Clear();
        }
        public void Acomprar()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Productos que están por agotarse");
            var result = _productos.Where(x => x.Cantidad < x.StockMin).ToList<Productos>();
            result.ForEach(x => Console.WriteLine($"{contador++}: {x.NombreProducto} y cantidad a comprar {x.StockMax-x.Cantidad}"));
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();

            Console.Clear();
        }
        public void FacturasEnero()
        {
            Console.Clear();
            int contador = 1;
            Console.WriteLine("Facturas del mes de enero");
            var result = _factura.Where(x => x.Fecha.Month == 1 ).ToList<Factura>();
            result.ForEach(x => Console.WriteLine($"{contador++}: {x.Fecha:dd-MM-yyyy}"));
            Console.WriteLine("Enter para menu principal");
            Console.ReadKey();

            Console.Clear();
        }


        // public bool GoMenu()
        // {
        //     Console.WriteLine("1.Volver al menu principal.");
        //     Console.WriteLine("2.Salir del programa.");
        //     bool AddMenu = true;
        //     string optionmenu = Console.ReadLine();
        //     int typeMenu = Int16.Parse(optionmenu);
        //     if (typeMenu == 1)
        //     {
        //         AddMenu = true;
        //     }
        //     else
        //     {
        //         AddMenu = false;
        //     }
        //     return AddMenu;
        // }

    }
}