using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerretiaLinqCristian.Classes
{
    public class ProductoDetalle
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Valor { get; set; }
        public int ValorTotalPro {get;set;}
    }
}