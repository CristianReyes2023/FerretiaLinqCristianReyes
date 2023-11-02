using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerretiaLinqCristian.Classes;
public class Productos
{
    public int IdProducto { get; set; }
    public string NombreProducto { get; set; }
    public int PrecioUnit { get; set; }
    public int Cantidad { get; set; }
    public int StockMin { get; set; }
    public int StockMax { get; set; }
}
