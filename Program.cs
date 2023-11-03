using System.Diagnostics;
using FerretiaLinqCristian.Extensions;

internal class Program
{

    private static void Main(string[] args)
    {
        bool AddMenu = true;
        while (AddMenu)
        {
            Core core = new Core();
            core.MENU();
            string option = Console.ReadLine();
            if (option.Length > 1)
            {
                while (option.Length > 1 )
                {
                    Console.WriteLine("Se ingreso un opción incorrecta");
                    Console.ReadKey();
                    Console.Clear();
                    core.MENU();
                    string option2 = Console.ReadLine();
                    option = option2;
                }
            }
            char typeOrder = Char.Parse(option);
            switch (typeOrder)
            {
                case '1':
                    core.Productos();
                    break;
                case '2':
                    core.CasiAgotado();
                    break;
                case '3':
                    core.Acomprar();
                    break;
                case '4':
                    core.FacturasEnero();
                    break;
                case '5':
                    core.ProductosVendidos();
                    break;
                case '6':
                    core.ValorInventario();
                    break;
                case '0':
                    AddMenu = false;
                    break;
                default:
                    Console.WriteLine("Se ingreso un opción incorrecta");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}