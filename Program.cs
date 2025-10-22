using RPGGame.Components;
using System.Text;
namespace RPGGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StateManager stateManager = new();
            stateManager.RunApp();
        }
    }
}
