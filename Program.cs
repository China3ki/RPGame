using RPGGame.Components;
using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Characters.Entities;
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
