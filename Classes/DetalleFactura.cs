using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerretiaLinqCristian.Classes;
public class DetalleFactura
{
    public int IdDetalleFactura { get; set; }
    public int IdFactura { get; set; }

    public List<ProductoDetalle> ProductosDetalle { get; set; }

}
