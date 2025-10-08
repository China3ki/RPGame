using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Items;

namespace RPGGame
{
    internal class Program
    {
        static List<Inventory> lista = [new Inventory(1), new Inventory(1)];
        static Inventory a = lista[0];
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(lista[1] == a);
        }
    }
}
