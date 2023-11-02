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
                    
                    break;
                case '6':
                    break;
                case '0':
                    AddMenu = false;
                    break;
                default:
                    break;
            }
        }
    }
}