using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters.Entities;

namespace RPGGame.States
{
    internal class StatsMenu(Stats stats) : IGameState
    {
        private Stats _stats = stats;
        public void InitState()
        {
            Console.Clear();
            View.RenderInfo("===== Statystyki =====", ConsoleColor.Cyan);
            View.RenderInfo($"Rozegrane tury: {_stats.TurnsPlayed}", ConsoleColor.White);
            View.RenderInfo($"Zadane obrażenia: {_stats.DamageGiven}", ConsoleColor.White);
            View.RenderInfo($"Przyjęte obrażenia: {_stats.DamageTaken}", ConsoleColor.White);
            View.RenderInfo($"Przemioty kupione: {_stats.ItemPurchased}", ConsoleColor.White);
            View.RenderInfo($"Sprzedane przedmioty: {_stats.ItemsSold}", ConsoleColor.White);
            View.RenderInfo($"Wydane pieniądze: {_stats.MoneySpent}", ConsoleColor.White);
            View.WaitForEnter("======================", ConsoleColor.Cyan);
        }
        public void Update(StateManager stateManager)
        {
            stateManager.PopState();
        }
    }
}
